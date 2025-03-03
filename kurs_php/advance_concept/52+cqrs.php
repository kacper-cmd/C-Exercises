<?php
    /*
    Wzorzec CQRS (Command Query Responsibility Segregation) 
    pozwala na oddzielenie logiki odczytu od logiki zapisu, 
    co prowadzi do lepszej organizacji kodu,
    zwiększenia wydajności i skalowalności aplikacji.
    
    Zalety:
    - Zwiększa wydajność poprzez optymalizację zapytań odczytu i zapisu oddzielnie.
    - Ułatwia skalowanie, ponieważ można niezależnie skalować komponenty odczytu i zapisu.
    - Poprawia bezpieczeństwo, umożliwiając oddzielne zarządzanie uprawnieniami 
      do odczytu i zapisu.

    Wady:
    - Zwiększa złożoność architektury.
    - Może prowadzić do problemów związanych z spójnością danych.
    - Może wymagać dodatkowych narzędzi do synchronizacji danych między systemami 
      odczytu i zapisu. 
    */

    $dbConnection = mysqli_connect("localhost", "root", "", "tutorial");

    $createQuery = "
        CREATE TABLE IF NOT EXISTS cqrs_test (
            id INT AUTO_INCREMENT PRIMARY KEY,
            name VARCHAR(100) NOT NULL,
            value DECIMAL(10, 2) NOT NULL
        )    
    ";

    mysqli_query($dbConnection, $createQuery);

    class  CommandHandler {//zapisu na db 
        private $dbConnection;

        public function __construct($dbConnection) {
            $this->dbConnection = $dbConnection;
        }

        public function createItem($name, $value) {
            $query = "INSERT INTO cqrs_test (name, value) VALUES ('$name', $value)";
            mysqli_query($this->dbConnection, $query);
        }
        
        public function updateItem($id, $name, $value) {
            $query = "UPDATE cqrs_test SET name = '$name', value = $value WHERE id = $id ";
            mysqli_query($this->dbConnection, $query);
        }
    }

    class QueryHandler {// odczytu 
        private $dbConnection;

        public function __construct($dbConnection) {
            $this->dbConnection = $dbConnection;
        }

        public function getItem($id) {
            $query = "SELECT * FROM cqrs_test WHERE id = $id";
            $result = mysqli_query($this->dbConnection, $query);
            return mysqli_fetch_assoc($result);
        }

        public function getAllItems() {
            $query = "SELECT * FROM cqrs_test";
            $result = mysqli_query($this->dbConnection, $query);
            $items = [];
            while ($row = mysqli_fetch_assoc($result)) {
                $items[] = $row;
            }
            return $items;
        }
    }

    $command = new CommandHandler($dbConnection);
    $query = new QueryHandler($dbConnection);

    $command->createItem("Nowy element", 100.50);
    $command->createItem("Drugi element", 77.77);

    $item = $query->getItem(1);
    echo "Element: " . $item["name"] . ", wartość: " . $item["value"] . "<br>";
    
    $command->updateItem(1, "Zaktualizowany element", 222.76);
    
    $allItems = $query->getAllItems();
    foreach ($allItems as $item) {
        echo "Element z wielu: " . $item["name"] . ", wartość: " . $item["value"] . "<br>";
    }

    mysqli_close($dbConnection);





?>
