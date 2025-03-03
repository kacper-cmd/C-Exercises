<?php

require 'vendor/autoload.php';
use PHPUnit\Framework\TestCase;

function multiply($a, $b){
    return $a * $b;
}
class Test06_dataProvider extends TestCase{
    public static function multiplyDataProvider(){
        return [
            [2,2,4],//2* 2 =4
            [3,3,9],
            [4,5,20],
            [0,0,0]
        ];
    }
    /**
     * Test mnożenia z użyciem dostawcy danych
     */
    
    #[\PHPUnit\Framework\Attributes\DataProvider('multiplyDataProvider')]
    public function testMultiply($a, $b, $expected) {
        $this->assertEquals($expected, multiply($a, $b));
    }
}
?>