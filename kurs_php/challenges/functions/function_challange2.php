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
            1. Napisz funkcję która obliczy i zwróci BMI według wzoru:
               Prawidłowe BMI 18,5 < BMI < 24,9

               bmi = masa / (wzrost * wzrost)
               wzrost w metrach np. 1.8
            2. Pokaż BMI dla danych:
               - 1.7 i 70kg
               - 1.8 i 100kg
        */

        function getBmi($weight, $height) {
            return $weight / ($height * $height);
        }
    
        echo("BMI dla 1.7m i 70kg: ". getBmi(70, 1.7) . "<br>" );
        echo("BMI dla 1.8m i 100kg: ". getBmi(100, 1.8) . "<br>" );
        






    ?>
    
</body>
</html>