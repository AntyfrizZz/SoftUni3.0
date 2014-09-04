<?php
$varString = "hello";

if(is_numeric($varString)) {
    var_dump($varString);
} else {
    echo gettype($varString);
}
?>