<?php
    /*
    Wzorzec projektowy Bridge służy do oddzielenia abstrakcji od implementacji, 
    dzięki czemu obie mogą być rozwijane niezależnie. Wzorzec ten jest przydatny 
    w sytuacjach, gdzie chcemy odseparować pewne operacje od obiektów, na których 
    są wykonywane, umożliwiając różne warianty tych operacji.

    Czym jest wzorzec Bridge:
    - Oddzielenie Abstrakcji od Implementacji: Bridge pozwala zmieniać implementację 
      niezależnie od abstrakcji.
    - Większa Elastyczność: Umożliwia tworzenie rozszerzalnych i łatwych w utrzymaniu aplikacji.
    
    Przykład wzorca Bridge:
    Zaimplementujemy wzorzec Bridge dla systemu urządzeń i pilotów do ich kontrolowania. 
    Urządzenia to abstrakcje, a sposoby ich kontroli to implementacje.
    */

    interface Device {
        public function turnOn();
        public function turnOff();
        public function setChannel($number);
    }

    class TV implements Device {
        public function turnOn() {
            echo "TV włączony <br>";
        }

        public function turnOff() {
            echo "TV wyłączony <br>";
        }

        public function setChannel($number) {
            echo "TV - zmiana kanału na nr.: $number <br>";
        }
    }

    class Radio implements Device {
        public function turnOn() {
            echo "Radio włączone <br>";
        }

        public function turnOff() {
            echo "Radio wyłączone <br>";
        }

        public function setChannel($number) {
            echo "Radio - zmiana kanału na nr.: $number <br>";
        }
    }

    abstract class RemoteControl {
        protected $device;

        public function __construct(Device $device) {
            $this->device = $device;
        }

        public abstract function togglePower();
        public abstract function channelUp();
        public abstract function channelDown();
    }

    class SimpleRemoteControl extends RemoteControl {
        public function togglePower() {
            echo "Przełącznik zasilania <br>";
            $this->device->turnOn();
        }

        public function channelUp() {
            echo "Kanał w górę<br>";
        }

        public function channelDown() {
            echo "Kanał w dół<br>";
        }
    }

    class AdvancedRemoteControl extends RemoteControl {
        public function togglePower() {
            echo "Zaawansowany przełącznik zasilania <br>";
            $this->device->turnOff();
        }

        public function channelUp() {
            echo "Kanał w górę<br>";
        }

        public function channelDown() {
            echo "Kanał w dół<br>";
        }
    }

    $tv = new TV();
    $simpleRemote = new SimpleRemoteControl($tv);
    $simpleRemote->togglePower();

    $radio = new Radio();
    $advRemote = new AdvancedRemoteControl($radio);
    $advRemote->togglePower();



    

    


    

    

?>