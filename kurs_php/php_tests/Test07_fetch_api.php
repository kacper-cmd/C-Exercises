<?php
require 'vendor/autoload.php';
use PHPUnit\Framework\TestCase;

function fetchExchangeRates(){
    $url = "http://api.nbp.pl/api/exchangerates/tables/a/?format=json";
    $response = file_get_contents($url);
    return json_decode($response,true);
}

class Test07_fetch_api extends TestCase{
    public function testFetchExchangeRates(){
        $data = fetchExchangeRates();
        $this->assertIsArray($data);
        $this->assertArrayHasKey("rates",$data[0]);

        $this->assertNotEmpty($data[0]["rates"]);
    }
}


?>