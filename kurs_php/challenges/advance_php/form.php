<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>

    <form method="post" action="form.php">
        <p> Imię: <input type="text" name="name"> </p>
        <p> Email: <input type="text" name="email"> </p>
        <input type="submit" value="Wyślij">
    </form>

    <?php
        if (!empty($_POST["name"]) && !empty($_POST["email"]) ) {
            echo("<br><br>  Hello! ". $_POST["name"]);
        }
    

    ?>
</body>
</html>