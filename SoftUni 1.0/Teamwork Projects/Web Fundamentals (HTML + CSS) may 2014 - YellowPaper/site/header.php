<?php
    $page   = str_replace( '/', '', $_SERVER['SCRIPT_NAME'] );

    $type = substr( $page, 0, -5);
    $title = '';
    $add_jquery = false;
    
    switch( $type ) {
        case 'index':
            $title = 'Жълтурче - В Задния Двор на Софтуерното Образование';
            break;
        case 'aboutUs':
            $title = 'Жълтурче - Нашият Екип';
            break;
        case 'ourMission':
            $title = 'Жълтурче - Нашата Мисия';
            break;
        case 'submitATip':
            $title = 'Жълтурче - Сподели История';
            $add_jquery = true;
            break;
        case 'contacts':
            $title = 'Жълтурче - Контакти';
            break;       
    }
?>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title><?php echo $title; ?></title>
    <link type="text/css" href="css/reset.css" rel="stylesheet" media="all" />
    <link type="text/css" href="css/style.css" rel="stylesheet" media="all" />
    <?php if( $add_jquery ) : ?>
        <script src="//ajax.googleapis.com/ajax/libs/jquery/1.10.1/jquery.min.js"></script>
        <script type="text/javascript" src="js/script.js"></script>
    <?php endif; ?>
</head>
<body>
    <div id="container">
        <header id="header">
            <h1><a href="index.html" title="Home">Жълтурче</a></h1>
            <h2>В Задния Двор на Софтуерното Образование</h2>
        </header>
        <nav id="rotate">
            <ul>
                <li>
                    <a href="index.html">Новини</a>
                </li>
                <li>
                    <a href="aboutUs.html">Екипът</a>
                </li>
                <li>
                    <a href="ourMission.html">Нашата Мисия</a>
                </li>
                <li>
                    <a href="submitATip.html">Сподели История</a>
                </li>
                <li>
                    <a href="contacts.html">Контакти</a>
                </li>
            </ul>
        </nav>
        <main>