<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Most Frequent Tag</title>
</head>
<body>
    <form method="post">
        <label for="tags">Enter tags:</label>
        <br/>
        <input type="text" name="tags" id="tags"/>
        <input type="submit" name="submit">
        <br/><br/>
        <?php
        if ($_POST && isset($_POST["submit"])) {
            $tags = explode(", ", $_POST["tags"]);

            $count = array_count_values($tags);
            $val = array_search(max($count), $count);

            arsort($count);

            echo "<div id=\"result\">";

            foreach ($count as $key => $value) {
                echo $key . " : " . $value . " time" . ($value == 1 ? "" : "s") . "<br />";
            }

            echo "Most frequent tag is: " . array_keys($count)[0];
            echo "</div>";
        }
        ?>
    </form>
</body>
</html>