<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectTemplate.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.Task.SelectTemplate" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>江西省卫生监督执法管理系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="Css/main.css" />
    <style type="text/css">
        .fontSize {
        font-size:35px;
        font-weight:bold;
        }
    </style>
</head>
<body>
   <form id="frm_Main" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="rpnl_Main" runat="server" />
        <ext:RegionPanel ID="rpnl_Main" ShowBorder="false" runat="server">
            <Regions>
                <ext:Region ID="ren_Center" ShowHeader="false" Layout="Fit" Position="Center" Margins="2 2 2 0" runat="server">
                    <Items>
                        <ext:Panel ID="pnl_Main" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
                            Height="" EnableLargeHeader="true" ShowBorder="false" ShowHeader="false"
                            Layout="Fit">
                            <Toolbars>
                                <ext:Toolbar ID="tlr_Btn" runat="server">
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" Width="30px" Text="分类"></ext:Label>
                                        <ext:DropDownList ID="dropBig" AutoPostBack="true" Width="170" runat="server" OnSelectedIndexChanged="dropBig_SelectedIndexChanged">
                                        </ext:DropDownList>
                                        <ext:Label ID="Label4" runat="server" Width="6"></ext:Label>
                                        <ext:DropDownList ID="dropMiddle" AutoPostBack="true" runat="server" EnableSimulateTree="false" ShowRedStar="true" Width="170" OnSelectedIndexChanged="dropMiddle_SelectedIndexChanged">
                                        </ext:DropDownList>
                                        <ext:Label ID="Label5" runat="server" Width="6"></ext:Label>
                                        <ext:DropDownList ID="dropSmall" runat="server" EnableSimulateTree="true" Width="170">
                                        </ext:DropDownList>
                                        <ext:Label ID="Label2" runat="server" Width="6"></ext:Label>
                                        <ext:Button runat="server" IconUrl="../../Icons/zoom.png" Text="查询" ID="btnSelect" Type="Button" OnClick="btnSelect_Click">
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </Toolbars>
                            <Items>
                                <ext:Grid ID="gridTemp" ShowHeader="False" runat="server" AllowSorting="true" PageSize="20" ShowBorder="true" AllowPaging="true" EnableTextSelection="true"
                                    IsDatabasePaging="true" OnPageIndexChange="gr_Main_PageIndexChange" OnRowDoubleClick="gridTemp_RowDoubleClick"
                                EnableCheckBoxSelect="true" OnSort="gr_Main_Sort" EnableMultiSelect="false" DataKeyNames="TEMPLATE_ID" AutoScroll="true" EnableRowDoubleClick="true" EnableRowNumber="True">
                                    <Columns>
                                         <ext:BoundField DataToolTipField="TEMPLATE_NAME"  HeaderText="模板名称" SortField="TEMPLATE_NAME" DataField="TEMPLATE_NAME" ExpandUnusedSpace="true" />
                                         <ext:BoundField DataToolTipField="SMALL_TEMPLATE_NAME" Width="140px" HeaderText="模板分类" DataField="SMALL_TEMPLATE_NAME" />
                                         <ext:BoundField HeaderText="添加人" SortField="USER_NAME" DataField="USER_NAME" Width="50px"/>
                                         <ext:BoundField Width="120px" HeaderText="添加时间" SortField="CREATE_DATE" DataField="CREATE_DATE" />
                                         <ext:BoundField Width="120px" HeaderText="更新时间" SortField="UPDATE_DATE" DataField="UPDATE_DATE" />
                                    </Columns>
                                </ext:Grid>
                            </Items>
                            <Toolbars>
                                 <ext:Toolbar ID="tbr_Search" Position="Bottom" runat="server">
                                    <Items>
                                 <ext:ToolbarFill ID="tf_sb" runat="server"></ext:ToolbarFill>
                                        <ext:Button ID="btnOk" Text="确定" OnClick="btnOk_Click" ValidateForms="sf_Edit" runat="server" Icon="Accept">
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </Toolbars>
                   
                        </ext:Panel>
                    </Items>
                </ext:Region>
            </Regions>
        </ext:RegionPanel>
    </form>
</body>
</html>
