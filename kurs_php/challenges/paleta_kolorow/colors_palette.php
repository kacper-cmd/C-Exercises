<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Paleta kolorów</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <div class="palette-wrapper">
        <h3 class="main-title">Generator losowych kolorów</h3>
        <div class="grid-palette">
            <?php
                for ($i = 0; $i < 12; $i++) {
                    // red 0xFF0000
                    // green 0x00FF00
                    // blue 0x0000FF
                    $randValueHexStr = dechex(mt_rand(0, 0xFFFFFF)); // liczba szesnastkowa jako string, 0xFFFFFF -max kolor 
                    $hexColor = "#" . str_pad($randValueHexStr, 6, "0", STR_PAD_LEFT);//dopelnic 6 znakami zero jesli brakuje  z lewej stribt

                    echo "<div class='color-card'>";
                    echo "   <div class='color-display' style='background-color: {$hexColor};'> </div>";
                    echo "   <p class='color-code'>{$randValueHexStr}</p>";
                    echo "</div>";
                }
            ?>
        </div>

        <div class="controls">
            <button id="btnGenerate" onClick="window.location.reload();">Nowa paleta kolorów</button>
        </div>
    </div>
    
</body>
</html>