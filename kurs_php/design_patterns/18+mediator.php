<?php
    /*
    Wzorzec projektowy Mediator służy do centralizacji złożonych komunikacji i kontroli 
    między obiektami w systemie. Mediator umożliwia obiektom komunikowanie się przez niego, 
    zamiast bezpośrednio między sobą, co redukuje zależności krzyżowe między nimi i ułatwia 
    zarządzanie komunikacją.

    Czym jest wzorzec Mediator:
    - Centralizacja Komunikacji: Mediator służy jako centralny punkt, przez który 
      wszystkie komponenty komunikują się ze sobą.
    - Redukcja Zależności: Obiekty nie komunikują się bezpośrednio, co zmniejsza zależności 
      między nimi.
    - Łatwiejsza Zarządzalność: Ułatwia zarządzanie komunikacją w skomplikowanych systemach.
    
    Przykład wzorca Mediator:
    Zaimplementujemy Mediator dla systemu, w którym różne komponenty (np. przycisk, 
    checkbox) komunikują się z centralnym mediatorem.    
    */


    interface Mediator {
        public function notify($sender, $event); 
    }

    class Button {
        private $mediator;

        public function setMediator(Mediator $mediator) {
            $this->mediator = $mediator;
        }

        public function click() {
            $this->mediator->notify($this, "click");
        }
    }

    class Checkbox {
        private $mediator;
        private $isChecked = false;

        public function setMediator(Mediator $mediator) {
            $this->mediator = $mediator;
        }

        public function check() {
            $this->isChecked = !$this->isChecked();
            $this->mediator->notify($this, "check");
        }

        public function isChecked() {
            return $this->isChecked;
        }
    }

    class ConcreteMediator implements Mediator {
        private $button;
        private $checkbox;

        public function setButton(Button $button) {
            $this->button = $button;
            $this->button->setMediator($this);
        }

        public function setCheckBox(Checkbox $checkbox) {
            $this->checkbox = $checkbox;
            $this->checkbox->setMediator($this);
        }

        public function notify($sender, $event) {
            if ($sender instanceof Button && $event == "click") {
                echo "Button został kliknięty <br>";
                if ($this->checkbox->isChecked()) {
                    echo "Checkbox jest zaznaczony <br>";
                } else {
                    echo "Checkbox nie jest zaznaczony <br>";
                }
            }
            
            if ($sender instanceof Checkbox && $event == "check") {
                echo "Stan checkboxa zmieniony <br>";
            }
        }
    }

    $mediator = new ConcreteMediator();
    $button = new Button();
    $checkbox = new Checkbox();

    $mediator->setButton($button);
    $mediator->setCheckbox($checkbox);

    $button->click();
    $checkbox->check();

?>