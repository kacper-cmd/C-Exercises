<?php
    /*
    Unit of Work to wzorzec projektowy stosowany w programowaniu, szczególnie przy pracy 
    z bazami danych i ORM (Object-Relational Mapping). Jego głównym zadaniem jest zarządzanie 
    cyklem życia operacji na danych, zapewniając, że wszystkie zmiany w danych (takie jak 
    dodawanie, modyfikacja, usunięcie rekordów) są traktowane jako jedna spójna operacja, 
    czyli "jednostka pracy".

    Zalety:
    - Umożliwia grupowanie operacji na danych w jedną transakcję, zapewniając ich spójność.
    - Ułatwia zarządzanie cyklem życia obiektów w kontekście trwałości.
    - Optymalizuje dostęp do bazy danych poprzez redukcję liczby zapytań.
    Wady:
    - Zwiększa złożoność kodu poprzez dodanie dodatkowej warstwy zarządzania stanem.
    - Może być trudny w implementacji w dużych i skomplikowanych systemach.
    - Wymaga uważnego zarządzania zasobami, szczególnie w długotrwałych transakcjach.
    Przykład wykorzystuje MySQL do zarządzania danymi.*/

    abstract class Entity {
        public $id;
    }

    class User extends Entity {
        public $name;
        public $email;
    }

    interface UnitOfWork {
        public function commit();
        public function registerNew(Entity $entity);
        public function registerDirty(Entity $entity);
        public function registerDeleted(Entity $entity);
    }

    class MySqlUnitOfWork implements UnitOfWork {
        private $newEntities = [];
        private $dirtyEntities = [];
        private $deletedEntities = [];
        private $con;

        public function __construct() {
            $this->con = mysqli_connect("localhost", "root", "", "tutorial");
            $this->createTableIfNotExists();
            mysqli_begin_transaction($this->con);
        }

        public function createTableIfNotExists() {
            $createQuery = "
                CREATE TABLE IF NOT EXISTS unitofwork_test (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    name VARCHAR(100) NOT NULL,
                    email VARCHAR(100) NOT NULL
                )
            ";

            mysqli_query($this->con, $createQuery);
        }

        public function commit() {
            foreach ($this->newEntities as $entity) {
                $name = mysqli_real_escape_string($this->con, $entity->name);
                $email = mysqli_real_escape_string($this->con, $entity->email);
                $query = "INSERT INTO unitofwork_test (name, email) VALUEs ('$name', '$email')";
                mysqli_query($this->con, $query);
                $entity->id = mysqli_insert_id($this->con);
            }

            foreach ($this->dirtyEntities as $entity) {//zmienione
                $name = mysqli_real_escape_string($this->con, $entity->name);
                $email = mysqli_real_escape_string($this->con, $entity->email);
                $query = "UPDATE unitofwork_test SET name='$name',  email='$email' 
                    WHERE id = " . $entity->id;

                mysqli_query($this->con, $query); 
            }

            foreach ($this->deletedEntities as $entity) { 
                $query = "DELETE FROM unitofwork_test WHERE id = " . $entity->id; 
                mysqli_query($this->con, $query); 
            }

            mysqli_commit($this->con);

            $this->newEntities = [];
            $this->dirtyEntities = [];
            $this->deletedEntities = [];
        }
        
        public function registerNew(Entity $entity) {
            $this->newEntities[] = $entity;
        }
        
        public function registerDirty(Entity $entity) {
            $this->dirtyEntities[] = $entity;
        }

        public function registerDeleted(Entity $entity) {
            $this->deletedEntities[] = $entity;
        }

        public function __destruct() {
            mysqli_close($this->con);
        }
    }

    $unitOfWork = new MySqlUnitOfWork();

    $newUser = new User();
    $newUser->name = "Ala";
    $newUser->email = "ala@example.com";
    $unitOfWork->registerNew($newUser);

    $existingUser = new User();
    $existingUser->id = 1;
    $existingUser->name = "Alina";
    $existingUser->email = "alina@example.com";
    $unitOfWork->registerDirty($existingUser);

    $deletedUser = new User();
    $deletedUser->id = 2;
    $unitOfWork->registerDeleted($deletedUser);

    try {
        $unitOfWork->commit();
        echo "Commit ok";
    } catch (Exception $e) {
        echo "Wyjątek: " . $e->getMessage() ."<br>";
    }
?>
    




