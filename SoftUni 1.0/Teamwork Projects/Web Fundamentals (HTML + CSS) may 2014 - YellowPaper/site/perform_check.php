<?php   
session_start();

$userval = strtolower(trim($_POST['captchavalue']));
$thecapt = strtolower($_SESSION['captcha']);

if( $userval == $thecapt ) {
    echo "true"; 
} else { 
    echo "false";
}
?>
