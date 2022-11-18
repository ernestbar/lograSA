<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testAni.aspx.cs" Inherits="appLograAdmin.testAni" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Lato" />
     <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.5.0/Chart.min.js"></script>
   <script type="text/javascript">
       function cargar() {
           var densityData = {
               label: 'Density of Planet (kg/m3)',
               data: [5427, 5243, 5514, 3933, 1326, 687, 1271, 1638],
               backgroundColor: 'rgba(0, 99, 132, 0.6)',
               borderColor: 'rgba(0, 99, 132, 1)',
               yAxisID: "y-axis-density"
           };

           var gravityData = {
               label: 'Gravity of Planet (m/s2)',
               data: [3.7, 8.9, 9.8, 3.7, 23.1, 9.0, 8.7, 11.0],
               backgroundColor: 'rgba(99, 132, 0, 0.6)',
               borderColor: 'rgba(99, 132, 0, 1)',
               yAxisID: "y-axis-gravity"
           };

           var planetData = {
               labels: ["Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune"],
               datasets: [densityData, gravityData]
           };

           var chartOptions = {
               scales: {
                   xAxes: [{
                       barPercentage: 1,
                       categoryPercentage: 0.6
                   }],
                   yAxes: [{
                       id: "y-axis-density"
                   }, {
                       id: "y-axis-gravity"
                   }]
               }
           };

           var barChart = new Chart(densityCanvas, {
               type: 'bar',
               data: planetData,
               options: chartOptions
           });
       }

   </script>
</head>
<body>
    <form id="form1" runat="server">
      <canvas id="densityChart" onload="cargar()" width="600" height="400"></canvas>
    </form>
</body>
    
</html>
