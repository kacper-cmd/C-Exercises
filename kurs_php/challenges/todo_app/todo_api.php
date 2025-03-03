<?php

    $db = new PDO("mysql:host=localhost;dbname=tutorial;charset=utf8mb4", "root", "");

    $db->exec("CREATE TABLE IF NOT EXISTS todo_items (
        id INT AUTO_INCREMENT PRIMARY KEY,
        description VARCHAR(255) NOT NULL,
        due_date DATE NOT NULL,
        completed BOOLEAN NOT NULL DEFAULT FALSE
    )");

    $method = $_SERVER["REQUEST_METHOD"]; // POST, GET

    if ($method == "GET") {
        $statement = $db->query("SELECT * FROM todo_items");
        $todos = $statement->fetchALL(PDO::FETCH_ASSOC);
        echo json_encode($todos);
    } 
    elseif ($method == "POST") {
        $input = json_decode(file_get_contents("php://input"), true);
        $statement = $db->prepare("INSERT INTO todo_items (description, due_date)
            VALUES (:description, :due_date) ");
        $statement->execute([
            "description" => $input["description"],
            "due_date" => $input["due_date"]
        ]);
    }
    elseif ($method == "DELETE") {
        $id = $_GET["id"];
        $statement = $db->prepare("DELETE FROM todo_items WHERE id = :id");
        $statement->execute(["id" => $id]);
    }

    header("Content-Type: application/json");


?>