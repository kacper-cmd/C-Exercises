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
            Zadanie z funkcjami:
            1. Napisz tablicę liczb od 0 do 12 z krokiem co 3
            2. Stwórz funkcję sumArr(arr) która przyjmie jako argument
               tablicę, zsumuje jej elementy i zwróci z funkcji sumę
            3. Wywołaj funkcję z tablicą
            4. Pokaż sumę liczb w przeglądarce
        */

        $data = [0,3,6,9,12];

        function sumArr($arr) {
            $sum = 0;

            foreach ($arr as $v) {
                $sum += $v;
            }

            return $sum;
        }

        $result = sumArr($data);
        echo($result);






    ?>
    
</body>
</html>