﻿
<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8" name="viewport" content="width=device-width" />
    <title>Page Not Found - MondoSurf</title>
    <style>
        body {
            background: linear-gradient(45deg, steelblue, lightsteelblue);
        }

        .body-content {
            width: 100vw;
            height: 100vh;
        }
        .main {
            display: block;
        }
        #gradient {
            position: absolute;
            z-index: 2;
            right: 0;
            bottom: 0;
            left: 0;
            height: 300px;
            background: none;
            background: -moz-linear-gradient(top, rgba(255,255,255,0) 0%, rgba(255,255,255,1) 80%);
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(255,255,255,0)), color-stop(80%,rgba(255,255,255,1)));
            background: -webkit-linear-gradient(top, rgba(255,255,255,0) 0%,rgba(255,255,255,1) 80%);
        }
        #wipeoutText {
            font-size: xx-large;
            text-align: center;
        }
    </style>
</head>
<body>
    <div class="body-content">
        <div class="main">
            <h3 id="wipeoutText">Wipeout!</h3>
            <img id="wipeoutPic" src="./Content/404_Wipeout.jpg" />
        </div>
        <div id="gradient"></div>
        <div><p>Head back to <a href="/">shore</a>, mate.</p></div>
    </div>
</body>
</html>
