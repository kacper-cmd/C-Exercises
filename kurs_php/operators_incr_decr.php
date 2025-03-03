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
        // inkrementacji pozwala o zwiększenie wartości zmiennej o 1
        // oraz przypisanie wyniku do tej samej zmiennej.
        // dekrementacja działa podobnie tylko odejmuje 1

        $a = 5;
        $a = $a + 1; // 6
        $a++; // 7
        echo($a."<br>");

        $a--; // 6
        echo($a."<br>");

        $b = 10;
        echo($b++ ."<br>"); // 10
        echo($b."<br>"); // 11

        $c = 10;
        echo(++$c ."<br>"); // 11  
        echo($c."<br>"); // 11 


        
    ?>
</body>
</html>