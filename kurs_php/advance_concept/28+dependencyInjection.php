<?php
    /*
    Dependency Injection (DI) to wzorzec projektowy używany w programowaniu do osiągnięcia 
    luźnego powiązania między komponentami oprogramowania. W DI, zależności (takie jak obiekty, 
    wartości, lub usługi) są dostarczane do komponentu z zewnątrz zamiast być tworzone 
    bezpośrednio wewnątrz komponentu. Dzięki temu komponent staje się bardziej modularny, 
    łatwiejszy w testowaniu i konserwacji.
    
    Zalety:
    - Zwiększa modularność i elastyczność kodu poprzez oddzielenie tworzenia obiektów od ich użytkowania.
    - Ułatwia testowanie, ponieważ zależności mogą być łatwo podmieniane, np. na mocki w testach jednostkowych.
    - Promuje zasadę pojedynczej odpowiedzialności i luźne powiązania między klasami.

    Wady:
    - Może zwiększyć złożoność kodu, szczególnie w małych projektach.
    - Wymaga dodatkowego kodu do zarządzania zależnościami.
    - Może być trudniejszy do zrozumienia dla początkujących programistów.
    */


    interface Mailer {
        public function send($to, $subject, $message);
    }

    class SimpleMailer implements Mailer {
        public function send($to, $subject, $message) {
            echo "Wysyłanie maila do: $to z tematem: $subject i treścią: $message <br>";
        }
    }

    class UserRegistration {
        private $mailer;

        public function __construct(Mailer $mailer) {
            $this->mailer = $mailer;
        }

        public function register($email, $username) {
            echo "Rejestracja użytkownika: $username z email: $email <br>";
            $this->mailer->send($email, "Witamy na stronie", "Cześć $username...");
        }
    }

    $mailer = new SimpleMailer();

    $userRegistration = new UserRegistration($mailer);
    $userRegistration->register("kasia@example.com", "Kasia");
    
?>
