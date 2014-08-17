<?php
session_start(); 

$im = imagecreatefrompng("./img/captcha.png");

$chars = array('a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'm', 'n', 'p', 'q', 'r', 't', 'u', 'v', 'w', 'x', 'y', 'z');
$str1 = $chars[mt_rand(0, count($chars)-1)];
$str2 = $chars[mt_rand(0, count($chars)-1)];
$str3 = $chars[mt_rand(0, count($chars)-1)];
$str4 = $chars[mt_rand(0, count($chars)-1)];
$font = "./css/webfonts/creativeblock.ttf";
$size = mt_rand(14, 18);

$_SESSION['captcha'] = $str1.$str2.$str3.$str4;

$angle = mt_rand(-5, 5);
$color = imagecolorallocate($im, 55, 55, 55);
$textsize = imagettfbbox($size, $angle, $font, "XXXX");

$twidth = abs($textsize[2]-$textsize[0]);
$theight = abs($textsize[5]-$textsize[3]);

$x = mt_rand(5, 60);
$y = mt_rand(18, 35);

imagettftext($im, $size, $angle, $x, $y, $color, $font, $str1);
imagettftext($im, $size, $angle, $x+mt_rand(20, 25), $y+mt_rand(1, 3), $color, $font, $str2);
imagettftext($im, $size, $angle, $x+mt_rand(45, 50), $y+mt_rand(1, 3), $color, $font, $str3);
imagettftext($im, $size, $angle, $x+mt_rand(65, 70), $y+mt_rand(1, 3), $color, $font, $str4);

// Output the image 
header("Content-type: image/png"); 
imagepng($im);
imagedestroy($im);
?>
