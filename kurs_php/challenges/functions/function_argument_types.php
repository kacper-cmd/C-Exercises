<?php declare(strict_types=1); ?>
<!-- sprawdzanie typów  -->
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
            W php możemy określić jakiego typu argument akceptuje funkcja
            oraz jaki konkretny typ zwraca np:
            int, float, array, string, object, resource, bool, null
        */

        function add(int $a, int $b) : int {//jest tez autoconversja add(5.23,2.4); jak nie ma php declare(strict_types=1);
            return $a + $b;
        }

        function addFloats(float $a, float $b) : float {
            return $a + $b;
        }

        echo( add(5, 7) . "<br>" );
        echo( addFloats(5.23, 7.56) . "<br>" );


        function add3( int | float $a, int | float $b ) : int | float {//union of type  $a can be int or float 
            return $a + $b;
        }

        echo( add3(56, 12) . "<br>" );
        echo( add3(56, 12.456) . "<br>" );
        echo( add3(56.465, 12.456) . "<br>" );
         
        function printData(?string $str) : void { //NULLABLE 
            echo($str."<br>");
        }

        printData("Hello World!");
        printData(null);
        





    ?>
    
</body>
</html>