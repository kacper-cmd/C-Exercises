<?php

/*
Przykład wzorca Event Aggregator Pattern. Wzorzec ten jest używany do uproszczenia 
komunikacji między wieloma obiektami lub komponentami w systemie. Zamiast, aby każdy 
komponent komunikował się bezpośrednio z innymi, wszystkie zdarzenia są przekazywane 
przez centralny agregator, który następnie rozsyła je do zainteresowanych odbiorców.

Zalety:
- Redukuje zależności między komponentami systemu.
- Upraszcza zarządzanie zdarzeniami w skomplikowanych systemach.
- Poprawia organizację kodu i ułatwia jego utrzymanie.

Wady:
- Może prowadzić do nadmiernego skupienia zdarzeń w jednym miejscu.
- Zbyt wiele zdarzeń przetwarzanych przez jedną klasę może spowodować spadek wydajności.
- Może być trudno śledzić przepływ zdarzeń w dużych systemach.
*/






    interface EventListener {
        public function handle($event);
    }

    class EventAggregator {
        private $listeners = [];

        public function subscribe($eventType, EventListener $listener) {
            $this->listeners[$eventType][] = $listener;
        }

        public function publish($event) {
            $eventType = get_class($event);
            
            if (isset($this->listeners[$eventType])) {
                foreach ($this->listeners[$eventType] as $listener) {
                    $listener->handle($event);
                }
            }
        }
    }

    class UserLoggedInEvent {
        public $username;
        public function __construct($username) {
            $this->username = $username;
        }
    }

    class NewMessageEvent {
        public $message;
        public function __construct($message) {
            $this->message = $message;
        }
    }

    class Logger implements EventListener {
        public function handle($event) {
            if ($event instanceof UserLoggedInEvent) {
                echo "User zalogowany <br>";
            } elseif ($event instanceof NewMessageEvent) {
                echo "Nowa wiadomość <br>";
            }
        }
    }

    class NotificationManager implements EventListener {
        public function handle($event) {
            if ($event instanceof NewMessageEvent) {
                echo "Powiadomienie: nowa wiadomość <br>";
            }
        }
    }

    $eventAggregator = new EventAggregator();
    $logger = new Logger();
    $notificationManager = new NotificationManager();

    $eventAggregator->subscribe(UserLoggedInEvent::class, $logger);
    $eventAggregator->subscribe(NewMessageEvent::class, $logger);
    $eventAggregator->subscribe(NewMessageEvent::class, $notificationManager);

    $eventAggregator->publish(new UserLoggedInEvent("Asia"));
    $eventAggregator->publish(new NewMessageEvent("Witaj w systemie!"));

?>