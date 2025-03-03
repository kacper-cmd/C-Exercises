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
        
        // continue pozwala na pominięcie aktualnej iteracji pętli

        $arr = [1,2,3,4,5,6,7,8,9,10];

        for ($i = 0; $i < count($arr); $i++) {
            $v = $arr[$i];

            if ($v == 2 || $v == 4 || $v == 6) continue;

            echo($v."<br>"); 
        }


        for ($i = 0; $i < count($arr); $i++) {
            $v = $arr[$i];

            if ($v % 2 == 0) continue; // parzysta

            echo($v."<br>"); 
        }

        







    ?>
    
</body>
</html>