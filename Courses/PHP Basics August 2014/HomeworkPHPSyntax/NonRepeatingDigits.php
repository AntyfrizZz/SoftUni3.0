<?php
$input = 247;

if ($input < 100) {
    echo 'no';
} else {
    for ($i = 100; $i <= $input; $i++) {
        if ($i < 1000) {
            $firstDigit = $i % 10;
            $secondDigit = floor($i % 100 / 10);
            $thirdDigit = floor($i % 1000 / 100);
            if ($firstDigit != $secondDigit && $firstDigit != $thirdDigit && $secondDigit != $thirdDigit) {
                echo $i . ', ';
            }
        }
    }
}
?>