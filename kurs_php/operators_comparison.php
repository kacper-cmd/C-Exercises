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
        // Operatory porównania sprawdzają dwie wartości i jako
        // wynik dają wartość logiczną: true lub false

        $a = 10;
        $b = 12;
        $flag = $a > $b; // false
        $flag2 = $a < $b; // true
        
        var_export( 23 >= 10 ); echo("<br>"); // true
        var_export( 23 >= 23 ); echo("<br>"); // true
        var_export( 23 >= 40 ); echo("<br>"); // false

        var_export( 100 <= 234 ); echo("<br>"); // true

        var_export( 1 == 1 ); echo("<br>"); // true Równość (==): Sprawdza, czy dwie wartości są równe po konwersji typów.
        var_export( 1 == 1.0 ); echo("<br>"); // true
        var_export( 1 != 1 ); echo("<br>"); // false
        var_export( 1 != 7 ); echo("<br>"); // true


        var_export( 1 === 1 ); echo("<br>"); // true wartosc i typ 
        var_export( 1 === 1.0 ); echo("<br>"); // false
        var_export( 1 !== 1.0 ); echo("<br>"); // true

        var_export( "Ania" == "Ania" ); echo("<br>"); // true
        var_export( "Ania" == "ANIA" ); echo("<br>"); // false
        var_export( true == true ); echo("<br>"); // true 
        var_export( true == false ); echo("<br>"); // false 
        


        
    ?>
</body>
</html>