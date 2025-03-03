<?php
    /*
    Wzorzec projektowy Visitor pozwala na dodanie nowych operacji do istniejących klas bez 
    zmiany ich implementacji. Umożliwia wykonanie operacji na grupie obiektów z różnych klas.

    Czym jest wzorzec Visitor:
    - Oddzielenie Operacji od Obiektów: Umożliwia dodawanie nowych operacji do istniejących 
      klas bez ich modyfikacji.
    - Dodawanie Funkcjonalności: Możliwość rozszerzenia funkcjonalności klas bez zmiany ich kodu.
    - Wspieranie Operacji na Strukturach Złożonych: Szczególnie przydatny, gdy operacje muszą 
      być wykonane na różnych elementach złożonej struktury.
    
    Przykład wzorca Visitor:
    Zaimplementujemy wzorzec Visitor w kontekście systemu komputerowego, który składa się 
    z różnych komponentów.
    */


    interface Component {
        public function accept(Visitor $visitor);//Visitor ma zobaczyć czym jest dany komponent 
    }

    interface Visitor {
        public function visitCPU(CPU $cpu);
        public function visitGPU(GPU $gpu);
    }

    class CPU implements Component {
        public function accept(Visitor $visitor) {
            $visitor->visitCPU($this);//intacja CPU, dzieki temu visitor zobaczy info o tym procesorze
        }
    }

    class GPU implements Component {
        public function accept(Visitor $visitor) {
            $visitor->visitGPU($this);
        }
    }

    class HardwareInfoVisitor implements Visitor {
        public function visitCPU(CPU $cpu) {
            echo "Odczytanie informacji o cpu. <br>";
        }

        public function visitGPU(GPU $gpu) {
            echo "Odczytanie informacji o gpu. <br>";
        }
    }

    $cpu = new CPU();
    $gpu = new GPU();

    $visitor = new HardwareInfoVisitor();
    $cpu->accept($visitor);
    $gpu->accept($visitor);
   
?>