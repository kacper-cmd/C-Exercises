<?php
    /*
        Wyrażenia regularne w PHP to potężne 
        narzędzie do przeszukiwania i manipulowania
        tekstem. Używane są dla określenia wzorców 
        w tekście, co pozwala na efektywne dopasowywanie, 
        wyszukiwanie i zastępowanie różnych fragmentów 
        tekstu. Wyrażenia regularne w PHP wykorzystują 
        składnię Perl Compatible Regular Expressions (PCRE).
        Oto kilka kluczowych cech wyrażeń regularnych 
        w PHP:
        - Dopasowania: Możemy określić wzorzec, który 
          ma zostać dopasowany w tekście, np. \d dla cyfr.
        - Elementy składowe: Używamy kwantyfikatorów, 
          grup, zakresów i metaznaków do tworzenia wzorców.
        - Flagi: Modyfikują one zachowanie wyrażeń 
          regularnych, np. flaga i sprawia, że dopasowanie 
          jest niewrażliwe na wielkość liter.
        Wyrażenia regularne są skutecznym narzędziem, 
        ale wymagają praktyki i zrozumienia ich złożoności.
    */



    $simpleRegex = "/a/";//a w jakis tekscie, pierwsze wystopienie
    echo "a w apple: " . preg_match($simpleRegex, "apple") . "<br>";
    echo "i w apple: " . preg_match("/i/", "apple") . "<br>";//szukam litery i 

    preg_match_all("/ap/", "apple application apple", $matches);//wiele wystapień
    echo "ap: ";
    print_r($matches);

    preg_match_all("/ap/", "apple application apple", $matches2, PREG_OFFSET_CAPTURE);//info o indeksie wystapienie
    echo "<hr>ap: ";
    print_r($matches2);

    function getIndexes($matches) {
        if ($matches == null) return null;

        $indexes = array_map(function ($match) {
            return $match[1];
        }, $matches[0]);

        return $indexes;
    }

    $indexes = getIndexes($matches2);
    echo "<hr> Wystąpienia w matches2: " . print_r($indexes, true);

    // Flagi w PHP, np. "i" dla ignorowania wielkości liter ignore case, szukana litera t 
    preg_match_all("/t/i", "Temperature in Tokyo is Too high today", $matches3, PREG_OFFSET_CAPTURE);
    echo "<hr>   indexes: " . print_r( getIndexes($matches3), true ); 


    // Użycie \b dla granic słowa, dopasowuje pełne słowa "city"
    preg_match_all("/\bcity\b/i", "I love the city, in the CITY center. 
        The electricity bill is high.", $cities, PREG_OFFSET_CAPTURE);
    echo "<hr>   indexes: " . print_r( getIndexes($cities), true ); 


    // Operator alternatywy | dla dopasowania słów "mountain" lub "sea" (pipe - |)
    preg_match_all("/\b(mountain|sea)\b/i", "The mountain view is breathtaking. 
        I also love the serenity of the sea. Sea is nice.", $res, PREG_OFFSET_CAPTURE);
    echo "<hr> mountain|sea indexes: " . print_r( getIndexes($res), true ); 


    // \d+ dla dopasowania jednej lub więcej cyfr
    preg_match_all("/\d+/", "I have 3 cats and 20 dogs.", $matches, PREG_OFFSET_CAPTURE);
    echo "<hr> digits indexes: " . print_r( getIndexes($matches), true );

?>