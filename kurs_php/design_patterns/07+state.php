<?php
    /*
        Wzorzec projektowy State pozwala na zmianę zachowania obiektu, gdy zmienia się 
        jego stan wewnętrzny. Jest to szczególnie przydatne, gdy zachowanie obiektu musi 
        być zmienione w zależności od jego stanu.

        Czym jest wzorzec State:
        - Zmiana Zachowania w Czasie Rzeczywistym: Umożliwia obiektowi zmianę jego 
          zachowania, gdy jego stan wewnętrzny się zmienia.
        - Elastyczność: Pozwala na dodawanie nowych stanów bez zmiany istniejących klas.
        - Oddzielenie Stanów: Stany są oddzielone od głównej klasy, co ułatwia zarządzanie nimi.
        
        Przykład wzorca State:
        Zaimplementujemy wzorzec State w kontekście maszyny stanów dla automatu z napojami
        automat z napojami wrzucanie monenty stan sie zmieni wydanie napoju , po wydanu stan bez monety 
    */

    interface State {
        public function doAction(VendingMachine $context);
    }

    class VendingMachine {
        private $state;

        public function __construct(State $state) {
            $this->state = $state;
        }

        public function setState(State $state) {
            $this->state = $state;
        }

        public function doAction() {
            $this->state->doAction($this);//this intancja vendingchaine
            // na state wywoluj doAction, bo state mogę zmienić za pomocą mehody setState
            //zmieniam intancje na której wywolam doAction, state przechowuje instancje innych kolejnych klas 
        }
    }

    class NoCoinState implements State {
        public function doAction(VendingMachine $context) {
            echo "Brak monety, proszę wrzucić monetę. <br>";
            $context->setState(new HasCoinState());//z braku monety na stan z moneta, to przycisk który zmienia stan 
        }
    }

    class HasCoinState implements State {
        public function doAction(VendingMachine $context) {
            echo "Moneta została wrzucona do maszyny, proszę wybrać napój. <br>";
            $context->setState(new DispensingState());//wydanie napoju 
        }
    }

    class DispensingState implements State {//stan wydawany napoj 
        public function doAction(VendingMachine $context) {
            echo "Napój wydany, dziękujemy!. <br>";
            $context->setState(new NoCoinState());
        }
    }

    $vendingMachine = new VendingMachine(new NoCoinState());
    $vendingMachine->doAction();
    $vendingMachine->doAction();
    $vendingMachine->doAction();
?>