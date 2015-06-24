<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="CJia.Health.Web.UI.HomePage" %>

<%--<!DOCTYPE html>--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <%--<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />--%>
    <title>病案借阅申请系统</title>
    <script src="Js/Main.js" type="text/javascript"></script>
    <script src="Js/TabControl.js" type="text/javascript"></script>
    <script>
        //加载皮肤文件
        loadCss(_skinId, 'Main.css');

        function ShowMenu() {
            if (tdMenu.style.display == '') {
                tdMenu.style.display = 'none';
                $("tdMenu1").title = $("tdMenu2").title = "显示菜单"
            }
            else {
                tdMenu.style.display = '';
                $("tdMenu1").title = $("tdMenu2").title = "隐藏菜单"
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="right: 10px; top: 5px; position: absolute; height: 21px; text-align: right">
            <a>皮肤：</a><a href="#" onclick="loadSkin('1')">藤蔓绿</a>&nbsp;<a href="#" onclick="loadSkin('2')">经典蓝</a>&nbsp;<a href="#" onclick="loadSkin('3')">甜蜜橙</a>&nbsp;<a href="#" onclick="loadSkin('4')">淡雅灰</a>
        </div>
        <!--把logo病案放在这里-->
        <div class="logopic"></div>
        <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="60" colspan="2" class="top"></td>
            </tr>
            <tr>
                <td class="menuwidth" id="tdMenu">
                    <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="menu11"></td>
                            <td class="menu12"></td>
                            <td class="menu13"></td>
                        </tr>
                        <tr>
                            <td class="menu21"></td>
                            <td class="menu22" valign="top">
                                <iframe style="width: 100%; height: 100%" frameborder="0" src="Menu.aspx"></iframe>
                            </td>
                            <td class="menu23" id="tdMenu1" onclick="ShowMenu()">
                                <div class="tripbar">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="menu31"></td>
                            <td class="menu32"></td>
                            <td class="menu33"></td>
                        </tr>
                    </table>
                </td>
                <td valign="top">
                    <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="right11"></td>
                            <td class="right12"></td>
                            <td class="right13"></td>
                        </tr>
                        <tr>
                            <td class="right21" id="tdMenu2" onclick="ShowMenu()"></td>
                            <td class="right22" valign="top">
                                <script>
                                    var myTab = new HTabControl(_skinId, true);
                                    document.write(myTab.init());
                                    myTab.Cts("查询病案", "QueryPatientView.aspx")
                                </script>
                            </td>
                            <td class="right23"></td>
                        </tr>
                        <tr>
                            <td class="right31"></td>
                            <td class="right32"></td>
                            <td class="right33"></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
