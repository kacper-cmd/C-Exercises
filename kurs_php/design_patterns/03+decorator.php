<?php

// Wzorzec projektowy (structural ) Decorator pozwala na dynamiczne 
// dodawanie nowych funkcji do obiektów. W tym przykładzie 
// stworzę prosty system logowania, a następnie zastosuję 
// wzorzec Decorator do rozszerzenia jego funkcjonalności, 
// na przykład o logowanie z timestampem czy logowanie 
// do pliku.
//Decorator is a structural design pattern that lets you attach new behaviors to objects by placing these objects inside special wrapper objects that contain the behaviors.



interface Logger {
    public function log($message);
}

class SimpleLogger implements Logger {
    public function log($message) {
        echo $message . "<br>";
    }
}

abstract class LoggerDecorator implements Logger {
    protected Logger $logger;

    public function __construct(Logger $logger) {
        $this->logger = $logger;
    }

    abstract public function log($message);
}

class TimestampLogger extends LoggerDecorator {
    public function log($message) {
        $date = new DateTime();
        $this->logger->log($date->format("Y-m-d H:i:s") . ": " . $message );
    }
}

class FileLogger extends LoggerDecorator {
    private string $filePath;

    public function __construct(Logger $logger, $filePath) {
        parent::__construct($logger);
        $this->filePath = $filePath;
    }

    public function log($message) {
        file_put_contents($this->filePath, $message . PHP_EOL, FILE_APPEND);//PHP_EOL koniec lini end of line linx, windows
        $this->logger->log($message);
    }
}

$simpleLogger = new SimpleLogger();

$fileLogger = new FileLogger($simpleLogger, "log.txt");
$timestampLogger = new TimestampLogger($fileLogger);
$timestampLogger->log("Wiadomość logowania do pliku i z timestamp");









?>