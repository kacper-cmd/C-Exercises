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
            Tablice pozwalają na przechowywanie wielu wartości w zmiennej
        */ 
        
        $userNames = ["Kasia", "Adam", "Ania", "Karol", 12];
        echo($userNames[0] . "<br>"); // Kasia
        echo($userNames[1] . "<br>"); // Adam
        echo($userNames[2] . "<br>"); // Ania

        $carBrandModels = []; // tablica asocjacyjna z kluczami i wartościami
        $carBrandModels["Ford"] = "Mustang";
        $carBrandModels["Dodge"] = "Viper";
        $carBrandModels["Hummer"] = ["H1", "H2", "H3"];

        echo($carBrandModels["Ford"] . "<br>");
        echo($carBrandModels["Dodge"] . "<br>");
        echo($carBrandModels["Hummer"][1] . "<br>");
        // echo($carBrandModels[0] . "<br>"); // błąd

        print_r($carBrandModels);

        $formattedText = print_r($carBrandModels, true);
        
        echo("<pre>$formattedText</pre>");
    ?>
    
</body>
</html>