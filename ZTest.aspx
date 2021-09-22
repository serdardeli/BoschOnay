<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ZTest.aspx.vb" Inherits="BoschOnay.ZTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">  
        function SelectedItemCLR(source) {
            source.style.backgroundColor = source.options[source.selectedIndex].innerText;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <telerik:RadColorPicker ID="CmtRenk" runat="server" PaletteModes="WebPalette" ShowIcon="True" Width="100px" NoColorText="Seçilmedi" AutoPostBack="true"></telerik:RadColorPicker>
            <asp:DropDownList ID="DropDownList1" runat="server" onchange="SelectedItemCLR(this)">
            </asp:DropDownList><br />
            <telerik:RadLabel ID="RadLabel1" runat="server"></telerik:RadLabel>
            <br />
            <telerik:RadLabel ID="RadLabel2" runat="server"></telerik:RadLabel>
            <br />
            <telerik:RadLabel ID="RadLabel3" runat="server"></telerik:RadLabel>
            <br />
            <telerik:RadLabel ID="RadLabel4" runat="server"></telerik:RadLabel>
            <br />
            <telerik:RadLabel ID="RadLabel5" runat="server"></telerik:RadLabel>
            <br />
            <telerik:RadLabel ID="RadLabel6" runat="server"></telerik:RadLabel>
            <br />
            <telerik:RadLabel ID="RadLabel7" runat="server"></telerik:RadLabel>
            <br />
            <telerik:RadLabel ID="RadLabel8" runat="server"></telerik:RadLabel>
            <br />

        </div>
    </form>
</body>
</html>
