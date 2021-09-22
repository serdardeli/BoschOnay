<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BoschOnay.Master" CodeBehind="FYetkiTanimRaporu.aspx.vb" Inherits="BoschOnay.FYetkiTanimRaporu" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; height: 100%;">
        <tr>
            <td align="left" colspan="2" class="baslik">
                <asp:Label ID="BBaslik" runat="server">Yetki Tanım raporu</asp:Label></td>
        </tr>

        <tr>
            <td style="border: 1px solid lightgray">
                <table style="background-color: gainsboro; border: none; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: lighter; width: 100%">
                    <tr>
                        <td>
                            <telerik:RadLabel ID="RadLabel1" runat="server" ForeColor="White" CssClass="labelbox" Width="110px" Text="Yetki Tanımı"></telerik:RadLabel>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="ryetki" runat="server" CheckBoxes="true" AllowCustomText="true" EmptyMessage="Seçimi yapınız.." TabIndex="7" EnableCheckAllItemsCheckBox="true" LoadingMessage="açılıyor..." Width="180px" MaxHeight="150px" Filter="Contains">
                                <Localization AllItemsCheckedString="Tümü Seçili" CheckAllString="Tümünü Seç" ItemsCheckedString=" adet seçildi" NoMatches="Select" />
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <telerik:RadLabel ID="RadLabel3" runat="server" ForeColor="White" CssClass="labelbox" Width="110px" Text="Kullanıcı Grubu"></telerik:RadLabel>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="rkullanici" runat="server" CheckBoxes="true" AllowCustomText="true" EmptyMessage="Seçimi yapınız.." TabIndex="7" EnableCheckAllItemsCheckBox="true" LoadingMessage="açılıyor..." Width="180px" MaxHeight="150px" Filter="Contains">
                                <Localization AllItemsCheckedString="Tümü Seçili" CheckAllString="Tümünü Seç" ItemsCheckedString=" adet seçildi" NoMatches="Select" />
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <telerik:RadLabel ID="RadLabel4" runat="server" ForeColor="White" CssClass="labelbox" Width="110px" Text="Menu Yetkisi"></telerik:RadLabel>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="rmenu" runat="server" CheckBoxes="true" AllowCustomText="true" EmptyMessage="Seçimi yapınız.." TabIndex="7" EnableCheckAllItemsCheckBox="true" LoadingMessage="açılıyor..." Width="300px" MaxHeight="150px" Filter="Contains">
                                <Localization AllItemsCheckedString="Tümü Seçili" CheckAllString="Tümünü Seç" ItemsCheckedString=" adet seçildi" NoMatches="Select" />
                            </telerik:RadComboBox>
                        </td>

                        <td style="width: 100%" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="BYenile" runat="server" ImageUrl="~/images/buttonrefresh.png" Height="32px" Width="32px" BorderColor="GhostWhite" BorderStyle="Solid" BorderWidth="1px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top" style="height: 100%;">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%"></rsweb:ReportViewer>

            </td>
        </tr>
    </table>
</asp:Content>
