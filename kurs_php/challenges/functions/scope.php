<?php declare(strict_types=1); ?>
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
            Zasięg zmiennych w PHP:
            - zmienne globalne - zdefiniowane poza funkcją
            - zmienne lokalne - dostępne tylko wewnątrz funkcji.
              Uwaga funkcja nie ma dostępu do zmiennych globalnych
              zdefiniowanych poza funkcją! Jeśli są potrzebne trzeba 
              to wskazać słowem kluczowym global wewnątrz funkcji.
            - zmienne superglobalne - dostępne wszędzie w skrypcie
              oraz wewnątrz funkcji
        */
        
        $num = 10; // zmienna globalna
        $name = "Ania";

        function test() {
            global $name; // wskazanie że cchemy mieć dostęp do globalnej zmiennej
            echo($num); // warning nie ma dostępu do zmiennej globalnej $num

            echo($name);

            $data = "Hello!";
            echo($data);

            var_dump($_SERVER);
        }

        test();

        echo("Test: $data"); // warning - nie ma dostępu do lokalnych
                             // zmiennych funkcji poza tą funkcją

        var_dump($_SERVER); // superglobalna
        
        





    ?>
    
</body>
</html>