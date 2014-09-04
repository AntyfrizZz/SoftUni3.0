<!DOCTYPE html>
<html>
<head>
    <title>URL Replacer</title>
    <meta charset="UTF-8">
</head>
<body>
<form method="post">
    <textarea name="text"></textarea><br>
    <input type="submit" value="Replace URL's"/>
</form>
<?php
if (isset($_POST['text'])) {
    $text = ($_POST['text']);
    $text = str_replace('</a>', '[/URL]', $text);
    $text = preg_replace('/<a href="(.*?)">/', '[URL=\1]', $text);
    echo htmlentities($text);
}
?>
</body>
</html>