<?php
    /*
    Wzorzec projektowy Command umożliwia enkapsulację (ukrywanie danych) żądań jako obiektów, 
    co pozwala na parametryzację klientów z różnymi żądaniami, kolejkowanie lub rejestrowanie 
    żądań oraz implementację operacji cofania.

    Czym jest wzorzec Command:
    - Enkapsulacja Żądań: Przekształca żądania lub proste operacje w obiekty.
    - Odziedziczanie i Rozszerzalność: Umożliwia tworzenie różnorodnych klas poleceń, 
      które wykonują różne działania.
    - Oddzielenie Źródła Polecenia od Wykonawcy: Źródło polecenia (nadawca) nie musi 
      znać szczegółów wykonawcy (odbiorcy).

    Przykład wzorca Command:
    Zaimplementujemy prosty wzorzec Command w kontekście prostego pilota do urządzeń domowych.
    */

    // Definiujemy różne konkretnie polecenia, które implementują Command:
    interface Command {
        public function execute();
    }

    class LightOnCommand implements Command {//1 stan
        private $light;

        public function __construct(Light $light) {
            $this->light = $light;
        }

        public function execute() {
            $this->light->turnOn();
        }
    }

    class LightOffCommand implements Command {
        private $light;

        public function __construct(Light $light) {
            $this->light = $light;
        }

        public function execute() {
            $this->light->turnOff();
        }
    }

    class Light {
        public function turnOn() {
            echo "Światło jest włączone <br>";
        }

        public function turnOff() {
            echo "Światło jest wyłączone <br>";
        }
    }

    class RemoteControl {
        private $command;

        public function setCommand(Command $command) {
            $this->command = $command;
        }

        public function pressButton() {
            $this->command->execute();
        }
    }

    $light = new Light();
    $lightOnCommand = new LightOnCommand($light);
    $lightOffCommand = new LightOffCommand($light);

    $remote = new RemoteControl();
    $remote->setCommand($lightOnCommand);
    $remote->pressButton();

    $remote->setCommand($lightOffCommand);
    $remote->pressButton();


?>