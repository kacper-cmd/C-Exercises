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
            G - godzina w formacie 24-godzinnym (bez zera) od 0 do 23
            H - godzina w formacie 24-godzinnym (z zerem) od 00 do 23
            i - minuty od 00 do 59
            s - sekundy od 00 do 59
            d - dzień miesiąca (z zerem) od 01 do 31
            D - nazwa dnia tygodnia (3 litery) od Mon do Sun
            l - (mała liera L) nazwa dnia tygodnia od Sunday do Saturday
            j - dzień miesiąca (bez zera) od 1 do 31
            w - dzień tygodnia (0 — niedziela do 6 — sobota)  
            z - dzień roku od 1 do 365
            F - nazwa miesiąca od January do December
            m - miesiąc roku (z zerem) od 01 do 12
            N - miesiąc roku (bez zera) od 1 do 12
            t - liczba dni w miesiącu od 28 do 31
            Y - rok (4 cyfry) 2023
            y - rok (2 cyfry) 23
        */

        date_default_timezone_set("Europe/Warsaw");

        echo("Aktualny czas:" . date("Y.m.d H:i:s") );

        echo("Aktualny czas:" . time() ); // timestamp
                                          // ilość sekund od 01.01.1970r


    ?>
</body>
</html>