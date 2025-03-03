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
        $num = 100;

        switch ($num) {
            case 0:
                echo("num to 0");
                break;
            case 3:
                echo("num to 3");
                break;
            case 10:
                echo("num to 10");
                break;
            case 12:
                echo("num to 12");
                break;
            default:
                echo("Default z $num");
        }


        $data = 2;
        switch ($data) { 
            case -2: 
            case -3: 
            case -10: 
            case -12:
                echo("data to liczba ujemna o wartości $data");
                break;
            case 2: 
            case 3: 
            case 10: 
            case 12:
                echo("data to liczba dodatnia o wartości $data");
                break;
            default:
                echo("Default z $data");
        }
        


    ?>
    
</body>
</html>