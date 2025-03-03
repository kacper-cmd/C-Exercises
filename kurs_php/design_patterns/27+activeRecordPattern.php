<?php
    /*
    Active Record zapewnia obiektowy interfejs dostępu i manipulacji danymi 
    zapisanymi w bazie danych.
    
    Zalety:
    - Łączy logikę biznesową z logiką dostępu do bazy danych w jednej klasie.
    - Uproszcza dostęp i manipulację danymi, oferując intuicyjny interfejs.
    - Zmniejsza ilość potrzebnego kodu do interakcji z bazą danych.

    Wady:
    - Łączy logikę biznesową i dostępu do danych, co może naruszać zasadę pojedynczej odpowiedzialności (SOLID).
    - Może być trudny w testowaniu i utrzymaniu, zwłaszcza w dużych aplikacjach.
    - Może prowadzić do zbyt dużej zależności od konkretnej implementacji bazy danych.
    */

    abstract class ActiveRecord {
        protected static $db;

        public static function setDb($db) {
            static::$db = $db;
        }

        abstract public function save();
        abstract public function delete();
        abstract public static function findById($id);
        abstract public static function findAll();
    }

    class User extends ActiveRecord {
        public $id;
        public $name;
        public $email;
    
        public function save() {
            if (isset($this->id)) {
                echo "Użytkwonik zaktualizowany <br>";
            } else {
                echo "Nowy użytkownik zapisany do bazy<br>";
            }
        }

        public function delete() {
            if (isset($this->id)) {
                echo "Rekord usunięty o id " . $this->id . " <br> ";
            }
        }

        public static function findById($id) {
            echo "Wyszukiwanie usera o id $id <br>";
            return new User();
        }

        public static function findAll() {
            echo "Wyszukiwanie wszystkicj użytkowników <br>";
            return [new User(), new User()];
        }
    }

    User::setDb(new stdClass());//stdClass pusta instacja obiektu 

    $newUser = new User();
    $newUser->name = "Jan";
    $newUser->email = "jan@example.com";
    $newUser->save();

    $existingUser = User::findById(1);
    $existingUser->name = "Karol";
    $existingUser->save();

    $existingUser->delete();

    $users = User::findAll();

    

?>
