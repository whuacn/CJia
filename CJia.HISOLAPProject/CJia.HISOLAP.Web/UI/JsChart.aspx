<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JsChart.aspx.cs" Inherits="CJia.HISOLAP.Web.UI.JsChart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../Js/jquery-1.8.0.min.js"></script>
    <script src="../Js/highcharts.js"></script>
    <script src="../Js/exporting.js"></script>
</head>
<body>
    <script type="text/javascript">
        $(function () {
            $('#container').highcharts({
                chart: {
                    type: 'column'
                },
                title: {
                    text: '九江市妇幼保键院'
                },
                subtitle: {
                    text: '出院人次统计'
                },
                xAxis: {
                    categories: [
                        '01月',
                        '02月',
                        '03月',
                        '04月',
                        '05月',
                        '06月',
                        '07月',
                        '08月',
                        '09月',
                        '10月',
                        '11月',
                        '12月'
                    ]
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: '人数'
                    }
                },
                tooltip: {
                    headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                    pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                        '<td style="padding:0"><b>{point.y:.1f} </b></td></tr>',
                    footerFormat: '</table>',
                    shared: true,
                    useHTML: true
                },
                plotOptions: {
                    column: {
                        pointPadding: 0.2,
                        borderWidth: 0
                    }
                },
                series: <%= Data %>
            });
        });
		</script>
    <form id="form1" runat="server">
        <div id="container" style="min-width: 310px; height: 400px; margin: 0 auto"></div>
    </form>
</body>
</html>
