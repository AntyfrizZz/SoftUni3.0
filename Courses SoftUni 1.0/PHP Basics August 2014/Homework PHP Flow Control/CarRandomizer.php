<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Rich People's Problems</title>
</head>
<body>
    <form method="post">
        <label for="cars">Enter cars:</label>
        <input type="text" name="cars" id="cars"/>
        <input type="submit" value="Show result"/>
    </form>

    <?php
    if (isset($_POST["cars"]) && !empty($_POST["cars"])) :
        $cars = preg_split('/[ ,]/', $_POST["cars"], 0, PREG_SPLIT_NO_EMPTY);
        $colors = ["black", "silver", "white", "red", "pink", "yellow", "green"]; ?>
        <table border="1">
            <thead>
            <tr>
                <th>Car</th>
                <th>Color</th>
                <th>Count</th>
            </tr>
            </thead>
            <tbody>
            <?php foreach ($cars as $car): ?>
                <tr>
                    <td><?= $car ?></td>
                    <td><?= $colors[array_rand($colors)] ?></td>
                    <td><?= rand(1, 5) ?></td>
                </tr>
            <?php endforeach; ?>
            </tbody>
        </table>
    <?php endif; ?>
</body>
</html>