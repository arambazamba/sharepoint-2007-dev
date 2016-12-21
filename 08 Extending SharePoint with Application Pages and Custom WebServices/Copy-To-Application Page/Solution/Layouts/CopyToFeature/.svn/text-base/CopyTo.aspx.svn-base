<%@ Assembly Name="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Assembly Name="CopyToFeature, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b8c1e1a21841a588" %>


<%@ Page Language="C#" MasterPageFile="~/_layouts/application.master" 
         Inherits="Integrations.CopyTo"
         EnableViewState="true" EnableViewStateMac="false" %>

<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
  Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>



<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" style="vertical-align: top" width="850">
            <tr>
                <td colspan="2" valign="top" style="height: 40px">
                                <asp:LinkButton ID="lbConnect" runat="server" OnClick="PopulateTree">Connect</asp:LinkButton>
                                |
                                <asp:LinkButton ID="lbCopy" runat="server" OnClick="CopyItem">Copy</asp:LinkButton></td>
            </tr>
            <tr>
                <td style="width: 400px; background-color: antiquewhite;" valign="top">
                    <table border="0" cellspacing="10" width="100%">
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label8" runat="server" Text="Site Collection"></asp:Label></td>
                            <td valign="top">
                                <asp:TextBox ID="txtSiteCol" runat="server" Width="250px">http://chiron</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label6" runat="server" Text="List Item"></asp:Label></td>
                            <td valign="top">
                                <asp:Label ID="lblListItem" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label10" runat="server" Text="Selected List"></asp:Label></td>
                            <td valign="top">
                                <asp:Label ID="lblList" runat="server" Width="250px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2" valign="top">
                                <asp:Label ID="lblStatus" runat="server" Width="350px"></asp:Label></td>
                        </tr>
                    </table>
                </td>
                <td style="width: 250px; background-color: antiquewhite;" valign="top">
                    <asp:TreeView ID="tvSite" runat="server" ImageSet="Simple" OnSelectedNodeChanged="NodeSelected" Width="250px">
                        <ParentNodeStyle Font-Bold="False" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                            VerticalPadding="0px" />
                        <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="0px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                    </asp:TreeView>
                </td>
            </tr>
        </table>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Integrations - Copy To Destination Feature
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea"
  runat="server">
    Please connect to choose your destination
</asp:Content>