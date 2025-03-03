<?php

// Factory Method jest wzorcem projektowym należącym 
// do kategorii kreacyjnych, które skupiają się na sposobach 
// tworzenia roznych obiektów. Wzorzec ten definiuje interfejs 
// do tworzenia obiektu, ale pozwala klasom potomnym zmienić 
// typ tworzonych obiektów.
// tworzy intancje samochodów

// Factory Method jest używany, gdy:

// Istnieje potrzeba oddzielenia logiki tworzenia obiektu 
// od jego użycia.
// System powinien być skonfigurowany z jednym z wielu 
// rodzajów obiektów.
// Grupa powiązanych obiektów jest zaprojektowana do współpracy
// i trzeba zapewnić elastyczność w ich tworzeniu.

// Wzorzec ten jest szczególnie przydatny w sytuacjach, 
// gdzie klasy tworzące obiekty mają większą wiedzę o tym, 
// które klasy powinny być tworzone, niż klasa główna lub klient.
// Jest to często stosowane w bibliotekach i frameworkach, 
// gdzie szczegóły implementacyjne są ukrywane przed 
// użytkownikiem końcowym.

interface Car {
    public function getBrand();
    public function getModel();
    public function getTopSpeed();
}

class BaseCar implements Car {
    protected $brand;
    protected $model;
    protected $topSpeed;

    public function __construct($brand, $model, $topSpeed) {
        $this->brand = $brand;
        $this->model = $model;
        $this->topSpeed = $topSpeed;
    }

    public function getBrand() {
        return $this->brand;
    }

    public function getModel() {
        return $this->model;
    }

    public function getTopSpeed() {
        return $this->topSpeed;
    }

    public function displayCarDetails() {
        echo "Marka: " . $this->brand .
             ", model: " . $this->model .
             ", prędkość maksymalna: " . $this->topSpeed . " k,/h <br>";
    }
}

class Sedan extends BaseCar {
    public function sedanUniqueMethod() {

    }
}

class SUV extends BaseCar {
    public function suvUniqueMethod() {
        
    }
}

class Hatchback extends BaseCar { 
}


// Factory method - generowanie intacji method
class CarFactory {
    public static function createCar(
        $brand,
        $model,
        $topSpeed
    ) {
        switch ($model) {
            case "Sedan":
                return new Sedan($brand, $model, $topSpeed);
            case "SUV":
                return new SUV($brand, $model, $topSpeed);
            case "Hatchback":
                return new Hatchback($brand, $model, $topSpeed);
            default:
                throw new Exception("Invalid car model");
        }
    }
}


try {
    $sedan = CarFactory::createCar("Audi", "Sedan", 200);
    $suv = CarFactory::createCar("GMC", "SUV", 180);
    $hatchback = CarFactory::createCar("Merc", "Hatchback", 190);

    $sedan->displayCarDetails();
    $suv->displayCarDetails();
    $hatchback->displayCarDetails();
} catch (Exception $e) {
    echo "Błąd: " . $e->getMessage();
}


?>