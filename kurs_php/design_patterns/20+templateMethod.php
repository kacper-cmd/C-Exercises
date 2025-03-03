<?php
    /*
    Wzorzec projektowy Template Method polega na definiowaniu szkieletu algorytmu 
    w metodzie szablonu, pozostawiając niektóre kroki do nadpisania przez podklasy. 
    Pozwala to na ponowne wykorzystanie kodu algorytmu przy jednoczesnym uniknięciu 
    duplikacji i zachowaniu elastyczności w dostosowywaniu poszczególnych kroków. 
    
     Zalety:
     - Umożliwia ponowne wykorzystanie kodu: Szkielet algorytmu jest zdefiniowany raz, 
       a różne kroki można dostosowywać w klasach potomnych.
     - Wzmacnia konsystencję: Ten sam algorytm jest używany w różnych kontekstach.
     - Zachowanie elastyczności: Pozwala na modyfikacje poszczególnych części algorytmu 
       przez klasy potomne.
    
     Wady:
     - Ogranicza elastyczność, ponieważ zmiany wymagają modyfikacji istniejącej klasy bazowej.
     - Może prowadzić do naruszenia zasady Liskov Substitution, jeśli podklasy nie implementują 
       poprawnie wszystkich kroków algorytmu.
     - Może skomplikować kod, jeśli algorytm zawiera wiele opcjonalnych kroków lub rozgałęzień.
    */

    abstract class Game {//skeleton
        final public function play() {
            $this->start();

            while (!$this->hasEnded()) {
                $this->takeTurn();
            }
            
            $this->end();
        }

        abstract protected function start();
        abstract protected function takeTurn();
        abstract protected function hasEnded();
        abstract protected function end();
    }

    class Chess extends Game {
        protected function start() {
            echo "Rozpoczęcie gry w szachy <br>";
        }

        protected function takeTurn() {
            echo "Wykonanie ruchy w grze <br>";
        }

        protected function hasEnded() {
            return rand(0, 1) > 0.5;
        }

        protected function end() {
            echo "Zakończenie gry w szachy <br>";
        }
    }

    $chessGame = new Chess();
    $chessGame->play();



?>