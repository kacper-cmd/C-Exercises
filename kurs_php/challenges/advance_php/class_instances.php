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

        class Engine {
            public function __construct(
                private int $horsePower
            ) {
            }

            public function getHP() {
                return $this->horsePower;
            }
        }

        class Truck {
            private $engine;

            public function __construct(
                private string $brand,
                private string $model,
                int $horsePower
            ) {
                $this->engine = new Engine($horsePower);
            }

            public function showData() {
                echo($this->brand . " " . $this->model . " " . $this->engine->getHP());
            }
        }

        $truck = new Truck("Kewnworth", "X1", 523);
        $truck->showData();

        
        





    ?>
</body>
</html>