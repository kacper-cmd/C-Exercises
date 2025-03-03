<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <section>
        <ul class="filter-menu">
            <li class="filter-option <?php echo !isset($_GET["filter"]) ? "active" : ""  ?>">
                <a href="?">Wszystkie</a>
            </li>
            <li class="filter-option <?php echo isset($_GET["filter"]) 
                && $_GET["filter"] == "city" ? "active" : ""  ?>">
                <a href="?filter=city">Miasta</a>
            </li>
            <li class="filter-option <?php echo isset($_GET["filter"]) 
                && $_GET["filter"] == "car" ? "active" : ""  ?>">
                <a href="?filter=car">Samochody</a>
            </li>
            <li class="filter-option <?php echo isset($_GET["filter"]) 
                && $_GET["filter"] == "nature" ? "active" : ""  ?>">
                <a href="?filter=nature">Natura</a>
            </li>
            <li class="filter-option <?php echo isset($_GET["filter"]) 
                && $_GET["filter"] == "electronics" ? "active" : ""  ?>">
                <a href="?filter=electronics">Elektronika</a>
            </li>
        </ul>
        <div class="gallery">
            <?php
                $categories = ["city", "car", "nature", "electronics"];
                $totalImages = 12;
                $currentFilter = isset($_GET["filter"]) ? $_GET["filter"]: "all";

                for ($i = 0; $i < $totalImages; $i++) {
                    $category = $categories[$i % count($categories)];//otrzymam 0-3  (0%4 =0 | 1%4=1 |2%4 = 2| 3%4 = 3 | 4%4 =0 )

                    if ($currentFilter === "all" || $currentFilter === $category) {
                        echo "<div class='gallery-item' 
                            style='background-image: url(https://source.unsplash.com/200x200/?" 
                            .$category . "&" .rand(). ");'>z
                            </div>";
                    }
                }
            ?>
        </div>
    </section>
</body>
</html>