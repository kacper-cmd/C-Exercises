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

        $filename = "visits.txt";
        $numVisits = -1;

        if (!is_file($filename)) {
            file_put_contents($filename, "1");
            $numVisits = 1;
        } else {
            $file = fopen($filename, "r+");

            if (flock($file, LOCK_EX)) {//zablokoawanie dostepu do pliku, dla jednego użytkownika 
                $num = (int)fread($file, filesize($filename));
                $num++;

                fseek($file, 0);
                fwrite($file, $num);

                flock($file, LOCK_UN);
                fclose($file);
                $numVisits = $num;
            }

        }

        echo("Licznik odwiedzin: $numVisits");













        
    ?>
    
</body>
</html>