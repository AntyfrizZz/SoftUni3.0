<?php
$month = date("F");
$year = date("Y");
$totalDays = date("t");

for($i = 1; $i <= $totalDays; $i++) {
    $date = strtotime("$i $month $year");
    if(date("l", $date) == "Sunday") {
        echo date("jS F, Y", $date) . "<br>";
    }
}
?>