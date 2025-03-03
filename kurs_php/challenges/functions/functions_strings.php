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
        
        $str = "Ola ma kota";
        $strUp = strtoupper($str);
        echo($strUp."<br>");

        echo( strtolower($str)."<br>" );

        echo( str_repeat($str, 3)."<br>" );

        $str2 = "Ola ma psa oraz Ola ma kota";
        echo( str_replace("Ola", "Kasia", $str2) . "<br>" );

        echo( str_contains($str2, "kota") . "<br>" );

        echo( str_starts_with($str2, "Ola") . "<br>" );
        echo( str_ends_with($str2, "kota") . "<br>" );

        $pos = strpos($str2, "oraz");//position of 'oraz' 
        if ($pos !== false) {
            echo("Słowo oraz znajduje się pod indeksem: $pos");
        }

        $pos = strrpos($str2, "Ola");//od konca szukam of prawej 
        if ($pos !== false) {
            echo("Słowo Ola jako ostatnie wystąpienie znajduje się pod indeksem: $pos <br>");
            $txt = substr($str2, $pos, strlen($str2) - $pos);
            echo("fragment txt: $txt <br>");
        }

        echo( str_shuffle($str2) . "<br>" );

        $arr = explode(" ", $str2); //split 
        //var_dump($arr);

        $strFromArr = implode(" . ", $arr);
        echo($strFromArr."<br>");














    ?>
    
</body>
</html>