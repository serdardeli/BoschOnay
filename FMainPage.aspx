﻿d<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BoschOnay.Master" CodeBehind="FMainPage.aspx.vb" Inherits="BoschOnay.FMainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function listBoxLoad(sender, args) {
                // reference to the ListBox
                var listBoxElement = $telerik.$(sender.get_element());
                //listBoxElement.find('input[id$="filterCheckListSearch"]').on('keyup', function () {
                //    debugger;
                //});
                // reference to the List Group
                var listBoxGroup = listBoxElement.find('.rlbGroup');
                // create a custom Check All Checkbox and add it to the list group
                listBoxGroup.prepend('<div class="myChekAllCheckBox" style="display: none;"><label><input type="checkbox" class="customCheckAll">Check All</label></div>');

                // wire up the change event to the Custom Check All Checkbox.
                // when changed, execute the script inside the function
                listBoxGroup.find('.customCheckAll').change(function (e) {
                    // find only the visible listbox items (li)
                    var lbItems = listBoxGroup.find('.rlbList li:visible');
                    // find the checkboxes within the visible listbox items and check/uncheck them based on the Check All Checkbox state
                    lbItems.find('input').prop('checked', this.checked);

                    if (this.checked) {
                        // uncheck other items
                        listBoxGroup.find('.rlbList li:hidden input').prop('checked', false);
                    }
                });

                // attach the following two events - For the Show Loading indicator functionality
                sender.add_itemsRequested(hideLbLoadingSign);
                sender.add_itemsRequestFailed(hideLbLoadingSign);
            }

            function hideLbLoadingSign(sender, args) {
                //remove the custom loading sign class
                $telerik.$(sender.get_element()).find(".rlbGroup").first().removeClass("lbLoadingSign");
                // show the check all checkbox
                $telerik.$(sender.get_element()).find(".rlbGroup .myChekAllCheckBox").first().show();
            }

            function showLoadingSign(sender, args) {
                //add the custom loading sign class
                $telerik.$(sender.get_childListElement()).find(".rlbGroup").first().addClass("lbLoadingSign");
            }

            function OnClientHidden(sender, args) {
                // Optional: hide the Check All checkbox when the menu closed

                // selector to select all occurences of .RadMenu.myCheckAllCheckBox on the page
                $telerik.$(".RadMenu .rgHCMFilter .RadListBox .myChekAllCheckBox").hide();

                // get reference to RadGrid this ContextMenu belongs.
                var currentRadGrid = sender.get_parent();

                // selector to select only the myCheckAllCheckBox that belongs to the current RadGrid firing opening this ContextMenu.
                $telerik.$(".RadMenu[id^='" + currentRadGrid.ClientID + "'] .rgHCMFilter .RadListBox .myChekAllCheckBox").hide();
            }
            // handle filtering
            Telerik.Web.UI.Grid.FilterSearch = function (grid, input) {
                var ListBox = $telerik.$('#' + grid._filterCheckListClientID)
                // hide all as soon as start searching
                ListBox.find('.rlbList li').hide();
                // show only search results


                var visibleItems = ListBox.find('.rlbList li').filter(function (index) {
                    return $(this).text().toLowerCase().indexOf(input.value.toLowerCase()) > -1;
                    //return index % 3 === 2;
                })

                visibleItems.show();


                //var visibleItems = ListBox.find('.rlbList li:contains(' + input.value.toLowerCase() + ')').show();

                var visibleItemsCount = visibleItems.length;
                var checkedItemsCount = visibleItems.find('input[type="checkbox"]:checked').length;
                // Check/Uncheck the CheckAll checkbox whether all visible items on the list are checked
                ListBox.find('.myChekAllCheckBox input[type="checkbox"]').prop('checked', visibleItemsCount > 0 && visibleItemsCount == checkedItemsCount);
            }

            // handle per item check
            // store a reference to the original method
            var original = Telerik.Web.UI.RadListBox.prototype._onCheck;
            // override the original method
            Telerik.Web.UI.RadListBox.prototype._onCheck = function (e, targetItem) {
                var ListBox = $(this.get_element());

                // condition check if ListBox is part of the HeaderContextFilterMenu of RadGrid
                if (ListBox.closest('.rgHCMFilter').length < 1) {
                    // if not, call the original method stored above
                    original.call(this, e, targetItem);
                    // exit the function to prevent the excution of further logic
                    return;
                }

                // logic below will only be executed if the ListBox is part of the HeaderContextFilterMenu of RadGrid.

                var visibleItems = ListBox.find('.rlbList li:visible');

                var visibleItemsCount = visibleItems.length;
                var checkedItemsCount = visibleItems.find('input[type="checkbox"]:checked').length;

                // Check/Uncheck the CheckAll checkbox whether all visible items on the list are checked
                ListBox.find('.myChekAllCheckBox input[type="checkbox"]').prop('checked', visibleItemsCount > 0 && visibleItemsCount == checkedItemsCount);
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" Width="100%" Height="100%" 
        AllowFilteringByColumn="True" AllowMultiRowSelection="False" ShowGroupPanel="True"
        FilterType="HeaderContext"
        EnableHeaderContextMenu="true"
        EnableHeaderContextFilterMenu="true">
        <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="False" AllowDragToGroup="True">
            <Scrolling AllowScroll="true" UseStaticHeaders="true" FrozenColumnsCount="1" />
        </ClientSettings>
        <HeaderContextMenu OnClientShown="showLoadingSign" OnClientHidden="OnClientHidden" ExpandAnimation-Duration="0" />
        <GroupingSettings ShowUnGroupButton="true" RetainGroupFootersVisibility="true" CaseSensitive="false"></GroupingSettings>
        <MasterTableView ShowGroupFooter="true" AutoGenerateColumns="False">
            <RowIndicatorColumn Visible="False">
            </RowIndicatorColumn>
            <ExpandCollapseColumn Created="True">
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="Per_PersNr" HeaderText="SicilNo" UniqueName="Per_PersNr"
                    ShowFilterIcon="True" Groupable="false" HeaderStyle-Width="100px" FilterCheckListEnableLoadOnDemand="true" CurrentFilterFunction="EqualTo" />
                <telerik:GridBoundColumn DataField="PersName" HeaderText="Adı ve Soyadı" UniqueName="PersName"
                    ShowFilterIcon="False" CurrentFilterFunction="Contains" Groupable="false" HeaderStyle-Width="200px" />
                <telerik:GridBoundColumn DataField="Per_Grp0" HeaderText="Per_Grp0" UniqueName="Per_Grp0"
                    ShowFilterIcon="True" FilterCheckListEnableLoadOnDemand="true" CurrentFilterFunction="Contains" />
                <telerik:GridBoundColumn DataField="Per_Grp1" HeaderText="Per_Grp1" UniqueName="Per_Grp1"
                    ShowFilterIcon="True" FilterCheckListEnableLoadOnDemand="true" CurrentFilterFunction="Contains" />
                <telerik:GridBoundColumn DataField="Per_Grp2" HeaderText="Per_Grp2" UniqueName="Per_Grp2"
                    ShowFilterIcon="True" FilterCheckListEnableLoadOnDemand="true" CurrentFilterFunction="Contains" />
                <telerik:GridBoundColumn DataField="Per_Grp3" HeaderText="Per_Grp3" UniqueName="Per_Grp3"
                    ShowFilterIcon="True" FilterCheckListEnableLoadOnDemand="true" CurrentFilterFunction="Contains" />
                <telerik:GridBoundColumn DataField="Per_Grp4" HeaderText="er_Grp4" UniqueName="Per_Grp4"
                    ShowFilterIcon="True" FilterCheckListEnableLoadOnDemand="true" CurrentFilterFunction="Contains" />
                <telerik:GridBoundColumn DataField="Per_Grp5" HeaderText="Per_Grp5" UniqueName="Per_Grp5"
                    ShowFilterIcon="True" FilterCheckListEnableLoadOnDemand="true" CurrentFilterFunction="Contains" />
                <telerik:GridBoundColumn DataField="Per_Grp6" HeaderText="Per_Grp6" UniqueName="Per_Grp6"
                    ShowFilterIcon="True" FilterCheckListEnableLoadOnDemand="true" CurrentFilterFunction="Contains" />
                <telerik:GridBoundColumn DataField="Per_Grp7" HeaderText="Per_Grp7" UniqueName="Per_Grp7"
                    ShowFilterIcon="True" FilterCheckListEnableLoadOnDemand="true" CurrentFilterFunction="Contains" />
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</asp:Content>
