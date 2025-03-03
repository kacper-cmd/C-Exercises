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
        

        for ($i = 0; $i <= 6; $i++) {
            echo($i.", ");
        }
        echo("Koniec pętli for <br>");

        $arr = [1,2,3,4,5,6];

        for ($a = 0; $a < count($arr); $a++) {
            $value = $arr[$a] * 3;
            echo($value.", ");
        }
        echo("Koniec pętli for <br>");


        for ($i = 1, $j = 10; $i <= 10; $i++, $j-- ) {
            echo($i." - ".$j ."<br>");
        }

        /*
        Zapisz zmienna z tablica wraz z elem od 0 do 10 z krakiem co 2 czyli 2,4,6 ..
        baousz petle for która przejdzie po wsyztskich tyhch elementwach pobierze wartosc z tablicy według indeksu, doda 5 do liczbt z tablict i calosc pomnozy przez 2  Wynik kazdej iteracji zapisz w przegladarce
        */
        $data = [0, 2, 4, 6,8, 10];
        for($i=0; $i < count($data); $i++){
            $v =  $data[$i];
            $v = ($v + 5) * 2;
            echo($v.", ");
        }


    ?>
</body>
</html>