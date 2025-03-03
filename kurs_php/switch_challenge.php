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
            Zadanie z switch
            1. W zmiennej $temp będzie temperatura
            2. Napisz switch sprawdzający przypadki wartości temperatury,
               dla poniższych wartości:
               - -10, -5, 0, 5 pokaż informację "zima"
               - 10, 12 to "wiosna lub jesień"
               - 20, 25 to "lato"
            3. Domyślna informacja to "nieznany przypadek"
        */

        $temp = 12;
        
        switch ($temp) {
            case -10:
            case -5:
            case 0:
            case 5:
                echo("Zima");
                break;
            case 10:
            case 12:
                echo("Wiosna lub jesień");
                break;
            case 20:
            case 25:
                echo("Lato");
                break;
            default:
                echo("Nieznany przypadek");
        }


    ?>
    
</body>
</html>