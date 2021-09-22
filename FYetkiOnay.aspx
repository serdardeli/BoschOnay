<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BoschOnay.Master" CodeBehind="FYetkiOnay.aspx.vb" Inherits="BoschOnay.FYetkiOnay" %>

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
            function Degistir() {
                var RadGrid1 = $find("<%=RadGrid1.ClientID%>");
                if (RadGrid1.get_masterTableView().get_selectedItems().length == 0) {
                    alert("Lütfen önce bir yetki seçiniz!");
                    return false;
                }
            }
            function Sil() {
                var RadGrid1 = $find("<%=RadGrid1.ClientID%>");
                if (RadGrid1.get_masterTableView().get_selectedItems().length == 0) {
                    alert("Lütfen önce bir yetki seçiniz!");
                    return false;
                }
                var quit = confirm("Seçili kaydı silmek istiyor musunuz?");
                if (quit) return true;
                return false;
            }
        </script>
    </telerik:RadScriptBlock>
    <table style="width: 100%; height: 100%;">
        <tr>
            <td align="left" colspan="2" class="baslik">
                <asp:Label ID="BBaslik" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td valign="top">
                <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" Width="300px" Height="100%" AutoGenerateColumns="False"
                    AllowMultiRowSelection="False">
                    <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="true" />
                        <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                    </ClientSettings>
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="YetkiNo" HeaderText="Kodu" UniqueName="YetkiNo" HeaderStyle-Width="70px" ReadOnly="true" />
                            <telerik:GridBoundColumn DataField="YetkiAdi" HeaderText="Açıklama" UniqueName="YetkiAdi" HeaderStyle-Width="200px" ReadOnly="true" />
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid></td>
            <td valign="top" align="left" style="width: 100%;">
                <table style="height: 100%;">
                    <tr>
                        <td>
                            <table style="background-color: gainsboro; border: none; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: lighter; width: 100%">
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="BEkle" runat="server" ImageUrl="~/images/buttonadd.png" Height="32px" Width="32px" BorderColor="GhostWhite" BorderStyle="Solid" BorderWidth="1px" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="BDegistir" runat="server" ImageUrl="~/images/buttonedit.png" Height="32px" Width="32px" OnClientClick="return Degistir();" BorderColor="GhostWhite" BorderStyle="Solid" BorderWidth="1px" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="BSil" runat="server" ImageUrl="~/images/buttontrash.png" Height="32px" Width="32px" OnClientClick="return Sil();" BorderColor="GhostWhite" BorderStyle="Solid" BorderWidth="1px" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Kayit" runat="server" Font-Names="Calibri" Font-Size="14px" Width="200px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="BKaydet" runat="server" ImageUrl="~/images/buttonaccept.png" Height="32px" Width="32px" Visible="False" OnClientClick="return Kaydet();" BorderColor="GhostWhite" BorderStyle="Solid" BorderWidth="1px" />
                                    </td>
                                    <td style="width: 100%">
                                        <asp:ImageButton ID="BVazgec" runat="server" ImageUrl="~/images/buttoncancel.png" Height="32px" Width="32px" Visible="False" BorderColor="GhostWhite" BorderStyle="Solid" BorderWidth="1px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="border: 1px solid lightgray">
                            <table style="border: none; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: lighter; width: 100%">
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel2" runat="server" BackColor="CornflowerBlue" ForeColor="White" Height="20px" Width="200px" Text="Kodu"></telerik:RadLabel>
                                    </td>
                                    <td style="width: 100%">
                                        <asp:TextBox ID="YtkNo" runat="server" MaxLength="5" Width="80px" Font-Names="Segoe UI" Enabled="false" Font-Size="12px" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel1" runat="server" BackColor="CornflowerBlue" ForeColor="White" Height="20px" Width="200px" Text="Açıklama"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Aciklama" Enabled="false" runat="server" MaxLength="50" Width="200px" Font-Names="Segoe UI" Font-Size="12px" /></td>
                                </tr> 
                            </table>
                        </td>
                    </tr>
                    <tr style="background-color: cornflowerblue; color: white; border: none; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: lighter">
                        <td>Menü Yetkisi</td>
                    </tr>
                    <tr style="height: 100%">
                        <td>
                            <telerik:RadGrid ID="RadGrid2" runat="server" AllowSorting="true" Width="520px" Height="100%" AutoGenerateColumns="False"
                                AllowMultiRowSelection="False">
                                <ClientSettings AllowKeyboardNavigation="true">
                                   
                                    <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                                </ClientSettings>
                                <MasterTableView EditMode="Batch">
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="Kodu" HeaderText="Kodu" UniqueName="Kodu" HeaderStyle-Width="60px" ReadOnly="true" />
                                        <telerik:GridBoundColumn DataField="Baslik" HeaderText="Açıklama" UniqueName="Baslik" HeaderStyle-Width="200px" ReadOnly="true" />
                                        <telerik:GridTemplateColumn HeaderText="Yetki" UniqueName="Yetki" HeaderStyle-Width="60px">
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="CheckBox1" Enabled="false" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>

                                          <telerik:GridTemplateColumn HeaderText="Onaylanmayı Bekleyen Yetkiler" UniqueName="Yetki1" HeaderStyle-Width="90px">
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="CheckBox2"/> 
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid></td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Label ID="Mesaj" runat="server" Font-Names="Calibri" Font-Size="14px" ForeColor="Red"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>
