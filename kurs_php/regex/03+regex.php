<?php 
 
    // Zwrócenie samych indeksów występowania w bardziej czytelnej formie
    function getIndexes($matches) {
      if ($matches == null) return null;

      $indexes = array_map(function ($match) {
          return $match[1];
      }, $matches[0]);

      return $indexes;
    }

    // Dopasowanie dowolnego pojedynczego znaku przy użyciu kropki (.)
    preg_match_all("/./", "Example: a.b.c.", $matches);
    echo "/./ results: ";
    print_r($matches[0]);  
    echo("<hr>");

    // Dopasowanie wzorca a.c, gdzie . oznacza dowolny znak
    preg_match_all("/a.c/", "Example: a.b.c. abc test abcde adc", $matches, PREG_OFFSET_CAPTURE);
    echo "<hr> abc indexes: " . print_r( getIndexes($matches), true );

    // Wyszukanie całych słów z a.c
    preg_match_all("/\ba.c\b/", "Example: a.b.c. abc test abcde adc", $matches, PREG_OFFSET_CAPTURE);
    echo "<hr> a.c indexes: " . print_r( getIndexes($matches), true );

    // Dopasowanie wzorca z wieloma nieznanymi znakami
    preg_match_all("/\bt..t\b/", "Example: a.b.c. abc test tester test", $matches, PREG_OFFSET_CAPTURE);
    echo "<hr> test indexes: " . print_r( getIndexes($matches), true );

    // Dopasowanie wzorca ca*t, gdzie * oznacza zero lub więcej wystąpień "a"
    preg_match_all("/ca*t/", "tat ct, cat, caat, caaat", $matches, PREG_OFFSET_CAPTURE);
    echo "<hr> cat indexes: " . print_r( getIndexes($matches), true );

    // Dopasowanie wzorca ^Hello na początku tekstu
    preg_match_all("/^Hello/", "Hello world! Hello again.", $matches, PREG_OFFSET_CAPTURE);
    echo "<hr> Hello indexes: " . print_r( getIndexes($matches), true );

    // Negacja: Dopasowanie każdego znaku oprócz małej litery "b"
    preg_match_all("/[^an]/", "Banana", $matches);
    echo "<hr> Hello indexes: " . print_r(  $matches , true );

    // Dopasowanie wzorca world na końcu tekstu
    preg_match_all("/world$/", "Hello world! How is the world", $matches, PREG_OFFSET_CAPTURE);
    echo "<hr> world indexes: " . print_r( getIndexes($matches), true );


?>