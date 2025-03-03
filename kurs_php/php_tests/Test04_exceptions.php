<?php
require 'vendor/autoload.php';

use PHPUnit\Framework\TestCase;

function checkPositiveNumber($number) {
    if ($number < 0) {
        throw new InvalidArgumentException("Number must be positive");
    }

    return true;
}

class DatabaseConnection {
    public function connect() {
        return "connected";
    }

    public function disconnect() {
        return "disconnected";
    }
}

class Test04_exceptions extends TestCase {
    protected $dbConnection;

    protected function setUp(): void {
        $this->dbConnection = new DatabaseConnection();
    }

    protected function tearDown(): void {
        $this->dbConnection = null;
    }

    public function testExceptionIsThrown() {
        $this->setUp();
        $this->expectException(InvalidArgumentException::class);
        checkPositiveNumber(-1);
    }
}

?>
