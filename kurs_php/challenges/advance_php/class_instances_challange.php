<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    





    <?php

        /*
            Napisz dwie klasy:
            1. Klasę Address z adresem domu czyli: kraj, miasto, ulica itd
            2. Klasę Home opisującą dom, w której wewnątrz będzie instancja
               Address. Dodaj dodatkowe właściwości do Home jak np. ilość
               pięter itd.
            Stwórz obie instancje z dowolnymi danymi. 
        */

        class Address {
            public function __construct(
                private string $country,
                private string $city,
                private string $street,
                private string $postalCode,
            ) {

            }

            public function getData() {
                return $this->country." ".$this->city." "
                        .$this->street." ".$this->postalCode; 
            }
        }

        class Home {
            private $address;

            public function __construct(
                string $country, string $city, $street, $postalCode,
                private int $numFloors, private string $color
            ) {
                $this->address = new Address($country, $city, $street, $postalCode);
            }

            public function showData() {
                echo($this->address->getData() 
                    . " ".$this->numFloors." ".$this->color);
            }
        }

        $home = new Home("Poland", "Nowy Sącz", "Reja 3", "33-300", 2, "white");
        $home->showData();




        
        





    ?>
</body>
</html>