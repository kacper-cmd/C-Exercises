<?php
require 'vendor/autoload.php';
use PHPUnit\Framework\TestCase;
class Product{
    public $name;
    public $price;
    public function __construct($name, $price)
    {
        $this->name = $name;
        $this->price = $price;        
    }
}
function getProducts(){
    return [
        new Product("Produkt 1", 100),
        new Product("Produkt 2", 200),
        new Product("Produkt 3", 300)
    ];
}

class Test08_colections extends TestCase{
    public function testProductCollections() {

        $products = getProducts();
        
        $this->assertIsArray($products);
        $this->assertCount(3, $products);
        foreach($products as $product){
            $this->assertInstanceOf(Product::class, $product);
        }
    }
    public function testProductProperties(){
        $product = getProducts()[0];
        $this->assertEquals("Produkt 1", $product->name);
        $this->assertEquals(100, $product->price);
        $this->assertEquals("Produkt 2", $product->name);

    }
}