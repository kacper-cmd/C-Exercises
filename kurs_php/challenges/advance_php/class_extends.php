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

        class Account {
            
            private $balance;

            public function __construct($balance) {
                $this->balance = $balance;
            }
            
            public function getBalance() {
                return $this->balance;
            }

            public function setBalance($balance) {
                $this->balance = $balance;
            }

            public function deposit($amount) {
                if ($amount > 0) $this->balance += $amount;
            }

            public function withdraw($amount) {
                if ($amount <= $this->balance) {
                    $this->balance -= $amount;
                    return $amount;
                }

                return null;
            }
        }

        class SavingAccount extends Account {
            public function __construct(
                $balance,
                private $interestRate
            ) {
                parent::__construct($balance);
            }

            public function addInterest() {
                $value = $this->interestRate * $this->getBalance();
                $this->deposit($value);
            }
        }


        $bankAccount = new SavingAccount(1000, 0.07);
        $bankAccount->addInterest();
        echo( $bankAccount->getBalance() );






        
        





    ?>
</body>
</html>