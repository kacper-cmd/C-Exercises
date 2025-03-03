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
        $userNames = ["Kasia", "Adam", "Ania", "Karol"]; 

        foreach ($userNames as $value) {
            echo($value."<br>");
        }

        $userInfo = [
            "name" => "Jan",
            "surname" => "Nowak",
            "age" => 25
        ];
        
        foreach ($userInfo as $key => $value) {
            echo $key . ": " . $value . "<br>";
        }

    ?>
    
</body>
</html>