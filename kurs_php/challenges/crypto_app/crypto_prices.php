<?php
    // crypto_prices.php

    function getCryptoPrices() {
        $ids = "bitcoin,ethereum,litecoin";
        $url = "https://api.coingecko.com/api/v3/simple/price?ids=$ids&vs_currencies=usd";

        $response = file_get_contents($url);
        $prices = json_decode($response, true);

        $result = [];

        foreach ($prices as $crypto => $data) {//tablica assocjacyjna key cryptio | data -
            $result[] = [
                "symbol" => strtoupper($crypto),
                "price" => number_format($data["usd"], 2)
            ];
        }

        return $result;
    }

    header("Content-Type: application/json");
    echo json_encode(getCryptoPrices());

?>