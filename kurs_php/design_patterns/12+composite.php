<?php
    /* 
    Wzorzec projektowy Composite pozwala na traktowanie pojedynczych obiektów i kompozycji 
    obiektów (grup obiektów) w jednolity sposób. Jest to szczególnie przydatne w hierarchicznych 
    strukturach, gdzie elementy mogą mieć podobne operacje, ale niektóre z nich mogą zawierać 
    również inne elementy. np. system plików to mamy katalog : pliki i pogkatalogi i przenies pliki 

    Czym jest wzorzec Composite:
    - Hierarchiczna Struktura: Umożliwia budowanie struktur drzewiastych obiektów.
    - Jednolite Traktowanie Elementów: Elementy pojedyncze i złożone są traktowane jednolicie 
      przez klienta.
    - Uproszczenie Klienta: Klient nie musi martwić się o różnice między elementami pojedynczymi
      a złożonymi.
    
    Przykład wzorca Composite:
    Zaimplementujemy wzorzec Composite dla systemu plików, gdzie zarówno pliki, 
    jak i foldery mogą być traktowane jako 'elementy systemu plików'.
    */

    interface FileSystemComponent {
        public function showDetails();
    }

    class File implements FileSystemComponent {
        private $name;

        public function __construct($name) {
            $this->name = $name;
        }

        public function showDetails() {
            echo "Plik: $this->name <br>";
        }
    }

    class Folder implements FileSystemComponent {
        private $name;
        private $children = [];//inne pliki, foldery 

        public function __construct($name) {
            $this->name = $name;
        }

        public function add(FileSystemComponent $component) {
            $this->children[] = $component;
        }

        public function showDetails() {
            echo "Folder: $this->name <br>";

            foreach ($this->children as $child) {
                $child->showDetails();
            }
        }
    }

    $root = new Folder("Root");

    $subFolder1 = new Folder("SubFolder1");
    $subFolder1->add(new File("File1.txt"));
    $subFolder1->add(new File("File2.txt"));

    $subFolder2 = new Folder("SubFolder2");
    $subFolder2->add(new File("image1.jpg"));
    $subFolder2->add(new File("File3.txt"));
    $subFolder2->add(new File("File4.txt"));

    $root->add($subFolder1);
    $root->add($subFolder2);

    $root->showDetails();
?>