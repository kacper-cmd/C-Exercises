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
            Łańcuchy znaków tzw string
        */ 

        $name = "Ania";
        $username = $name." Kowalska <br>";

        echo($username);

        $usernameLen = strlen($username); // długość łańcucha
        echo($usernameLen . "<br>");

        $num = 12.456;
        echo("Wartość zmiennej num:".$num."<br>");
        echo("Wartość zmiennej num: $num w naszym programie <br>");

        echo("Test \" cytat \" łańcucha");
        
    ?>
    
</body>
</html>