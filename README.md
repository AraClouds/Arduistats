# Arduistats #


[![License](https://img.shields.io/badge/license-MIT-blue.svg)](https://opensource.org/licenses/MIT)
 
 ![Screenshots](https://i.imgur.com/2BAsTYR.jpg)
 
*Get live visitors from your website displayed your Arduino device.*

Setup on your server :
0. insert this snippett xx to head or footer


<?php

include 'ct/countertest.php';

?>

1. copy the /ct/ folder to your root www
2. enter domain in arduistats

#Requirement

arduinotft display compatible utft


# Common issue :

why chose php session ?

Google analytics say that there is active visitors but not on arduistats, why ?
A - Arduistats use php sessions for getting live users / heavy timeout

log said xxx, how to fix it ?

Nothing shown on my displayed
A - ensure that your lcd screen is supported by UTFT library

if you have 3 dots on arduino everything is fine, your live visit is 0

# To-Do

wordpress shortcode for counting live visit on specific url / page

*General*
icon app

create an api to dodge the txt process (wordpress)
Full arduino standalone (needs wifi module)
Windows standalone (notifications, tray icon etc)

*Arduino*
emit sound ?
manage the last visit counter and format
