<?php
    /* 
    Wzorzec projektowy Iterator pozwala na sekwencyjne przeglądanie elementów kolekcji 
    (takich jak listy, drzewa itp.) bez konieczności eksponowania jej wewnętrznej
    reprezentacji. Iterator oddziela algorytmy iteracji od konkretnych klas kolekcji.

    Czym jest wzorzec Iterator:
    - Dostęp do Elementów Kolekcji: Umożliwia dostęp do elementów kolekcji 
      bez ujawniania jej wewnętrznej struktury.
    - Wspieranie Różnych Algorytmów Iteracji: Możliwość implementacji różnych algorytmów iteracji.
    - Oddzielenie Logiki Iteracji od Kolekcji: Dekompozycja odpowiedzialności kolekcji i iteracji.
    
    Przykład wzorca Iterator: przejscie po całej kolekcji 
    Stworzymy prosty przykład kolekcji książek i iteratora, który 
    umożliwi przeglądanie tych książek.
    */

    interface BookIteratorInterface {
        public function hasNext(): bool;
        public function next();
    }

    interface Collection {
        public function getIterator(): BookIteratorInterface;
    }

    class BookCollection implements Collection {
        private $books = [];

        public function addBook($book) {
            $this->books[] = $book;
        }

        public function getIterator(): BookIteratorInterface {
            return new BookIterator($this);//aktualna instacja BookCollection w jej kontekscie dziala book iterator 
        }

        public function getBooks() {
            return $this->books;
        }
    }


    class BookIterator implements BookIteratorInterface {
        private $collection;
        private $currentIndex = 0;

        public function __construct(BookCollection $collection) {
            $this->collection = $collection;
        }

        public function hasNext(): bool {
            return $this->currentIndex < count($this->collection->getBooks());
        }

        public function next() {
            if ($this->hasNext()) {
                return $this->collection->getBooks()[$this->currentIndex++];//zwrocona tablica i pobieram ze wzgledu na index 
            }

            return null;
        }
    }

    $bookCollection = new BookCollection();
    $bookCollection->addBook("Book 1");
    $bookCollection->addBook("Book 2");
    $bookCollection->addBook("Book 3");
    $bookCollection->addBook("Book 4");

    $iterator = $bookCollection->getIterator();

    while ($iterator->hasNext()) {
        echo $iterator->next() . "<br>";
    }
    
    

    



?>