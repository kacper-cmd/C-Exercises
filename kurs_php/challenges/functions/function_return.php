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
        
        function sum($a, $b) {
            $result = $a + $b;
            echo("Wynik: $result <br>");
        }

        sum(10, 2);
        sum(16, 12);
        sum(40, 23);
        sum(19, 123);


        function multiply($num1, $num2) {
            return $num1 * $num2;
        }

        $result = multiply(4, 5);
        echo("Wynik mnożenia: $result <br>");
        
        //Chociaż return może zwrócić bezpośrednio tylko jedną wartość, możemy obejść to ograniczenie, zwracając tablicę:

        function calculate($a, $b) {
            $sum = $a + $b;
            $difference = $a - $b;
            return ["sum" => $sum, "difference" => $difference];
        }
        
        $result = calculate(10, 5);
        echo "Suma: " . $result["sum"] . ", Różnica: " . $result["difference"];


    ?>
    
</body>
</html>