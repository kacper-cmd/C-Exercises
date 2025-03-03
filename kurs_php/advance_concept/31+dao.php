<?php /*
    DAO (Data Access Object) to wzorzec projektowy stosowany w programowaniu, mający na celu 
    oddzielenie logiki biznesowej aplikacji od szczegółów dostępu do danych. DAO zapewnia 
    abstrakcyjny interfejs do jakiegokolwiek typu operacji związanych z bazą danych lub 
    innym mechanizmem przechowywania danych. Umożliwia to zmianę szczegółów przechowywania 
    danych bez wpływu na resztę aplikacji, co ułatwia zarządzanie kodem i jego utrzymanie.

    Zalety:
    - Oddziela logikę dostępu do danych od logiki biznesowej.
    - Ułatwia testowanie przez izolację logiki bazodanowej.
    - Promuje ponowne wykorzystanie kodu i modularność.
    Wady:
    - Dodaje dodatkową warstwę abstrakcji, co może skomplikować kod.
    - Może prowadzić do nadmiernego abstrakcjonizmu w prostych aplikacjach.
    - Wymaga dodatkowego kodu i konfiguracji.
    */


    interface UserDao {
        public function find($id);
        public function findAll();
        public function save($user);
        public function delete($id);
    }

    class User {
        public $id;
        public $name;
        public $email;

        public function __construct($id, $name, $email) {
            $this->id = $id;
            $this->name = $name;
            $this->email = $email;
        }
    }

    class MySqlUserDao implements UserDao {
        private $con;

        public function __construct() {
            $this->con = mysqli_connect("localhost", "root", "", "tutorial");//lub wrzuyc do signletona
            $this->createTableIfNotExists();
        }

        public function createTableIfNotExists() {
            $createQuery = "
                CREATE TABLE IF NOT EXISTS dao_test (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    name VARCHAR(255) NOT NULL,
                    email VARCHAR(255) NOT NULL
                )
            ";

            mysqli_query($this->con, $createQuery);
        }

        public function find($id) {
            $result = mysqli_query($this->con, 
                "SELECT * FROM dao_test WHERE id = " . intval($id));
            $row = mysqli_fetch_assoc($result);
            return new User($row["id"], $row["name"], $row["email"]);
        }

        public function findAll() {
            $users = [];
            $result = mysqli_query($this->con, "SELECT * FROM dao_test");
            while ($row = mysqli_fetch_assoc($result)) {
                $users[] = new User($row["id"], $row["name"], $row["email"]);
            }

            return $users;
        }

        public function save($user) {
            if ($user->id) {
                $query = "UPDATE dao_test SET name = 
                    '".mysqli_real_escape_string($this->con, $user->name)."',
                    email = '".mysqli_real_escape_string($this->con, $user->email)."'
                    WHERE id = " . intval($user->id);
                mysqli_query($this->con, $query);
            } else {
                $query = "INSERT INTO dao_test (name, email) VALUES (
                    '".mysqli_real_escape_string($this->con, $user->name)."',
                    '".mysqli_real_escape_string($this->con, $user->email)."'
                )";
                mysqli_query($this->con, $query);
                $user->id = mysqli_insert_id($this->con);
            }
        }

        public function delete($id) {
            mysqli_query($this->con, "DELETE FROM dao_test WHERE id = " . intval($id));
        }

        public function __destruct() {
            mysqli_close($this->con);
        }
    }
    
    $userDao = new MySqlUserDao();
    $newUser = new User(null, "Kasia", "kasia@example.com");
    $userDao->save($newUser);

    $exisitingUser = $userDao->find($newUser->id);
    $exisitingUser->name = "Ania";
    $userDao->save($exisitingUser);
    
    $allUsers = $userDao->findAll();
    foreach($allUsers as $user) {
        echo "ID: " . $user->id . " imię: " . $user->name . "<br>";
    }

?>




