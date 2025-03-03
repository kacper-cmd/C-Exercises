<?php declare(strict_types=1); ?>
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
        
        function downloadFile(string $fileUrl, int $timeout, $onError) {
            echo("$fileUrl $timeout <br>");
        }

        $onErr = function() {

        };

        downloadFile("https://example.com/file.pdf", 60000, $onErr);
        
        downloadFile( 
            timeout: 60000, 
            fileUrl: "https://example.com/file.pdf",  
            onError: $onErr
        );
        

        
        





    ?>
    
</body>
</html>