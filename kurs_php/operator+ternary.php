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
        // Operator ternary to skrócony zapis if else

        $name = "Asia";

        if ($name == "Kasia") {
            echo("Witaj Kasia");
        } else {
            echo("Witaj!");
        }


        $msg = ($name == "Kasia") ? "Witaj Kasia" : "Witaj!";
        echo($msg);


    ?>
    
</body>
</html>