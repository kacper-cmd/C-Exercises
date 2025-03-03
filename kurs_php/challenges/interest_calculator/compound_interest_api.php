<?php
    // compound_interest_api.php

    header("Content-Type: application-json");

    function calculateCompoundInterest($principal, $rate, $time) {
        $results = [];

        for ($year = 1; $year <= $time; $year++) {
            $amount = $principal * pow((1 + $rate / 100), $year);
            $results[] = array("year" => $year, "amount" => round($amount, 2));
        }

        return $results;
    }

    $principal = $_GET["principal"] ?? 0;
    $rate = $_GET["rate"] ?? 0;
    $time = $_GET["time"] ?? 0;

    echo json_encode(calculateCompoundInterest($principal, $rate, $time));

?>