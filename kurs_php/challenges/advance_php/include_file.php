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
        //require("test2.php"); // nie ma pliku to fatal error
        include("test.php"); // tylko warning jeśli nie ma pliku  
        include_once("if.php"); // jeśli raz dołączony plik
        include_once("if.php"); // to już ponownie nie zostanie
        include_once("if.php"); // dołączony do programu

        echo( add(1, 3) );
    ?>

</body>
</html>