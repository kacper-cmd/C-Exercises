<?php
    /*
    Wzorzec projektowy Fluent Interface polega na projektowaniu obiektowych interfejsów API 
    w sposób, który pozwala na tworzenie bardziej czytelnych kodów przez łańcuchowe wywoływanie metod.

    Zalety:
    - Poprawia czytelność i zrozumiałość kodu.
    - Ułatwia tworzenie skomplikowanych obiektów i wywoływanie sekwencji metod.
    - Sprzyja tworzeniu bardziej ekspresyjnych interfejsów API.

    Wady:
    - Może prowadzić do nadmiernego łańcuchowania, co może wprowadzać zamieszanie.
    - Nie zawsze jest intuicyjne, gdzie kończy się łańcuchowanie i jakie są jego efekty.
    - Może utrudniać debugowanie i testowanie. 
    */
    
    class FluentQueryBuilder {
        private $query = "";

        public function select($columns) {
            $this->query .= "SELECT $columns";//laczenie lancucha .=
            return $this;//zwracam aktualna instacje
        }

        public function from($table) {
            $this->query .= " FROM $table ";
            return $this;
        }

        public function where($condition) {
            $this->query .= " WHERE $condition ";
            return $this;
        }

        public function andWhere($condition) {
            $this->query .= " AND $condition ";
            return $this;
        }

        public function orWhere($condition) {
            $this->query .= " OR $condition ";
            return $this;
        }

        public function orderBy($column, $direction = "ASC") {
            $this->query .= " ORDER BY $column $direction ";
            return $this;
        }

        public function limit($limit) {
            $this->query .= " LIMIT $limit ";
            return $this;
        }

        public function build() {
            return $this->query;
        }
    }

    $dbConnection = mysqli_connect("localhost", "root", "", "tutorial");
 
    $createTableQuery = "
        CREATE TABLE IF NOT EXISTS fluent_test (
            id INT AUTO_INCREMENT PRIMARY Key,
            name VARCHAR(100) NOT NULL,
            email VARCHAR(100) NOT NULL
        )
    ";

    mysqli_query($dbConnection, $createTableQuery);
    
    $insertDataQuery = "INSERT INTO fluent_test (name, email) VALUES ('Ania Kowalska', 'ania@gmail.com')";
    mysqli_query($dbConnection, $insertDataQuery);

    $queryBuilder = new FluentQueryBuilder();

    $sql = $queryBuilder->select("*")
                        ->from("fluent_test")
                        ->where("name LIKE 'A%'")
                        ->orderBy("name")
                        ->limit(10)
                        ->build();

    $result = mysqli_query($dbConnection, $sql);
    while ($row = mysqli_fetch_assoc($result)) {
        echo print_r($row, true) . "<br>";
    }

    mysqli_close($dbConnection);


    



?>
