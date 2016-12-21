<%@ Control Language="C#" ClassName="HelloSmartPart" %>

<script runat="server">

    protected void Button1_Click(object sender, EventArgs e)
    {
        Button1.Text = "The SmartPart is alive!!";
    }
</script>

If you can read this, the Return of the SmartPart is successfully installed!<br />
<br />
<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Click me!" />
