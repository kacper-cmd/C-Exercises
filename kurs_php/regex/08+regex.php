<?php
    // Dopasowanie jednego znaku alfanumerycznego przed @
    // e@ 
    preg_match("/[a-zA-Z0-9]@/", "Email is example@email.com", $matches);
    print_r($matches);
    echo "<br>";

    preg_match("/[a-zA-Z0-9]+@/", "Email is example@email.com", $matches);//wszystkie znaki + dowolna ilosc znakow
    print_r($matches);
    echo "<br>";

    preg_match("/[a-zA-Z0-9]+@[a-zA-Z0-9]+/", "Email is example@email.com", $matches); 
    print_r($matches);
    echo "<br>";

    preg_match("/[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z]+/", "Email is example@email.com.pl", $matches);
    print_r($matches);
    echo "<br>";

    preg_match("/[a-zA-Z0-9]+@[a-zA-Z0-9.]+/", "Email is example@email.com.pl", $matches);
    print_r($matches);
    echo "<br>";

    preg_match("/[a-zA-Z0-9]+@[a-zA-Z0-9.]+/", "Email is example@email...com.pl", $matches);
    print_r($matches);
    echo "<br>";

    preg_match("/[a-zA-Z0-9]+@[a-zA-Z0-9]+(?:\.[a-zA-Z0-9]+)+/", "Email is example@email.com.pl", $matches);
    print_r($matches);
    echo "<br>";
?>
