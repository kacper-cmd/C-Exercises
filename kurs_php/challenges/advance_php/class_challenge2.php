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
            1. Stwórz klasę Math z podstawowymi operacjami matematycznymi
               z metodami:
               - add - dodającą dwie liczby i zwracającą wynik
               - substract - odejmującą liczby
               - divide - dzielącą liczby
               - pow - liczba do potęgi
            2. Stwórz instancję klasy i przeprowadź przykładowe operacje
               matematyczne
        */

        class Math {
            public function add($a, $b) {
                return $a + $b;
            }

            public function substract($a, $b) {
                return $a - $b;
            }

            public function divide($a, $b) {
                return $a / $b;
            }

            public function pow($a, $b) {
                return $a ** $b;
            }
        }

        $math = new Math();

        echo( $math->add(3, 5)."<br>" );
        echo( $math->substract(3, 5)."<br>" );
        echo( $math->divide(3, 5)."<br>" );
        echo( $math->pow(3, 5)."<br>" );






    ?>
</body>
</html>