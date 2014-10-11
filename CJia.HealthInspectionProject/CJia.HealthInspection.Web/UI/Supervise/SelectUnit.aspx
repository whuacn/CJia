<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectUnit.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.Supervise.SelectUnit" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>江西省卫生监督执法管理系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="Css/main.css" />
    <style type="text/css">
        .fontSize {
        font-size:35px;
        font-weight:bold;
        }

        .titleColor {
            color: gray;
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
                                        <%--<ext:Label ID="Label1" runat="server" Text="单位查询条件"></ext:Label>--%>
                                        <ext:TextBox ID="txt_Unit" runat="server" Width="500px" CssClass="titleColor" EmptyText="填写单位名称、单位地址、单位组织代码、法人作为关键字查询" Label="单位查询条件"></ext:TextBox>
                                        <ext:Button runat="server" IconUrl="../../Icons/zoom.png" Text="查询" ID="btnSerch" Type="Button" OnClick="btnSerch_Click">
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </Toolbars>
                            <Items>
                                <ext:Grid ID="gridUnit" ShowHeader="False" runat="server" AllowSorting="true" PageSize="20" ShowBorder="true" AllowPaging="true" EnableTextSelection="true"
                                    IsDatabasePaging="true" OnPageIndexChange="gr_Main_PageIndexChange" OnPreRowDataBound="gridUnit_PreRowDataBound" OnRowDoubleClick="gridUnit_RowDoubleClick"
                                EnableCheckBoxSelect="true"  EnableMultiSelect="false" DataKeyNames="UNIT_ID" AutoScroll="true" EnableRowDoubleClick="true" EnableRowNumber="True">
                                    <Columns>
                                        <ext:BoundField DataToolTipField="UNIT_NAME"  HeaderText="单位名称"  DataField="UNIT_NAME" ExpandUnusedSpace="true" />
                                        <ext:BoundField DataToolTipField="UNIT_CODE"  HeaderText="公司代码" DataField="UNIT_CODE" /> 
                                        <ext:BoundField DataToolTipField="LEGAL_PERSON"  HeaderText="法人" DataField="LEGAL_PERSON" />
                                        <ext:BoundField DataToolTipField="RESPONSIBLE_PERSON"  HeaderText="负责人" DataField="RESPONSIBLE_PERSON" />  
                                        <ext:BoundField DataToolTipField="UNIT_ADDRESS" HeaderText="公司地址" DataField="RESPONSIBLE_PERSON" />  
                                        <ext:BoundField DataToolTipField="COUNTY" HeaderText="所属区县" DataField="COUNTY" />  
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
