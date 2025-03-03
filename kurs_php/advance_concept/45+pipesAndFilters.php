<?php
    /*
    Wzorzec projektowy Pipes and Filters służy do przetwarzania danych poprzez serię etapów (filtrów), 
    każdy z nich wykonuje określoną operację. Dane przesyłane są między filtrami za pomocą rur (pipes).

    Zalety:
    - Umożliwia modularne i elastyczne projektowanie procesów przetwarzania danych.
    - Ułatwia testowanie i ponowne wykorzystanie poszczególnych filtrów.
    - Poprawia czytelność i organizację kodu poprzez oddzielanie różnych etapów przetwarzania.

    Wady:
    - Może prowadzić do zwiększenia złożoności systemu.
    - Wymaga starannego zarządzania przepływem danych między filtrami.
    - Może wprowadzić narzut wydajnościowy ze względu na przesyłanie danych między filtrami.
    */

    abstract class Filter {
        abstract public function execute($input);
    }

    class TrimFilter extends Filter {
        public function execute($input) {
            return trim($input);
        }
    }

    class SanitizeFilter extends Filter {
        public function execute($input) {
            return htmlspecialchars($input);
        }
    }

    class UpperCaseFilter extends Filter {
        public function execute($input) {
            return strtoupper($input);
        }
    }

    class Pipe {
        private $filters;

        public function __construct() {
            $this->filters = [];
        }

        public function addFilter(Filter $filter) {
            $this->filters[] = $filter;
            return $this;
        }

        public function process($input) {
            foreach ($this->filters as $filter) {
                $input = $filter->execute($input);
            }

            return $input;
        }
    }

    $pipe = new Pipe();
    $pipe->addFilter(new TrimFilter())
         ->addFilter(new UpperCaseFilter());

    $output = $pipe->process(" Hello World! ");
    echo $output;


?>
