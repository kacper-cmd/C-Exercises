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
            1. Napisz program kwalifikacyjny do oddania krwi,
               zrób funkcję przyjmującą wiek oraz wagę osoby.
               Musi mieć minimum 18 lat oraz 50 kg.
               W funkcji sprawdź czy wiek i waga jest prawidłowa,
               jeśli pewnych wymagań kandydat nie spełnia podaj 
               informację za pomocą echo() i zwróć false z funkcji.
            2. Jeśli kandydat spełnia wymagania zwróć z funkcji true
            3. Przetestuj funkcję dla danych:
               -  19 i 60kg
               -  34 i 49kg
               Wynik czy spełnia wymagania pokaż w przeglądarce
        */

        function checkDonor($age, $weight) {
            if ($age >= 18) {
                if ($weight >= 50) {
                    echo("Kandydat spełnia wymagania wieku($age) oraz wagi($weight) <br>");
                    return true;
                } else {
                    echo("Kandydat spełnia wymaganie wieku($age) ale ma za małą wagę($weight) <br>");
                    return false;
                }
            } else {
                echo("Kandydat w wieku $age nie może oddać krwi <br>");
                return false;
            }
        }

        $candidate1 = checkDonor(19, 60);
        var_dump($candidate1);

        $candidate2 = checkDonor(34, 49);
        var_dump($candidate2);

        





    ?>
    
</body>
</html>