<?php 
/*
Wzorzec projektowy N-Tier polega na podziale aplikacji na oddzielne warstwy 
(tzw. tiers), które są logicznie rozdzielone i realizują określone zadania.

Zalety:
- Ułatwia utrzymanie i rozbudowę systemu poprzez oddzielenie logiki biznesowej od 
  interfejsu użytkownika i warstwy danych.
- Zwiększa skalowalność i elastyczność.
- Ułatwia testowanie i wdrażanie zmian w poszczególnych warstwach systemu.

Wady:
- Może zwiększyć złożoność systemu.
- Może wprowadzić większe opóźnienia w komunikacji między warstwami.
- Wymaga starannego planowania i dobrego projektowania.
 
*/



class PresentationLayer {
    private $businessLogic;

    public function __construct(BusinessLogicLayer $businessLogic) {
        $this->businessLogic = $businessLogic;
    }

    public function addNewProduct($name, $price) {
        $this->businessLogic->addProduct($name, $price);
        echo "Dodano nowy produkt: $name <br>";
    }

    public function displayAllProducts() {
        $products = $this->businessLogic->getAllProducts();

        foreach ($products as $product) { 
            echo "ID: " . $product["id"] . ", nazwa: " . $product["name"] 
                . ", cena: " . $product["price"] . "<br>";
        }
    }
}


class BusinessLogicLayer {
    private $dataAccess;

    public function __construct(DataAccessLayer $dataAccess) {
        $this->dataAccess = $dataAccess;
    }

    public function addProduct($name, $price) {
        $this->dataAccess->insertProduct($name, $price);
    }

    public function getAllProducts() {
        return $this->dataAccess->fetchAllProducts();
    }
}

class DataAccessLayer {
    private $dbConnection;

    public function __construct($dbConnection) {
        $this->dbConnection = $dbConnection;
        $this->ensureTableExists();
    }

    public function ensureTableExists() {
        $createQuery = "
            CREATE TABLE IF NOT EXISTS ntier_test (
                id INT AUTO_INCREMENT PRIMARY KEY,
                name VARCHAR(100) NOT NULL,
                price DECIMAL(10, 2) NOT NULL
            )
        ";
        mysqli_query($this->dbConnection, $createQuery);
    }

    public function fetchAllProducts() {
        $query = "SELECT * FROM ntier_test";
        $result = mysqli_query($this->dbConnection, $query);
        $products = [];
        while ($row = mysqli_fetch_assoc($result)) {
            $products[] = $row;
        } 
        return $products;
    }

    public function insertProduct($name, $price) {
        $query = "INSERT INTO ntier_test (name, price) VALUES ('$name', $price)";
        mysqli_query($this->dbConnection, $query);
    }
}

$dbConnection = mysqli_connect("localhost", "root", "", "tutorial");

$dataAccess = new DataAccessLayer($dbConnection);
$businessLogic = new BusinessLogicLayer($dataAccess);
$presentation = new PresentationLayer($businessLogic);

$presentation->addNewProduct("Produkt 1", 99.77);
$presentation->displayAllProducts();

mysqli_close($dbConnection);

?>
