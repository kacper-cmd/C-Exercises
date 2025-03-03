<?php
    /*
    Wzorzec Dirty Flag służy do oznaczania, czy stan obiektu uległ zmianie od ostatniego zapisu.
    Jest szczególnie przydatny w sytuacjach, gdy chcemy uniknąć kosztownych operacji zapisu,
    jeśli stan obiektu nie uległ zmianie.

    Zalety:
    - Optymalizacja wydajności poprzez ograniczenie niepotrzebnych operacji zapisu.
    - Jasna reprezentacja stanu obiektu (zmieniony/niezmieniony).

    Wady:
    - Dodatkowa złożoność w zarządzaniu stanem obiektu.
    - Ryzyko błędów w przypadku nieprawidłowego resetowania flagi.
    */


    class DirtyFlag {
        private $isDirty = false;

        public function setDirty($dirty = true) {
            $this->isDirty = $dirty;
        }

        public function isDirty() {
            return $this->isDirty;
        }
    }

    class Product extends DirtyFlag {
        private $id;
        private $name;
        private $price;

        public function __construct($id, $name, $price) {
            $this->id = $id;
            $this->name = $name;
            $this->price = $price;
        }

        public function setName($name) {
            if ($this->name !== $name) {
                $this->name = $name;
                $this->setDirty();
            }
        }

        public function setPrice($price) {
            if ($this->price !== $price) {
                $this->price = $price;
                $this->setDirty();
            }
        }

        public function save() {
            if ($this->isDirty()) {
                echo "Zapisano produkt {$this->name} o cenie {$this->price} <br> ";
            } else {
                echo "Produkt nie wymaga zapisu <br>";
            }
        }
    }

    $product = new Product(1, "Produkt A", 100);
    $product->save();
    
    $product->setPrice(100);
    $product->save();
    
    $product->setName("Produkt A+");
    $product->setPrice(150);
    $product->save();

?>
