<?php
    /*
        Wzorzec projektowy Flyweight służy do optymalizacji wydajności i zużycia 
        pamięci poprzez współdzielenie wspólnych stanów między wieloma obiektami. 
        Jest szczególnie przydatny w sytuacjach, gdzie program musi tworzyć dużą 
        liczbę podobnych obiektów.

        Czym jest wzorzec Flyweight:
        - Optymalizacja Wydajności: Pozwala na oszczędność pamięci poprzez współdzielenie 
          informacji między wieloma obiektami.
        - Podział na Wewnętrzny i Zewnętrzny Stan: Wewnętrzny stan jest wspólny 
          i niezmienialny, natomiast zewnętrzny stan może być specyficzny dla każdej instancji.
    */

    class TreeType {//wspoldzileone 
        private $name;
        private $color;
        private $texture;

        public function __construct($name, $color, $texture) {
            $this->name = $name;
            $this->color = $color;
            $this->texture = $texture;
        }

        public function draw($canvas, $x, $y) {
            echo "Rysuj drzewo '$this->name' koloru '$this->color' na pozycji ($x, $y) na $canvas <br> ";
        }
    }

    class TreeFactory {
        private static $treeTypes = [];

        public static function getTreeType($name, $color, $texture) {
            $key = md5($name . $color . $texture);//unique key base on name color , texture

            if (!isset(self::$treeTypes[$key])) {
                self::$treeTypes[$key] = new TreeType($name, $color, $texture); //kombinacja drzew np. sosna topla bedzie np. 10 a w lesie ma ich posyawie beda tysiace na ich podstawie 
            }

            return self::$treeTypes[$key];
        }

        public static function getNumTreeTypes() {
            return count(self::$treeTypes);
        }
    }

    class Tree {//unikalne z pozycja
        private $x;
        private $y;
        private $treeType;

        public function __construct($x, $y, TreeType $treeType) {
            $this->x = $x;
            $this->y = $y;
            $this->treeType = $treeType;
        }

        public function draw($canvas) {
            $this->treeType->draw($canvas, $this->x, $this->y);
        }
    }

    class Forest {//las drzew
        private $trees = [];

        public function plantTree($x, $y, $name, $color, $texture) {
            $type = TreeFactory::getTreeType($name, $color, $texture);
            $tree = new Tree($x, $y, $type);
            $this->trees[] = $tree;
        }

        public function draw($canvas) {
            foreach ($this->trees as $tree) {
                $tree->draw($canvas);
            }
        }

        public function showStats() {
            echo "<br> Ilość drzew w lesie: " . count($this->trees);
            echo "<br> Ilość rodzajów drzew w lesie: " . TreeFactory::getNumTreeTypes();//unikalne wlasciwosci danego drzewa
        }
    }


    $forest = new Forest();
    $forest->plantTree(1, 1, "Sosna", "Zielony", "Gładka");
    $forest->plantTree(1, 2, "Sosna", "Zielony", "Gładka");
    $forest->plantTree(3, 1, "Sosna", "Zielony", "Gładka");
    $forest->plantTree(5, 1, "Sosna", "Zielony", "Gładka");
    $forest->plantTree(1, 6, "Sosna", "Zielony", "Gładka");
    $forest->plantTree(1, 10, "Brzoza", "Biała", "Chropowata");
    $forest->plantTree(1, 10, "Brzoza", "Biała", "Chropowata");
    $forest->plantTree(1, 10, "Brzoza", "Biała", "Chropowata");
    $forest->plantTree(1, 15, "Brzoza", "Biało-brązowa", "Chropowata");
    $forest->plantTree(12, 12, "Brzoza", "Biało-brązowa", "Chropowata");
    $forest->plantTree(1, 17, "Brzoza", "Biała", "Chropowata");
    $forest->plantTree(10, 3, "Dąb", "Brązowy", "Chropowata");
    $forest->plantTree(101, 32, "Dąb", "Brązowy", "Chropowata");
    $forest->plantTree(10, 31, "Dąb", "Brązowy", "Chropowata");
    $forest->plantTree(101, 39, "Dąb", "Brązowy", "Chropowata");
    $forest->plantTree(10, 36, "Dąb", "Brązowy", "Chropowata");

    $forest->draw("Canvas1");

    $forest->showStats();


?>