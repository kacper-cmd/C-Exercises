<?php
    /*
    Wzorzec projektowy Repository  służy do oddzielenia warstwy logiki od warstwy 
    dostępu do danych lub persystencji.
    
    Zalety:
    - Centralizacja logiki dostępu do danych, ułatwiająca zarządzanie i testowanie.
    - Separacja logiki biznesowej od logiki dostępu do danych.
    - Elastyczność w zmianie mechanizmów przechowywania danych.

    Wady:
    - Może prowadzić do zbyt dużej abstrakcji i skomplikowania systemu.
    - Może być nadmierny w prostych aplikacjach.
    - Może ukrywać szczegóły implementacji, utrudniając optymalizację wydajności.
    */

    interface Repository {
        public function find($id);
        public function findAll();
        public function findBy($criteria);
        public function save($entity);
        public function delete($entity);
        public function update($entity);
    }

    abstract class BaseEntity {
        protected $id;

        public function getId() {
            return $this->id;
        }

        abstract public function setData($data);
        abstract public function getData();
    }

    class User extends BaseEntity {
        private $data;

        public function setData($data) {
            $this->data = $data;
        }

        public function getData() {
            return $this->data;
        }
    }

    class Product extends BaseEntity {
        private $data;

        public function setData($data) {
            $this->data = $data;
        }

        public function getData() {
            return $this->data;
        }
    }

    class DatabaseRepository implements Repository {
        private $entities = [];

        public function __construct() {
            $this->entities["user"] = new User();
            $this->entities["product"] = new Product();
        }

        public function find($id) {
            echo "Pobieranie danych po id: $id<br>";
            return $this->entities[$id];
        }

        public function findAll() {
            echo "Pobieranie wszystkich danych <br>";
            return $this->entities;
        }

        public function findBy($criteria) {
            echo "Pobieranie danych po criteria: $criteria<br>";
            return $this->entities[$criteria];
        }

        public function save($entity) {
            echo "Zapis entity: " . $entity->getId();
        }

        public function delete($entity){
            echo "Kasowanie entity: " . $entity->getId();
        }

        public function update($entity) {
            echo "Update entity: " . $entity->getId();
        }
    }

    $repository = new DatabaseRepository();
    $user = $repository->find("user");
    $user->setData("Aktualizacja danych użytkownika");
    $repository->update($user);

    
    



?>
