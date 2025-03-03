<?php
    /*
    Wzorzec projektowy Chain of Responsibility pozwala na przekazywanie 
    żądań wzdłuż łańcucha obiektów. Żądanie przekazywane jest od jednego obiektu 
    do następnego, dopóki nie zostanie obsłużone. 
    Jest użyteczny w sytuacjach, gdzie więcej niż jeden obiekt może obsłużyć żądanie, 
    a dokładny obsługujący nie jest znany z góry.

    Czym jest wzorzec Chain of Responsibility:
    - Łańcuch Obsługujących: Żądania przekazywane są wzdłuż łańcucha obsługujących.
    - Elastyczność w Obsługiwaniu Żądań: Różne obiekty w łańcuchu mogą obsłużyć żądanie w różny sposób.
    - Oddzielenie Nadawców od Odbiorców: Nadawca żądania nie musi znać obiektu, który je obsłuży.
    
    Przykład wzorca Chain of Responsibility:
    Zaimplementujemy wzorzec Chain of Responsibility w kontekście systemu obsługi 
    zgłoszeń technicznych.
    */

    interface Handler {
        public function setNext(Handler $handler);
        public function handle($request);
    }

    class EmailHandler implements Handler {
        private $nextHandler;

        public function setNext(Handler $handler) {
            $this->nextHandler = $handler;
        }

        public function handle($request) {
            if ($request === "Email") {
                echo "EmailHandler obsługuje żądanie<br>";
            } elseif ($this->nextHandler != null) {
                $this->nextHandler->handle($request);
            }
        }
    }

    class FAQHandler implements Handler {
        private $nextHandler;

        public function setNext(Handler $handler) {
            $this->nextHandler = $handler;
        }

        public function handle($request) {
            if ($request === "FAQ") {
                echo "FAQHandler obsługuje żądanie<br>";
            } elseif ($this->nextHandler != null) {
                $this->nextHandler->handle($request);
            }
        }
    }

    class DefaultHandler implements Handler {  
        public function setNext(Handler $handler) {

        }

        public function handle($request) { 
            echo "DefaultHandler obsługuje żądanie $request<br>"; 
        }
    }


    $emailHandler = new EmailHandler();
    $faqHandler = new FAQHandler();
    $defaultHandler = new DefaultHandler();

    $emailHandler->setNext($faqHandler);
    $faqHandler->setNext($defaultHandler);

    $emailHandler->handle("Email");
    $emailHandler->handle("FAQ");
    $emailHandler->handle("Inne zapytanie");

    


?>