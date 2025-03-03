<!-- 
 mocki i stuby pozwalaja symulować zachowanie obiektów, z którymi testowana klasa wchidzi w interakcję.
 Gdy chce izolować testowaną jednostkę od zewnętrznych zależnosci jak db -->
<?php
 require 'vendor/autoload.php';
 use PHPUnit\Framework\TestCase;

class ExternalService{
    public function fetchData(){
        return "real data from server";
    }
 }

class DataProcessor {
    private $service;
    public function __construct(ExternalService $service)
    {
        $this->service = $service;
    }
    public function processData(){
        $data = $this->service->fetchData();
        return strtoupper($data);
    }
 }

class Test05_mocks extends TestCase{
    public function testProcessDataWithMock(){
        $serviceMock = $this->createMock(ExternalService::class);

        $serviceMock->method("fetchData")->willReturn("mocked data");
        $dataProcessor = new DataProcessor($serviceMock);
        $this->assertEquals("MOCKED DATA", $dataProcessor->processData());
    }
 }
 ?>