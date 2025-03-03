<?php
    function fetchFromApi($endpoint) {
        $url = "https://themealdb.com/api/json/v1/1/$endpoint";
        $response = file_get_contents($url);
        return json_decode($response, true);//true tablica assoc
    }
    if (isset($_GET["action"])) {
        header("Content-Type: application/json");//wysylalm header do js

        // http://localhost/kurs_php/projects/php_recipes/recipes.php?action=search&keyword=banana
        if ($_GET["action"] == "search" && isset($_GET["keyword"])) {
            $keyword = $_GET["keyword"];
            echo json_encode(fetchFromApi("filter.php?i=$keyword"));
            exit;//koncze bez ponizszego kodu html przewywam 
        }

        // http://localhost/kurs_php/projects/php_recipes/recipes.php?action=getRecipe&id=52855
        if ($_GET["action"] == "getRecipe" && isset($_GET["id"])) {
            $id = $_GET["id"];
            echo json_encode(fetchFromApi("lookup.php?i=$id"));
            exit;
        }
    }
    //jak isset nie ustawione to zwroci poniższy kod html 

    
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link rel="stylesheet" href="style.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css" integrity="sha512-DTOQO9RWCH3ppGqcWaEA1BIZOC6xxalwEsw9c2QQeAIftl+Vegovlnee1c9QX4TctnWMn13TZye+giMm8e2LwA==" crossorigin="anonymous" referrerpolicy="no-referrer" />
</head>
<body>
    <div class="app-container">
        <div class="app-header">
            <div class="header-container">
                <h1>Wyszukiwarka przepisów</h1>
            </div>
        </div>

        <section class="search-section">
            <input type="text" id="ingredient-input" placeholder="Wpisz słowo kluczowe po angielsku">
            <button id="search-button">
                <i class="fas fa-search"></i>
            </button>
        </section>

        <section class="results-section" id="results"></section>

        <div class="modal" id="meal-modal">
            <div class="modal-content" id="modal-content"></div>
            <span class="close-button" id="close-modal">&times;</span>
        </div>

    </div>

    <script src="script.js"></script>
</body>
</html>