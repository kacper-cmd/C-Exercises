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
            Zastosuj if else if do sprawdzenia czy wartość
            w zmiennej $num jest dodatnia, ujemna czy równa 0,
            pokaż w przeglądarce stosowną informację.
        */

        $num = 5;

        if ($num > 0) {
            echo("$num jest dodatnie");
        } else if ($num == 0) {
            echo("$num jest równe zero");
        } else {
            echo("$num jest ujemne");
        }






    ?>
</body>
</html>