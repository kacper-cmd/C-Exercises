<?php
    /*
    Shard Pattern, znany również jako Sharding, to wzorzec projektowy stosowany 
    w bazach danych do zarządzania dużymi zestawami danych z wysoką przepustowością 
    poprzez horyzontalne partycjonowanie danych. W sharding, dane są rozdzielane na 
    mniejsze, łatwiejsze do zarządzania fragmenty, zwane "shardami", które są rozłożone 
    na różne serwery lub instancje bazy danych. Każdy shard zawiera podzbiór danych, 
    a wszystkie shardy razem tworzą pełną bazę danych.
    
    Zalety:
    - Umożliwia skalowanie horyzontalne aplikacji poprzez rozdzielenie 
      danych na wiele serwerów.
    - Może zwiększyć wydajność poprzez równomierny rozkład obciążenia.
    - Ułatwia zarządzanie dużymi zbiorami danych poprzez ich podział.

    Wady:
    - Zwiększa złożoność zarządzania danymi.
    - Może wymagać dodatkowej logiki do obsługi transakcji i spójności danych.
    - Może prowadzić do nierównomiernego rozkładu danych, jeśli klucz 
      shardowania nie jest dobrze dobrany.
 
    */

    class Shard {
        private $data;

        public function __construct() {
            $this->data = [];
        }

        public function storeData($key, $value) {
            $this->data[$key] = $value;//w db
        }

        public function getData($key) {
            return $this->data[$key] ?? null;
        }
    }

    class ShardManager {
        private $shards;

        public function __construct($numberOfShards) {
            $this->shards = [];
            for ($i = 0; $i < $numberOfShards; $i++) {
                $this->shards[$i] = new Shard();
            }
        }
//rozdzaila dużych danych na rozne servery, osobne dane na kazdym serverze, jak pobierzemy to calosc bedziemy mieli
        private function getShardKey($key) {
            return crc32($key) % count($this->shards);//od zera do ilosci shardow//rozdzaila danych miedzy shardy serwery
        }

        public function store($key, $value) {
            $shardKey = $this->getShardKey($key);
            $this->shards[$shardKey]->storeData($key, $value);//pseudo servery 
        }

        public function retrive($key) {
            $shardKey = $this->getShardKey($key);
            return $this->shards[$shardKey]->getData($key);
        }
    }

    $shardManager = new ShardManager(3);

    $shardManager->store("klucz1", "wartość1");
    $shardManager->store("klucz2", "wartość2");
    $shardManager->store("klucz3", "wartość3");
    $shardManager->store("klucz4", "wartość4");

    echo "klucz1: " . $shardManager->retrive("klucz1") . "<br>";
    echo "klucz2: " . $shardManager->retrive("klucz2") . "<br>";
    echo "klucz3: " . $shardManager->retrive("klucz3") . "<br>";
    echo "klucz4: " . $shardManager->retrive("klucz4") . "<br>";

?>
