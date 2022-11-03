<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testAni.aspx.cs" Inherits="appLograAdmin.testAni" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="dist/test-tube.css" />
   <style>
        @import url('https://fonts.googleapis.com/css?family=Roboto');

            .porcentage{
              position:absolute;
              top:0;
              left:30px;
              color:white;
              font-family: 'Roboto', sans-serif;
            }

            [id^="circle_button"]:hover {
              fill: #efefef;
              cursor: pointer;
            }

            [id^="circle_button"]:active {
              fill: #cecece;
            }
   </style>
</head>
<body>
    <form id="form1" runat="server">
       <div id="mount"></div>
        <script src="https://code.haiku.ai/scripts/core/HaikuCore.4.3.9.min.js"></script>
        <script src="https://cdn.haiku.ai/7196255e-aeb6-4c99-9c9f-c2260d064dab/71ae360100da556898a7e300cf8aee1bd3e26078/index.embed.js"></script>
        <h1 class="porcentage">0%</h1>

        
    </form>
</body>
    <script>
        var component = HaikuComponentEmbed_andreperegrina_Glassofwatter(
            document.getElementById('mount'),
            { loop: true }
        );
        var timeline = component.getDefaultTimeline();

        // Check out the docs:  https://docs.haiku.ai

        // Example: control playback
        // timeline.gotoAndPlay(1200)

        // Example: control states
        // component.assignConfig({
        //   states: {
        //     someState: {value: 0},
        //     anotherState: {value: 0}
        //   }
        // })
        var porcentage = 0;
        var currentIntervalTime = 1;
        var intervalTimePorcentageCount = 0;
        setInterval(function () {
            var newPorcentage = component.state.porcentage;
            if (porcentage < newPorcentage) {
                intervalTimePorcentageCount++;
                var myIntervalTime = intervalTimePorcentageCount;
                var untilPorcentage = newPorcentage;
                var currentPorcentage = porcentage;
                var myInterval = setInterval(function () {
                    if (currentIntervalTime == myIntervalTime) {
                        currentPorcentage++;
                        if (currentPorcentage == untilPorcentage) {
                            currentIntervalTime++;
                            clearInterval(myInterval);
                        }
                        $('.porcentage').html(currentPorcentage + "%");
                    }
                }, 25);
                porcentage = newPorcentage;
            }
        }, 100);
    </script>
</html>
