<?php
function getMonthName($number)
{
    return date("F", strtotime(date("d-$number-Y")));
}

?>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Annual Expenses</title>
</head>
<body>
<form method="post">
    <label for="costs">Enter number of years:</label>
    <input type="text" name="costs" id="costs"/>
    <input type="submit" value="Show costs"/>
</form>
<br/>
<?php
if (isset($_POST["costs"]) && !empty($_POST["costs"])):
    $years = $_POST["costs"];
    $currentYear = date("Y");
    ?>
    <table border="1">
        <thead>
        <tr>
            <th>Year</th>
            <?php
            for ($month = 1; $month <= 12; $month++) {
                echo "<th>" . getMonthName($month) . "</th>";
            }
            ?>
            <th>Total:</th>
        </tr>
        </thead>
        <tbody>
        <?php
        for ($year = $currentYear; $year > $currentYear - $years; $year--) {
            echo "<tr><td>$year</td>";
            $total = 0;
            for ($month = 1; $month <= 12; $month++) {
                $currentCost = rand(0, 999);
                echo "<td>" . $currentCost . "</td>";
                $total += $currentCost;
            }
            echo "<td>$total</td></tr>";
        }
        ?>
        </tbody>
    </table>
<?php endif; ?>
</body>
</html>