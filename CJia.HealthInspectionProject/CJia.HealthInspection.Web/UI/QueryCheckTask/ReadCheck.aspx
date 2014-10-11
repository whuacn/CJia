<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReadCheck.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.QueryCheckTask.ReadCheck" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>江西省卫生监督执法管理系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
</head>
<body>
    <form id="form1" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="rpnl_Main" runat="server" />
        <ext:RegionPanel ID="rpnl_Main" ShowBorder="false" runat="server">
            <Regions>
                <ext:Region ID="ren_Center" ShowHeader="false" Layout="Fit" Position="Center" Margins="2 0 2 2" runat="server">
                    <Items>
                        <ext:Form ID="sf_Edit" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                            AutoScroll="true" LabelWidth="75px" BodyPadding="25px 15px" runat="server" EnableCollapse="True">
                            <Rows>
                                <ext:FormRow ColumnWidths="100%%">
                                    <Items>
                                        <ext:TextBox ID="txt_unitName" ShowRedStar="true" runat="server" Label="单位名称" Readonly="true" MaxLength="100" Text=""></ext:TextBox>
                                    </Items>
                                </ext:FormRow>
                                <ext:FormRow ColumnWidths="100%">
                                    <Items>
                                        <ext:TextBox ID="txt_Tmp" ShowRedStar="true" runat="server" Label="模板名称" Readonly="true" MaxLength="100" Text=""></ext:TextBox>
                                    </Items>
                                </ext:FormRow>
                                <ext:FormRow ColumnWidths="50% 50%">
                                    <Items>
                                        <ext:DropDownList ID="ddl_wuzheng" AutoPostBack="true" runat="server" Label="是否无证" Readonly="true" EnableSimulateTree="true">
                                            <ext:ListItem Text="无证" Value="0" />
                                            <ext:ListItem Text="有证" Value="1" />
                                            <ext:ListItem Text="不用发证" Value="2" />
                                        </ext:DropDownList>
                                        <ext:DropDownList ID="ddl_jiandang" AutoPostBack="true" runat="server" EnableSimulateTree="true" Readonly="true" Label="是否已建档">
                                            <ext:ListItem Text="未建" Value="0" />
                                            <ext:ListItem Text="已建" Value="1" />
                                        </ext:DropDownList>
                                    </Items>
                                </ext:FormRow>
                                <ext:FormRow ColumnWidths="100%">
                                    <Items>
                                        <ext:TextBox ID="txt_address" ShowRedStar="true" runat="server" Label="检查地点" MaxLength="100" Text="" Readonly="true"></ext:TextBox>
                                    </Items>
                                </ext:FormRow>
                                <ext:FormRow ColumnWidths="50% 50%">
                                    <Items>
                                        <ext:DatePicker ID="dp_start" Label="开始时间" runat="server" Readonly="true"></ext:DatePicker>
                                        <ext:DatePicker ID="dp_end" Label="结束时间" runat="server" Readonly="true" CompareControl="dp_start" DateFormatString="yyyy-MM-dd" CompareOperator="GreaterThanEqual"></ext:DatePicker>
                                    </Items>
                                </ext:FormRow>
                                <ext:FormRow ColumnWidths="50% 50%" ID="row_zhenggai">
                                    <Items>
                                        <ext:DropDownList ID="ddl_zhenggai" AutoPostBack="true" runat="server" Readonly="true" EnableSimulateTree="true" Label="是否要整改">
                                            <ext:ListItem Text="否" Value="0" />
                                            <ext:ListItem Text="是" Value="1" />
                                        </ext:DropDownList>
                                        <ext:DatePicker ID="dp_fucha" Label="复查日期" runat="server" Hidden="true" Readonly="true" HideMode="Visibility" EmptyText="( 无 )"></ext:DatePicker>
                                    </Items>
                                </ext:FormRow>
                                <ext:FormRow ColumnWidths="50% 50%">
                                    <Items>
                                        <ext:DropDownList ID="ddl_fucha" AutoPostBack="true" runat="server" Readonly="true" EnableSimulateTree="true" Label="此是否复查">
                                            <ext:ListItem Text="否" Value="0" Selected="true" />
                                            <ext:ListItem Text="是" Value="1" />
                                        </ext:DropDownList>
                                        <ext:DropDownList ID="ddl_zhqk" AutoPostBack="true" runat="server" Readonly="true" Hidden="true" HideMode="Visibility" EnableSimulateTree="true" Label="整改情况">
                                            <ext:ListItem Text="完成" Value="1" />
                                            <ext:ListItem Text="未完成" Value="0" />
                                        </ext:DropDownList>
                                    </Items>
                                </ext:FormRow>
                                <ext:FormRow ColumnWidths="100%" ID="row_TouchFiled" runat="server">
                                    <Items>
                                        <%--<ext:CheckBoxList runat="server" ID="cb_sheji" Label="涉及条线" ColumnVertical="true" TableColspan="50" ColumnWidth="100px">
                                            <ext:CheckItem Text="采供血卫生" Value="0" />
                                            <ext:CheckItem Text="化妆品" Value="1" Selected="true" />
                                            <ext:CheckItem Text="传染病防治" Value="1" Selected="true" />
                                            <ext:CheckItem Text="公共场所" Value="1" Selected="true" />
                                            <ext:CheckItem Text="放射卫生" Value="1" />
                                            <ext:CheckItem Text="涉水产品" Value="0" />
                                            <ext:CheckItem Text="生活饮用水" Value="0" />
                                            <ext:CheckItem Text="食品安全" Value="0" />
                                            <ext:CheckItem Text="消毒卫生" Value="0" />
                                            <ext:CheckItem Text="学校卫生" Value="0" />
                                            <ext:CheckItem Text="医疗卫生" Value="0" />
                                            <ext:CheckItem Text="职业卫生" Value="0" />
                                        </ext:CheckBoxList>--%>
                                    </Items>
                                </ext:FormRow>
                                <ext:FormRow ColumnWidths="100%">
                                    <Items>
                                        <ext:TextArea ID="txt_remark" runat="server" Label="备注" Readonly="true" Text="" MaxLength="200" Height="70"></ext:TextArea>
                                    </Items>
                                </ext:FormRow>
                                <ext:FormRow ColumnWidths="50%" ID="row_CheckResult" runat="server">
                                    <Items>
                                        <ext:TextBox ID="txt_CheckResult" ShowRedStar="true" runat="server" Label="检查结果" Readonly="true" MaxLength="100" Text=""></ext:TextBox>

                                        <%--<ext:DropDownList ID="ddl_result" runat="server" Label="检查结果" EnableSimulateTree="false">
                                            <ext:ListItem Text="合格" Value="0" />
                                            <ext:ListItem Text="不合格" Value="1" />
                                            <ext:ListItem Text="不确定" Value="2" />
                                            <ext:ListItem Text="未完成" Value="3" />
                                        </ext:DropDownList>
                                        <ext:Label runat="server"></ext:Label>--%>
                                    </Items>
                                </ext:FormRow>
                                <ext:FormRow ColumnWidths="100%">
                                    <Items>
                                        <ext:TextArea ID="txta_CheckResult" runat="server" Label="检查结果" Readonly="true" Text="" Height="80"></ext:TextArea>
                                    </Items>
                                </ext:FormRow>
                                <ext:FormRow ColumnWidths="100%">
                                    <Items>
                                        <ext:TextArea ID="txta_CheckAdvice" runat="server" Label="检查意见" Readonly="true" Text="" Height="80"></ext:TextArea>
                                    </Items>
                                </ext:FormRow>
                                <ext:FormRow>
                                    <Items>
                                        <ext:TextBox runat="server" ID="txt_Checker" Label="执行人员" Readonly="true"></ext:TextBox>
                                    </Items>
                                </ext:FormRow>
                            </Rows>
                        </ext:Form>
                    </Items>
                </ext:Region>
                <ext:Region ID="ren_Right" Title="检查题" EnableCollapse="true" Split="true" ShowHeader="false"
                    EnableSplitTip="true" CollapseMode="Mini" Width="320px" Margins="2 0 2 0" BodyPadding="0px" Position="Right"
                    runat="server" Layout="Fit">
                    <Items>
                        <ext:Accordion ID="Accordion1" Title="检查题" runat="server" Width="350px" EnableLargeHeader="false"
                            EnableFill="false" ShowBorder="True" >
                            <Panes>
                            </Panes>
                        </ext:Accordion>
                        <%--<ext:Panel ID="pnl_Main" runat="server" EnableBackgroundColor="true" BodyPadding="2 2 2 2"
                            Height="" EnableLargeHeader="true" ShowBorder="false" ShowHeader="false"
                            Layout="Fit">
                            <Items>
                                <ext:Grid ID="gridCheckTitle" ShowHeader="False" runat="server" AllowSorting="true" PageSize="20" ShowBorder="true" AllowPaging="true" EnableTextSelection="true" IsDatabasePaging="true" EnableRowNumber="True" 
                                    EnableCheckBoxSelect="false" OnSort="gr_Main_Sort" EnableMultiSelect="false" DataKeyNames="CHECK_TITLE_ID" AutoScroll="true" EnableRowDoubleClick="true">
                                    <Columns>
                                        <ext:TemplateField RenderAsRowExpander="true" ColumnID="AnswerID">
                                            <ItemTemplate>
                                                <ext:radiobuttonlist runat="server" ID="radio" ColumnNumber="1" >
                                                    <ext:RadioItem Text="可选项 1" Value="value1" />
                                                    <ext:RadioItem Text="可选项 2" Value="value2" />
                                                    <ext:RadioItem Text="可选项 3" Value="value3" />
                                                </ext:radiobuttonlist>
                                            </ItemTemplate>
                                        </ext:TemplateField>
                                        <ext:BoundField DataToolTipField="CHECK_TITLE_NAME" Width="400px" HeaderText="题目名称" SortField="CHECK_TITLE_NAME" DataField="CHECK_TITLE_NAME" />
                                    </Columns>
                                </ext:Grid>
                            </Items>
                            <Toolbars>
                                <ext:Toolbar ID="Toolbar1" Position="Bottom" runat="server">
                                    <Items>
                                        <ext:ToolbarFill ID="ToolbarFill1" runat="server"></ext:ToolbarFill>
                                        <ext:Button ID="btn_AddTitel" Text="增加零星题" IconUrl="../../Icons/add.png" runat="server" Icon="TextRuler" >
                                        </ext:Button>
                                        <ext:Button ID="btn_answer" Text="答题" IconUrl="../../Icons/award_star_gold_1.png" runat="server" Icon="TextRuler" >
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </Toolbars>
                        </ext:Panel>--%>
                    </Items>
                </ext:Region>
            </Regions>
        </ext:RegionPanel>
    </form>
</body>
</html>
