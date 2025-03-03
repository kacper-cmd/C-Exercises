<?php
    /* 
    Extension Object to wzorzec projektowy stosowany w programowaniu obiektowym, 
    który pozwala na rozszerzenie funkcjonalności istniejących klas bez modyfikacji 
    ich kodu źródłowego. Jest to szczególnie przydatne w sytuacjach, gdy klasa jest 
    częścią biblioteki lub frameworka, którego nie można lub nie chce się modyfikować, 
    a także w przypadkach, gdy chce się uniknąć problemów związanych z dziedziczeniem, 
    takich jak eksplozja kombinatoryczna klas pochodnych.

    Zalety:
    - Umożliwia rozszerzenie funkcjonalności obiektów bez modyfikacji ich klas.
    - Poprawia elastyczność i możliwości ponownego wykorzystania kodu.
    - Ułatwia utrzymanie i rozwój aplikacji, ponieważ zmiany są izolowane 
      od klas bazowych.

    Wady:
    - Może zwiększyć złożoność systemu.
    - Wymaga dodatkowej pracy przy projektowaniu rozszerzeń i zarządzaniu nimi.
    - Może prowadzić do problemów związanych z zarządzaniem zależnościami 
      i kompatybilnością rozszerzeń. 
    */

    interface Extension {
        public function extendFunctionality();
    }

    class BaseObject {
        private $extensions = [];

        public function addExtension($name, Extension $extension) {
            $this->extensions[$name] = $extension;
        }

        public function getExtension($name) {
            return $this->extensions[$name] ?? null;
        }
    }

    class ConcreteExtension implements Extension {
        public function extendFunctionality() {
            return "Dodatkowa funkcjonalność";
        }
    }

    $baseObject = new BaseObject();
    $extension = new ConcreteExtension();

    $baseObject->addExtension("concrete", $extension);

    $ext = $baseObject->getExtension("concrete");
    if ($ext != null) {
        echo $ext->extendFunctionality() . "<br>";
    }

    




























    /*
    W tym przykładzie, 'BaseObject' może być rozszerzony poprzez 
    dodanie do niego instancji 'ConcreteExtension'.
    Dzięki temu możliwe jest dodawanie nowych funkcjonalności 
    do obiektów bez konieczności modyfikacji ich klas.
    */
?>
