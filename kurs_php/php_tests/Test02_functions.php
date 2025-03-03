<?php
require "vendor/autoload.php";
use PHPUnit\Framework\TestCase;

function addNumbers($a, $b) {
    return $a + $b;
}

function substractNumbers($a, $b) {
    return $a - $b;
}

function concatenateStrings($str1, $str2) {
    return $str1 . $str2;
}

function isNumberPositive($number) {
    return $number > 0;
}

function greet($name = "Guest") {
    return "Hello, " . $name;
}

class Test02_functions extends TestCase {
    public function testAddNumbers() {
        $this->assertEquals(5, addNumbers(2, 3));
    }

    public function testSubstractNumbers() {
        $this->assertEquals(3, substractNumbers(5, 2));
    }

    public function testConcatenateStrings() {
        $this->assertEquals("HelloWorld", concatenateStrings("Hello", "World"));
    }

    public function testIsNumberPositive() {
        $this->assertTrue(isNumberPositive(5));
        $this->assertTrue(isNumberPositive(15));
        $this->assertFalse(isNumberPositive(-5));
    }

    public function testGreetWithDefaultValue() {
        $this->assertEquals("Hello, Guest", greet());
    }

    public function testGreetWithArgument() {
        $this->assertEquals("Hello, John", greet("John"));
    }
}


?>