<?php
    /*
    Saga Pattern to wzorzec projektowy używany w aplikacjach dystrybuowanych do zarządzania 
    transakcjami, które obejmują wiele usług, gdzie tradycyjne podejście do zarządzania 
    transakcjami (jak np. ACID w bazach danych) może nie być wykonalne lub efektywne. 
    Saga pozwala na realizację długotrwałych procesów biznesowych, które są rozkładane 
    na serię mniejszych transakcji, każda z nich wykonywana w różnych usługach lub mikroserwisach.

    Zalety:
    - Umożliwia zarządzanie długotrwałymi transakcjami w rozproszonych systemach.
    - Zapewnia spójność i możliwość odwracania operacji w przypadku błędów.
    - Ułatwia oddzielanie i koordynację logiki biznesowej między różnymi usługami.

    Wady:
    - Zwiększa złożoność systemu poprzez wprowadzenie dodatkowej koordynacji.
    - Wymaga implementacji mechanizmów kompensacyjnych dla każdej operacji.
    - Może być trudny w debugowaniu i testowaniu ze względu na rozproszoną naturę.

    */

    class SagaStep {
        public $operation;//nazwa funckji 
        public $compensation;
        public $data;

        public function __construct($operation, $compensation, $data) {
            $this->operation = $operation;
            $this->compensation = $compensation;
            $this->data = $data;
        }
    }

    class Saga {
        private $steps = [];
        private $con;

        public function __construct() {
            $this->con = mysqli_connect("localhost", "root", "", "tutorial");
            $this->createSagaTable();
        }

        private function createSagaTable() {
            $createQuery = "
                CREATE TABLE IF NOT EXISTS saga_test (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    saga_data VARCHAR(255) NOT NULL
                )
            ";

            mysqli_query($this->con, $createQuery);
        }

        public function addStep(SagaStep $step) {
            $this->steps[] = $step;
        }

        public function execute() {
            foreach ($this->steps as $step) {
                try {
                    call_user_func($step->operation, $this->con, $step->data);///operation funcja do wywolania 
                } catch (Exception $e) {//operacje kompensacyjne, wrocenie do poprzedniego stanu
                    foreach (array_reverse($this->steps) as $compensationStep) {
                        call_user_func($compensationStep->compensation, 
                            $this->con, $compensationStep->data);
                    }

                    throw $e;
                }
            }
        }

        public function __destruct() {
            mysqli_close($this->con);
        }
    }

    function addRecord($con, $data) {
        $escapedData = mysqli_real_escape_string($con, $data);
        $query = "INSERT INTO saga_test (saga_data) VALUES ('$escapedData') ";
        mysqli_query($con, $query);
    }

    function removeRecord($con, $data) {//do komponsacji 
        $escapedData = mysqli_real_escape_string($con, $data);
        $query = "DELETE FROM saga_test WHERE saga_data = '$escapedData' ";
        mysqli_query($con, $query);
    }

    $saga = new Saga();

    $saga->addStep(new SagaStep("addRecord", "removeRecord", "Testowa operacja 1"));//addRecord do wywolania, removeRecord komponsacja
    $saga->addStep(new SagaStep("addRecord", "removeRecord", "Testowa operacja 2"));

    try {
        $saga->execute();
        echo "Operacje Saga wykonane";
    } catch (Exception $e) {
        echo "Wystąpił błąd podczas wykonywania operacja Saga: " . $e->getMessage() . "<br>";
    }
    



?>
