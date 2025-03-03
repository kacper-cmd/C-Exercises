<?php
    /*
    Wzorzec projektowy Twin umożliwia współpracę dwóch obiektów posiadających 
    różne interfejsy, które jednak mają być traktowane jako para.  

    Zalety:
    - Umożliwia ścisłą współpracę między klasami, które mają różne interfejsy.
    - Zwiększa elastyczność w projektowaniu, pozwalając na lepszą separację obowiązków.
    - Przydatny w językach, które nie wspierają wielokrotnego dziedziczenia.

    Wady:
    - Może prowadzić do zwiększenia złożoności projektu.
    - Wiąże ze sobą dwa obiekty, co może utrudniać ich niezależne użycie.
    - Może wprowadzić dodatkową warstwę skomplikowania w utrzymaniu i rozumieniu kodu.
    */


    abstract class GameCharacter {
        protected $twin;

        public function setTwin($twin) {
            $this->twin = $twin;
        }

        abstract public function move();
        abstract public function attack();
    }

    class PhysicalCharacter extends GameCharacter {
        public function move() {
            echo "PhysicalCharacter moving <br>";
            $this->twin->move();
        }

        public function attack() {
            echo "PhysicalCharacter attacks <br>";
        }
    }

    class GhostCharacter extends GameCharacter {
        public function move() {
            echo "GhostCharacter moving <br>"; 
        }

        public function attack() {
            echo "GhostCharacter attacks <br>";
        }
    }

    $physical = new PhysicalCharacter();
    $ghost = new GhostCharacter();

    $physical->setTwin($ghost);
    $ghost->setTwin($physical);

    $physical->move();
    $ghost->attack();
   





?>
