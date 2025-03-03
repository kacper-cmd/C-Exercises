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
        $arr = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        $arr[] = 11;//na koniec dodaje nowy element
        $arr[] = 12;
        array_push($arr, 3,3,5, 5);
        print_r($arr);

        function even($v) {
            if ($v % 2 == 0) {
                return true;
            } else {
                return false;
            }
        }

        print_r(array_filter($arr, "even")); echo("<br>");


        $filteredArr = array_filter($arr, function ($v){
            if ($v > 5) {
                return true;
            } else {
                return false;
            }
        });
        
        print_r($filteredArr); echo("<br>");
        


        

        













    ?>
    
</body>
</html>