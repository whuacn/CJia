<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Low.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.Low.Low" %>

<%@ Register assembly="ExtAspNet" namespace="ExtAspNet" tagprefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>江西省卫生监督执法管理系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="Css/main.css" />
    <style type="text/css">
        #div_down
        {
            position:absolute;
            right:120px;
            bottom:5px;
            z-index:10000;
        }
    </style>
    <script type="text/javascript">
        function savetxt(fileURL) {
            var fileURL = window.open(fileURL, "_blank", "height=0,width=0,toolbar=no,menubar=no,scrollbars=no,resizable=on,location=no,status=no");
            fileURL.document.execCommand("SaveAs");
            fileURL.window.close();
            fileURL.close();
        }

        function downloadFile(url) {
            var elemIF = document.createElement("iframe");
            elemIF.src = url;
            elemIF.style.display = "none";
            document.body.appendChild(elemIF);
        }

        function ok(url) {
            var input = document.getElementById("frame1");
            input.src = url;
        }
    </script>
</head>
<body>
    <form id="frm_Main" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="rpnl_Main" runat="server" />
        <ext:RegionPanel ID="rpnl_Main" ShowBorder="false" runat="server">
            <Regions>
                <ext:Region ID="rgn_Top" Split="true" EnableSplitTip="true" CollapseMode="Mini" EnableCollapse="true" Width="180px" Margins="2 0 2 2" ShowHeader="false" Position="Left"
                    Layout="Fit" runat="server">
                    <Items>
                        <ext:Tree ID="tree_Low" runat="server"  OnNodeCommand="tree_Low_NodeCommand" EnableArrows="true" ShowBorder="false" Title="法律法规文件"  ShowHeader="true" AutoScroll="true" />
                    </Items>
                </ext:Region>
                <ext:Region ID="ren_Center" ShowHeader="false" Layout="Fit" Position="Center" Margins="2 2 2 0" runat="server">
                    <Items>
                        <ext:TabStrip ID="tabs_Main" EnableTabCloseMenu="true"  EnableLargeHeader="true" ShowBorder="false" runat="server">
                            <Tabs>
                                <ext:Tab ID="LowFile" Title="法律法规" AutoScroll="true"  Layout="Fit"  runat="server" EnableIFrame="true" >
                                </ext:Tab>
                            </Tabs>
                        </ext:TabStrip>
                    </Items>
                    <Toolbars>
                    <ext:Toolbar ID="tbr_Search" Position="Bottom" runat="server">
                        <Items>
                            <ext:ToolbarFill ID="tf_sb" runat="server"></ext:ToolbarFill>
                            <ext:Button ID="btn_FileDown" Text="保存" ValidateForms="sf_Edit" runat="server" Icon="TextRuler" OnClick="btn_FileDown_Click" >
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
            </Toolbars>
                </ext:Region>
            </Regions>
        </ext:RegionPanel>
    </form>
</body>
</html>
