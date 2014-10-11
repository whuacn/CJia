<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PivotCustom.aspx.cs" Inherits="CJia.HISOLAP.Web.UI.PivotCustom" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v12.1, Version=12.1.8.0, Culture=neutral, PublicKeyToken=655b027630c07ea6" Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%">
                <tr>
                    <td></td>
                    <td style="width: 350px; vertical-align: top;">
                        <dx:ASPxPivotCustomizationControl ID="ASPxPivotCustomizationControl2" runat="server" Height="484px" Width="350px" ASPxPivotGridID="ASPxPivotGrid1" Enabled="False" Layout="BottomPanelOnly2by2">
                        </dx:ASPxPivotCustomizationControl>
                    </td>
                    <td style="width: 750px; vertical-align: top;">
                        <dx:ASPxPivotGrid ID="ASPxPivotGrid1" Width="750px" runat="server" ClientIDMode="AutoID" OLAPConnectionString="provider=MSOLAP;data source=http://192.168.1.209/OLAP/msmdpump.dll;initial catalog=JKDA;cube name=JJFB;User Id=hisolap;Password=creater123!@#;" Theme="Metropolis" EnableTheming="True">
                            <Fields>
                                <dx:PivotGridField ID="field" Area="DataArea" AreaIndex="0" Caption="平均住院天数" DisplayFolder="住院重点手术情况" FieldName="[Measures].[平均住院天数]" CellFormat-FormatString="{0:F}" CellFormat-FormatType="Custom" Width="120">
                                </dx:PivotGridField>
                                <dx:PivotGridField ID="PivotGridField1" Area="DataArea" AreaIndex="1" Caption="术后非预期再手术例数" DisplayFolder="住院重点手术情况" FieldName="[Measures].[术后非预期再手术例数]" ExportBestFit="False" Width="180">
                                </dx:PivotGridField>
                                <dx:PivotGridField ID="PivotGridField2" Area="DataArea" AreaIndex="2" Caption="平均住院费用" DisplayFolder="住院重点手术情况" FieldName="[Measures].[平均住院费用]" CellFormat-FormatString="{0:F}" CellFormat-FormatType="Numeric" Width="120">
                                </dx:PivotGridField>
                                <dx:PivotGridField ID="PivotGridField3" Area="DataArea" AreaIndex="3" Caption="住院天数" DisplayFolder="住院重点手术情况" FieldName="[Measures].[住院天数]" Width="120">
                                </dx:PivotGridField>
                                <dx:PivotGridField ID="fieldDATEYEARNAME1" AreaIndex="0" FieldName="[DATE DIM].[DATE YEAR NAME].[DATE YEAR NAME]" Caption="年" Width="120">
                                </dx:PivotGridField>
                                <dx:PivotGridField ID="fieldLevel02" Area="RowArea" AreaIndex="0" Caption="重点手术" FieldName="[KEY OPERATION DIM].[PARENT CODE].[Level 02]" GroupIndex="0" InnerGroupIndex="0">
                                </dx:PivotGridField>
                                <dx:PivotGridField ID="fieldLevel03" Area="RowArea" AreaIndex="1" Caption="子手术" FieldName="[KEY OPERATION DIM].[PARENT CODE].[Level 03]" GroupIndex="0" InnerGroupIndex="1">
                                </dx:PivotGridField>
                            </Fields>
                            <OptionsView ShowColumnGrandTotalHeader="False" ShowColumnGrandTotals="False" ShowColumnHeaders="False" ShowDataHeaders="False" ShowRowGrandTotals="False" ShowRowTotals="False" ShowFilterHeaders="False" ShowRowHeaders="False" />
                            <StylesPrint Cell-BackColor2="" Cell-GradientMode="Horizontal" FieldHeader-BackColor2="" FieldHeader-GradientMode="Horizontal" TotalCell-BackColor2="" TotalCell-GradientMode="Horizontal" GrandTotalCell-BackColor2="" GrandTotalCell-GradientMode="Horizontal" CustomTotalCell-BackColor2="" CustomTotalCell-GradientMode="Horizontal" FieldValue-BackColor2="" FieldValue-GradientMode="Horizontal" FieldValueTotal-BackColor2="" FieldValueTotal-GradientMode="Horizontal" FieldValueGrandTotal-BackColor2="" FieldValueGrandTotal-GradientMode="Horizontal" Lines-BackColor2="" Lines-GradientMode="Horizontal"></StylesPrint>
                            <Groups>
                                <dx:PivotGridWebGroup Caption="重点手术类" Hierarchy="[KEY OPERATION DIM].[PARENT CODE]" ShowNewValues="True" />
                            </Groups>
                        </dx:ASPxPivotGrid>
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
