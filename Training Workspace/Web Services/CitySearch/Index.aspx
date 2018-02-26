<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Facebook.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   
    <form id="form1" runat="server">


        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


        <div>
            <asp:Label ID="lblfriend" runat="server" Text="Search Friend"></asp:Label>
            <asp:TextBox ID="txtfriend" runat="server"></asp:TextBox>
            <%--<ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" ServicePath="http://localhost:1773/FriendService.asmx/" ServiceMethod="GetFriendList" TargetControlID="txtfriend" MinimumPrefixLength="1" CompletionInterval="0" EnableCaching="false" CompletionSetCount="10" runat="server"></ajaxToolkit:AutoCompleteExtender>--%>


          <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />


        </div>
    <div>
     <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </div>
        
    </form>
</body>
</html>
