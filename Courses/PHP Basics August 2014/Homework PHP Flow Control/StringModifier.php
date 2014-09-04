<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Modify String</title>
</head>
<body>
<form method="post">
    <input type="text" name="string" placeholder="Enter your string"/>
    <input type="radio" name="function" value="checkPalindrome" id="checkPalindrome" checked/>
    <label for="checkPalindrome">Check Palindrome</label>
    <input type="radio" name="function" value="reverseString" id="reverseString"/>
    <label for="reverseString">Reverse String</label>
    <input type="radio" name="function" value="splitString" id="splitString"/>
    <label for="splitString">Split</label>
    <input type="radio" name="function" value="hashString" id="hashString"/>
    <label for="hashString">Hash String</label>
    <input type="radio" name="function" value="shuffleString" id="shuffleString"/>
    <label for="shuffleString">Shuffle String</label>
    <input type="submit"/>
</form>
<?php
if (isset($_POST["string"]) && isset($_POST["function"]) && !empty($_POST["string"])) {
    $allowedFunctions = array("checkPalindrome", "reverseString", "splitString", "hashString", "shuffleString");
    if (in_array($_POST["function"], $allowedFunctions)) {
        echo $_POST["function"]($_POST["string"]);
    } else {
        echo "<div>Invalid function selected.</div>";
    }
}

function checkPalindrome($string)
{
    $normalizedString = strtolower(preg_replace("/[^A-Za-z0-9]/", "", $string));
    return "$string is " . ($normalizedString == strrev($normalizedString) ? "" : "not ") . "a palindrome!";
}

function reverseString($string)
{
    return strrev($string);
}

function splitString($string)
{
    $result = array();
    preg_match_all('/[A-Za-zА-Яа-я]/', $string, $result);
    return implode(" ", $result[0]);
}

function hashString($string)
{
    return crypt($string);
}

function shuffleString($string)
{
    return str_shuffle($string);
}

?>
</body>
</html>