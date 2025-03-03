<?php  

    // W PHP możemy wyłuskać konkretne dane z tekstu
    // np datę i czas za pomocą tzw. named capture groups
 
    // \d{4} oznacza sekwencję czterech cyfr (od 0 do 9), 
    // używane tutaj do przechwycenia roku.
    // \d{2} oznacza sekwencję dwóch cyfr, używane tutaj 
    // do przechwycenia miesiąca i dnia.
    // (?<year>), (?<month>) i (?<day>) są tzw. 
    // "named capture groups". Dzięki nim możemy przypisać 
    // nazwy (year, month, day) do przechwyconych fragmentów
    // wyrażenia regularnego, co ułatwia ich późniejsze 
    // identyfikowanie i używanie.
    $rg = "/(?<year>\d{4})-(?<month>\d{2})-(?<day>\d{2})/";
    preg_match($rg, "Test 2031-05-29 example", $matches);
    print_r($matches);
    echo ("<br>");
    echo ("Year:" . $matches["year"]); // 2031
    


?>

