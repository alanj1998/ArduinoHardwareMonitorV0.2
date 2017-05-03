<?php
    $cpuTemp = $_POST['cpuTemp'];
    $cpuUse = $_POST['cpuUse'];
    $ramUse = $_POST['ramUse'];
    $hddUse = $_POST['hddUse'];
    $cpuName = $_POST['cpuName'];
    $ramName = $_POST['ramName'];

    $file = fopen("pcData.txt", "w") or die ("Unable to open the file!");
    $string = $cpuTemp . "," . $cpuUse . "," . $ramUse . "," . $hddUse . "," . $cpuName . "," . $ramName;
    fwrite($file, $string);
    fclose($file);
?>