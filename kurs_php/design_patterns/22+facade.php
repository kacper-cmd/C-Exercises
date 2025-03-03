<?php

    /*
        Wzorzec projektowy Facade polega na dostarczeniu 
        uproszczonego interfejsu do złożonego zestawu 
        funkcjonalności. W kontekście operacji na bazie 
        danych. 
        Facade może ułatwić wykonywanie standardowych operacji 
        takich jak połączenie, zapytania i zamknięcie połączenia 
        bez konieczności bezpośredniego interakcjonowania 
        z niskopoziomowymi detalami.
    */

    class DatabaseFacade {
        private $con;

        public function __construct() {
            $this->con = mysqli_connect("localhost", "root", "");
            if (!$this->con) {
                throw new Exception("Błąd połączenia z bazą danych " . mysqli_connect_error());
            }

            mysqli_select_db($this->con, "tutorial");
        }

        // $dbFacade->createTable("facade_test", [
        //     "id" => "INT AUTO_INCREMENT PRIMARY KEY",
        //     "name" => "VARCHAR(120)",
        //     "age" => "INT"
        // ]);

        public function createTable($tableName, $columns) {
            $columnDefs = array();
            foreach ($columns as $column => $type) {
                $columnDefs[] = "$column $type";
            }
            $columnSQL = implode(", ", $columnDefs);
            $sql = "CREATE TABLE IF NOT EXISTS $tableName ($columnSQL)";

            return mysqli_query($this->con, $sql);
        }

        // $result = $dbFacade->select("facade_test", "name, age");
        public function select($table, $columns = "*") {
            $sql = "SELECT $columns FROM $table";
            return mysqli_query($this->con, $sql);
        }

        // $dbFacade->insert("facade_test", ["name" => "Nowy Użytkownik", "age" => 34]);
        public function insert($table, $data) {
            $columns = implode(", ", array_keys($data));
            $valuesData = array_values($data);
            $valuesToInsert = [];
            foreach ($valuesData as $data) {
                $valuesToInsert[] = "'$data'";
            }

            $values = implode(", ", $valuesToInsert);

            $sql = "INSERT INTO $table ($columns) VALUES ($values)";  
            return mysqli_query($this->con, $sql);
        }

        // $dbFacade->update("facade_test", ["age" => $age + 1 ], "age = " . $age);
        public function update($table, $data, $conditions) {
            $updatedData = [];

            foreach ($data as $key => $value) {
                $updatedData[] = "$key = '$value'";
            }

            $updatedString = implode(", ", $updatedData);
            $sql = "UPDATE $table SET $updatedString WHERE $conditions";
            return mysqli_query($this->con, $sql);
        }

        public function delete($table, $conditions) {
            $sql = "DELETE FROM $table WHERE $conditions";
            return mysqli_query($this->con, $sql);
        }

        public function close() {
            mysqli_close($this->con);
        }
    }


    $dbFacade = new DatabaseFacade();

    $dbFacade->createTable("facade_test", [
        "id" => "INT AUTO_INCREMENT PRIMARY KEY",
        "name" => "VARCHAR(100)",
        "surname" => "VARCHAR(100)",
        "age" => "INT"
    ]);

    $age = rand(20, 50);
    echo("age: $age <br>");
    $dbFacade->insert("facade_test", ["name" => "Kasia", "surname" => "Kowalska", "age" => $age]);

    $dbFacade->update("facade_test", ["age" => $age + 1], "age = " . $age);
    
    $dbFacade->delete("facade_test", "id = 1");

    $result = $dbFacade->select("facade_test", "id, name, age");
    while ($row = mysqli_fetch_assoc($result)) {
        echo $row["id"] . ": " . $row["name"] . " " . $row["age"] . "<br>";
    }


    $dbFacade->close();










?>