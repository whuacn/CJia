<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownLoad.aspx.cs" Inherits="CJia.Evaluation.Web.FrontStage.DownLoad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>三甲医院评审资料管理系统</title>
    <link href="../Css/Style.css" rel="stylesheet" />
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="../Css/main.css" />
    <style type="text/css">
        body {
            margin: 0;
            padding: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-color: #007ACC; font-weight: bold; height: 80px; font-size: 30px; color: #ffffff; float: left; width: 100%;">
            <table style="height: 100%; width: 100%">
                <tr style="height: 100%; width: 100%">
                    <td style="width: 70px;">
                        <img src="../Images/hsz.png" height="65" width="65" title="" alt="" style="margin-top: 2px;" />
                    </td>
                    <td style="align-content: center; vertical-align: middle; width: 600px;">
                        <label>三甲医院评审资料管理系统</label>
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
        <div id="warp">
            <div class="news1" runat="server" id="title"></div>
            <div class="news">
                <h1 runat="server" id="name"><%--2012年1-7月住院统计报表<span>发布时间:2012-12-04&nbsp;&nbsp;责任编辑:</span>--%></h1>
                <ul>
                    <li>
                        <%--<p>查看附件：</p>--%>
                        <p runat="server" id="txt"><%--<a href="/newspic/20121204143903.pdf">2012年1-7月住院统计报表</a>--%></p>
                        <p>&nbsp;</p>
                    </li>
                </ul>
            </div>
        </div>
    </form>
</body>
</html>
