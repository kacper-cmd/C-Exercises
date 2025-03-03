<?php
    /*
    Wzorzec projektowy Repository:
    
    Zalety:
    - Centralizacja logiki dostępu do danych, ułatwiająca zarządzanie i testowanie.
    - Separacja logiki biznesowej od logiki dostępu do danych.
    - Umożliwia łatwą zmianę mechanizmu przechowywania danych.

    Wady:
    - Może prowadzić do zwiększenia złożoności systemu, zwłaszcza w przypadku prostych aplikacji.
    - Może ukrywać szczegóły implementacji, co utrudnia optymalizację wydajności.
    - Dodatkowa warstwa abstrakcji może być niepotrzebna w niektórych przypadkach.
    */

    abstract class BaseRepository {
        protected $con;

        public function __construct() {
            $this->con = mysqli_connect("localhost", "root", "");
            mysqli_select_db($this->con, "tutorial");
            $this->createTableIfNotExists();
        }

        public function __destruct() {
            mysqli_close($this->con);
        }

        private function createTableIfNotExists() {
            $createQuery = "CREATE TABLE IF NOT EXISTS repository_test (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    data VARCHAR(255) NOT NULL
            )";

            mysqli_query($this->con, $createQuery);
        }

        abstract public function find($id);
        abstract public function findAll();
        abstract public function save($entity);
        abstract public function delete($id);
    }

    class TestEntity {
        public $id;
        public $data;

        public function __construct($id = null, $data = null) {
            $this->id = $id;
            $this->data = $data;
        }
    }

    class TestRepository extends BaseRepository {
        public function find($id) {
            $query = "SELECT * FROM repository_test WHERE id = " . intval($id);
            $result = mysqli_query($this->con, $query);
            $row = mysqli_fetch_assoc($result);
            return new TestEntity($row["id"], $row["data"]);
        }

        public function findAll() {
            $entities = [];
            $result = mysqli_query($this->con, "SELECT * FROM repository_test");
            while ($row = mysqli_fetch_assoc($result)) {
                $entities[] = new TestEntity($row["id"], $row["data"]);
            }

            return $entities;
        }

        public function save($entity) {
            if (isset($entity->id)) {
                $query = "UPDATE repository_test SET data = '" .
                mysqli_real_escape_string($this->con, $entity->data). 
                "' WHERE id = " . intval($entity->id);

                mysqli_query($this->con, $query);
            } else {
                $query = "INSERT INTO repository_test (data) VALUES ('" .
                mysqli_real_escape_string($this->con, $entity->data). "')";
            
                mysqli_query($this->con, $query);
                $entity->id = mysqli_insert_id($this->con);
            }
        }

        public function delete($id) {
            $query = "DELETE FROM repository_test WHERE id = " . intval($id);
            mysqli_query($this->con, $query);
        }
    }

    $repository = new TestRepository();

    $newEntity = new TestEntity(null, "Nowe dane");
    $repository->save($newEntity);

    echo "Utworzono nowy rekord w bazie o id: " . $newEntity->id . "<br>";

    $exisitingEntity = $repository->find($newEntity->id);
    $exisitingEntity->data = "Zmienione dane";
    $repository->save($exisitingEntity);

    $repository->delete(1);

    $allEntities = $repository->findAll();
    echo "Liczba znalezionych rekordów: " . count($allEntities);

?>



