<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    <asp:CreateUserWizard ID="MainWizard" runat="server" BackColor="#E3EAEB" BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" OnContinueButtonClick="goBack" >
        <SideBarStyle BackColor="#1C5E55" Font-Size="0.9em" VerticalAlign="Top" />
        <SideBarButtonStyle ForeColor="White" />
        <NavigationButtonStyle BackColor="White" BorderColor="#C5BBAF" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Verdana" ForeColor="#1C5E55" />
        <HeaderStyle BackColor="#666666" BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="2px"
            Font-Bold="True" Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />
        <CreateUserButtonStyle BackColor="White" BorderColor="#C5BBAF" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Verdana" ForeColor="#1C5E55" />
        <ContinueButtonStyle BackColor="White" BorderColor="#C5BBAF" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Verdana" ForeColor="#1C5E55" />
        <StepStyle BorderWidth="0px" />
        <TitleTextStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" EnableViewState="False">
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep runat="server" EnableViewState="False">
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
    </div>
    </form>
</body>
</html>
