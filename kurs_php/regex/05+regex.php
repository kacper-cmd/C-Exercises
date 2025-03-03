<?php 

    function getIndexes($matches) {
        if ($matches == null) return null;

        $indexes = array_map(function ($match) {
            return $match[1];
        }, $matches[0]);

        return $indexes;
    }
     

    // W wyrażeniach regularnych nawiasy klamrowe {} służą 
    // jako kwantyfikatory określające dokładną liczbę 
    // wystąpień poprzedzającego elementu. 
	// Przykłady:
	// Dokładna liczba: {n} dopasowuje dokładnie n wystąpień
    // poprzedzającego elementu.
	// Przykład: a{3} dopasuje ciąg "aaa" ale nie "aa" 
    // ani "aaaa".
	// Zakres: {n,m} dopasowuje od n do m wystąpień 
    // poprzedzającego elementu.
	// Przykład: a{2,4} dopasuje "aa", "aaa" lub "aaaa".
    
    //Dopasowanie dokładnie czterech liter 'a'  
    preg_match_all("/a{4}/", "aaaaa bb aa cc aaaa", $matches, PREG_OFFSET_CAPTURE);
    echo "<hr>   indexes: " . print_r( getIndexes($matches), true ); 

    //Dopasowanie dokładnie czterech liter 'a'  \b -zeby bylo samodzielne slowo  tylko ostatnie aaaa
    preg_match_all("/\ba{4}\b/", "aaaaa bb aa cc aaaa", $matches, PREG_OFFSET_CAPTURE);
    echo "<hr>   indexes: " . print_r( getIndexes($matches), true );  
    
    // Dopasowanie słowa składającego się z 3 do 5 liter a, i samodzielne slowo 
    preg_match_all("/\ba{3,5}\b/", "aaaaa bb aa cc aaaa aaa", $matches, PREG_OFFSET_CAPTURE);
    echo "<hr>   indexes: " . print_r( getIndexes($matches), true );  
 
     
?>

