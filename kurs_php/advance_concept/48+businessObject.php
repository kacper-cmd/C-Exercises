<?php
    /*
    Wzorzec Business Object pozwala na oddzielenie logiki biznesowej od logiki dostępu do danych.
    Obiekty biznesowe reprezentują encje w systemie i zawierają metody do manipulacji tymi danymi.

    Zalety:
    - Ułatwia zarządzanie logiką biznesową i jej testowanie.
    - Oddziela logikę biznesową od szczegółów implementacji bazy danych.
    - Umożliwia ponowne wykorzystanie logiki biznesowej.

    Wady:
    - Może zwiększyć złożoność systemu.
    - Może prowadzić do nadmiernego sprzężenia, jeśli nie jest odpowiednio projektowany.
    */


    $dbConnection = mysqli_connect("localhost", "root", "", "tutorial");

    $createQuery = "
        CREATE TABLE IF NOT EXISTS businessobject_test (
            id INT AUTO_INCREMENT PRIMARY KEY,
            name VARCHAR(255) NOT NULL,
            value DECIMAL(10, 2) NOT NULL
        )
    ";
    
    mysqli_query($dbConnection, $createQuery);

    class BusinessObject {
        public $id;
        public $name;
        public $value;

        public function __construct($name, $value, $id = null) {
            $this->name = $name;
            $this->value = $value;
            $this->id = $id;
        }

        public function save() {
            global $dbConnection;
            if ($this->id === null) {
                $query = "INSERT INTO businessobject_test (name, value)
                    VALUES('$this->name', $this->value) ";
                mysqli_query($dbConnection, $query);
                $this->id = mysqli_insert_id($dbConnection);
            } else {
                $query = "UPDATE businessobject_test SET name = '$this->name', value = $this->value
                          WHERE id = $this->id ";
                mysqli_query($dbConnection, $query);
            }
        }

        public static function load($id) {
            global $dbConnection;
            $query = "SELECT * FROM businessobject_test WHERE id = $id ";
            $result = mysqli_query($dbConnection, $query);
            
            if ($row = mysqli_fetch_assoc($result)) {
                return new BusinessObject($row["name"], $row["value"], $row["id"]);
            }

            return null;
        }

        public function getName() { return $this->name; }
        public function getValue() { return $this->value; }
        public function setName($name) { $this->name = $name; }
        public function setValue($value) { $this->value = $value; }
    }

    $newObject = new BusinessObject("Obiekt 1", 100.00);
    $newObject->save();

    $loadedObject = BusinessObject::load($newObject->id);
    echo "Nazwa: " . $loadedObject->getName() . " wartość: " . $loadedObject->getValue() . " <br> ";

    $loadedObject->setValue(200.00);
    $loadedObject->save();

    mysqli_close($dbConnection);


?>
