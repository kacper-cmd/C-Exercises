<?php
    /*
    Wzorzec Inversion of Control (IoC) polega na przeniesieniu kontroli nad zależnościami 
    do zewnętrznego obiektu, zamiast tworzyć je bezpośrednio w klasach, które z nich korzystają. 
    Często stosowany w połączeniu z Dependency Injection (DI), umożliwia łatwą zmianę 
    i zarządzanie zależnościami.

    Zalety:
    - Większa modularność i elastyczność kodu.
    - Ułatwienie testowania poprzez odseparowanie zależności.
    - Możliwość łatwej zmiany implementacji zależności.

    Wady:
    - Zwiększenie złożoności architektury.
    - Potrzeba większej uwagi przy zarządzaniu zależnościami.
    - Możliwość nadużywania wzorca, co prowadzi do niepotrzebnej złożoności. 
    */

    interface EmailService {
        public function sendEmail($to, $subject, $message);
    }

    interface LoggerService {
        public function log($message);
    }

    class SimpleEmailService implements EmailService {
        public function sendEmail($to, $subject, $message) {
            echo "Email tytułem: $subject do: $to o treści: $message został wysłany <br>";
        }
    }

    class FileLoggerService implements LoggerService {
        public function log($message) {
            echo "Log zapisany: $message <br>";
        }
    }

    class ServiceContainer {
        private $services = [];

        public function setService($name, $service) {
            $this->services[$name] = $service;
        }

        public function getService($name) {
            if (!isset($this->services[$name])) {
                throw new Exception("Usługa $name nie jest zdefiniowana");
            }

            return $this->services[$name];
        }
    }

    class OrderProcessor {
        private $emailService;
        private $loggerService;

        public function __construct(EmailService $emailService, LoggerService $loggerService) {
            $this->emailService = $emailService;
            $this->loggerService = $loggerService;
        }

        public function processOrder($orderDetails) {
            $this->emailService->sendEmail("klient@example.com", "Potwierdzenie zamówienia", "Treść...");
            $this->loggerService->log("Zamówienie potwierdzone: $orderDetails");
        }
    }

    $container = new ServiceContainer();
    $container->setService("email", new SimpleEmailService());
    $container->setService("logger", new FileLoggerService());

    $orderProcessor = new OrderProcessor($container->getService("email"), 
            $container->getService("logger"));
    
    $orderProcessor->processOrder("Zamówienie nr. 123");

?>
