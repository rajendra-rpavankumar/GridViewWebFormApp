<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HelloWorldCsv.aspx.cs" Inherits="GridViewBindCsvData.HelloWorldCsv" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hello World CSV</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1> Hello, World!</h1>

            <div>
                <asp:GridView ID="GridViewData" runat="server"></asp:GridView>
            </div>
            <br />
            <div>
                <asp:Button ID="ButtonShowFootote" runat="server" Text="Show first footnote" />
                <br />
                <asp:Label ID="LabelFootnote" runat="server"></asp:Label>
            </div>
            

        </div>
    </form>
</body>
</html>
