<%@ Page Language="C#" MasterPageFile="~/Sample.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>
<%-- Add content controls here --%>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="DetailsContent">
    &nbsp;&nbsp;
    <asp:LoginView ID="LoginView1" runat="server">
        <RoleGroups>
            <asp:RoleGroup Roles="Tester">
                <ContentTemplate>
                    Tester content
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
        <LoggedInTemplate>
            For known users
        </LoggedInTemplate>
        <AnonymousTemplate>
            For all users
        </AnonymousTemplate>
    </asp:LoginView>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="LeftContent">
    <div style="font-size=14">
    <asp:LoginView ID="MainLoginView" runat="server">
        <AnonymousTemplate>
            <asp:Login ID="InlineLoginControl" runat="server" DisplayRememberMe="False" Width="94px" BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" >
                <LayoutTemplate>
                    <table border="0" cellpadding="1">
                        <tbody>
                            <tr>
                                <td>
                                    <table border="0" cellpadding="0" style="width: 119px">
                                        <tbody>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    Log In</td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 79px; height: 40px">
                                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Width="100%">User Name:</asp:Label></td>
                                                <td style="width: 100px; height: 40px">
                                                    <asp:TextBox ID="UserName" runat="server" Width="88px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                        ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="InlineLoginControl">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 79px">
                                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label></td>
                                                <td style="width: 100px">
                                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="86px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                        ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="InlineLoginControl">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" style="color: red; height: 13px;">
                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="2">
                                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="InlineLoginControl" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
                <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px"
                    Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
                <TextBoxStyle Font-Size="0.8em" />
                <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
                <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            </asp:Login>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <asp:LoginName ID="MainLoginName" runat="server" />
            
        </LoggedInTemplate>
    </asp:LoginView>
    <br />
    <asp:HyperLink ID="MembersLink" runat="server" 
            NavigateUrl="~/SecureArea/SecurePage.aspx" Text="Secure Area" />
    </div>
</asp:Content>
<asp:Content ID="Content4" runat="server" ContentPlaceHolderID="RightContent">
    Welcome to the Membership API Test. Here you will find some information about the
    user:<br />
    <br />
    <asp:Label ID="UserInfoLabel" runat="server"></asp:Label><br />
    <br />
</asp:Content>
