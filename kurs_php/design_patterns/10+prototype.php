<?php

//jak tworzenie nowej instacji klasy jest kosztowne lub skomplikowane to prototype upraszcza kopiowanie obiektów
// Wzorzec projektowy Prototype umożliwia kopiowanie 
// istniejących obiektów bez potrzeby zwracania uwagi 
// na ich konkretną implementację i bez korzystania 
// z konstruktorów. Wzorzec ten jest szczególnie przydatny,
// gdy tworzenie instancji klasy jest kosztowne lub 
// skomplikowane.

// Zalety i Wady Wzorca Prototype
// Zalety:
// Efektywność: Tworzenie obiektów przez klonowanie 
//              jest często bardziej wydajne niż przez 
//              instancjonowanie klasy, zwłaszcza gdy 
//              tworzenie nowej instancji jest kosztowne.
// Unikanie skomplikowanego tworzenia: Wzorzec pozwala uniknąć
//               skomplikowanego kodu tworzenia obiektów, 
//               zwłaszcza gdy obiekt ma wiele konfiguracji.
// Dodanie i usuwanie obiektów w runtime: Umożliwia 
//               dynamiczne dodawanie lub usuwanie 
//               prototypów w trakcie działania programu.

// Wady:
// Skomplikowane klonowanie: Klonowanie obiektów może być 
//            skomplikowane, jeśli mają one skomplikowane 
//            relacje z innymi obiektami.
// Płytkie vs głębokie klonowanie: Należy zachować ostrożność
//            w przypadku płytkiego klonowania, szczególnie 
//            gdy obiekty odnoszą się do innych zasobów, 
//            które nie powinny być współdzielone.
// Zachowanie stanu: Może być trudne do zarządzania, jeśli 
//            klonowane obiekty muszą zachować stan, który 
//            był ważny tylko dla oryginalnego obiektu.

interface Prototype {
    public function clone();
}

class Graphic implements Prototype {
    private $type;

    public function __construct($type) {
        $this->type = $type;
    }

    public function clone() {
        return new Graphic($this->type);
    }

    public function getType() {
        return $this->type;
    }

    public function setType($type) {
        $this->type = $type;
    }
}

$originalGraphic = new Graphic("Circle");

$clonedGraphic1 = $originalGraphic->clone();
$clonedGraphic1->setType("Square");

$clonedGraphic2 = $originalGraphic->clone();
$clonedGraphic2->setType("Triangle");

echo $originalGraphic->getType() . "<br>";
echo $clonedGraphic1->getType() . "<br>";
echo $clonedGraphic2->getType() . "<br>";

?>