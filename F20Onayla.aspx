<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BoschOnay.Master" CodeBehind="F20Onayla.aspx.vb" Inherits="BoschOnay.F20Onayla" %>
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
            function Yenile() {
                var quit = confirm("Bilgileri yenilemek istiyor musunuz?\n\nBu durumda kaydedilmemiş Onay/Red bilgileriniz kaldırılacaktır.");
                if (quit) return true;
                return false;
            }
            function Onayla() {
                var RadGrid1 = $find("<%=RadGrid1.ClientID%>");
                if (RadGrid1.get_masterTableView().get_selectedItems().length == 0) {
                    alert("Lütfen önce bir kayıt seçiniz!");
                    return false;
                }
            }
            function Reddet() {
                var RadGrid1 = $find("<%=RadGrid1.ClientID%>");
                if (RadGrid1.get_masterTableView().get_dataItems().length == 0) {
                    return false;
                }
                if (RadGrid1.get_masterTableView().get_selectedItems().length == 0) {
                    alert("Lütfen önce bir kayıt seçiniz!");
                    return false;
                }
            }
            function Temizle() {
                var RadGrid1 = $find("<%=RadGrid1.ClientID%>");
                if (RadGrid1.get_masterTableView().get_dataItems().length == 0) {
                    return false;
                }
                if (RadGrid1.get_masterTableView().get_selectedItems().length == 0) {
                    alert("Lütfen önce bir kayıt seçiniz!");
                    return false;
                }
                var quit = confirm("Seçili kayıtların onay/ret bilgisini silmek istiyor musunuz?");
                if (quit) return true;
                return false;
            }
        </script>
    </telerik:RadScriptBlock>
    <table style="width: 100%; height: 100%;">
        <tr>
            <td align="left" colspan="2" class="baslik"><asp:Label ID="BBaslik" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="border: 1px solid lightgray">
                <table style="background-color: gainsboro; border: none; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: lighter; width: 100%">
                    <tr>
                        <td>
                            <telerik:RadLabel ID="RadLabel1" runat="server" ForeColor="White" Width="110px" Text="Başlangıç" CssClass="labelbox"></telerik:RadLabel>
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
                            <asp:ImageButton ID="BYenile" runat="server" ImageUrl="~/images/buttonrefresh.png" Height="32px" Width="32px" BorderColor="GhostWhite" BorderStyle="Solid" BorderWidth="1px" OnClientClick="return Yenile();" /></td>
                        <td>
                            <asp:ImageButton ID="BFiltre" runat="server" ImageUrl="~/images/buttonfilter.png" Height="32px" Width="32px" BorderColor="GhostWhite" BorderStyle="Solid" BorderWidth="1px" Visible="False" /></td>
                        <td>
                            <telerik:RadLabel ID="RadLabel2" runat="server" ForeColor="White" CssClass="labelbox" Width="110px" Text="Onay / Red Notu"></telerik:RadLabel>
                        </td>
                        <td>
                            <asp:TextBox ID="OnayText" runat="server" MaxLength="50" Width="200px" cssclass="textbox" /></td>
                        <td>
                            <asp:ImageButton ID="BOnayla" runat="server" ImageUrl="~/images/buttonaccept.png" Height="32px" Width="32px" BorderColor="GhostWhite" BorderStyle="Solid" BorderWidth="1px" Visible="False" OnClientClick="return Onayla();" />
                        </td>
                        <td>
                            <asp:ImageButton ID="BReddet" runat="server" ImageUrl="~/images/buttonreddet.png" Height="32px" Width="32px" BorderColor="GhostWhite" BorderStyle="Solid" BorderWidth="1px" Visible="False" OnClientClick="return Reddet();" />

                        </td>
                        <td>
                            <asp:ImageButton ID="BTemizle" runat="server" ImageUrl="~/images/buttontrash.png" Height="32px" Width="32px" BorderColor="GhostWhite" BorderStyle="Solid" BorderWidth="1px" Visible="False" OnClientClick="return Temizle();" />
                        </td>
                        <td style="width: 100%" align="right">
                            <asp:ImageButton ID="BKaydet" runat="server" ImageUrl="~/images/buttonsave.png" Height="32px" Width="32px" BorderColor="GhostWhite" BorderStyle="Solid" BorderWidth="1px" Visible="False" OnClientClick="return Kaydet();" />
                        </td>

                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top" style="height: 100%;">
                <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" Width="100%" Height="100%" AutoGenerateColumns="False"
                    AllowMultiRowSelection="True">
                    <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="False">
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="true" />
                        <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                    </ClientSettings>
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="SicilNo" HeaderText="Sicil No" UniqueName="SicilNo" HeaderStyle-Width="100px" ReadOnly="true" />
                            <telerik:GridBoundColumn DataField="AdSoyad" HeaderText="Adı, Soyadı" UniqueName="AdSoyad" HeaderStyle-Width="150px" ReadOnly="true" />
                            <telerik:GridBoundColumn DataField="MasrafYeri" HeaderText="Masraf Yeri" UniqueName="MasrafYeri" HeaderStyle-Width="100px" ReadOnly="true" />
                            <telerik:GridBoundColumn DataField="Tarih" HeaderText="Tarih" UniqueName="Tarih" DataFormatString="{0:dd.MM.yyyy}" HeaderStyle-Width="80px" ReadOnly="true" />
                            <telerik:GridBoundColumn DataField="Baslangic" HeaderText="Başlangıç" UniqueName="Baslangic" DataFormatString="{0:HH:mm}" HeaderStyle-Width="60px" ReadOnly="true" />
                            <telerik:GridBoundColumn DataField="Bitis" HeaderText="Bitiş" UniqueName="Bitis" DataFormatString="{0:HH:mm}" HeaderStyle-Width="60px" ReadOnly="true" />
                            <telerik:GridBoundColumn DataField="Sure" HeaderText="Süre" UniqueName="Sure" HeaderStyle-Width="60px" DataFormatString="{0:N2}" ReadOnly="true" />
                            <telerik:GridBoundColumn DataField="Onay" HeaderText="Onay" UniqueName="Onay" HeaderStyle-Width="100px" ReadOnly="true" />
                            <telerik:GridBoundColumn DataField="Aciklama" HeaderText="Açıklama" UniqueName="Aciklama" HeaderStyle-Width="200px" ReadOnly="true" />
                            <telerik:GridBoundColumn DataField="IdNr" HeaderText="IdNr" UniqueName="IdNr" display="false" ReadOnly="true" />
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
</asp:Content>
