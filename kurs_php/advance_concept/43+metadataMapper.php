<?php
    /*
    Metadata Mapper to wzorzec projektowy używany  w kontekście mapowania obiektowo-relacyjnego (ORM).
    Jego głównym zadaniem jest oddzielenie sposobu, w jaki dane są reprezentowane w bazie danych, 
    od sposobu ich reprezentacji w kodzie aplikacji.

    Wzorzec ten pozwala na zdefiniowanie mapowania między strukturą tabel w bazie danych a klasami 
    i obiektami w języku programowania, co ułatwia zarządzanie danymi i ich manipulację. 
    Dzięki temu programiści mogą pracować z bardziej intuicyjnymi i obiektowymi strukturami 
    danych w swoim kodzie, jednocześnie zachowując możliwość efektywnego przechowywania
    i pobierania danych z relacyjnej bazy danych.
    */ 

    class MetadataMap {
        private $dataMap;

        public function __construct() {
            $this->dataMap = [];
        }

        // $metadataMap->addMapping(User::class, 'metadatamapper_test', 
        // ['id' => 'user_id', 'name' => 'username', 'email' => 'email']);//jakie pola w  bazie odpowiadaja jakiemu polu w obiekcie php

        public function addMapping($objectClass, $tableName, $fieldMappings) {
            $this->dataMap[$objectClass] = ["tableName" => $tableName, "fields" => $fieldMappings];
        }

        public function getMapping($objectClass) {
            return $this->dataMap[$objectClass] ?? null;
        }
    }

    class DataMapper {
        private $metadataMap;
        private $dbConnection;

        public function __construct(MetadataMap $metadataMap, $dbConnection) {
            $this->metadataMap = $metadataMap;
            $this->dbConnection = $dbConnection;
        }

        public function mapObjectToRow($object) {//mapowanie obiektu php na poszczegolne wiersze w tabeli
            $class = get_class($object);
            $mapping = $this->metadataMap->getMapping($class);

            if (!$mapping) {
                throw new Exception("No mapping defined for $class");
            }

            $row = [];//row in db 
            foreach ($mapping['fields'] as $propertyName => $columnName) {
                $row[$columnName] = $object->$propertyName;// propertyName to id w instacji obiektu to bedzie zmapowane na columnName user_id w db msql
            }

            return $row;
        }

        public function mapRowToObject($row, $class) {
            $mapping = $this->metadataMap->getMapping($class);
            if (!$mapping) {
                throw new Exception("No mapping defined for $class");
            }

            $object = new $class();//nowa intacja class (np.Product, User)
            foreach ($mapping["fields"] as $propertyName => $columnName) {
                $object->$propertyName = $row[$columnName] ?? null;
            }
                    
            return $object;
        }

        public function fetchById($class, $id) {
            $mapping = $this->metadataMap->getMapping($class);
            if (!$mapping) {
                throw new Exception("No mapping defined for $class");
            }

            $tableName = $mapping["tableName"];
            $idColumn = array_search("id", array_flip($mapping["fields"]));//array flip odwroci to co było kluczem bedzie wartoscia i na odwroc
            //['id' => 'user_id'] i tutaj wyszykan np. user_id 

            $query = "SELECT * FROM $tableName WHERE $idColumn = $id ";
            $result = mysqli_query($this->dbConnection, $query);
            
            if ($row = mysqli_fetch_assoc($result)) {
                return $this->mapRowToObject($row, $class);
            }

            return null;
        }

        public function createTableIfNotExists() {
            $query = "CREATE TABLE IF NOT EXISTS metadatamapper_test (
                user_id INT AUTO_INCREMENT PRIMARY KEY,
                username VARCHAR(255),
                email VARCHAR(255)
            )";

            mysqli_query($this->dbConnection, $query);
        }
    }

    class User {
        public $id;
        public $name;
        public $email;
    }

    $metadataMap = new MetadataMap();
    $metadataMap->addMapping(User::class, "metadatamapper_test",
        ["id" => "user_id", "name" => "username", "email" => "email"]);// id w klasie user ma być mapowanie na user_id w tabeli w bazie 

    $dbConnection = mysqli_connect("localhost", "root", "", "tutorial");

    $dataMapper = new DataMapper($metadataMap, $dbConnection);
    $dataMapper->createTableIfNotExists();

    try {
        $fetchedUser = $dataMapper->fetchById(User::class, 1);
        if ($fetchedUser) {
            echo "Pobrano usera: {$fetchedUser->name}, Email: {$fetchedUser->email} <br> ";
        } else {
            echo "Nie znaleziono usera <br>";
        }

        $newUser = new User();
        $newUser->name = "Kasia Kowalska";
        $newUser->email = "kasiakowalska@example.com";

        $userRow = $dataMapper->mapObjectToRow($newUser);
        $columns = implode(", ", array_keys($userRow));
        $values = "'" . implode("', '", array_values($userRow)) . "'";
        $insertQuery = "INSERT INTO metadatamapper_test ($columns) VALUES ($values)";
        mysqli_query($dbConnection, $insertQuery);

        $newUserId = mysqli_insert_id($dbConnection);
        echo "Id nowo dodanego usera: $newUserId <br>";

    } catch (Exception $e) {
        echo "Error: " . $e->getMessage();
    }

    
    mysqli_close($dbConnection);

?>

