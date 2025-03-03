<?php
    /*
    Wzorzec projektowy Observer umożliwia obiektom (obserwatorom) otrzymywanie 
    powiadomień o zmianach stanu innych obiektów (obserwowanych). Jest użyteczny w sytuacjach, 
    gdy jeden obiekt musi automatycznie informować wielu innych o zmianach w swoim stanie.

    Czym jest wzorzec Observer:
    - Decentralizacja Powiadomień: Zamiast centralnego mechanizmu kontroli, obiekty obserwujące 
      samodzielnie rejestrują się do otrzymywania powiadomień.
    - Elastyczność: Umożliwia dynamiczne dołączanie i odłączanie obserwatorów 
      w trakcie działania aplikacji.
    - Oddzielenie Obserwowanych od Obserwatorów: Obserwowany nie musi znać szczegółów 
      implementacji obserwatorów.
    
    Przykład wzorca Observer:
    Zaimplementujemy wzorzec Observer w kontekście systemu powiadomień.
    */

    interface Observer {
        public function update($message);
    }

    interface Subject {
        public function attach(Observer $observer);
        public function detach(Observer $observer);
        public function notify();
    }

    class NewsPublisher implements Subject {
        private $observers = [];
        private $latestNews;

        public function attach(Observer $observer) {
            $this->observers[] = $observer;//dodanie na koniec tablicy 
        }

        public function detach(Observer $observer) {//kasowanie
            $this->observers = array_filter($this->observers, function($o) use ($observer) {//funcje na kazdeym obserkerzde, wkazuje se chec użyc observer z argumentu 
                return $o !== $observer;
            });
        }

        public function notify() {
            foreach ($this->observers as $observer) {
                $observer->update($this->latestNews);
            }
        }

        public function publishNews($news) {
            $this->latestNews = $news;
            $this->notify();
        }
    }

    class EmailSubscriber implements Observer {
        public function update($message) {
            echo "Email subscriber: Nowa wiadomość: $message <br>";
        }
    }

    class RSSSubscriber implements Observer {
        public function update($message) {
            echo "RSS subscriber: Nowa wiadomość: $message <br>";
        }
    }

    $newsPublisher = new NewsPublisher();

    $emailSubscriber = new EmailSubscriber();
    $rssSubscriber = new RSSSubscriber();

    $newsPublisher->attach($emailSubscriber);
    $newsPublisher->attach($rssSubscriber);

    $newsPublisher->publishNews("Ważna wiadomość!");

    $newsPublisher->detach($rssSubscriber);

    $newsPublisher->publishNews("Kolejna wiadomość...");
?>