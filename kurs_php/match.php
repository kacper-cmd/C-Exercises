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
        //match jest to, że porównuje ona wartości w sposób ścisły (===) oraz automatycznie zwraca wartość bez potrzeby stosowania break.
        //Zwracanie wartości: match automatycznie zwraca wartość, eliminując potrzebę używania return lub przypisywania wyniku do zmiennej w każdym przypadku.
        //Porównanie ścisłe: match używa porównania ścisłego (===), co czyni ją bardziej przewidywalną niż switch, który używa porównania luźnego (==).
        //Bez break: Nie trzeba używać break po każdym przypadku, co zmniejsza ryzyko błędów.
        $num = 8;

        $result = match($num) {
            0 => "zero",
            3 => "trzy",
            8 => "osiem",
            10 => "dziesięć",
            default => "nieznana wartość"
        };

        echo($result);







    ?>
    
</body>
</html>