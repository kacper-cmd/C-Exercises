<?php
    /*
    Multiton to wzorzec projektowy w programowaniu, który jest wariacją wzorca Singleton. 
    Podczas gdy wzorzec Singleton zapewnia, że istnieje tylko jedna instancja klasy dla 
    całej aplikacji, Multiton pozwala na stworzenie ograniczonej liczby instancji klasy, 
    zazwyczaj zarządzanych przez słownik lub inną strukturę danych, w której każda 
    instancja jest skojarzona z konkretnym kluczem.

    Zalety:
    - Kontroluje liczbę instancji danej klasy, zapewniając unikalną 
      instancję dla każdego klucza.
    - Zapobiega tworzeniu niepotrzebnych instancji i zarządza istniejącymi.

    Wady:
    - Utrudniona testowalność kodu ze względu na globalny stan.
    - Może prowadzić do nieoczekiwanego zachowania w aplikacji wielowątkowej.
    - Zwiększa złożoność kodu w porównaniu do pojedynczego Singletona.

    Implementacja wzorca Multiton w PHP.
    */

    class Multition {
        private static $instances = [];
        private $id;

        private function __construct($id) {
            $this->id = $id;
        }

        public static function getInstance($id) {
            if (!isset(self::$instances[$id])) {
                self::$instances[$id] = new Multition($id);
            }

            return self::$instances[$id];
        }

        public function getId() {
            return $this->id;
        }

        private function __clone() {}//zablonowanie klonowanie
        public function __wakeup() {//zablokowana deserializacja 
            new Exception("Err");
        }
    }


    $multition1 = Multition::getInstance("1");
    echo "Instancja multition 1 ID: " . $multition1->getId() . "<br>";

    $multition2 = Multition::getInstance("2");
    echo "Instancja multition 2 ID: " . $multition2->getId() . "<br>";

    $anotherMultition1 = Multition::getInstance("1");
    echo "Instancja multition 1 ID ponownie: " . $anotherMultition1->getId() . "<br>";

    if ($multition1 === $anotherMultition1) {
        echo "Te same instance dla klucza 1";
    }


?>
