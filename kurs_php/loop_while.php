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
        // Pętla pozwala na wielokrotne wykonanie tego samego kodu
        


        $i = 10;

        while ($i >= 0) {
            echo($i . ", ");
            $i--;
        }

        echo(" Koniec pętli while <br>");


        $a = 3;

        do {
            echo($a . ", ");
            $a++;
        } while ($a < 8);

        echo(" Koniec pętli do while <br>");


    ?>
</body>
</html>