<?php
$sender = $_POST['name'];
$return = $_POST['email'];

$message = nl2br($_POST['message']);

$to = "mina.dodunekova@gmail.com";
$subject = "Съобщение от http://yellowpaper.atwebpages.com/";
$headers = "From: <animallover@abv.bg> \nReply-To: ".strip_tags($return)."\nContent-type: text/html; charset=utf-8 \nDate: ".date('r');

$msg = '	
   <html>
	<body>
	  <p>История от Жълтурче</p>
	  <table border="1" cellpadding="2" cellspacing="0">
		<tr>
		  <td>Име:</td>
		  <td>'.$sender.'</td>
		</tr>
		<tr>
		  <td>E-mail:</td>
		  <td>'.$return.'</td>
		</tr>
		<tr>
		  <td>История:</td>
		  <td>'.$message.'</td>
		</tr>
		<tr>
		  <td>Referral:</td>
		  <td>'.$_SERVER['HTTP_REFERER'].'</td>
		</tr>				
	  </table>
	</body>
	</html>';


if(@mail($to, $subject, $msg, $headers)) {
	echo "yes";
} else {
	echo "no";
}
?>