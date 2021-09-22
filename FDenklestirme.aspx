<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BoschOnay.Master" CodeBehind="FDenklestirme.aspx.vb" Inherits="BoschOnay.FDenklestirme" %>

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
                    alert("Lütfen önce bir kayıt seçiniz!");
                    return false;
                }
            }

            function ekle() {
                return true;
             }

            function Sil() {
                var RadGrid1 = $find("<%=RadGrid1.ClientID%>");
                if (RadGrid1.get_masterTableView().get_selectedItems().length == 0) {
                    alert("Lütfen önce bir kayıt seçiniz!");
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
            <td align="left" colspan="2" class="baslik"><asp:Label ID="BBaslik" runat="server"></asp:Label></td>
        </tr>
        <tr style="height:100%">
            <td valign="top">
                <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" Width="520px" Height="100%" AutoGenerateColumns="False"
                    AllowMultiRowSelection="False">
                    <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="true" />
                        <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                    </ClientSettings>
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="Kodu" HeaderText="Kodu" UniqueName="Kodu" HeaderStyle-Width="70px" ReadOnly="true" />
                            <telerik:GridBoundColumn DataField="Kodu2" HeaderText="Kodu2" UniqueName="Kodu2" HeaderStyle-Width="70px" ReadOnly="true" />
                            <telerik:GridBoundColumn DataField="Aciklama" HeaderText="Açıklama" UniqueName="Aciklama" HeaderStyle-Width="200px" ReadOnly="true" />
                            <telerik:GridBoundColumn DataField="OnayBasTar" HeaderText="Onay Baş." UniqueName="OnayBasTar" HeaderStyle-Width="80px" DataFormatString="{0:dd.MM.yyyy}" ReadOnly="true" />
                            <telerik:GridBoundColumn DataField="OnayBitTar" HeaderText="Onay Bit." UniqueName="OnayBitTar" HeaderStyle-Width="80px" DataFormatString="{0:dd.MM.yyyy}" ReadOnly="true" />
                            <telerik:GridBoundColumn DataField="IdNr" HeaderText="IdNr" UniqueName="IdNr" HeaderStyle-Width="70px" Display="false" ReadOnly="true" />
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid></td>
            <td valign="top" align="left" style="width: 100%;">
                <table style="height: 100%;">
                    <tr>
                        <td colspan="2">
                            <table style="background-color: gainsboro; border: none; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: lighter; width: 100%">
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="BEkle" runat="server" ImageUrl="~/images/buttonadd.png" Height="32px" Width="32px" OnClientClick="return ekle();" BorderColor="GhostWhite" BorderStyle="Solid" BorderWidth="1px" Visible="false" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="BDegistir" runat="server" ImageUrl="~/images/buttonedit.png" Height="32px" Width="32px" OnClientClick="return Degistir();" BorderColor="GhostWhite" BorderStyle="Solid" BorderWidth="1px" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="BSil" runat="server" ImageUrl="~/images/buttontrash.png" Height="32px" Width="32px" OnClientClick="return Sil();" BorderColor="GhostWhite" BorderStyle="Solid" BorderWidth="1px" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="BTumu" runat="server" ImageUrl="~/images/buttontumu.png" Height="32px" Width="32px" OnClientClick="return Degistir();" BorderColor="GhostWhite" BorderStyle="Solid" BorderWidth="1px" />
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
                                        <telerik:RadLabel ID="RadLabel2" runat="server" forecolor="White" CssClass="labelbox" Width="150px" Text="Kodu"></telerik:RadLabel>
                                    </td>
                                    <td style="width: 100%">
                                        <asp:TextBox ID="Kodu" runat="server" MaxLength="50" Width="200px" cssclass="textbox" Enabled="false" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel1" runat="server" forecolor="White" CssClass="labelbox" Width="150px" Text="Kodu2"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Kodu2" runat="server" MaxLength="50" Width="200px" cssclass="textbox" Enabled="false" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel5" runat="server" forecolor="White" CssClass="labelbox" Width="150px" Text="Açıklama"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Aciklama" runat="server" MaxLength="50" Width="200px" cssclass="textbox" Enabled="false" /></td>
                                </tr>

                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel3" runat="server" forecolor="White" CssClass="labelbox" Width="150px" Text="Yıllık İzin Başlangıç Tarihi"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <telerik:RadDatePicker ID="Tarih" runat="server" Culture="tr-TR" Width="100px" WrapperTableCaption="" AutoPostBack="False" Enabled="false">
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
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel4" runat="server" forecolor="White" CssClass="labelbox" Width="150px" Text="FM Onay Başlangıç Tarihi"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <telerik:RadDatePicker ID="Tarih2" runat="server" Culture="tr-TR" Width="100px" WrapperTableCaption="" AutoPostBack="False" Enabled="false">
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
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel6" runat="server" forecolor="White" CssClass="labelbox" Width="150px" Text="FM Onay Bitiş Tarihi"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <telerik:RadDatePicker ID="Tarih3" runat="server" Culture="tr-TR" Width="100px" WrapperTableCaption="" AutoPostBack="False" Enabled="false">
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
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 100%">
                        <td colspan="2" align="center" valign="top">
                            <asp:Label ID="Mesaj" runat="server" Font-Names="Calibri" Font-Size="14px" ForeColor="Red"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
