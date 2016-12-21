<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SiteDirectory.ascx.cs" Inherits="SiteDirectory" %>
<table border="0" cellspacing="15" style="width: 100%">
    <tr>
        <td rowspan="1" style="width: 30%" valign="top">
            <strong>Sites</strong></td>
        <td style="width: 50%" valign="top">
            <strong>Description</strong></td>
    </tr>
    <tr>
        <td rowspan="4" style="width: 30%" valign="top">
            <asp:GridView ID="gvSites" runat="server" AutoGenerateColumns="False" CellPadding="4"
                ForeColor="#333333" GridLines="None" OnSelectedIndexChanging="GetSelectedWeb" ShowHeader="False">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:BoundField DataField="Sitename" HeaderText="Available Sites">
                        <ItemStyle Width="100%" />
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:CommandField SelectText="Details" ShowSelectButton="True" />
                </Columns>
                <RowStyle BackColor="#EFF3FB" />
                <EditRowStyle BackColor="#2461BF" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </td>
        <td style="width: 50%" valign="top">
            <asp:Label ID="lblDescr" runat="server" Height="40px" Width="100%"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 50%" valign="top">
            <strong>Site Type</strong></td>
    </tr>
    <tr>
        <td style="width: 50%" valign="top">
        </td>
    </tr>
    <tr>
        <td style="width: 50%" valign="top">
            <asp:GridView ID="gvLists" runat="server" AutoGenerateColumns="False" CellPadding="4"
                ForeColor="#333333" GridLines="None" Width="100%">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:BoundField DataField="Listname" HeaderText="List / Library">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Listtype" HeaderText="Type">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                </Columns>
                <RowStyle BackColor="#EFF3FB" />
                <EditRowStyle BackColor="#2461BF" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </td>
    </tr>
</table>
