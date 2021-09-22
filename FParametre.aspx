<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BoschOnay.Master" CodeBehind="FParametre.aspx.vb" Inherits="BoschOnay.FParametre" %>

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
            function SelectedItemCLR(source) {
                source.style.backgroundColor = source.options[source.selectedIndex].innerText;
            }
        </script>
    </telerik:RadScriptBlock>

    <table style="height: 100%; width: 100%">
        <tr>
            <td align="left" class="baslik"><asp:Label ID="BBaslik" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <table style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: lighter;">
                    <tr>
                        <td>
                            <telerik:RadLabel ID="RadLabel2" runat="server" Width="200px" Text="Firma adı" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="Firma" runat="server" MaxLength="50" Width="300px" CssClass="textbox" /></td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadLabel ID="RadLabel1" runat="server" Width="200px" Text="Lisans sayısı" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="Lisans" runat="server" Culture="tr-TR" DbValueFactor="1" LabelWidth="64px" MinValue="0" Width="100px" Height="20px">
                                <NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                            </telerik:RadNumericTextBox></td>
                        <td>
                            <telerik:RadLabel ID="RadLabel21" runat="server" Width="200px" Text="Cumartesi günü rengi" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                        </td>
                        <td align="left" style="width: 100%">
                            <asp:DropDownList ID="bCmtRenk" runat="server" CssClass="dropdownmenu" Width="150px" onchange="SelectedItemCLR(this)">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadLabel ID="RadLabel3" runat="server" Width="200px" Text="Giriş şekli" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                        </td>
                        <td>
                            <asp:DropDownList ID="LoginUser" runat="server" Width="200px" CssClass="dropdownmenu">
                                <asp:ListItem Text="Standart" />
                                <asp:ListItem Text="Windows" />
                                <asp:ListItem Text="LDAP" />
                            </asp:DropDownList></td>
                        <td>
                            <telerik:RadLabel ID="RadLabel20" runat="server" Width="200px" Text="Pazar günü rengi" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="bPazRenk" runat="server" CssClass="dropdownmenu" Width="150px" onchange="SelectedItemCLR(this)">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadLabel ID="RadLabel4" runat="server" Width="200px" Text="İşlem sınırı" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="IslemGun" runat="server" Culture="tr-TR" DbValueFactor="1" LabelWidth="64px" MinValue="0" Width="100px" Height="20px">
                                <NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                            </telerik:RadNumericTextBox>
                            gün</td>
                        <td>
                            <telerik:RadLabel ID="RadLabel19" runat="server" Width="200px" Text="Resmi tatil rengi" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="bRestaRenk" runat="server" CssClass="dropdownmenu" Width="150px" onchange="SelectedItemCLR(this)">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadLabel ID="RadLabel5" runat="server" Width="200px" Text="Planlama geçmişi" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="PlanGun" runat="server" Culture="tr-TR" DbValueFactor="1" LabelWidth="64px" MinValue="0" Width="100px" Height="20px">
                                <NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                            </telerik:RadNumericTextBox>
                            gün</td>
                        <td>
                            <telerik:RadLabel ID="RadLabel18" runat="server" Width="200px" Text="Onaylama rengi" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="bOnayRenk" runat="server" CssClass="dropdownmenu" Width="150px" onchange="SelectedItemCLR(this)">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadLabel ID="RadLabel6" runat="server" Width="200px" Text="Puantaj aktarımı" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                        </td>
                        <td>
                            <asp:DropDownList ID="Puantaj" runat="server" Width="200px" CssClass="dropdownmenu">
                                <asp:ListItem Text="Puantaj'a aktarma" />
                                <asp:ListItem Text="Puantaj'a aktar" />
                            </asp:DropDownList></td>
                        <td>
                            <telerik:RadLabel ID="RadLabel17" runat="server" Width="200px" Text="Geçmiş günler rengi" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="bGecmisRenk" runat="server" CssClass="dropdownmenu" Width="150px" onchange="SelectedItemCLR(this)">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadLabel ID="RadLabel7" runat="server" Width="200px" Text="Sayılacak vardiyalar" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                        </td>
                        <td>
                            <asp:TextBox ID="VardiyaSay" runat="server" MaxLength="50" Width="200px" CssClass="textbox" /></td>
                        <td>
                            <telerik:RadLabel ID="RadLabel16" runat="server" Width="200px" Text="Kilitli günler rengi" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="bKilitRenk" runat="server" CssClass="dropdownmenu" Width="150px" onchange="SelectedItemCLR(this)">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadLabel ID="RadLabel8" runat="server" Width="200px" Text="Kilit ekranı bekleme süresi" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="Kilit" runat="server" Culture="tr-TR" DbValueFactor="1" LabelWidth="64px" MinValue="0" Width="100px" Height="20px" AutoPostBack="true" Enabled="false">
                                <NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                            </telerik:RadNumericTextBox>
                            dakika</td>
                        <td>
                            <telerik:RadLabel ID="RadLabel15" runat="server" Width="200px" Text="Plansız FM rengi" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="bPsizFMRenk" runat="server" CssClass="dropdownmenu" Width="150px" onchange="SelectedItemCLR(this)">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadLabel ID="RadLabel9" runat="server" Width="200px" CssClass="labelbox" ForeColor="White" Text="Modüller"></telerik:RadLabel>
                        </td>
                        <td colspan="3">
                            <asp:CheckBoxList ID="Moduller" runat="server" RepeatDirection="Horizontal" ForeColor="Black" CssClass="dropdownmenu">
                                <asp:ListItem Text="Vardiya" />
                                <asp:ListItem Text="Mazeret" />
                                <asp:ListItem Text="Fazla Mesai" />
                                <asp:ListItem Text="Masraf Merkezi" />
                                <asp:ListItem Text="Görev Kodu" />
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadLabel ID="RadLabel10" runat="server" Width="200px" Text="Saat dilimi M/FM/MM" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="MZDilim" runat="server" Width="100px" CssClass="dropdownmenu">
                                <asp:ListItem Text="TamSaat" />
                                <asp:ListItem Text="Yarım Saat" />
                                <asp:ListItem Text="Çeyrek Saat" />
                            </asp:DropDownList>
                            &nbsp;<asp:DropDownList ID="FMDilim" runat="server" Width="100px" CssClass="dropdownmenu">
                                <asp:ListItem Text="TamSaat" />
                                <asp:ListItem Text="Yarım Saat" />
                                <asp:ListItem Text="Çeyrek Saat" />
                            </asp:DropDownList>
                            &nbsp;<asp:DropDownList ID="MMDilim" runat="server" Width="100px" CssClass="dropdownmenu">
                                <asp:ListItem Text="TamSaat" />
                                <asp:ListItem Text="Yarım Saat" />
                                <asp:ListItem Text="Çeyrek Saat" />
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadLabel ID="RadLabel11" runat="server" Width="200px" Text="Denkleştirme FM1, FM2, FM3" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="FM1" runat="server" MaxLength="5" Width="70px" CssClass="textbox" />
                            &nbsp;<asp:TextBox ID="FM2" runat="server" MaxLength="5" Width="70px" CssClass="textbox" />
                            &nbsp;<asp:TextBox ID="FM3" runat="server" MaxLength="5" Width="70px" CssClass="textbox" />
                            &nbsp;<telerik:RadLabel ID="RadLabel12" runat="server" Width="70px" Text="Esnek İzin" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                            <asp:TextBox ID="ESNEK" runat="server" MaxLength="5" Width="70px" CssClass="textbox" />
                            <telerik:RadLabel ID="RadLabel13" runat="server" Width="70px" Text="NCAL" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                            <asp:TextBox ID="NCAL" runat="server" MaxLength="5" Width="70px" CssClass="textbox" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadLabel ID="RadLabel14" runat="server" Width="200px" Text="Onaylanan FM1, FM2, FM3" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="vFM1" runat="server" MaxLength="5" Width="70px" CssClass="textbox" />
                            &nbsp;<asp:TextBox ID="vFM2" runat="server" MaxLength="5" Width="70px" CssClass="textbox" />
                            &nbsp;<asp:TextBox ID="vFM3" runat="server" MaxLength="5" Width="70px" CssClass="textbox" />
                        </td>
                    </tr>
                    <tr style="background-color: cornflowerblue; color: white; border: none; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: lighter">
                        <td colspan="4">Filtre tanımları</td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <table>
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel22" runat="server" Width="30px" Text="Sıra" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel24" runat="server" Width="150px" Text="Başlığı" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel25" runat="server" Width="250px" Text="Alan Adı" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel23" runat="server" Width="30px" Text="Sıra" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel26" runat="server" Width="150px" Text="Başlığı" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel27" runat="server" Width="250px" Text="Alan Adı" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel28" runat="server" Width="30px" Text="01" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="GrpName00" runat="server" MaxLength="30" Width="150px" CssClass="textbox" /></td>
                                    <td>
                                        <asp:TextBox ID="Grp00" runat="server" MaxLength="255" Width="250px" CssClass="textbox" /></td>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel31" runat="server" Width="30px" Text="11" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="GrpName10" runat="server" MaxLength="30" Width="150px" CssClass="textbox" /></td>
                                    <td>
                                        <asp:TextBox ID="Grp10" runat="server" MaxLength="255" Width="250px" CssClass="textbox" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel29" runat="server" Width="30px" Text="02" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="GrpName01" runat="server" MaxLength="30" Width="150px" CssClass="textbox" /></td>
                                    <td>
                                        <asp:TextBox ID="Grp01" runat="server" MaxLength="255" Width="250px" CssClass="textbox" /></td>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel30" runat="server" Width="30px" Text="12" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="GrpName11" runat="server" MaxLength="30" Width="150px" CssClass="textbox" /></td>
                                    <td>
                                        <asp:TextBox ID="Grp11" runat="server" MaxLength="255" Width="250px" CssClass="textbox" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel32" runat="server" Width="30px" Text="03" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="GrpName02" runat="server" MaxLength="30" Width="150px" CssClass="textbox" /></td>
                                    <td>
                                        <asp:TextBox ID="Grp02" runat="server" MaxLength="255" Width="250px" CssClass="textbox" /></td>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel33" runat="server" Width="30px" Text="13" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="GrpName12" runat="server" MaxLength="30" Width="150px" CssClass="textbox" /></td>
                                    <td>
                                        <asp:TextBox ID="Grp12" runat="server" MaxLength="255" Width="250px" CssClass="textbox" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel34" runat="server" Width="30px" Text="04" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="GrpName03" runat="server" MaxLength="30" Width="150px" CssClass="textbox" /></td>
                                    <td>
                                        <asp:TextBox ID="Grp03" runat="server" MaxLength="255" Width="250px" CssClass="textbox" /></td>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel35" runat="server" Width="30px" Text="13" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="GrpName13" runat="server" MaxLength="30" Width="150px" CssClass="textbox" /></td>
                                    <td>
                                        <asp:TextBox ID="Grp13" runat="server" MaxLength="255" Width="250px" CssClass="textbox" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel36" runat="server" Width="30px" Text="05" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="GrpName04" runat="server" MaxLength="30" Width="150px" CssClass="textbox" /></td>
                                    <td>
                                        <asp:TextBox ID="Grp04" runat="server" MaxLength="255" Width="250px" CssClass="textbox" /></td>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel37" runat="server" Width="30px" Text="15 N" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="GrpName14" runat="server" MaxLength="30" Width="150px" CssClass="textbox" /></td>
                                    <td>
                                        <asp:TextBox ID="Grp14" runat="server" MaxLength="255" Width="250px" CssClass="textbox" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel38" runat="server" Width="30px" Text="06" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="GrpName05" runat="server" MaxLength="30" Width="150px" CssClass="textbox" /></td>
                                    <td>
                                        <asp:TextBox ID="Grp05" runat="server" MaxLength="255" Width="250px" CssClass="textbox" /></td>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel39" runat="server" Width="30px" Text="16 N" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="GrpName15" runat="server" MaxLength="30" Width="150px" CssClass="textbox" /></td>
                                    <td>
                                        <asp:TextBox ID="Grp15" runat="server" MaxLength="255" Width="250px" CssClass="textbox" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel40" runat="server" Width="30px" Text="07" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="GrpName06" runat="server" MaxLength="30" Width="150px" CssClass="textbox" /></td>
                                    <td>
                                        <asp:TextBox ID="Grp06" runat="server" MaxLength="255" Width="250px" CssClass="textbox" /></td>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel41" runat="server" Width="30px" Text="17 N" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="GrpName16" runat="server" MaxLength="30" Width="150px" CssClass="textbox" /></td>
                                    <td>
                                        <asp:TextBox ID="Grp16" runat="server" MaxLength="255" Width="250px" CssClass="textbox" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel42" runat="server" Width="30px" Text="08" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="GrpName07" runat="server" MaxLength="30" Width="150px" CssClass="textbox" /></td>
                                    <td>
                                        <asp:TextBox ID="Grp07" runat="server" MaxLength="255" Width="250px" CssClass="textbox" /></td>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel43" runat="server" Width="30px" Text="18 D" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="GrpName17" runat="server" MaxLength="30" Width="150px" CssClass="textbox" /></td>
                                    <td>
                                        <asp:TextBox ID="Grp17" runat="server" MaxLength="255" Width="250px" CssClass="textbox" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel44" runat="server" Width="30px" Text="09" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="GrpName08" runat="server" MaxLength="30" Width="150px" CssClass="textbox" /></td>
                                    <td>
                                        <asp:TextBox ID="Grp08" runat="server" MaxLength="255" Width="250px" CssClass="textbox" /></td>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel45" runat="server" Width="30px" Text="19 D" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="GrpName18" runat="server" MaxLength="30" Width="150px" CssClass="textbox" /></td>
                                    <td>
                                        <asp:TextBox ID="Grp18" runat="server" MaxLength="255" Width="250px" CssClass="textbox" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel46" runat="server" Width="30px" Text="10" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="GrpName09" runat="server" MaxLength="30" Width="150px" CssClass="textbox" /></td>
                                    <td>
                                        <asp:TextBox ID="Grp09" runat="server" MaxLength="255" Width="250px" CssClass="textbox" /></td>
                                    <td>
                                        <telerik:RadLabel ID="RadLabel47" runat="server" Width="30px" Text="20 D" CssClass="labelbox" ForeColor="White"></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="GrpName19" runat="server" MaxLength="30" Width="150px" CssClass="textbox" /></td>
                                    <td>
                                        <asp:TextBox ID="Grp19" runat="server" MaxLength="255" Width="250px" CssClass="textbox" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            <asp:ImageButton ID="BKaydet" runat="server" ImageUrl="~/images/buttonaccept.png" Height="32px" Width="32px" Visible="False" OnClientClick="return Kaydet();" BorderColor="GhostWhite" BorderStyle="Solid" BorderWidth="1px" /></td>
                    </tr>
                    <tr style="height: 100%">
                        <td align="center" valign="top" colspan="4">
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
