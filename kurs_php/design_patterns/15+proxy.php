<?php
    /*
    Obrazek ladowany wtedy kiedy bedzie potrzebny (lazy load)
    Wzorzec projektowy Proxy służy jako zastępczy obiekt dla innego obiektu, aby kontrolować 
    dostęp do niego. Jest on szczególnie przydatny w sytuacjach, gdzie potrzebujemy dodatkowej 
    funkcjonalności podczas dostępu do obiektu, takiej jak leniwe ładowanie, kontrola dostępu, 
    logowanie itp.

    Czym jest wzorzec Proxy:
    - Kontrola Dostępu: Proxy może kontrolować dostęp do obiektu, który reprezentuje.
    - Dodatkowa Funkcjonalność: Może wykonywać dodatkowe działania, np. ładowanie obiektu 
      na żądanie, logowanie lub sprawdzanie bezpieczeństwa.
    - Przezroczystość Użycia: Dla klienta proxy jest używane tak samo jak rzeczywisty obiekt.
    
    Przykład wzorca Proxy:
    Zaimplementujemy prosty wzorzec Proxy do reprezentowania obrazów. 
    Proxy będzie zarządzać tworzeniem obiektów obrazów tylko wtedy, gdy są one faktycznie 
    potrzebne (leniwe ładowanie).
    */


    interface Image {
        public function display();
    }

    class RealImage implements Image {
        private $filename;

        public function __construct($filename) {
            $this->filename = $filename;
            $this->loadFromDisk();
        }

        public function loadFromDisk() {
            echo "Symulacja ładowania prawdziwego obrazka <br>";
        }

        public function display() {
            echo "Wyświetlenie obrazu z pliku: $this->filename <br>";
        }
    }


    class ImageProxy implements Image { //czy jest zaladowany jak nie to zaladuje 
        private $filename;
        private $realImage;

        public function __construct($filename) {
            $this->filename = $filename; 
        }

        public function display() {
            if ($this->realImage == null) {
                $this->realImage = new RealImage($this->filename);
            }

            $this->realImage->display();
        }
    }

    $image1 = new ImageProxy("image1.jpg");
    $image2 = new ImageProxy("image2.jpg");

    $image1->display();
    $image1->display();

    $image2->display();










    








    
    /*
    Zalety i Wady Wzorca Proxy
    Zalety: 
    - Leniwe Ładowanie: Proxy może opóźnić kosztowne operacje ładowania obiektu do momentu, 
      gdy są faktycznie potrzebne.
    - Kontrola Dostępu: Może kontrolować, kto i kiedy ma dostęp do obiektu.
    - Oddzielenie Obiektu od Jego Użytkowania: Proxy może zapewnić dodatkową warstwę abstrakcji.
    
    Wady: 
    - Opóźnienia: Może powodować opóźnienia ze względu na dodatkowy poziom pośrednictwa.
    - Złożoność Kodu: Wprowadza dodatkową warstwę abstrakcji, która może skomplikować kod.
    - Niezamierzona Opóźnienia: Leniwe ładowanie może czasami prowadzić do nieoczekiwanych 
      opóźnień w przypadkach, gdy obiekt jest nagle potrzebny.
    
    Wzorzec Proxy jest bardzo użyteczny w kontrolowaniu dostępu do obiektów oraz w zarządzaniu 
    ich cyklem życ

    */
    

    



?>