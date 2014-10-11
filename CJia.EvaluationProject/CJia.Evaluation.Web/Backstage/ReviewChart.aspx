<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReviewChart.aspx.cs" Inherits="CJia.Evaluation.Web.Backstage.ReviewChart" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                    text: '评审统计'
                },
                xAxis: {
                    categories: [
                        '普通条款A',
                        '普通条款B',
                        '普通条款C',
                        '核心条款A',
                        '核心条款B',
                        '核心条款C'
                    ]
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: '完成率'
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
