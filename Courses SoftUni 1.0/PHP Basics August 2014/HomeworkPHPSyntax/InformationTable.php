<?php
$name = "Gosho";
$phone = "0882-321-423";
$age = "24";
$address = "Hadji Dimitar";
?>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8"/>
    <title>Problem 6. HTML Table</title>
    <style>
        table {
            text-indent: 5px;
            border-collapse: collapse;
        }
        table tr {
            border: 1px solid #000;
        }
        table th, table td {
            width: 105px;
            line-height: 25px;
        }
        table th {
            text-align: left;
            background: #FF9C00;
        }
        table td {
            text-align: right;
        }
    </style>
</head>
<body>
<table>
    <tbody>
        <tr>
            <th>Name</th>
            <td><?php echo $name; ?></td>
        </tr>
        <tr>
            <th>Phone number</th>
            <td><?php echo $phone; ?></td>
        </tr>
        <tr>
            <th>Age</th>
            <td><?php echo $age; ?></td>
        </tr>
        <tr>
            <th>Address</th>
            <td><?php echo $address; ?></td>
        </tr>
    </tbody>
</table>
</body>
</html>