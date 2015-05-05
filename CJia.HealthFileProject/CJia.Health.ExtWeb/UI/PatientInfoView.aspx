<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientInfoView.aspx.cs" Inherits="CJia.Health.ExtWeb.UI.PatientInfoView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body style="background-color: #F2F2F2;">
    <form id="form1" runat="server">
        <div>
            <table width="100%" style="text-align: left; font-family: 宋体; font-size: 18px;">
                <tr style="height: 30px">
                    <td style="text-align: right;" colspan="7">病人『<asp:Label ID="lblPatientName" runat="server" Text="张三"></asp:Label>
                        第<asp:Label ID="lblInHosTimes" runat="server" Text="01"></asp:Label>次入院』
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td></td>
                    <td style="width: 200px;">病案号：<asp:Label ID="lblRecordNO" runat="server" Text="C00001"></asp:Label>
                    </td>
                    <td style="width: 200px;">姓名：<asp:Label ID="lblPatientName1" runat="server" Text="张三"></asp:Label>
                    </td>
                    <td style="width: 200px;">性别：<asp:Label ID="lblGender" runat="server" Text="男"></asp:Label>
                    </td>
                    <td colspan="2" style="width: 200px;">出生日期：<asp:Label ID="lblBirthDay1" runat="server" Text="1990-4-21"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr style="height: 30px">
                    <td></td>
                    <td style="width: 200px;">婚否：<asp:Label ID="lblHunFou" runat="server" Text="已婚"></asp:Label>
                    </td>
                    <td style="width: 200px;">职业：<asp:Label ID="lblZhiYe" runat="server" Text="IT农民工"></asp:Label>
                    </td>
                    <td colspan="3" style="width: 200px;">出生地：<asp:Label ID="lblBirthCity" runat="server" Text="中国江西省南昌市"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr style="height: 30px">
                    <td></td>
                    <td style="width: 200px;">民族：<asp:Label ID="lblMinZu" runat="server" Text="汉"></asp:Label>
                    </td>
                    <td style="width: 200px;">国籍：<asp:Label ID="lblGuoJi" runat="server" Text="中国"></asp:Label>
                    </td>
                    <td colspan="3" style="width: 200px;">入院方式：<asp:Label ID="lblRYFS" runat="server" Text="开飞机"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr style="height: 30px">
                    <td></td>
                    <td colspan="2" style="width: 200px;">入院科室：<asp:Label ID="lblRYDept" runat="server" Text="精神病科"></asp:Label>
                    </td>
                    <td style="width: 200px;">入院日期：<asp:Label ID="lblRYDate" runat="server" Text="1990-4-21"></asp:Label>
                    </td>
                    <td style="width: 200px;">入院医生：<asp:Label ID="lblRYDoctor" runat="server" Text="张三三"></asp:Label>
                    </td>
                    <td style="width: 200px;">入院医生编号：<asp:Label ID="lblRYDoctorNO" runat="server" Text="00003"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr style="height: 30px">
                    <td></td>
                    <td colspan="2" style="width: 200px;">出院科室：<asp:Label ID="lblCYDept" runat="server" Text="精神病科"></asp:Label>
                    </td>
                    <td style="width: 200px;">出院日期：<asp:Label ID="lblCYDate" runat="server" Text="1990-4-21"></asp:Label>
                    </td>
                    <td style="width: 200px;">出院医生：<asp:Label ID="lblCYDoctor" runat="server" Text=" "></asp:Label>
                    </td>
                    <td style="width: 200px;">出院医生编号：<asp:Label ID="lblCYDoctorNO" runat="server" Text=" "></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr style="height: 30px">
                    <td></td>
                    <td colspan="2" style="width: 200px;">出院诊断1：<asp:Label ID="lblCYZD1" runat="server" Text="精神病术后"></asp:Label>
                    </td>
                    <td colspan="3" style="width: 200px;">出院诊断2：<asp:Label ID="lblCYZD2" runat="server" Text="精神病术后"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr style="height: 30px">
                    <td></td>
                    <td colspan="2" style="width: 200px;">出院诊断3：<asp:Label ID="lblCYZD3" runat="server" Text="精神病术后"></asp:Label>
                    </td>
                    <td colspan="3" style="width: 200px;">出院诊断4：<asp:Label ID="lblCYZD4" runat="server" Text="精神病术后"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr style="height: 30px">
                    <td></td>
                    <td colspan="2" style="width: 200px;">手术名称1：<asp:Label ID="lblSSMC1" runat="server" Text="精神病术后"></asp:Label>
                    </td>
                    <td colspan="3" style="width: 200px;">手术名称2：<asp:Label ID="lblSSMC2" runat="server" Text="精神病术后"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr style="height: 30px">
                    <td></td>
                    <td colspan="2" style="width: 200px;">手术名称3：<asp:Label ID="lblSSMC3" runat="server" Text="精神病术后"></asp:Label>
                    </td>
                    <td colspan="3" style="width: 200px;">手术名称4：<asp:Label ID="lblSSMC4" runat="server" Text="精神病术后"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr style="height: 30px">
                    <td></td>
                    <td colspan="2" style="width: 200px;">院内感染1：<asp:Label ID="lblYNGR1" runat="server" Text="精神病术后"></asp:Label>
                    </td>
                    <td colspan="3" style="width: 200px;">院内感染2：<asp:Label ID="lblYNGR2" runat="server" Text="精神病术后"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr style="height: 30px">
                    <td></td>
                    <td colspan="2" style="width: 200px;">病理诊断1：<asp:Label ID="lblBLZD1" runat="server" Text="精神病术后"></asp:Label>
                    </td>
                    <td colspan="3" style="width: 200px;">病理诊断2：<asp:Label ID="lblBLZD2" runat="server" Text="精神病术后"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr style="height: 50px">
                    <td></td>
                    <td colspan="2" style="width: 200px;"></td>
                    <td colspan="2" style="width: 200px;">
                        <%--<input id="Button1" type="button" value="关闭" onclick="onclose();" style="width: 65px" />--%>
                    </td>
                    <td style="width: 200px;"></td>
                    <td></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
