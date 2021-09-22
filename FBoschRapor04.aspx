<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BoschOnay.Master" CodeBehind="FBoschRapor04.aspx.vb" Inherits="BoschOnay.FBoschRapor04" %>

<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=12.2.18.1017, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table style="width: 100%; height: 100%;">
        <tr>
            <td align="left" colspan="2" class="baslik"><asp:Label ID="BBaslik" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="border: 1px solid lightgray">
                <table style="background-color: gainsboro; border: none; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: lighter; width: 100%">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td style="width: 100%" align="right">
                            <asp:ImageButton ID="BYenile" runat="server" ImageUrl="~/images/buttonrefresh.png" Height="32px" Width="32px" BorderColor="GhostWhite" BorderStyle="Solid" BorderWidth="1px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top" style="height: 100%;">
                <telerik:ReportViewer ID="RaporGoster" runat="server" Width="100%" Height="100%" ProgressText="Rapor hazırlanıyor..." ShowHistoryButtons="False" ShowParametersButton="False" ShowPrintPreviewButton="False" ShowRefreshButton="False" ViewMode="PrintPreview">
                    <typereportsource typename="BoschOnay.BoschRapor04, BoschOnay, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"></typereportsource>
                </telerik:ReportViewer>
            </td>
        </tr>
    </table>
</asp:Content>
