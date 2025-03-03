<?php
// Przykład sortowania tablicy z użyciem funkcji
// anonimowej jako funkcji zwrotnej
$numbers = [3, 2, 5, 6, 1];

// Używamy funkcji anonimowej jako funkcji 
// porównującej dla sortowania tablicy
usort($numbers, function($a, $b) {
    // Porównujemy dwie wartości
    return $a <=> $b; // asc  // $b <=> $a; desc 
});

// Wyświetlanie posortowanej tablicy
echo "<h1>Posortowana tablica</h1>";
echo "<p>" . implode(', ', $numbers) . "</p>";

// Użycie funkcji anonimowej w połączeniu z HTML i JavaScript
?>
<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="UTF-8">
    <title>Funkcje Anonimowe i Callback w PHP</title>
</head>
<body>
    <h2>Kliknij przycisk, aby zobaczyć wiadomość</h2>
    <button onclick="showMessage()">Pokaż Wiadomość</button>
    <script>
        // Definicja funkcji showMessage używająca PHP 
        // do wstrzyknięcia treści
        function showMessage() {
            alert("<?php 
                // Używamy funkcji anonimowej przypisanej 
                // do zmiennej, aby wygenerować treść komunikatu
                $getMessage = function() {
                    return "Witaj, to komunikat z PHP!";
                };
                echo $getMessage();
            ?>");
        }
    </script>
</body>
</html>
