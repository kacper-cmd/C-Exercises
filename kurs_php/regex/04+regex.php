<?php 

    function getIndexes($matches) {
        $indexes = array_map(function($matches) {
            return $matches[1];
        }, $matches[0]);

        return $indexes;
    } 
    
    // W wyrażeniach regularnych nawiasy kwadratowe [] służą
    // do definiowania dopasowań znaków. Pozwalają na 
    // dopasowanie jednego z wielu możliwych znaków 
    // określonych wewnątrz nawiasów. 
    preg_match_all("/[abc]/", "Apple, banana, cherry", $matches, PREG_OFFSET_CAPTURE);
    echo "<hr> digits indexes: " . print_r( getIndexes($matches), true );

    // Dopasowanie małych liter od a do z 
    preg_match_all("/[a-z]/", "Apple, banana, cherry", $matches, PREG_OFFSET_CAPTURE);
    echo "<hr> a to z indexes: " . print_r( getIndexes($matches), true );

    // Dopasowanie małych liter od A do Z
    preg_match_all("/[A-Z]/", "Apple, banana, cherry", $matches, PREG_OFFSET_CAPTURE);
    echo "<hr> A to Z indexes: " . print_r( getIndexes($matches), true );

    // Dopasowanie małych liter od A do Z
    preg_match_all("/[a-zA-Z]/", "Apple, banana, cherry", $matches, PREG_OFFSET_CAPTURE);
    echo "<hr> a -z i A to Z indexes: " . print_r( getIndexes($matches), true );

    // Dopasowanie małych liter od A do Z
    preg_match_all("/[a-zA-Z0-9]/", "Apple 12 , 3 banana 4, cherry 5", $matches, PREG_OFFSET_CAPTURE);
    echo "<hr> a -z i A to Z indexes: " . print_r( getIndexes($matches), true );

    // Dopasowanie znaków specjalnych
    // Aby dopasować znaki specjalne
    // musimy je poprzedzić znakiem ukośnika `\`.  
    preg_match_all("/[\[\]{}]/", "apple [banana] {cherry} date", $matches, PREG_OFFSET_CAPTURE);
    echo "<hr> special signs indexes: " . print_r( getIndexes($matches), true );

    // W wyrażeniach regularnych metaznak \s reprezentuje 
    // białe znaki. Obejmuje to np:
	// Spacje ( )
	// Tabulacje (\t)
	// Znaki nowej linii (\n) itd  
    preg_match_all("/\s/", "Console laptop \n \t computer", $matches, PREG_OFFSET_CAPTURE);
    echo "<hr>  indexes: " . print_r( getIndexes($matches), true );













     
?>

