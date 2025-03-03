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
        // Operatory logiczny and czyli && zwraca prawdę jesli po obu 
        // stronach będzie prawda

        var_export( 10 >= 3 && 12 == 12 ); echo("<br>"); // true
        var_export( 10 >= 22 && 12 == 12 ); echo("<br>"); // false
        var_export( 10 >= 22 && 12 != 12 ); echo("<br>"); // false
        var_export( 55 != 12 && 1 >= 0 && "Ania" == "Ania" ); echo("<br>"); // true
        var_export( 55 != 12 && 1 >= 3 && "Ania" == "Ania" ); echo("<br>"); // false
        
        // Operatory logiczny and czyli && zwraca prawdę jeśli po obu 
        // stronach będzie prawda

        // Zadanie, zapisz na kartce wynik dla poszczególnych przypadków:

        echo("<br>#1 "); var_export( 1 == 2 && 3 >= -1 ); // false
        echo("<br>#2 "); var_export( 7 < 10 && "A" != "B"); // true
        echo("<br>#3 "); var_export( 22 >= 22 && 10 != 11 && 3 >= -3 ); // true
        echo("<br>#4 "); var_export( 6 === 6.0 && 1 === 1.0 ); // false 


        
    ?>
</body>
</html>