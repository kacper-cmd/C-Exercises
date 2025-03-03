<?php 
    // Wzorzec projektowy Abstract Factory służy do tworzenia 
    // grup powiązanych lub zależnych obiektów bez określania 
    // ich konkretnych klas.

    interface Computer {
        public function getDescription();
    }

    interface Accessory {
        public function getDescription();
    }
    
    class Laptop implements Computer {
        public function getDescription() {
            echo "Laptop <br>";
        }
    }

    class Desktop implements Computer {
        public function getDescription() {
            echo "Desktop <br>";
        }
    }

    class Mouse implements Accessory {
        public function getDescription() {
            echo "Mouse <br>";
        }
    }

    class Keyboard implements Accessory {
        public function getDescription() {
            echo "Keyboard <br>";
        }
    }

    abstract class ComputerFactory {
        abstract public function createComputer(): Computer;
        abstract public function createAccessory(): Accessory;
    }

    class LaptopFactory extends ComputerFactory {
        public function createComputer(): Computer {
            return new Laptop();
        }

        public function createAccessory(): Accessory {
            return new Mouse();
        }
    }

    class DesktopFactory extends ComputerFactory {
        public function createComputer(): Computer {
            return new Desktop();
        }

        public function createAccessory(): Accessory {
            return new Keyboard();
        }
    }

    function testComputerFactory(ComputerFactory $factory) {
        $computer = $factory->createComputer();
        $accessory = $factory->createAccessory();

        $computer->getDescription();
        $accessory->getDescription();
    }

    testComputerFactory(new LaptopFactory());
    testComputerFactory(new DesktopFactory());









?>