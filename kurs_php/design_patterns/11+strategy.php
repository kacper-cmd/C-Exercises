<?php
    /*
    Klasy reprezentuja algorytmy 
    Wzorzec projektowy Strategy pozwala na definiowanie rodziny algorytmów, umieszczenie 
    ich w oddzielnych klasach oraz umożliwia ich zamienne używanie. Pozwala to na zmianę 
    zachowania wybranego obiektu w trakcie działania programu.

    Czym jest wzorzec Strategy:
    - Elastyczność: Umożliwia łatwą zmianę algorytmu wykorzystywanego przez obiekt.
    - Oddzielenie Algorytmu od Klienta: Klient nie musi znać szczegółów implementacji algorytmu.
    - Łatwa Zmiana Zachowania: Możliwość zmiany zachowania obiektu poprzez zastosowanie innego algorytmu.
    
    Przykład wzorca Strategy:
    Zaimplementujemy wzorzec Strategy w kontekście różnych strategii sortowania.
    */

    interface SortingStrategy {
        public function sort(array $dataset): array;
    }

    class BubbleSortStrategy implements SortingStrategy {
        public function sort(array $dataset): array {
            sort($dataset);
            echo "<br><br>Sortowanie bąbelkowe: ";
            print_r($dataset);

            return $dataset;
        }
    }

    class QuickSortStrategy implements SortingStrategy {
        public function sort(array $dataset): array {
            rsort($dataset); // malejąco
            echo "<br><br>Sortowanie szybkie: ";
            print_r($dataset);

            return $dataset;
        }
    }

    class Context {
        private $strategy;

        public function __construct(SortingStrategy $strategy) {
            $this->strategy = $strategy;
        }

        public function setStrategy(SortingStrategy $strategy) {
            $this->strategy = $strategy;
        }

        public function sortArray(array $dataset): array {
            return $this->strategy->sort($dataset);
        }
    }

    $dataset = [1, 5, 3, 2, 8, 7];
    $context = new Context(new BubbleSortStrategy());
    $sorted = $context->sortArray($dataset);

    $context->setStrategy(new QuickSortStrategy());
    $sorted = $context->sortArray($dataset);
    
?>