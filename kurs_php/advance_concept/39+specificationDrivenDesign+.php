<?php
    /*
    Specification Driven Design to podejście projektowe w inżynierii oprogramowania, 
    które kładzie nacisk na tworzenie precyzyjnych, formalnych specyikacji systemu, 
    które są następnie wykorzystywane do przewodzenia procesowi projektowania 
    i implementacji oprogramowania. Głównym celem tego podejścia jest zapewnienie, 
    że finalny produkt oprogramowania ścisłe odpowiada zdefiniowanym wymaganiom i specyikacjom.

    Zalety:
    - Ułatwia definiowanie złożonych reguł biznesowych.
    - Poprawia czytelność i utrzymanie kodu przez oddzielenie logiki biznesowej.
    - Umożliwia ponowne wykorzystanie specyfikacji w różnych częściach aplikacji.

    Wady:
    - Może zwiększyć złożoność kodu, szczególnie dla prostych warunków.
    - Wymaga dodatkowego nakładu pracy przy definiowaniu specyfikacji.
    - Może być trudny w optymalizacji dla bardzo złożonych reguł.

    Przykład implementacji wzorca Identity Specification w PHP.
    */

    interface Specification {
        public function isSatisfiedBy($candidate); 
    }

    class IsAdultSpecification implements Specification {
        public function isSatisfiedBy($candidate) {
            return $candidate->getAge() >= 18;
        }
    }

    class HasValidEmailSpecification implements Specification {
        public function isSatisfiedBy($candidate) {
            return filter_var($candidate->getEmail(), FILTER_VALIDATE_EMAIL) !== false;
        }
    }

    class User {
        private $age;
        private $email;

        public function __construct($age, $email) {
            $this->age = $age;
            $this->email = $email;
        }

        public function getAge() {
            return $this->age;
        }

        public function getEmail() {
            return $this->email;
        }
    }

    $user = new User(20, "asia@example.com");
    $isAdultSpec = new IsAdultSpecification();
    $hasValidEmailSpec = new HasValidEmailSpecification();

    if ($isAdultSpec->isSatisfiedBy($user) && $hasValidEmailSpec->isSatisfiedBy($user)) {
        echo "User spełnia specyfikacje <br>";
    } else {
        echo "User nie spełnia specyfikacji <br>";
    }






?>
