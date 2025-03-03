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
        $emailSent = false;

        if ($emailSent == false) {
            echo("Trzeba wysłać email <br>");
        }

        if ($emailSent == true) {
            echo("Email został wysłany <br>");
        }


        if ($emailSent) {
            echo("Email został wysłany <br>");
        }

        if (!$emailSent) {
            echo("Trzeba wysłać email <br>");
        }
        


    ?>
    
</body>
</html>