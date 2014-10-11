<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ColumEdit.aspx.cs" Inherits="CJia.Evaluation.Web.Backstage.ColumEdit" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="pm_Main" AutoSizePanelID="rpnl_Main" runat="server" />
        <ext:RegionPanel ID="rpnl_Main" ShowBorder="false" runat="server">
            <Regions>
                <ext:Region ID="ren_Center" ShowHeader="false" Layout="Fit" Position="Center" Margins="2 2 2 2" runat="server">
                    <Items>
                        <ext:Panel ID="pnl_Main" runat="server" EnableBackgroundColor="true" BodyPadding="3px" BoxMargin="0"
                            Height="" EnableLargeHeader="true" ShowBorder="false" ShowHeader="false"
                            Layout="Fit">
                            <Toolbars>
                                <ext:Toolbar ID="tlr_Btn" runat="server">
                                    <Items>
                                        <ext:Button ID="btnAddColum" Icon="TableAdd" Text="增加" runat="server" OnClick="btnAddColum_Click">
                                        </ext:Button>
                                        <ext:Button ID="btnEditColum" Icon="TableEdit" Text="修改" runat="server" OnClick="btnEditColum_Click">
                                        </ext:Button>
                                        <ext:Button ID="btnDeleteColum" Icon="TableDelete" Text="删除" runat="server" ConfirmText="是否删除该节点和其子节点？" ConfirmIcon="Question" OnClick="btnDeleteColum_Click">
                                        </ext:Button>
                                        <ext:ToolbarFill ID="tbf_t" runat="server"></ext:ToolbarFill>
                                    </Items>
                                    
                                </ext:Toolbar>
                            </Toolbars>
                            <Items>
                                <ext:Tree ID="tree_Main" runat="server"  EnableArrows="true" EnableSingleExpand="true" ShowBorder="false"   ShowHeader="false"  AutoScroll="true" />
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Region>
            </Regions>
        </ext:RegionPanel>
        <ext:Window ID="win_Edit" Hidden="true" EnableIFrame="true" Icon="ApplicationFormEdit" Target="Parent" runat="server"
            CloseAction="HidePostBack" IsModal="true" Width="700px" Height="450px">
        </ext:Window>
    </form>
</body>
</html>
