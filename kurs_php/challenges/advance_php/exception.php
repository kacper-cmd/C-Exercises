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

        function divide($numerator, $denominator) {
            if (!$denominator) {
                throw new Exception("Dzielenie przez zero");
            }

            return $numerator / $denominator;
        }

        try {
            echo( divide(5, 0) ."<br>" );
        } catch (Exception $e) {
            echo("Nastąpił wyjątek:". $e->getMessage() . "<br>");
        }

        echo( "Dalszy program <br>" );






        


    ?>

</body>
</html>