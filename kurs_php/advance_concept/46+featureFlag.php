<?php
    /*
    Wzorzec Feature Flag umożliwia dynamiczne włączanie lub wyłączanie określonych 
    funkcji w aplikacji.
    Jest to szczególnie przydatne w zarządzaniu wersjami i testowaniu nowych funkcji.

    Zalety:
    - Dynamiczne włączanie/wyłączanie funkcji aplikacji.
    - Łatwe testowanie nowych funkcji.
    - Możliwość stopniowego wdrażania zmian.

    Wady:
    - Zwiększona złożoność zarządzania flagami.
    - Potencjalna konieczność częstego dostępu do bazy danych.
    - Ryzyko błędów przy nieprawidłowym zarządzaniu flagami.
    */


    class FeatureFlagManager {
        private $dbConnection;

        public function __construct($dbConnection) {
            $this->dbConnection = $dbConnection;
        }

        private function queryFlags() {
            $query = "SELECT feature_name, is_enabled FROM feature_test";
            $result = mysqli_query($this->dbConnection, $query);
            $flags = [];

            while ($row = mysqli_fetch_assoc($result)) {
                $flags[$row["feature_name"]] = $row["is_enabled"] == "1";
            }

            return $flags;
        }

        public function isFeatureEnabled($featureName) {
            $flags = $this->queryFlags();
            return $flags[$featureName] ?? false;
        }

        public function addFeatureFlag($featureName, $isEnabled) {
            if (array_key_exists($featureName, $this->queryFlags())) {
                return;
            }
            
            $isEnabledInt = $isEnabled ? 1 : 0;

            $query = "INSERT INTO feature_test (feature_name, is_enabled)
                        VALUES('$featureName', $isEnabledInt) ";
            mysqli_query($this->dbConnection, $query);
        }

        public function updateFeatureFlag($featureName, $isEnabled) {
            $isEnabledInt = $isEnabled ? 1 : 0;
            $query = "UPDATE feature_test SET is_enabled = $isEnabledInt
                      WHERE feature_name = '$featureName' ";
            mysqli_query($this->dbConnection, $query);
        }

        public function getAllFeatureFlags() {
            return $this->queryFlags();
        }
    }

    $dbConnection = mysqli_connect("localhost", "root", "", "tutorial");
    $createTableQuery = "CREATE TABLE IF NOT EXISTS feature_test (
        id INT AUTO_INCREMENT PRIMARY Key,
        feature_name VARCHAR(100) NOT NULL,
        is_enabled TINYINT(1) NOT NULL
    )";

    mysqli_query($dbConnection, $createTableQuery);

    $featureFlagManager = new FeatureFlagManager($dbConnection);
    $featureFlagManager->addFeatureFlag("new_feature", true);
    $featureFlagManager->updateFeatureFlag("new_feature", false);

    if ($featureFlagManager->isFeatureEnabled("new_feature")) {
        echo "new_feature włączony <br>";
    } else {
        echo "new_feature wyłączony <br>";
    }

    $allFlags = $featureFlagManager->getAllFeatureFlags();
    print_r($allFlags);

    mysqli_close($dbConnection);

?>
