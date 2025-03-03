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
        $a = 10;
        $b = 23;
        $sum = $a + $b;

        $result = ((($a + $b) * 2) + 100) / 3;
        echo($result . "<br>");

        echo( 3 ** 3 . "<br>");//potega **  Podnosi jedną wartość do potęgi drugiej wartości.

        echo( 40 % 12 . "<br>" ); // 4 remainder of division 

        $intNum = (int)$result; // 55
        echo($intNum . "<br>");

        $floatNum = (float)$intNum;
        echo($floatNum."<br>");
        var_dump($floatNum);//float(55)

        
    ?>
</body>
</html>