<?php  

    function getIndexes($matches) {
        if ($matches == null) return null;

        $indexes = array_map(function ($match) {
            return $match[1];
        }, $matches[0]);

        return $indexes;
    }

    
    // W wyrażeniach regularnych znak + to kwantyfikator, 
    // który oznacza "jedno lub więcej wystąpień" 
    // poprzedzającego elementu. Innymi słowy, dopasowuje 
    // co najmniej jedno wystąpienie danego wzorca. 
    // ['3', '20'] 
    preg_match_all("/\d+/", "I have 3 cats and 20 dogs.", $matches, PREG_OFFSET_CAPTURE);
    echo "<hr> Digits indexes: " . print_r( $matches, true );


    // W wyrażeniach regularnych metaznak \w oznacza 
    // "dopasuj dowolny znak alfanumeryczny lub podkreślenie. 
    // Konkretnie:
    // Dopasowuje dowolną literę (małą lub dużą) od a do z.
    // Dopasowuje dowolną cyfrę od 0 do 9.
    // Dopasowuje znak podkreślenia _.
    // \w+ dopasuje całe słowo (ciąg liter, cyfr i/lub
    // podkreśleń) w tekście.
    preg_match_all("/\w/", "Hello, world!", $matches);
    echo "<hr> Digits indexes: " . print_r( $matches, true );


    preg_match_all("/\w+/", "Hello, world!", $matches);//osobno cale slowa 
    echo "<hr> Digits indexes: " . print_r( $matches, true );


    preg_match_all("/H\w+/", "Hello, world! How1 are you?", $matches);
    echo "<hr> H indexes: " . print_r( $matches, true );










?>

