<?php
    /*
    Identity Map to wzorzec projektowy stosowany w programowaniu, szczególnie w kontekście 
    Object-Relational Mapping (ORM), do zarządzania obiektami pobranymi z bazy danych. 
    Głównym celem tego wzorca jest zapewnienie, że dla każdego wiersza w bazie danych 
    w danym kontekście aplikacji istnieje tylko jedna instancja obiektu w pamięci. 
    Oznacza to, że gdy dany obiekt jest żądany więcej niż raz, nie jest on ponownie 
    ładowany z bazy danych, lecz zwracany jest istniejący obiekt z pamięci. 
    Dzięki temu wzorcowi można uniknąć redundantnych operacji odczytu i utrzymać spójność
    danych między różnymi częściami aplikacji.

    Zalety:
    - Zapobiega wielokrotnemu ładowaniu tego samego obiektu, co poprawia wydajność.
    - Ułatwia śledzenie i zarządzanie instancjami obiektów w aplikacji.
    - Może pomóc w zapewnieniu spójności danych w ramach sesji.

    Wady:
    - Zwiększa zużycie pamięci, ponieważ obiekty są przechowywane w pamięci.
    - Może być trudny w implementacji w bardziej złożonych scenariuszach.
    - Może prowadzić do przestarzałych danych, jeśli stan obiektu w bazie 
      danych ulegnie zmianie. 
    */

    class IdentityMap {
        private $objectPool;

        public function __construct() {
            $this->objectPool = [];
        }

        public function addObject($id, $object) {
            $this->objectPool[$id] = $object;
        }

        public function getObject($id) {
            return $this->objectPool[$id] ?? null;
        }

        public function containsObject($id) {
            return isset($this->objectPool[$id]);
        }
    }

    class User {
        private $id;
        private $name;

        public function __construct($id, $name) {
            $this->id = $id;
            $this->name = $name;
        }

        public function getId() {
            return $this->id;
        }

        public function getName() {
            return $this->name;
        }
    }

    $identityMap = new IdentityMap();
    $identityMap->addObject(1, new User(1, "Ania"));
    $identityMap->addObject(2, new User(2, "Kasia"));

    $user1 = $identityMap->getObject(1);
    if ($user1) {
        echo "User1 pobrany z name: ". $user1->getName() . "<br>";
    }

    if ($identityMap->containsObject(2)) {
        echo "Objekt z id 2 istnieje";
    } else {
        echo "Objekt z id 2 nie istnieje";
    }












    















    /*
    W tym przykładzie Identity Map zarządza obiektami użytkowników. 
    Każdy użytkownik jest ładowany tylko raz,
    a następnie przechowywany w mapie identyczności. Dzięki temu, 
    nie ma potrzeby ponownego ładowania tych samych
    obiektów, co poprawia wydajność i pomaga w zarządzaniu stanem aplikacji.
    */
?>
