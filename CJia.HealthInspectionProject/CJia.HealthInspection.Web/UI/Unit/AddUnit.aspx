<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUnit.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.Unit.AddUnit" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>江西省卫生监督执法管理系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <style type="text/css">
        .titleColor {
            color: gray;
        }
    </style>
</head>
<body>
    <form id="frm_Main" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="sf_Edit" runat="server" />
        <ext:Form ID="sf_Edit" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
            AutoScroll="true" LabelWidth="85px" BodyPadding="25px 15px" runat="server" EnableCollapse="True">
            <Rows>
                <ext:FormRow ColumnWidths="34% 66%">
                    <Items>
                        <ext:TextBox ID="txt_xuke" AutoPostBack="true" ShowRedStar="true" runat="server" Label="许可证号" MaxLength="100" Text="" Required="True"></ext:TextBox>
                        <ext:TextBox ID="txt_unitName" AutoPostBack="true" ShowRedStar="true" runat="server" Label="单位名称" MaxLength="100" Text="" Required="True"></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="34% 33% 33%">
                    <Items>
                        <ext:DropDownList ID="ddl_leixing" AutoPostBack="true" runat="server" Label="类型" EnableSimulateTree="false">
                        </ext:DropDownList>
                        <ext:DropDownList ID="ddl_huyuan" AutoPostBack="true" runat="server" EnableSimulateTree="true" Label="是否户源">
                            <ext:ListItem Text="不指定" Value="" />
                            <ext:ListItem Text="是" Value="1" />
                            <ext:ListItem Text="否" Value="0" />
                        </ext:DropDownList>
                        <ext:DropDownList ID="ddl_huleixing" runat="server" EnableSimulateTree="true" Label="户类型">
                            <ext:ListItem Text="不指定" Value="" />
                        </ext:DropDownList>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="34% 33% 33%">
                    <Items>
                        <ext:TextBox ID="txt_suoshuquxian" ShowRedStar="true" runat="server" Label="所属区县" MaxLength="100" Text="" Required="True"></ext:TextBox>
                        <ext:TextBox ID="txt_zhucedizhi" ShowRedStar="true" runat="server" Label="注册地址" MaxLength="100" Text="" Required="True"></ext:TextBox>
                        <ext:TextBox ID="txt_daima" ShowRedStar="true" runat="server" Label="代码" MaxLength="100" Text="组织机构代码和身份证代码" EmptyText="组织机构代码和身份证代码"></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="34% 66%">
                    <Items>
                        <ext:Label ID="Label1" runat="server" Text=""></ext:Label>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="34% 33% 33%">
                    <Items>
                        <ext:TextBox ID="txt_faren" ShowRedStar="true" runat="server" Label="法人" MaxLength="100" Text="" Required="True"></ext:TextBox>
                        <ext:DropDownList ID="ddl_farenType" ShowRedStar="true" runat="server" Label="法人证型" EnableSimulateTree="false">
                        </ext:DropDownList>
                        <ext:TextBox ID="txt_farenzhenhao" ShowRedStar="true" runat="server" Label="法人证号" MaxLength="100" Text="" Required="True"></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="34% 33% 33%">
                    <Items>
                        <ext:TextBox ID="txt_fuzeren" runat="server" Label="负责人" MaxLength="50" Text=""></ext:TextBox>
                        <ext:DropDownList ID="ddl_fuzerenType" runat="server" Label="负责人证型" EnableSimulateTree="false">
                        </ext:DropDownList>
                        <ext:TextBox ID="txt_fuzerenzhenhao" runat="server" Label="负责人证号" MaxLength="100" Text=""></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="34% 66%">
                    <Items>
                        <ext:DropDownList ID="ddl_ecoType" runat="server" Label="经济类型" EnableSimulateTree="false">
                        </ext:DropDownList>
                        <ext:Label runat="server" ShowLabel="false" CssClass="titleColor" Text="例：国有全资、集体全资、股份合作、联营、有限责任(公司)、股份有限(公司)。。。"></ext:Label>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="34% 33% 33%">
                    <Items>
                        <ext:TextBox ID="txt_lianxiren" runat="server" Label="联系人" MaxLength="50" Text=""></ext:TextBox>
                        <ext:TextBox ID="txt_lianxidianhua"  runat="server" Label="联系电话" MaxLength="12" Text=""></ext:TextBox>
                        <ext:TextBox ID="txt_youbian" runat="server" Label="邮编" MaxLength="6"></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="34% 33% 33%">
                    <Items>
                        <ext:TextBox ID="txt_dizhi" ShowRedStar="true" runat="server" Label="地址" MaxLength="100" Text="" Required="True"></ext:TextBox>
                        <ext:TextBox ID="txt_fazhenjigou" runat="server" Label="发证机构名称" MaxLength="100" Text=""></ext:TextBox>
                        <ext:DropDownList ID="ddl_shenqingType" runat="server" Label="申请类别" EnableSimulateTree="false">
                        </ext:DropDownList>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="34% 33% 33%">
                    <Items>
                        <ext:DatePicker ID="dp_xuke" Label="许可日期" runat="server"></ext:DatePicker>
                        <ext:DatePicker ID="dp_start" Label="有效期始" runat="server"></ext:DatePicker>
                        <ext:DatePicker ID="dp_end" Label="有效期至" runat="server"></ext:DatePicker>
                    </Items>
                </ext:FormRow>
            </Rows>
            <Toolbars>
                <ext:Toolbar ID="tbr_Search" Position="Bottom" runat="server">
                    <Items>
                        <ext:ToolbarFill ID="tf_sb" runat="server"></ext:ToolbarFill>
                        <ext:Button ID="btn_Save" ConfirmText="确定保存此单位？" Text="保存" ValidateForms="sf_Edit" runat="server" Icon="TextRuler" OnClick="btn_Save_Click">
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </Toolbars>
        </ext:Form>
    </form>
</body>
</html>
