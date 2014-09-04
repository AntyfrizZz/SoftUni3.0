<!DOCTYPE html>
<html>
<head>
    <title>Text Colorer</title>
    <meta charset="UTF-8">
    <style>
        .red {
            color: red;
        }
        .blue {
            color: blue;
        }
    </style>
</head>
<body>
    <form method="post">
        <textarea name="text"></textarea><br>
        <input type="submit" value="Color text"/>
    </form>
    <?php
    if (isset($_POST['text'])) {
        $text = $_POST['text'];
        for ($i = 0; $i < strlen($text); $i++) {
            if (ord($text[$i]) % 2 == 0) {
                echo "<span class='red'>$text[$i]</span>";
            } else {
                echo "<span class='blue'>$text[$i]</span>";
            }
        }
    }
    ?>
</body>
</html>