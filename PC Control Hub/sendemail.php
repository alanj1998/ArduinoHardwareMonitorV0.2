<?php
    $receiver = $_POST['customerEmail'];
    $temperature = $_POST['cpuTemp'];
    $subject = "CPU Overheat!";
    $headers = "From : Arduino Hardware Monitor Team";
    $message = "Dear User,
    Our servers have discovered that your CPU is starting to overheat!
    It is currently running at " . $temperature . " degrees!
    Please check your computer to avoid pernament damage!
    
    Yours Faithfully,
    Arduino Hardware Monitor Team";
    mail($receiver, $subject, $message, $headers);
?>