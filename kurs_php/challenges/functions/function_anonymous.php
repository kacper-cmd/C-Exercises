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
            Funkcja anonimowa to funkcja bez nazwy którą można zapisać
            do zmiennej i przekazać nawet jako argument do funkcji, czyli
            jest to tzw callback
        */

        $onSuccess = function($info) {
            echo("onSuccess: $info");
        };

        $onError = function($info) {
            echo("onError: $info");
        };


        function connectToServer(
            $url, 
            $userName, 
            $password, 
            $onSuccessCallback,
            $onErrorCallback) {
            
            if (true) {
                $onSuccessCallback("Connection established!");
            } else {
                $onErrorCallback("Error during connection to server");
            }
        }

        connectToServer("example.com", "admin", "1234", $onSuccess, $onError);

        





    ?>
    
</body>
</html>