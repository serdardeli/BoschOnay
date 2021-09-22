<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BoschOnay.Master" CodeBehind="FUsersOnay.aspx.vb" Inherits="BoschOnay.FUsersOnay" %>

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
                    alert("Lütfen önce bir personel seçiniz!");
                    return false;
                }
            }
            function Sil() {
                var RadGrid1 = $find("<%=RadGrid1.ClientID%>");
                if (RadGrid1.get_masterTableView().get_selectedItems().length == 0) {
                    alert("Lütfen önce bir personel seçiniz!");
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
                    AllowMultiRowSelection="False" AllowFilteringByColumn="True">
                    <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="true" />
                        <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                    </ClientSettings>
                    <GroupingSettings CaseSensitive="false" />
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="Userid" HeaderText="Kodu" UniqueName="Userid" HeaderStyle-Width="70px" ReadOnly="true" AutoPostBackOnFilter="True" CurrentFilterFunction="StartsWith" FilterControlWidth="100%"
                                ShowFilterIcon="False" />
                            <telerik:GridBoundColumn DataField="UserName" HeaderText="Açıklama" UniqueName="UserName" HeaderStyle-Width="200px" ReadOnly="true" AutoPostBackOnFilter="True" CurrentFilterFunction="StartsWith" FilterControlWidth="100%"
                                ShowFilterIcon="False" />
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
                        <td style="border: 1px solid lightgray">
                            <table style="border: none; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: lighter;">
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel2" runat="server" BackColor="CornflowerBlue" ForeColor="White" Height="20px" Width="110px" Text="Kullanıcı Kodu"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Userid" runat="server" MaxLength="16" Width="100px" Font-Names="Segoe UI" Font-Size="12px" />
                                        <asp:ImageButton ID="Getir" runat="server" ImageUrl="~/images/buttonrefresh.png" Height="20px" Width="20px" Visible="False" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" />
                                        &nbsp;
                                     
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel4" runat="server" BackColor="CornflowerBlue" ForeColor="White" Height="20px" Width="110px" Text="Kendisi"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="Kendisi" runat="server" Font-Names="Segoe UI" Font-Size="12px" Text="" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel1" runat="server" BackColor="CornflowerBlue" ForeColor="White" Height="20px" Width="110px" Text="Adı ve Soyadı"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Username" runat="server" MaxLength="50" Width="195px" Font-Names="Segoe UI" Font-Size="12px" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel16" runat="server" BackColor="CornflowerBlue" ForeColor="White" Height="20px" Width="110px" Text="Kullanıcı Grubu"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="PerYetki" runat="server" Width="200px" Font-Names="Segoe UI" Font-Size="12px" DataTextField="YtkAdi" DataValueField="YtkNo">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel7" runat="server" BackColor="CornflowerBlue" ForeColor="White" Height="20px" Width="110px" Text="Personel Sicil No"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="PerPersNr" runat="server" Culture="tr-TR" DbValueFactor="1" LabelWidth="64px" MinValue="0" Width="100px" Font-Names="Segoe UI" Font-Size="12px" Height="20px">
                                            <NumberFormat ZeroPattern="n" DecimalDigits="0" GroupSeparator=""></NumberFormat>
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel12" runat="server" BackColor="CornflowerBlue" ForeColor="White" Height="20px" Width="110px" Text="EMail"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Email" runat="server" MaxLength="100" Width="195px" Font-Names="Segoe UI" Font-Size="12px" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel18" runat="server" BackColor="CornflowerBlue" ForeColor="White" Height="20px" Width="110px" Text="Durumu"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="Durumu" runat="server" Width="200px" Font-Names="Segoe UI" Font-Size="12px">
                                            <asp:ListItem Text="Pasif" Value="0" />
                                            <asp:ListItem Text="Aktif" Value="1" />
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel3" runat="server" BackColor="CornflowerBlue" ForeColor="White" Height="20px" Width="110px" Text="External Kullanıcı"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="euser" runat="server" Font-Size="12px" Text="" Checked="false" Enabled="false" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 100%">
                        <td>
                            <telerik:RadGrid ID="RadGrid2" runat="server" AllowSorting="true" Width="550px" Height="100%" AutoGenerateColumns="False"
                                AllowMultiRowSelection="False">
                                <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="false">
                                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="true" />
                                    <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                                </ClientSettings>
                                <MasterTableView EditMode="Batch">
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="Kodu" HeaderText="Organizasyon Birimi" UniqueName="Kodu" HeaderStyle-Width="260px" ReadOnly="true" />
                                        <telerik:GridTemplateColumn HeaderText="Yetki" UniqueName="Yetki" HeaderStyle-Width="60px">
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="CheckBox1" Enabled="false" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>

                                        <telerik:GridTemplateColumn HeaderText="Onaylanmayı Bekleyen Yetkiler" UniqueName="Yetki1" HeaderStyle-Width="120px">
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="CheckBox2" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid></td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Label ID="Mesaj" runat="server" Font-Names="Calibri" Font-Size="14px" ForeColor="Red"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:HiddenField ID="HiddenField3" runat="server" Value="0" />
    <asp:HiddenField ID="hdfid" runat="server" />

    <asp:HiddenField ID="hdfekle" runat="server" />
    <asp:HiddenField ID="hdfsil" runat="server" />
    <asp:HiddenField ID="hdfeskiler" runat="server" />
</asp:Content>
