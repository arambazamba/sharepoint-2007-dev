
Partial Class listusers
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mylist As String = ""
        Response.Write("Current Membership Users are:<br>")
        For Each user As MembershipUser In Membership.GetAllUsers
            mylist += user.UserName & "<br>"
        Next
        Response.Write(mylist)

    End Sub
End Class
