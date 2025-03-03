<?php
    /* 
    Event Sourcing to wzorzec architektoniczny używany w projektowaniu oprogramowania, 
    w którym zmiany w stanie aplikacji są przechowywane jako sekwencja zdarzeń. 
    Zamiast zapisywać tylko aktualny stan obiektu (jak w tradycyjnych bazach danych), 
    Event Sourcing zapisuje każde zmieniające stan zdarzenie. Każde zdarzenie reprezentuje 
    fakt, który miał miejsce, i jest niezmienne po zapisaniu.

    Zalety:
    - Precyzyjne śledzenie historii zmian i stanu aplikacji.
    - Możliwość odtworzenia stanu aplikacji w każdym momencie z historii.
    - Ułatwia analizę i debugowanie poprzez zapis wszystkich zdarzeń.
    Wady:
    - Zwiększa złożoność systemu przez wymóg zarządzania i przechowywania historii zdarzeń.
    - Może prowadzić do dużego narzutu danych ze względu na konieczność zapisu wszystkich zdarzeń.
    - Potrzeba skutecznych mechanizmów zarządzania zdarzeniami i ich sekwencją.
    */ 
    

    class Event {
        public $aggregateId;
        public $type;
        public $data;
        public $timestamp;

        public function __construct($aggregateId, $type, $data) {
            $this->aggregateId = $aggregateId;
            $this->type = $type;
            $this->data = $data;
            $this->timestamp = time();
        }
    }

    class EventStore {//przechowuje zdarzenia
        private $events = [];

        public function store(Event $event) {
            $this->events[] = $event;//na koniec []
        }

        public function getEventsForAggregate($aggregateId) {//dla konkretnej grupy
            //use() can be become also useful if we use a reference to write to an external variable while looping:
            return array_filter($this->events, function($event) use ($aggregateId) {//wewnatrz tej fukcji bede korzystal z aggregateid bedzie potrzebny
                return $event->aggregateId === $aggregateId; 
            });
        }
    }


    class UserAggregate {//grupa 
        private $eventStore;
        private $id;
        private $name;
        private $email;
        private $changes = [];

        public function __construct(EventStore $eventStore, $id) {
            $this->eventStore = $eventStore;
            $this->id = $id;
        }

        public function changeName($newName) {
            $event = new Event($this->id, "nameChanged", ["newName" => $newName]);//kto zmienił dany element, admin, moderator
            $this->apply($event);
            $this->changes[] = $event;
        }
        
        public function changeEmail($newEmail) {
            $event = new Event($this->id, "emailChanged", ["newEmail" => $newEmail]);
            $this->apply($event);
            $this->changes[] = $event;
        }

        private function apply(Event $event) {
            switch ($event->type) {
                case "nameChanged":
                    $this->name = $event->data["newName"];// z bazy, pobieram to co zapisane 
                    break;
                case "emailChanged":
                    $this->email = $event->data["newEmail"];
                    break;
                default:
                    throw new Exception("Nieznane zdarzenie: " . $event->type);
            }
        }

        public function persistChanges() {
            foreach ($this->changes as $event) {
                $this->eventStore->store($event);//zapis do bazy 
            }

            $this->changes = [];
        }

        public function loadFromHistory() {
            $events = $this->eventStore->getEventsForAggregate($this->id);
            foreach ($events as $event) {
                $this->apply($event);
            }
        }

        public function getName() {
            return $this->name;
        }

        public function getEmail() {
            return $this->email;
        }
    }

    $eventStore = new EventStore();

    $user = new UserAggregate($eventStore, 1);

    $user->changeName("Asia Kowalska");
    $user->changeEmail("asiakowalska@gmail.com");
    $user->persistChanges();

    $anotherUserInstance = new UserAggregate($eventStore, 1);
    $anotherUserInstance->loadFromHistory();//data np. do kiedy odtworzyc zmiany

    echo "Nazwa usera: " . $anotherUserInstance->getName() . "<br>";
    echo "Email usera: " . $anotherUserInstance->getEmail() . "<br>";


    echo "Historia usera: <br>";
    foreach ($eventStore->getEventsForAggregate(1) as $event ) {
        echo "Zdarzenie typu: " . $event->type . ", dane: " . json_encode($event->data)
             . " timestamp: " . $event->timestamp . "<br>";
    }
?>

