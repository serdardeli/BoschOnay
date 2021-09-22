<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BoschOnay.Master" CodeBehind="FSifre.aspx.vb" Inherits="BoschOnay.FSifre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadScriptBlock ID="RadScripTBoschOnay" runat="server">
        <script type="text/javascript">
            function Kaydet() {
                var quit = confirm("Bilgileri kaydetmek istiyor musunuz?");
                if (quit) return true;
                return false;
            }
        </script>
    </telerik:RadScriptBlock>
    <table style="height: 100%; width: 100%">
        <tr>
            <td align="left" class="baslik">Kullanıcı Şifre Değiştirme</td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            <telerik:RadLabel ID="RadLabel2" runat="server" Width="110px" Text="Yeni Şifre" CssClass="labelbox"></telerik:RadLabel>
                        </td>
                        <td>
                            <asp:TextBox ID="Sifre" runat="server" MaxLength="16" Width="100px" CssClass="textbox" TextMode="Password" /></td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadLabel ID="RadLabel1" runat="server" Width="110px" Text="Şifre Tekrarı" CssClass="labelbox"></telerik:RadLabel>
                        </td>
                        <td>
                            <asp:TextBox ID="YSifre" runat="server" MaxLength="16" Width="100px" CssClass="textbox" TextMode="Password" /></td>

                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:ImageButton ID="BKaydet" runat="server" ImageUrl="~/images/buttonaccept.png" Height="32px" Width="32px" OnClientClick="return Kaydet();" BorderColor="GhostWhite" BorderStyle="Solid" BorderWidth="1px" /></td>
                    </tr>
                    <tr style="height: 100%">
                        <td align="center" valign="top" colspan="2">
                            <asp:Label ID="Mesaj" runat="server" Font-Names="Calibri" Font-Size="14px" ForeColor="Red"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="height: 100%">
            <td></td>
        </tr>
    </table>
</asp:Content>
