<?php
    /* 
    Wzorzec projektowy Builder służy do oddzielenia procesu tworzenia złożonego obiektu 
    od jego reprezentacji, co umożliwia tworzenie różnych reprezentacji tego samego obiektu 
    przy użyciu tego samego procesu konstrukcji. Wzorzec ten jest szczególnie przydatny w sytuacjach, 
    gdzie obiekt składa się z wielu komponentów i jego konfiguracja może być skomplikowana.

    Kluczowe cechy wzorca Builder:
    Oddzielenie Konstrukcji od Reprezentacji: Builder oddziela proces budowania (konstrukcji) 
    obiektu od jego części składowych, co pozwala na tworzenie różnych reprezentacji obiektu 
    przy użyciu tego samego procesu konstrukcyjnego.

    Kontrola nad Procesem Konstrukcji: Pozwala na krokowe tworzenie złożonego obiektu 
    i udostępnia interfejs do definiowania i konfigurowania jego różnych aspektów.

    Ułatwia Tworzenie Złożonych Obiektów: Pomocny w przypadkach, gdy tworzenie złożonego 
    obiektu wymaga wielu kroków, a każdy z nich może być konfigurowany niezależnie.
    */

    class QueryBuilder {
        private $con;
        private $query;

        public function __construct() {
            $this->con = mysqli_connect("localhost", "root", "");
            mysqli_select_db($this->con, "tutorial");
            $this->reset();//reset query
        }

        public function reset() {
            $this->query = new stdClass();//pusta intacja klasy, obiekt 
            $this->query->base = "";//nowy element
            $this->query->type = "";
            $this->query->where = [];
            $this->query->limit = null;
        }
//kod
        // $queryBuilder->createTable("builder_test", [
        //     ["id", "INT AUTO_INCREMENT PRIMARY KEY"],
        //     ["name", "VARCHAR(100)"],
        //     ["age", "INT"]
        // ])->execute();
        public function createTable($tableName, array $fields) {
            $this->reset();
            $this->query->type = "create";

            $fieldList = array_map( function ($field) {
                return "$field[0] $field[1]";//["id", "INT AUTO_INCREMENT PRIMARY KEY"], taka talica lacze łancuch znakow polaczony
            }, $fields);

            $this->query->base = "
                CREATE TABLE IF NOT EXISTS $tableName
                (" .implode(", ", $fieldList) . ")
            ";

            return $this;
        }

        // $queryBuilder->insert("builder_test", [
        //     "name" => "John Doe",
        //     "age" => rand(20, 50)
        // ])->execute();
    
        public function insert($table, array $data) {
            $this->reset();
            $this->query->base = "insert";

            $columns = implode(", ", array_keys($data) );
            $values = implode(", ", array_map(function ($value) {
                return "'$value'";//tutaj klucze 
            }, array_values($data)));//wartośćiarray_values  jon

            $this->query->base = "
                INSERT INTO $table ($columns)
                VALUES ($values)
            ";

            return $this;
        }


        // $queryBuilder->select("builder_test", ["name", "age"]);
        public function select($table, array $fields) {
            $this->reset();
            $this->query->type = "select";
            $fieldString = implode(", ", $fields);

            $this->query->base = "SELECT $fieldString FROM $table";
            return $this;
        }

        public function where($condition) {
            if (!in_array($this->query->type, ["select", "delete", "update"])) {
                throw new Exception("Where can only be used with select, delete and update");
            }

            $this->query->where[] = $condition;

            return $this;
        }

        public function limit($limit) {
            if ($this->query->type != "select") {
                throw new Exception("Only select can use limit");
            }

            $this->query->limit = "LIMIT $limit";
            return $this;
        }

        public function getSql() {
            $query = $this->query->base;

            if (!empty($this->query->where)) {
                $query .= " WHERE " . implode(" AND ", $this->query->where);//.= laczenie 
            }

            if ($this->query->limit) {
                $query .= " " . $this->query->limit; 
            }

            return $query;
        }

        public function execute() {
            $sql = $this->getSql();
            return mysqli_query($this->con, $sql);
        }

        public function closeConnection() {
            mysqli_close($this->con);
        }

        public function __destruct() {
            $this->closeConnection();
        }
    }


    $queryBuilder = new QueryBuilder();
    $queryBuilder->createTable("builder_test", [
        ["id", "INT AUTO_INCREMENT PRIMARY KEY"],
        ["name", "VARCHAR(100)"],
        ["surname", "VARCHAR(100)"],
        ["age", "INT"]
    ])->execute();

    $queryBuilder->insert("builder_test", [
        "name" => "Kasia",
        "surname" => "Kowalska",
        "age" => rand(20, 50)
    ])->execute();

    $queryBuilder->select("builder_test", ["id", "name", "age"]);

    $result = $queryBuilder->execute();
    if ($result) {
        while ($row = mysqli_fetch_assoc($result)) {
            echo $row["id"] . ": " . $row["name"] . " " . $row["age"] . " <br>";
        }
    } else {
        echo "Brak danych w tabeli";
    }

?>