<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Sum of Digits</title>
</head>
<body>
<form method="post">
    <label for="numbers">Input string:</label>
    <input type="text" name="numbers" id="numbers"/>
    <input type="submit"/>
</form>
<?php
if (isset($_POST["numbers"]) && !empty($_POST["numbers"])) {
    $numbers = preg_split('/[ ,]/', $_POST["numbers"], 0, PREG_SPLIT_NO_EMPTY);
    echo "<table border=\"1\">";
    foreach ($numbers as $number) {
        echo "<tr><td>$number</td><td>";
        if (ctype_digit($number)) {
            echo array_sum(str_split($number));
        } else {
            echo "I cannot sum that";
        }
        echo "</td></tr>";
    }

    echo "</table>";
}
?>
</body>
</html>