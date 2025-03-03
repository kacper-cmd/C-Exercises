<?php
    /*
    Wzorzec DTO (Data Transfer Object) to wzorzec projektowy używany do przekazywania danych 
    między procesami aplikacji, szczególnie w aplikacjach warstwowych. DTO pozwala na zgrupowanie 
    wielu atrybutów w jednym obiekcie, co ułatwia przekazywanie danych.

    Zalety:
    - Zwiększa czytelność i organizację kodu poprzez grupowanie atrybutów w jednym obiekcie.
    - Ułatwia przesyłanie danych między różnymi warstwami aplikacji.
    - Może zmniejszyć ilość kodu potrzebnego do przekazywania danych.

    Wady:
    - Może prowadzić do nadmiernego tworzenia klas DTO, jeśli dla każdego przypadku użycia 
      tworzona jest nowa klasa DTO.
    - W niektórych przypadkach może wprowadzać dodatkową złożoność.
    */

    class UserDTO {
        public $id;
        public $name;
        public $email;

        public function __construct($id, $name, $email) {
            $this->id = $id;
            $this->name = $name;
            $this->email = $email;
        }
    }

    class DatabaseHandler {
        private $conn;

        public function __construct() {
            $this->conn = mysqli_connect("localhost", "root", "", "tutorial");
            $this->createTableIfNeeded();
        }

        private function createTableIfNeeded() {
            $query = "
                CREATE TABLE IF NOT EXISTS dto_test (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    name VARCHAR(100),
                    email VARCHAR(100)
                )
            ";
            mysqli_query($this->conn, $query);
        }

        public function addUser($name, $email) {
            $query = "INSERT INTO dto_test (name, email) VALUES ('$name', '$email')";
            mysqli_query($this->conn, $query);
        }
        
        public function getUserById($id) {
            $query = "SELECT id, name, email FROM dto_test WHERE id = $id";
            $result = mysqli_query($this->conn, $query);
            if ($row = mysqli_fetch_assoc($result)) {
                return new UserDTO($row["id"], $row["name"], $row["email"]);
            }
            return null;
        }

        public function deleteUserById($id) {
            $query = "DELETE FROM dto_test WHERE id = $id";
            mysqli_query($this->conn, $query);
        }

        public function updateUser($id, $name, $email) {
            $query = "UPDATE dto_test SET name = '$name', email = '$email' WHERE id = $id ";
            mysqli_query($this->conn, $query);
        }
        
        public function getAllUsers() {
            $query = "SELECT id, name, email FROM dto_test";

            $result = mysqli_query($this->conn, $query);
            $users = [];

            while ($row = mysqli_fetch_assoc($result)) {
                $users[] = new UserDTO($row["id"], $row["name"], $row["email"]);
            }

            return $users;
        }

        public function closeConnection() {
            mysqli_close($this->conn);
        }
    }

    $dbHandler = new DatabaseHandler();
    $dbHandler->addUser("Zosia Kowalska", "zosia@example.com");
    $dbHandler->addUser("Adam Kowalski", "adam@example.com");

    $user = $dbHandler->getUserById(1);
    if ($user) {
        echo "Użytkownik: " . $user->name . ", email: " . $user->email . "<br>";
    }
    
    $dbHandler->updateUser(1, "Kasia Kowalska", "kasia@example.com");
    
    $users = $dbHandler->getAllUsers();
    foreach ($users as $user) {
        echo "Użytkownik: " . $user->name . ", email: " . $user->email . "<br>";
    }
    $dbHandler->deleteUserById(2);
    $dbHandler->closeConnection();



















?>

  

