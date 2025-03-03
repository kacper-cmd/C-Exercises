<?php
    /*
    Singleton to wzorzec projektowy należący do kategorii kreacyjnych, który ma na celu zapewnienie, 
    że klasa ma tylko jedną instancję w całym systemie i zapewnia globalny punkt dostępu do tej 
    instancji. Jest to jeden z prostszych wzorców projektowych, ale jego stosowanie wymaga pewnej 
    ostrożności.

    Kluczowe cechy wzorca Singleton:
    - Jedna Instancja: Zapewnia, że klasa ma tylko jedną instancję w całym systemie.
    - Łatwy dostęp: Udostępnia globalny punkt dostępu do tej instancji.
    - Kontrolowana Inicjalizacja: Pozwala na kontrolowane tworzenie i zarządzanie zasobami, 
      ponieważ instancja jest tworzona tylko raz, zazwyczaj przy pierwszym wywołaniu.
    */

    class DatabaseConnection {
        private static $instance = null;//wspolrzedilolan nmiedzy wsyztskie intsancje tej klasy

        private $con;

        private function __construct() {
            $this->con = mysqli_connect("localhost", "root", "");
            mysqli_select_db($this->con, "tutorial");

            mysqli_query($this->con, "
                CREATE TABLE IF NOT EXISTS
                singleton_test(
                    id INT NOT NULL AUTO_INCREMENT,
                    name VARCHAR(128),
                    surname VARCHAR(128),
                    PRIMARY KEY(id)
                )
            ");
        }

        //Use $this to refer to the current object. Use self to refer to the current class.
        //In other words, use $this->member for non-static members, use self::$member for static members.
        
        public static function getInstance() {
            if (self::$instance == null) {
                self::$instance = new DatabaseConnection();
            }

            return self::$instance;
        }

        public function getConnection() {
            return $this->con;
        }

        //żeby zapobiegac klonowania instacji tej klasy 
        private function __clone() {

        }
    }
    //Even static class functions are global as well, they always need the class-name to be called:
    $db1 = DatabaseConnection::getInstance();
    $con1 = $db1->getConnection();

    mysqli_query($con1, "
        INSERT INTO singleton_test
        (name, surname)
        VALUES ('Kasia', 'Kowalska')
    ");

    $db2 = DatabaseConnection::getInstance();
    $con2 = $db2->getConnection();

    mysqli_query($con2, "
        INSERT INTO singleton_test
        (name, surname)
        VALUES ('Adam', 'Adamski')
    ");

    echo( ($con1 == $con2) . "<br>" );

    $result = mysqli_query($con2, "SELECT * FROM singleton_test");

    while ($row = mysqli_fetch_assoc($result)) {
        echo $row["name"] ." ". $row["surname"] . "<br>";
    }

    mysqli_close($con2);




?>