<?php
// Test03_Classes_methods.php

require 'vendor/autoload.php'; 
use PHPUnit\Framework\TestCase;

class Calculator {
    public function add($a, $b) {
        return $a + $b;
    }

    public function substract($a, $b) {
        return $a - $b;
    }
}

class Test03_Classes_methods extends TestCase {
    public function testAdd() {
        $calculator = new Calculator(); 
        $this->assertEquals(4, $calculator->add(1, 3), "Adding 1 + 3 should equal 4");
    }

    public function testSubstract() {
        $calculator = new Calculator(); 
        $this->assertEquals(3, $calculator->substract(6, 3), "Substracting 6 - 3 should equal 3");
    }
    
    public function testResultsIsGreaterThan() {
        $calculator = new Calculator(); 
        $result = $calculator->add(2, 2);
        $this->assertGreaterThan(3, $result, "Result should be greater than 3");
    }

    public function testResultsIsLessThan() {
        $calculator = new Calculator(); 
        $result = $calculator->add(6, 2);
        $this->assertLessThan(10, $result, "Result should be less than 10");
    }
    
    public function testResultIsInteger() {
        $calculator = new Calculator(); 
        $result = $calculator->add(3, 3);
        $this->assertIsInt($result, "Result should be an integer");
    }
}








?>
