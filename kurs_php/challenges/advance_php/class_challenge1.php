<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    





    <?php

        /*  
            1. Stwórz klasę opisującą smartfon,klasa ma posiadać:
               - konstruktor przyjmujący string brand oraz model, 
                 float z wielkością ekranu oraz ilością pamięci jako int
               - dodaj metodę pokazującą te informacje w przeglądarce
            2. Stwórz dwie instancje na bazie klasy i pokaż ich dane
        */

        class Smartphone {
            private $memorySize;

            public function __construct(
                private string $brand,
                private string $model,
                private float $screenSize,
                int $memorySize
            ) {
                $this->memorySize = $memorySize * 0.9;
            }

            public function printData() {
                echo("brand: " . $this->brand . " model:" . $this->model ."<br>");
                echo("screenSize: " . $this->screenSize . " memorySize:" . $this->memorySize."<br>");
            }
        }


        $phone1 = new Smartphone("Sony", "X1", 5.5, 12000);
        $phone1->printData();

        $phone2 = new Smartphone("Sony", "X3", 5.7, 32000);
        $phone2->printData();






    ?>
</body>
</html>