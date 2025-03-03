<?php
    /*
    Wzorzec projektowy Memento pozwala na zapisywanie i przywracanie poprzedniego stanu 
    obiektu bez ujawniania szczegółów jego implementacji. Jest szczególnie przydatny 
    w sytuacjach, gdzie potrzebna jest możliwość cofnięcia lub przywrócenia stanu obiektu. Edytor tekstowy

    Czym jest wzorzec Memento:
    - Zapisywanie Stanu: Pozwala na zapisanie stanu obiektu w taki sposób, aby można 
      było go później przywrócić.
    - Kapsułkowanie Stanu: Stan obiektu jest kapsułkowany w obiekcie memento, 
      co nie narusza hermetyzacji.
    - Cofanie Zmian: Umożliwia cofanie zmian do wcześniejszego stanu.
    
    Przykład wzorca Memento:
    Zaimplementujemy wzorzec Memento w kontekście edytora tekstu, który pozwala na 
    zapisywanie i przywracanie stanu tekstu.
    */


    class TextMemento {
        private string $text;

        public function __construct($text) {
            $this->text = $text;
        }

        public function getText() {
            return $this->text;
        }
    }


    class TextEditor {
        private string $text;

        public function setText($text) {
            $this->text = $text;
        }

        public function getText() {
            return $this->text;
        }

        public function save() {//ctrl+ s
            return new TextMemento($this->text);
        }

        public function restore(TextMemento $memento) {//ctrl + z
            $this->text = $memento->getText();
        }
    }

    $editor = new TextEditor();

    $editor->setText("Pierwsza wersja tekstu");
    $savedState = $editor->save();

    $editor->setText("Druga wersja tekstu");

    $editor->restore($savedState);
    echo $editor->getText();
    

?>