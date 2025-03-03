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
            Stałe w PHP tworzymy z funkcją define(), nazwy stałych 
            nie mają znaku $, nie można zmieniać ich wartości
        */ 

        define("CONSTANT_TEST", 12);
        echo(CONSTANT_TEST . "<br>");

        //define("CONSTANT_TEST", 12);

        echo(__FILE__ . "<br>");
        echo(__DIR__ . "<br>");

        $emailSend = FALSE;//upper case 

        var_dump($emailSend);
    ?>
    
</body>
</html>