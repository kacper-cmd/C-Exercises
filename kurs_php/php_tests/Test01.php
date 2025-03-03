<?php

// Test01.php

 // instalacja minimum PHP 8
 // composer require --dev phpunit/phpunit ^11

 // sprawdzenie wersji 
 // php -v

 // odpalenie testu
 // vendor/bin/phpunit .\Test01.php    

// Dołączamy autoloadera Composer, który umożliwia ładowanie klas PHPUnit.
// Linia require 'vendor/autoload.php'; w PHP jest często spotykana w projektach, które korzystają z menedżera pakietów Composer. Ta instrukcja ma kluczowe znaczenie dla właściwego działania tych projektów. Oto, co robi i dlaczego jest ważna:

// Ładowanie Klas: Główną funkcją pliku autoload.php jest automatyczne ładowanie klas PHP. 
// Bez tego pliku musiałbyś ręcznie wymagać (require) lub dołączać (include) każdą klasę, 
// której używasz w swoim projekcie.
// Mechanizm Autoloadingu Composer: Composer generuje plik autoload.php, który implementuje 
// mechanizm autoloadingu. Dzięki temu, gdy odwołujesz się do klasy w swoim kodzie, 
// Composer automatycznie znajduje odpowiedni plik z definicją klasy i dołącza go do twojego projektu.

// Zarządzanie Zależnościami: Composer jest narzędziem do zarządzania zależnościami w projektach PHP. 
// Gdy instalujesz pakiety lub biblioteki przez Composer, zapisuje on informacje o tych pakietach w pliku composer.json,
// a następnie generuje odpowiadające im mapy autoloadingu w autoload.php.
require 'vendor/autoload.php';

// Tworzymy nową klasę testową, która rozszerza klasę TestCase z PHPUnit.
// Nazwa klasy testowej zwykle odpowiada nazwie klasy, którą testujemy.
class Test01 extends PHPUnit\Framework\TestCase
{
    // Metoda testowa musi zaczynać się od słowa "test".
    // W tym przypadku tworzymy test o nazwie "testTrueAssertsToTrue".
    public function testTrueAssertsToTrue()
    {
        // $this odnosi się do instancji obiektu SampleTest.
        // Metoda assertTrue jest metodą z klasy TestCase, którą dziedziczymy.
        // Sprawdza ona, czy przekazana wartość jest prawdziwa (true).
        $this->assertTrue(true);
    }
}

// W powyższym przykładzie, testTrueAssertsToTrue() jest prostym testem,
// który sprawdza, czy wartość true jest rzeczywiście traktowana jako true.
// Jest to bardzo podstawowy przykład, mający na celu zademonstrowanie struktury testu.
?>
