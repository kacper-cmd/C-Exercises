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

        $url = "https://filesamples.com/samples/document/txt/sample3.txt";

        $data = file_get_contents($url);

        file_put_contents("contentFromNet.txt",$data);







        
    ?>
    
</body>
</html>