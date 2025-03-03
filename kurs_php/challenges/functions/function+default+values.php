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
        
        function getUserData( $userName,
            $email = "unknown@example.com",
            $age = 18,
            $city = "unknown"
        ) {
            return array(
                "username" => $userName,
                "age" => $age,
                "city" => $city,
                "email" => $email
            );
        } 

        $user1 = getUserData("Kasia", "kasia@example.com", 32, "Krk");
        var_dump($user1);






    ?>
    
</body>
</html>