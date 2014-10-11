<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryPatientView.aspx.cs" Inherits="CJia.Health.Web.UI.QueryPatientView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查询病案</title>
    <script type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <script src="Js/Main.js"></script>
    <script type="text/javascript">
        //加载页面要使用的CSS
        loadCss(top._skinId, 'Page.css');
    </script>
    <style type="text/css">
        .HeaderStyle {
            color: white;
            background-color: #FF6600;
            height: 30px;
            line-height: 24px;
            text-align: center;
            vertical-align: middle;
            font-weight: bold;
            font-size: 18px;
        }

        .GridViewStyle {
            border: 1px solid #D7D7D7;
            font-size: 15px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnSelect">
        <div>
            <table width="100%" style="text-align: left; font-family: 宋体; font-size: 18px;">
                <tr style="height: 50px">
                    <td colspan="9" style="text-align: center; font-weight: bold; font-size: 20px; color: #000000;"></td>
                </tr>
                <tr style="height: 45px">
                    <td></td>
                    <td style="width: 15px;">
                        <asp:CheckBox Visible="false" ID="ckDate" runat="server" Text=" " AutoPostBack="True" OnCheckedChanged="ckDate_CheckedChanged" />
                    </td>
                    <td style="width: 85px; text-align: right;">
                        <asp:Label ID="Label1" runat="server" Text="出院时间:"></asp:Label>
                    </td>
                    <td style="width: 180px;">
                        <asp:TextBox class="Wdate" ID="startDate" runat="server" onClick="WdatePicker()" Width="150px"></asp:TextBox>
                    </td>
                    <td style="width: 15px;">至
                    </td>
                    <td colspan="2" style="width: 150px;">
                        <asp:TextBox class="Wdate" ID="endDate" runat="server" onClick="WdatePicker()" Width="150px"></asp:TextBox>
                    </td>
                    <td style="width: 70px;"></td>
                    <td></td>
                </tr>
                <tr style="height: 45px">
                    <td></td>
                    <td style="width: 15px;">
                        <asp:CheckBox Visible="false"  ID="ckRecord" runat="server" Text=" " AutoPostBack="True" OnCheckedChanged="ckRecord_CheckedChanged" />
                    </td>
                    <td style="width: 85px; text-align: right;">
                        <asp:Label ID="Label3" runat="server" Text="病案号:"></asp:Label>
                    </td>
                    <td style="width: 150px;">
                        <asp:TextBox ID="txtRecordNO" runat="server" Width="150px"></asp:TextBox>
                    </td>
                    <td style="width: 15px;">
                        <asp:CheckBox Visible="false" ID="ckPatientID" runat="server" Text=" " />
                    </td>
                    <td style="width: 85px; text-align: right;">
                        <asp:Label Visible="false" ID="Label4" runat="server" Text="病 人 ID:"></asp:Label>
                    </td>
                    <td style="width: 150px;">
                        <%--<asp:TextBox Visible="false" ID="txtPatientID" runat="server" Width="150px" Enabled="True" ReadOnly="True"></asp:TextBox>--%>
                    </td>
                    <td style="width: 70px;"></td>
                    <td></td>
                </tr>
                <tr style="height: 45px">
                    <td></td>
                    <td style="width: 15px;">
                        <asp:CheckBox Visible="false"  ID="ckCYZD" runat="server" Text=" " AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />
                    </td>
                    <td style="width: 85px; text-align: right;">
                        <asp:Label ID="Label2" runat="server" Text="出院诊断:"></asp:Label>
                    </td>
                    <td style="width: 150px;">
                        <asp:TextBox ID="CYZD" runat="server" Width="150px" Enabled="True"></asp:TextBox>
                    </td>
                    <td style="width: 15px;">
                        <asp:CheckBox Visible="false" ID="ckZLJG" runat="server" Text=" " AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged" />
                    </td>
                    <td style="width: 85px; text-align: right;">
                        <%--<asp:Label ID="Label5" runat="server" Text="治疗结果:"></asp:Label>--%>
                        <asp:Label ID="Label6" runat="server" Text="手术名称:"></asp:Label>
                    </td>
                    <td style="width: 150px;">
                        <%--<asp:DropDownList ID="cbZLJG" runat="server" Width="150px" Height="22px" Enabled="False" ReadOnly="True"></asp:DropDownList>--%>
                        <asp:TextBox ID="SSMC" runat="server" Width="150px" Enabled="True"></asp:TextBox>
                    </td>
                    <td style="width: 70px;"></td>
                    <td></td>
                </tr>
                <%--<tr style="height: 45px">
                    <td></td>
                    <td style="width: 15px;">
                        <asp:CheckBox ID="ckSSMC" runat="server" Text=" " AutoPostBack="True" OnCheckedChanged="CheckBox3_CheckedChanged" />
                    </td>
                    <td style="width: 85px; text-align: right;">
                        <asp:Label ID="Label6" runat="server" Text="手术名称:"></asp:Label>
                    </td>
                    <td style="width: 150px;">
                        <asp:TextBox ID="SSMC" runat="server" Width="150px" Enabled="True" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td style="width: 15px;">
                        <asp:CheckBox ID="ckYNGR" runat="server" Text=" " AutoPostBack="True" OnCheckedChanged="CheckBox4_CheckedChanged" />
                    </td>
                    <td style="width: 85px; text-align: right;">
                        <asp:Label ID="Label9" runat="server" Text="院内感染:"></asp:Label>
                    </td>
                    <td style="width: 150px;">
                        <asp:TextBox ID="YNGR" runat="server" Width="150px" Enabled="True" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td style="width: 70px;"></td>
                    <td></td>
                </tr>--%>
                <%--<tr style="height: 45px">
                    <td></td>
                    <td style="width: 15px;">
                        <asp:CheckBox ID="ckBLZD" runat="server" Text=" " AutoPostBack="True" OnCheckedChanged="CheckBox12_CheckedChanged" />
                    </td>
                    <td style="width: 85px; text-align: right;">
                        <asp:Label ID="Label7" runat="server" Text="病理诊断:"></asp:Label>
                    </td>
                    <td colspan="4" style="width: 150px;">
                        <asp:TextBox ID="BLZD" runat="server" Width="150px" Enabled="True" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td style="width: 70px;"></td>
                    <td></td>
                </tr>--%>
                <tr style="height: 45px">
                    <td></td>
                    <td style="width: 15px;">
                        <asp:CheckBox Visible="false" ID="ckPatientName" runat="server" Text=" " AutoPostBack="True" OnCheckedChanged="CheckBox6_CheckedChanged" Checked="True" />
                    </td>
                    <td style="width: 85px; text-align: right;">
                        <asp:Label ID="Label8" runat="server" Text="病人姓名:"></asp:Label>
                    </td>
                    <td style="width: 150px;">
                        <asp:TextBox ID="txtPatientName" runat="server" Width="150px"></asp:TextBox>
                    </td>
                    <td style="width: 15px;">
                        <%--<asp:CheckBox Visible="false"  ID="ckBirth" runat="server" Text=" " Width="20px" AutoPostBack="True" OnCheckedChanged="CheckBox7_CheckedChanged" />--%>
                    </td>
                    <td style="width: 85px; text-align: right;">
                        <asp:Label Visible="false" ID="Label18" runat="server" Text="出 生 地:"></asp:Label>
                    </td>
                    <td colspan="2" style="width: 220px;">
                        <%--<asp:DropDownList ID="cbSheng" runat="server" Width="80px" Height="22px" Enabled="False" ReadOnly="True" AutoPostBack="True" OnSelectedIndexChanged="cbSheng_SelectedIndexChanged"></asp:DropDownList>
                        <asp:Label ID="Label12" runat="server" Text="省"></asp:Label>
                        <asp:DropDownList ID="cbShi" runat="server" Width="80px" Height="22px" Enabled="False" ReadOnly="True"></asp:DropDownList>
                        <asp:Label ID="Label13" runat="server" Text="市"></asp:Label>--%>
                    </td>
                    <td></td>
                </tr>
                <tr style="height: 45px">
                    <td></td>
                    <td style="width: 15px;">
                        <asp:CheckBox Visible="false"  ID="ckRYDept" runat="server" Text=" " AutoPostBack="True" OnCheckedChanged="CheckBox8_CheckedChanged" />
                    </td>
                    <td style="width: 85px; text-align: right;">
                        <asp:Label ID="Label10" runat="server" Text="入院科室:"></asp:Label>
                    </td>
                    <td style="width: 150px;">
                        <asp:DropDownList ID="cbRYKS" runat="server" Width="150px" Height="22px"></asp:DropDownList>
                    </td>
                    <td style="width: 15px;">
                        <%--<asp:CheckBox ID="ckRYDoctor" runat="server" Text=" " Width="20px" AutoPostBack="True" OnCheckedChanged="CheckBox9_CheckedChanged" Height="21px" />--%>
                    </td>
                    <td style="width: 85px; text-align: right;">
                        <%--<asp:Label ID="Label11" runat="server" Text="入院医生:"></asp:Label>--%>
                        <asp:Label ID="Label14" runat="server" Text="出院科室:"></asp:Label>
                    </td>
                    <td style="width: 150px;">
                        <%--<asp:DropDownList ID="cbRYYS" runat="server" Width="150px" Height="22px" Enabled="False" ReadOnly="True"></asp:DropDownList>--%>
                         <asp:DropDownList ID="cbCYKS" runat="server" Width="150px" Height="22px"></asp:DropDownList>
                    </td>
                    <td style="width: 70px;"></td>
                    <td></td>
                </tr>
                <%--<tr style="height: 45px">
                    <td></td>
                    <td style="width: 15px;">
                        <asp:CheckBox ID="ckCYDept" runat="server" Text=" " AutoPostBack="True" OnCheckedChanged="CheckBox10_CheckedChanged" />
                    </td>
                    <td style="width: 85px; text-align: right;">
                        <asp:Label ID="Label14" runat="server" Text="出院科室:"></asp:Label>
                    </td>
                    <td style="width: 150px;">
                        <asp:DropDownList ID="cbCYKS" runat="server" Width="150px" Height="22px" Enabled="False" ReadOnly="True" AutoPostBack="True" OnSelectedIndexChanged="cbCYKS_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td style="width: 15px;">
                        <asp:CheckBox ID="ckCYDoctor" runat="server" Text=" " AutoPostBack="True" OnCheckedChanged="CheckBox11_CheckedChanged" />
                    </td>
                    <td style="width: 85px; text-align: right;">
                        <asp:Label ID="Label15" runat="server" Text="出院医生:"></asp:Label>
                    </td>
                    <td style="width: 150px;">
                        <asp:DropDownList ID="cbCYYS" runat="server" Width="150px" Height="22px" Enabled="False" ReadOnly="True"></asp:DropDownList>
                    </td>
                    <td style="width: 70px;"></td>
                    <td></td>
                </tr>--%>
                <tr style="height: 50px">
                    <td></td>
                    <td colspan="3" style="width: 280px; text-align: right">
                        <asp:Button ID="btnResert" runat="server" Text="重置" Width="65px" OnClick="btnResert_Click" />&nbsp;&nbsp;
                    </td>
                    <td style="width: 15px;"></td>
                    <td colspan="3" style="width: 200px;">
                        <asp:Button ID="btnSelect" runat="server" Text="查询" Width="65px" OnClick="btnSelect_Click" />
                        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
