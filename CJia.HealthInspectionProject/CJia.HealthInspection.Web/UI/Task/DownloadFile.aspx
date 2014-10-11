<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownloadFile.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.Task.DownloadFile" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
     <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="Css/main.css" />
    <style type="text/css">
        .fontSize {
            font-size: 35px;
            font-weight: bold;
        }
    </style>
    <script type="text/javascript">
        function downloadFile(url) {
            var elemIF = document.createElement("iframe");
            elemIF.src = url;
            elemIF.style.display = "none";
            document.body.appendChild(elemIF);
        }
    </script>
</head>
<body>
     <form id="frm_Main" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="sf_Edit" runat="server"/>
        <ext:Form ID="sf_Edit" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
             AutoScroll="true"  runat="server" EnableCollapse="True">
             <Rows>
                    <ext:FormRow ColumnWidths="100%">
                        <Items>
                            <ext:Grid ID="gridFiles" AutoPostBack="true" runat="server" Title="文件信息" ShowHeader="False" PageSize="18" ShowBorder="true"
                                IsDatabasePaging="true" AutoHeight="true" DataKeyNames="FILE_ID,FILE_PATH" AutoScroll="true" EnableRowNumber="true" OnRowCommand="gridFiles_RowCommand">
                                <Columns>
                                    <ext:BoundField DataToolTipField="FILE_ID" HeaderText="文件ID" DataField="FILE_ID" Hidden="true"/>
                                    <ext:BoundField DataToolTipField="FILE_NAME" HeaderText="文件名称" DataField="FILE_NAME" ExpandUnusedSpace="true" />
                                    <ext:BoundField DataToolTipField="FILE_PATH" HeaderText="文件路径" DataField="FILE_PATH" Hidden="true"/>
                                     <ext:LinkButtonField ColumnID="lbf_Down" HeaderText="&nbsp;" Width="35px" CommandName="Download" ToolTip="下载" Icon="ArrowDown" />
                                </Columns>
                            </ext:Grid>
                        </Items>
                    </ext:FormRow>
                </Rows>
            <Toolbars>
                <ext:Toolbar ID="tbr_Search" Position="Bottom" runat="server">
                    <Items>
                        <ext:ToolbarFill ID="tf_sb" runat="server"></ext:ToolbarFill>
                        <ext:Button ID="btnReturn" Text="返回" runat="server" Icon="BulletGo" OnClick="btnReturn_Click">
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </Toolbars>
        </ext:Form>
    </form>
</body>
</html>
