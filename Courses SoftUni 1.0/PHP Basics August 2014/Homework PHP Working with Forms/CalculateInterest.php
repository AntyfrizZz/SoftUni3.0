<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8"/>
    <title>Calculate Interest</title>
</head>
<body>
    <form method="post">
        <label for="amount">Enter Amount</label>
        <input type="text" name="amount" id="amount"/>
        <br/>

        <input type="radio" name="currency" value="USD" id="usd"/>
        <label for="usd">USD</label>
        <input type="radio" name="currency" value="EUR" id="eur"/>
        <label for="eur">EUR</label>
        <input type="radio" name="currency" value="BGN" id="bgn"/>
        <label for="bgn">BGN</label>
        <br/>

        <label for="interest">Compount Interest Amount</label>
        <input name="interest" id="interest"/>
        <br/>

        <select name="period-months">
            <option value="6">6 Months</option>
            <option value="12">1 Year</option>
            <option value="24">2 Years</option>
            <option value="60">5 Years</option>
        </select>

        <input type="submit" name="submit" value="Calculate">

        <?php
        if ($_POST && isset($_POST["submit"])) {
            if (isset($_POST["amount"]) && isset($_POST["currency"]) && isset($_POST["interest"]) && isset($_POST["period-months"])) {
                $amount = $_POST["amount"];
                $currency = $_POST["currency"];
                $interest = $_POST["interest"];
                $periodInMonths = $_POST["period-months"];

                if (is_numeric($amount) && is_numeric($interest)) {
                    $numberOfYears = $periodInMonths / 12;
                    $valueAtEndOfPeriod = $amount * pow(1 + ($interest / 100) / 12, 12 * $numberOfYears);

                    echo formatCurrency($valueAtEndOfPeriod, $currency);
                } else {
                    echo "The data you entered is invalid.";
                }
            } else {
                echo "You have not filled in all required fields.";
            }
        }

        function formatCurrency($amount, $currency)
        {
            $roundedAmount = round($amount, 2);
            switch ($currency) {
                case "USD":
                    return "$" . $roundedAmount;
                case "EUR":
                    return "€" . $roundedAmount;
                case "BGN":
                    return $roundedAmount . " лв.";
                default:
                    return $roundedAmount;
            }
        }
        ?>
    </form>
</body>
</html>