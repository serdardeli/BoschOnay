<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BoschOnay.Master" CodeBehind="FBoschRapor05.aspx.vb" Inherits="BoschOnay.FBoschRapor05" %>

<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=12.2.18.1017, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; height: 100%;">
        <tr>
            <td align="left" colspan="2" class="baslik">
                <asp:Label ID="BBaslik" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="border: 1px solid lightgray">
                <table style="background-color: gainsboro; border: none; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: lighter; width: 100%">
                    <tr>
                        <td>
                            <telerik:RadLabel ID="RadLabel1" runat="server" ForeColor="White" CssClass="labelbox" Width="110px" Text="Başlangıç"></telerik:RadLabel>
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="BasTar" runat="server" Culture="tr-TR" Width="100px" WrapperTableCaption="" AutoPostBack="False">
                                <Calendar runat="server" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                </Calendar>
                                <DateInput runat="server" AutoPostBack="False" DateFormat="dd.MM.yyyy" DisplayDateFormat="dd.MM.yyyy" LabelWidth="40%">
                                    <EmptyMessageStyle Resize="None" />
                                    <ReadOnlyStyle Resize="None" />
                                    <FocusedStyle Resize="None" />
                                    <DisabledStyle Resize="None" />
                                    <InvalidStyle Resize="None" />
                                    <HoveredStyle Resize="None" />
                                    <EnabledStyle Resize="None" />
                                </DateInput>
                            </telerik:RadDatePicker>
                        </td>
                        <td>
                            <telerik:RadLabel ID="RadLabel3" runat="server" ForeColor="White" CssClass="labelbox" Width="110px" Text="Bitiş"></telerik:RadLabel>
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="BitTar" runat="server" Culture="tr-TR" Width="100px" WrapperTableCaption="" AutoPostBack="False">
                                <Calendar runat="server" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                </Calendar>
                                <DateInput runat="server" AutoPostBack="False" DateFormat="dd.MM.yyyy" DisplayDateFormat="dd.MM.yyyy" LabelWidth="40%">
                                    <EmptyMessageStyle Resize="None" />
                                    <ReadOnlyStyle Resize="None" />
                                    <FocusedStyle Resize="None" />
                                    <DisabledStyle Resize="None" />
                                    <InvalidStyle Resize="None" />
                                    <HoveredStyle Resize="None" />
                                    <EnabledStyle Resize="None" />
                                </DateInput>
                            </telerik:RadDatePicker>
                        </td>
                        <td>
                            <telerik:RadLabel ID="RadLabel2" runat="server" ForeColor="White" CssClass="labelbox" Width="110px" Text="Mazeret Tipi"></telerik:RadLabel>
                        </td>
                        <td align="left">
                            <telerik:RadComboBox ID="RMazeretTipi" runat="server" CheckBoxes="True" Skin="Default" Width="200px">
                                <Localization AllItemsCheckedString="Seçilenlerin tümü" />
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <telerik:RadLabel ID="RadLabel4" runat="server" ForeColor="White" CssClass="labelbox" Width="110px" Text="Çalışma Tipi"></telerik:RadLabel>
                        </td>
                        <td align="left">
                            <telerik:RadComboBox ID="RCalismaTipi" runat="server" CheckBoxes="True" Skin="Default" Width="200px">
                                <Localization AllItemsCheckedString="Seçilenlerin tümü" />
                            </telerik:RadComboBox>
                        </td>
                        <td>

                        </td>
                        <td style="width: 100%" align="left">
                            <asp:ImageButton ID="BYenile" runat="server" ImageUrl="~/images/buttonrefresh.png" Height="32px" Width="32px" BorderColor="GhostWhite" BorderStyle="Solid" BorderWidth="1px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top" style="height: 100%;">
                <telerik:ReportViewer ID="RaporGoster" runat="server" Width="100%" Height="100%" ProgressText="Rapor hazırlanıyor..." ShowHistoryButtons="False" ShowParametersButton="False" ShowPrintPreviewButton="False" ShowRefreshButton="False" ViewMode="PrintPreview">
                    <typereportsource typename="BoschOnay.BoschRapor05, BoschOnay, Version=12.0.0.0, Culture=neutral, PublicKeyToken=null"></typereportsource>
                </telerik:ReportViewer>
            </td>
        </tr>
    </table>
</asp:Content>