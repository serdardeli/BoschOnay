<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BoschOnay.Master" CodeBehind="FMainPage2.aspx.vb" Inherits="BoschOnay.FMainPage2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 58px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="height: 100%; width: 100%;">
        <tr>
            <td>
                <div id="Filtre" runat="server" style="background-color: gainsboro; height: 100%; width: 100%; border: 1px solid lightgray">
                    <table style="width: 100%;">
                        <tr>
                            <td style="vertical-align: top;" class="auto-style1">
                                <telerik:RadLabel ID="LblSicilNo" runat="server" ForeColor="White" CssClass="labelbox" Width="160px" Text="Sicil No"></telerik:RadLabel>
                            </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="FltSicilNo" runat="server" Height="40px" TextMode="MultiLine"  Width="200px" Font-Names="Segoe UI" Font-Size="12px" /></td>

                            <td colspan="10" class="auto-style1">
                                <table>
                                    <tr>
                                        <td>
                                            <telerik:RadLabel ID="LblGrp1" runat="server" ForeColor="White" CssClass="labelbox" Width="160px" Text="LblGrp1"></telerik:RadLabel>
                                        </td>

                                        <td>
                                            <telerik:RadComboBox ID="FltGrp1" runat="server" CheckBoxes="true" Filter="Contains" Width="200px" Font-Names="Segoe UI" Font-Size="12px" Height="300px"></telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <telerik:RadLabel ID="LblGrp4" runat="server" ForeColor="White" CssClass="labelbox" Width="160px" Text="LblGrp4"></telerik:RadLabel>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="FltGrp4" runat="server" CheckBoxes="true" Filter="Contains" Width="200px" Font-Names="Segoe UI" Font-Size="12px" Height="300px"></telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <telerik:RadLabel ID="LblGrp7" runat="server" ForeColor="White" CssClass="labelbox" Width="160px" Text="LblGrp7"></telerik:RadLabel>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="FltGrp7" runat="server" CheckBoxes="true" Filter="Contains" Width="200px" Font-Names="Segoe UI" Font-Size="12px" Height="300px"></telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <telerik:RadLabel ID="LblGrp2" runat="server" ForeColor="White" CssClass="labelbox" Width="160px" Text="LblGrp2"></telerik:RadLabel>
                                        </td>

                                        <td>
                                            <telerik:RadComboBox ID="FltGrp2" runat="server" CheckBoxes="true" Filter="Contains" Width="200px" Font-Names="Segoe UI" Font-Size="12px" Height="300px"></telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <telerik:RadLabel ID="LblGrp5" runat="server" ForeColor="White" CssClass="labelbox" Width="160px" Text="LblGrp5"></telerik:RadLabel>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="FltGrp5" runat="server" CheckBoxes="true" Filter="Contains" Width="200px" Font-Names="Segoe UI" Font-Size="12px" Height="300px" EnableCheckAllItemsCheckBox="false"></telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>

                        </tr>
                        <tr>
                            <td>
                                <telerik:RadLabel ID="LblAdSoyad" runat="server" ForeColor="White" CssClass="labelbox" Width="160px" Text="Adı ve Soyadı"></telerik:RadLabel>
                            </td>
                            <td>
                                <asp:TextBox ID="FltAdSoyad" runat="server" MaxLength="50" Width="200px" Font-Names="Segoe UI" Font-Size="12px" /></td>
                            <td>
                                <telerik:RadLabel ID="LblGrp0" runat="server" ForeColor="White" CssClass="labelbox" Width="160px" Text="LblGrp0"></telerik:RadLabel>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="FltGrp0" runat="server" CheckBoxes="true" Filter="Contains" Width="200px" Font-Names="Segoe UI" Font-Size="12px" Height="300px"></telerik:RadComboBox>
                            </td>
                            <td>
                                <telerik:RadLabel ID="LblGrp3" runat="server" ForeColor="White" CssClass="labelbox" Width="160px" Text="LblGrp3"></telerik:RadLabel>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="FltGrp3" runat="server" CheckBoxes="true" Filter="Contains" Width="200px" Font-Names="Segoe UI" Font-Size="12px" Height="300px"></telerik:RadComboBox>
                            </td>
                            <td>
                                <telerik:RadLabel ID="LblGrp6" runat="server" ForeColor="White" CssClass="labelbox" Width="160px" Text="LblGrp6"></telerik:RadLabel>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="FltGrp6" runat="server" CheckBoxes="true" Filter="Contains" Width="200px" Font-Names="Segoe UI" Font-Size="12px" Height="300px"></telerik:RadComboBox>
                            </td>

                            <td colspan="2" rowspan="2" align="right" style="width: 100%">
                                <asp:ImageButton ID="ClearFilter" runat="server" ImageUrl="~/images/buttonfilter.png" Height="32px" Width="32px" BorderColor="GhostWhite" BorderStyle="Solid" BorderWidth="1px" />&nbsp;&nbsp;&nbsp;
                                <asp:ImageButton ID="Yenile" runat="server" ImageUrl="~/images/buttonrefresh.png" Height="32px" Width="32px" BorderColor="GhostWhite" BorderStyle="Solid" BorderWidth="1px" /></td>

                        </tr> 
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td style="height: 100%">
                <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" Width="100%" Height="100%"
                    AllowMultiRowSelection="False" ShowGroupPanel="True">
                    <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="False" AllowDragToGroup="True">
                        <Scrolling AllowScroll="true" UseStaticHeaders="true" FrozenColumnsCount="1" />
                    </ClientSettings>
                    <GroupingSettings ShowUnGroupButton="true" RetainGroupFootersVisibility="true" CaseSensitive="false"></GroupingSettings>
                    <MasterTableView ShowGroupFooter="true" AutoGenerateColumns="False">
                        <RowIndicatorColumn Visible="False">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Created="True">
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="Per_PersNr" HeaderText="SicilNo" UniqueName="Per_PersNr"
                                Groupable="false" HeaderStyle-Width="100px" />
                            <telerik:GridBoundColumn DataField="PersName" HeaderText="Adı ve Soyadı" UniqueName="PersName"
                                Groupable="false" HeaderStyle-Width="200px" />
                            <telerik:GridBoundColumn DataField="Per_Grp0" HeaderText="Per_Grp0" UniqueName="Per_Grp0" />
                            <telerik:GridBoundColumn DataField="Per_Grp1" HeaderText="Per_Grp1" UniqueName="Per_Grp1" />
                            <telerik:GridBoundColumn DataField="Per_Grp2" HeaderText="Per_Grp2" UniqueName="Per_Grp2" />
                            <telerik:GridBoundColumn DataField="Per_Grp3" HeaderText="Per_Grp3" UniqueName="Per_Grp3" />
                            <telerik:GridBoundColumn DataField="Per_Grp4" HeaderText="Per_Grp4" UniqueName="Per_Grp4" />
                            <telerik:GridBoundColumn DataField="Per_Grp5" HeaderText="Per_Grp5" UniqueName="Per_Grp5" />
                            <telerik:GridBoundColumn DataField="Per_Grp6" HeaderText="Per_Grp6" UniqueName="Per_Grp6" />
                            <telerik:GridBoundColumn DataField="Per_Grp7" HeaderText="Per_Grp7" UniqueName="Per_Grp7" />
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="HiddenField0" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:HiddenField ID="HiddenField3" runat="server" />
    <asp:HiddenField ID="HiddenField4" runat="server" />
    <asp:HiddenField ID="HiddenField5" runat="server" />
    <asp:HiddenField ID="HiddenField6" runat="server" />
    <asp:HiddenField ID="HiddenField7" runat="server" />
</asp:Content>
