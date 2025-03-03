<?php
    /*
    Object Pool to wzorzec projektowy stosowany w programowaniu, który polega na zarządzaniu 
    zbiorem zasobów, które mogą być kosztowne do tworzenia i niszczenia, takich 
    jak połączenia z bazami danych, wątki lub obiekty reprezentujące połączenia sieciowe. 
    Zamiast tworzyć i niszczyć te obiekty za każdym razem, gdy są potrzebne, wzorzec 
    Object Pool utrzymuje zbiór utworzonych wcześniej obiektów, które mogą być ponownie wykorzystane.

    Zalety:
    - Zmniejsza koszt tworzenia i niszczenia obiektów poprzez ich wielokrotne wykorzystanie.
    - Zarządza zasobami, ograniczając liczbę instancji obiektów w aplikacji.
    - Może znacznie poprawić wydajność w scenariuszach, gdzie tworzenie obiektów 
      jest kosztowne.

    Wady:
    - Zwiększa złożoność kodu przez dodanie zarządzania pulą obiektów.
    - Może prowadzić do problemów z zarządzaniem pamięcią, jeśli obiekty w puli nie 
      są odpowiednio zarządzane.
    - Nie jest odpowiedni w każdym scenariuszu, szczególnie tam, gdzie instancje 
      obiektów mają stan, który nie może być łatwo zresetowany.
 
    */


    class SampleObject {
        private $data;

        public function __construct() {
            $this->data = rand(1000, 9999);
        }

        public function processData() {
            echo "Processing data: " . $this->data . "<br>";
        }

        public function reset() {
            $this->data = rand(1000, 9999);
        }
    }

    class ObjectPool {
        private $available = [];
        private $inUse = [];

        public function getObject() {
            if (count($this->available) == 0) {
                $newObject = new SampleObject();
                $this->inUse[spl_object_hash($newObject)] = $newObject;
                return $newObject;
            } else {
                $object = array_pop($this->available);//pobieram ten obiekt i zostanie usuniety
                $object->reset();
                $this->inUse[spl_object_hash($object)] = $object;
                return $object;
            }
        }

        public function releaseObject($object) {
            $objectHash = spl_object_hash($object);
            if (isset($this->inUse[$objectHash])) {
                unset($this->inUse[$objectHash]);
                $this->available[] = $object;
            }
        }

        public function getPoolSize() {
            return count($this->available) + count($this->inUse);
        }
    }

    $pool = new ObjectPool();

    for ($i = 0; $i < 10; $i++) {
        $object = $pool->getObject();
        echo $object->processData();
        $pool->releaseObject($object);
    }

    echo "Rozmiar puli po wykonaniu pętli: " . $pool->getPoolSize();

?>
