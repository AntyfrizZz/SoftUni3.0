<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>CV Generator</title>
    <link href="styles.css" rel="stylesheet">
</head>
<body>
<?php
foreach ($_POST as $header => $content):
    if ($header == 'submit'):
        break;
    endif;
?>
    <table>
        <tr>
            <th colspan="2">
                <?php
                echo str_replace('_', ' ', $header);
                ?>
            </th>
        </tr>
        <?php
        foreach ($content as $key => $value):
        ?>
        <tr>
            <td>
                <?php
                echo $key;
                ?>
            </td>
            <td>
                <?php
                if ($key == "Driver's License"):
                    $value = implode(', ', $value);
                endif;

                if (gettype($value) != 'array'):
                    echo htmlspecialchars($value);
                else:
                ?>
                <table>
                    <tr>
                        <?php
                        $keys = array_keys($value);

                        foreach ($keys as $thValue):
                            echo "<th>$thValue</th>";
                        endforeach;

                        $row = 0;
                        ?>
                    </tr>
                    <?php
                    do {
                        echo '<tr>';

                        foreach ($keys as $k):
                            echo "<td>{$value[$k][$row]}</td>";
                        endforeach;

                        echo '</tr>';
                        $row++;
                    } while ($row < count($value[$k]));
                    ?>
                </table>
                <?php
                endif;
                ?>
            </td>
        </tr>
        <?php
        endforeach;
        ?>
    </table></br>
<?php
endforeach;
?>
</body>
</html>