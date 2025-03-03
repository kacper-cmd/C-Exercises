<?php 
    /*
        Data Mapper to wzorzec projektowy używany w programowaniu, który ma na celu oddzielenie 
        logiki biznesowej aplikacji od logiki dostępu do danych. Jest to forma mapowania 
        obiektowo-relacyjnego (ORM), która służy do przenoszenia danych między systemem 
        przechowywania danych (zazwyczaj bazą danych) a obiektami w aplikacj+*
    */

    class User {
        private $id;
        private $name;
        private $email;

        public function __construct($id, $name, $email) {
            $this->id = $id;
            $this->name = $name;
            $this->email = $email;
        }

        public function getId() { return $this->id; }
        public function setId($id) { $this->id = $id; }
        public function getName() { return $this->name; }
        public function setName($name) { $this->name = $name; }
        public function getEmail() { return $this->email; }
        public function setEmail($email) { $this->email = $email; }
    }

    interface UserDataMapper {
        public function findById($id);
        public function insert(User $user);
        public function update(User $user);
        public function delete(User $user);
    }

    class MySqlUserDataMapper implements UserDataMapper {
        private $con;

        public function __construct() {
            $this->con = mysqli_connect("localhost", "root", "", "tutorial");
            $this->createTableIfNotExists();
        }

        public function createTableIfNotExists() {
            $createQuery = "
                CREATE TABLE IF NOT EXISTS datamapper_test (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    name VARCHAR(100),
                    email VARCHAR(100)
                )
            ";
            mysqli_query($this->con, $createQuery);
        }

        public function findById($id) {
            $query = "SELECT * FROM datamapper_test WHERE id = " . intval($id);
            $result = mysqli_query($this->con, $query);
            $row = mysqli_fetch_assoc($result);
            
            if ($row) {
                return new User($row["id"], $row["name"], $row["email"]);
            }

            return null;
        }

        public function insert(User $user) {
            $name = mysqli_real_escape_string($this->con, $user->getName());
            $email = mysqli_real_escape_string($this->con, $user->getEmail());
            $query = "INSERT INTO datamapper_test (name, email) VALUES ('$name','$email')";
            mysqli_query($this->con, $query);
            $user->setId(mysqli_insert_id($this->con));
        }

        public function update(User $user) {
            $id = $user->getId();
            $name = mysqli_real_escape_string($this->con, $user->getName());
            $email = mysqli_real_escape_string($this->con, $user->getEmail());
            $query = "UPDATE datamapper_test SET name = '$name', email = '$email' WHERE id = $id ";
            mysqli_query($this->con, $query);
        }

        public function delete(User $user) {
            $id = $user->getId();
            $query = "DELETE FROM datamapper_test WHERE id = $id ";
            mysqli_query($this->con, $query);
        }

        public function __destruct() {
            mysqli_close($this->con);
        }
    }
    $userDataMapper = new MySqlUserDataMapper();
    
    $newUser = new User(null, "Asia", "asia@example.com");
    $userDataMapper->insert($newUser);
    echo "Utworzono nowego usera z id: " . $newUser->getId() . "<br>";

    $newUser->setName("Kasia");
    $newUser->setEmail("kasia@example.com");
    $userDataMapper->update($newUser);
    echo "Zaktualizowano usera z id: " . $newUser->getId() . "<br>";

    $fetchedUser = $userDataMapper->findById(1);
    if ($fetchedUser) {
        echo "Pobrano usera z id: " . $fetchedUser->getId() . "<br>";
    }

    $userDataMapper->delete($fetchedUser);
    echo "Skasowano usera o id: " . $fetchedUser->getId();

?>
