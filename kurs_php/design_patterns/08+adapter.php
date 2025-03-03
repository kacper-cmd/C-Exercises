<?php
// Wzorzec projektowy Adapter pozwala na współpracę klas, 
// które bez tego nie mogłyby ze sobą współdziałać z powodu
// niekompatybilności interfejsów. 

interface Logger {
    public function log($message);
}

class BrowserLogger implements Logger {
    public function log($message) {
        echo "Log do przeglądarki: $message <br>";
    }
}

class FileLogger {//nie implementuje Logger
    private $filePath;

    public function __construct($filePath) {
        $this->filePath = $filePath;
    }

    public function logToFile($message) {
        file_put_contents($this->filePath, $message . PHP_EOL, FILE_APPEND);
    }
}

class FileLoggerAdapter implements Logger {
    private FileLogger $fileLogger;

    public function __construct(FileLogger $fileLogger) {
        $this->fileLogger = $fileLogger;
    }

    public function log($message) {
        $this->fileLogger->logToFile($message);
    }
}

$browserLogger = new BrowserLogger();
$browserLogger->log("Wiadomość 1");
$browserLogger->log("Wiadomość 2");

$fileLogger = new FileLogger("adapter_log.txt");
$fileLoggerAdapter = new FileLoggerAdapter($fileLogger);
$fileLoggerAdapter->log("Wiadomość do pliku nr 1");
$fileLoggerAdapter->log("Wiadomość do pliku nr 2");

?>