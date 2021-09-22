<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BoschOnay.Master" CodeBehind="KullaniciTanimRaporu.aspx.vb" Inherits="BoschOnay.KullaniciTanimRaporu" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style3 {
            border-style: solid;
            border-width: 1px;
            font-family: 'Segoe UI';
            font-size: 12px;
            color: white;
            background-color: cornflowerblue;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; height: 100%;">
        <tr>
            <td align="left" colspan="2" class="baslik">
                <asp:Label ID="BBaslik" runat="server">Kullanici Tanımları raporu</asp:Label></td>
        </tr>
        <tr>
            <td style="border: 1px solid lightgray">
                <table style="background-color: gainsboro; border: none; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: lighter; width: 100%">
                    <tr>
                        <td style="vertical-align: top;" class="auto-style1">
                            <telerik:RadLabel ID="LblSicilNo" runat="server" ForeColor="White" CssClass="labelbox" Width="160px" Text="Kullanıcı Kodu"></telerik:RadLabel>
                        </td>
                        <td class="auto-style1">
                            <asp:TextBox ID="FltSicilNo" runat="server" Height="40px" TextMode="MultiLine" Width="200px" Font-Names="Segoe UI" Font-Size="12px" /></td>
                        <td>
                            <telerik:RadLabel ID="RadLabel3" runat="server" ForeColor="White" CssClass="labelbox" Width="110px" Text="Kullanıcı Grubu"></telerik:RadLabel>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="rkullanici" runat="server" CheckBoxes="true" AllowCustomText="true" EmptyMessage="Seçimi yapınız.." TabIndex="7" EnableCheckAllItemsCheckBox="true" LoadingMessage="açılıyor..." Width="200px" MaxHeight="150px" Filter="Contains">
                                <Localization AllItemsCheckedString="Tümü Seçili" CheckAllString="Tümünü Seç" ItemsCheckedString=" adet seçildi" NoMatches="Select" />
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <telerik:RadLabel ID="RadLabel1" runat="server" ForeColor="White" CssClass="auto-style3" Width="185px" Text="Kullanıcının Organizayon Birimi"></telerik:RadLabel>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="ryetki" runat="server" CheckBoxes="true" AllowCustomText="true" EmptyMessage="Seçimi yapınız.." TabIndex="7" EnableCheckAllItemsCheckBox="true" LoadingMessage="açılıyor..." Width="180px" MaxHeight="150px" Filter="Contains">
                                <Localization AllItemsCheckedString="Tümü Seçili" CheckAllString="Tümünü Seç" ItemsCheckedString=" adet seçildi" NoMatches="Select" />
                            </telerik:RadComboBox>
                        </td>



                        <td style="width: 100%" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="BYenile" runat="server" ImageUrl="~/images/buttonrefresh.png" Height="32px" Width="32px" BorderColor="GhostWhite" BorderStyle="Solid" BorderWidth="1px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadLabel ID="LblAdSoyad" runat="server" ForeColor="White" CssClass="labelbox" Width="160px" Text="Adı ve Soyadı"></telerik:RadLabel>
                        </td>
                        <td>
                            <asp:TextBox ID="FltAdSoyad" runat="server" MaxLength="50" Width="200px" Font-Names="Segoe UI" Font-Size="12px" /></td>

                        <td>
                            <telerik:RadLabel ID="RadLabel2" runat="server" ForeColor="White" CssClass="labelbox" Width="110px" Text="External Kullanıcı"></telerik:RadLabel>
                        </td>

                        <td>
                            <asp:RadioButtonList ID="CheckBox1" runat="server" RepeatDirection="Horizontal" Width="200px">
                                <asp:ListItem Value="2" Text="Tümü" Selected="True" ></asp:ListItem>
                                <asp:ListItem Value="1" Text="Evet" ></asp:ListItem>
                                <asp:ListItem Value="0" Text="Hayır" ></asp:ListItem>
                            </asp:RadioButtonList></td>
                       <%-- <td>
                            <telerik:RadLabel ID="RadLabel4" runat="server" ForeColor="White" CssClass="labelbox" Width="110px" Text="Menu Yetkisi"></telerik:RadLabel>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="rmenu" runat="server" CheckBoxes="true" AllowCustomText="true" EmptyMessage="Seçimi yapınız.." TabIndex="7" EnableCheckAllItemsCheckBox="true" LoadingMessage="açılıyor..." Width="180px" MaxHeight="150px" Filter="Contains">
                                <Localization AllItemsCheckedString="Tümü Seçili" CheckAllString="Tümünü Seç" ItemsCheckedString=" adet seçildi" NoMatches="Select" />
                            </telerik:RadComboBox>
                        </td>--%>
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
