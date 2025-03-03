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
        
        // break pozwala na przerywania działania pętli

        $arr = [1,2,3,4,5];

        for ($i = 0; $i < count($arr); $i++) {
            $v = $arr[$i];

            echo($v."<br>");

            if ($v >= 3 && $v < 10) break;
            
        }

        







    ?>
    
</body>
</html>