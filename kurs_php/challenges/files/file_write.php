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
        r - otwiera plik tylko do odczytu. Kursor na początku
        r+ - otwiera plik do odczytu i zapisu. Kursor na początku
        w - otwiera plik tylko do zapisu, usuwa jego zawartość.
            Jeśli plik nie istnieje, próbuje go utworzyć. Kursor na początku
        w+ - otwiera plik do zapisu i odczytu, usuwa jego zawartość.
             Jeśli plik nie istnieje, próbuje go utworzyć. Kursor na początku
        a - otwiera plik tylko do zapisu.
            Jeśli plik nie istnieje, próbuje go utworzyć. Kursor na końcu
        a+- otwiera plik do odczytu i zapisu.
            Jeśli plik nie istnieje, próbuje go utworzyć. Kursor na końcu
        */

        $filename = "fileWriteTest.txt";
        if (!is_file($filename)) {
            $file = fopen($filename, "w");

            fwrite($file, "Hello \t1 \n");
            fwrite($file, "Hello 2 \n");
            fwrite($file, "Hello 3 \n");

            fclose($file);
        }
    ?>
    
</body>
</html>