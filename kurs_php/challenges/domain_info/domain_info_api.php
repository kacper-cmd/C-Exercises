<?php
    function fetchDomainInfo($domain) {
        $curl = curl_init($domain);

        curl_setopt($curl, CURLOPT_RETURNTRANSFER, true); // wynik jako string

        $html = curl_exec($curl);

        curl_close($curl);

        $info = [];

        if ($html) {
            $doc = new DOMDocument();
            @$doc->loadHTML($html); // @ tłumi błędy warningi

            $titles = $doc->getElementsByTagName("title");
            if ($titles->length > 0) {
                $info["title"] = $titles->item(0)->nodeValue;
            }

            $metas = $doc->getElementsByTagName("meta");
            foreach ($metas as $meta) {
                $name = $meta->getAttribute("name");
                $content = $meta->getAttribute("content");
                if ($name) {
                    $info["meta"]["name"] = $content;
                }
            }
        }

        return $info;
    }

    $domain = $_GET["domain"] ?? "";

    $info = fetchDomainInfo($domain);

    header("Content-Type: application/json");

    echo json_encode($info);
?>