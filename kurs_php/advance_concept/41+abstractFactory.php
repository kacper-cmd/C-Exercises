<?php

// Wzorzec projektowy Abstract Factory służy do tworzenia 
// grup powiązanych lub zależnych obiektów bez określania 
// ich konkretnych klas. W kontekście operacji na bazie 
// danych, możemy zastosować wzorzec Abstract Factory 
// do tworzenia różnych rodzajów zapytań do bazy danych 
// (np. SELECT, INSERT, UPDATE, DELETE).

abstract class QueryFactory {
    protected $con;

    public function __construct() {
        $this->con = mysqli_connect("localhost", "root", "", "tutorial");
    }

    abstract public function createSelectQuery($table, $fields);
    abstract public function createInsertQuery($table, $data);
    abstract public function createUpdateQuery($table, $data, $conditions);
    abstract public function createDeleteQuery($table, $conditions);

    public function closeConnection() {
        mysqli_close($this->con);
    }

    public function __destruct() {
        $this->closeConnection();
    }
}

class MySQLQueryFactory extends QueryFactory {
    public function createSelectQuery($table, $fields) {
        $fieldsString = implode(", ", $fields);
        return "SELECT $fieldsString FROM $table";
    }

    public function createInsertQuery($table, $data) {
        $columns = implode(", ", array_keys($data));
        $values = implode("', '", array_values($data));
        return "INSERT INTO $table ($columns) VALUES('$values')";
    }

    public function createUpdateQuery($table, $data, $conditions) {
        $updateString = implode(", ", array_map(function ($key, $value){
            return "$key = '$value' ";
        }, array_keys($data), array_values($data)));
        return "UPDATE $table SET $updateString WHERE $conditions";
    }

    public function createDeleteQuery($table, $conditions) {
        return "DELETE FROM $table WHERE $conditions";
    }
}

$factory = new MySQLQueryFactory();

$selectQuery = $factory->createSelectQuery("abstractfactory_test", ["name", "age"]);
echo $selectQuery ."<br><br>";

$insertQuery = $factory->createInsertQuery("abstractfactory_test", ["name" => "Kasia", "age" => 27]);
echo $insertQuery ."<br><br>";

$updateQuery = $factory->createUpdateQuery("abstractfactory_test", 
    ["name" => "Asia", "age" => 27], " id = 1 ");
echo $updateQuery ."<br><br>";

$deleteQuery = $factory->createDeleteQuery("abstractfactory_test", " id = 1 ");
echo $deleteQuery ."<br><br>";

?>