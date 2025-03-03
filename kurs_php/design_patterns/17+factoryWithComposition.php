<?php
    /*
    Wzorzec projektowy Factory z kompozycją (Factory with Composition) łączy 
    wzorzec fabryki z kompozycją obiektów, aby umożliwić tworzenie złożonych obiektów. 
    Wykorzystuje fabrykę do tworzenia komponentów, które są następnie komponowane w większe struktury.
    
    Zalety:
     - Elastyczność: Możliwość tworzenia złożonych obiektów z mniejszych, niezależnych komponentów.
     - Separacja obowiązków: Oddziela logikę tworzenia komponentów od ich kompozycji.
     - Łatwa rozbudowa: Umożliwia łatwe dodawanie nowych komponentów i konfiguracji.
    
     Wady:
     - Zwiększenie złożoności: Większa liczba klas i interakcji między nimi 
       może zwiększyć złożoność systemu.
     - Ryzyko nadmiernego rozdrobnienia: Może prowadzić do tworzenia wielu małych klas, 
       co utrudnia zrozumienie ogólnej struktury.
     - Zarządzanie zależnościami: Konieczność zarządzania zależnościami między komponentami.
    */

    interface ComponentFactory {
        public function createEngine();
        public function createWheels();
    }

    abstract class  CarComponent {
        
    }

    class Engine extends CarComponent {
        public function __construct() {
            echo "Silnik został utworzony <br>";
        }
    }

    class Wheels extends CarComponent {
        public function __construct() {
            echo "Koła zostały utworzone <br>";
        }
    }

    class CarComponentFactory implements ComponentFactory {
        public function createEngine() {
            return new Engine();
        }

        public function createWheels() {
            return new Wheels();
        }
    }

    class Car {
        private $engine;
        private $wheels;

        public function __construct(ComponentFactory $factory) {
            $this->engine = $factory->createEngine();
            $this->wheels = $factory->createWheels();
        }

        public function describe() {
            echo "Samochód z elementami z fabryki";
        }
    }

    $factory = new CarComponentFactory();
    $car = new Car($factory);
    $car->describe();




?>