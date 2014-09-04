<?php
$result = "";
if($_SERVER['REQUEST_METHOD'] === 'POST') {
    $name = $_POST['name'];
    $age = $_POST['age'];
    $sex = $_POST['sex'];
    $result = "My name is $name. I am $age years old. I am $sex.";
}
?>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8"/>
    <title>Problem 7. Form Data</title>
    <style>
        input[type="text"], label {
            display: block;
        }
    </style>
</head>
<body>
<form method="post" action="">
    <input type="text" name="name" placeholder="Name">
    <input type="text" name="age" placeholder="Age">
    <label for="male"><input type="radio" id="male" name="sex" value="male">Male</label>
    <label for="female"><input type="radio" id="female" name="sex" value="female">Female</label>
    <input type="submit">
</form>
<?php echo $result; ?>
</body>
</html>