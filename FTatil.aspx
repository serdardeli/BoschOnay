<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BoschOnay.Master" CodeBehind="FTatil.aspx.vb" Inherits="BoschOnay.FTatil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .RadInput_Default {
            font: 12px "segoe ui",arial,sans-serif
        }

        .RadInput {
            vertical-align: middle
        }

            .RadInput .riTextBox {
                height: 17px
            }

        .auto-style1 {
            border-collapse: collapse;
            width: 100%;
            vertical-align: bottom;
            border-style: none;
            border-color: inherit;
            border-width: 0;
        }

        .auto-style2 {
            width: 100%;
            padding-right: 4px;
        }
    </style>
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
            <td align="left" colspan="2" class="baslik">
                <asp:Label ID="BBaslik" runat="server"></asp:Label></td>
        </tr>
        <tr style="height: 100%">
            <td valign="top">
                <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" Width="480px" Height="100%" AutoGenerateColumns="False"
                    AllowMultiRowSelection="False">
                    <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="true" />
                        <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                    </ClientSettings>
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="Gun" HeaderText="Gun" UniqueName="Gun" HeaderStyle-Width="60px" ReadOnly="true" />
                            <telerik:GridBoundColumn DataField="Ay" HeaderText="Ay" UniqueName="Ay" HeaderStyle-Width="60px" ReadOnly="true" />
                            <telerik:GridBoundColumn DataField="Yil" HeaderText="Yıl" UniqueName="Yil" HeaderStyle-Width="60px" ReadOnly="true" />
                            <telerik:GridBoundColumn DataField="Aciklama" HeaderText="Açıklama" UniqueName="Aciklama" HeaderStyle-Width="200px" ReadOnly="true" />
                            <telerik:GridBoundColumn DataField="IdNr" HeaderText="IdNr" UniqueName="IdNr" HeaderStyle-Width="80px" ReadOnly="true" Display="false" />
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
                                        <telerik:RadLabel ID="RadLabel5" runat="server" ForeColor="White" CssClass="labelbox" Width="150px" Text="Gün"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="Gun" runat="server" Culture="tr-TR" DbValueFactor="1" LabelWidth="64px" MinValue="0" Width="50px" Height="20px" Enabled="false">
                                            <NumberFormat ZeroPattern="n" DecimalDigits="0" GroupSeparator=""></NumberFormat>
                                        </telerik:RadNumericTextBox>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel1" runat="server" ForeColor="White" CssClass="labelbox" Width="150px" Text="Ay"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <telerik:RadNumericTextBox ID="Ay" runat="server" Culture="tr-TR" DbValueFactor="1" LabelWidth="64px" MinValue="0" Width="50px" Height="20px" Enabled="false">
                                            <NumberFormat ZeroPattern="n" DecimalDigits="0" GroupSeparator=""></NumberFormat>
                                        </telerik:RadNumericTextBox>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel2" runat="server" ForeColor="White" CssClass="labelbox" Width="150px" Text="Yıl"></telerik:RadLabel>
                                    </td>
                                    <td style="width: 100%">
                                        <telerik:RadNumericTextBox ID="Yil" runat="server" Culture="tr-TR" DbValueFactor="1" LabelWidth="64px" MinValue="0" Width="50px" Height="20px" Enabled="false">
                                            <NumberFormat ZeroPattern="n" DecimalDigits="0" GroupSeparator=""></NumberFormat>
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>



                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel3" runat="server" ForeColor="White" CssClass="labelbox" Width="150px" Text="Açıklama"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Aciklama" runat="server" MaxLength="50" Width="200px" Enabled="false" CssClass="textbox" />
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
    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>
