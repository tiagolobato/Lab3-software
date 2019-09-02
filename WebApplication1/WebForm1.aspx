<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center;width:480px;"><br><br>
            <asp:button style="text-align:center;width:40px;" ID="ButtonUp" runat="server" text="&#x25B2;" onmousedown="javascript:toggleButton();" onmouseup="javascript:toggleButton2();"/><br />
            <asp:button ID="ButtonLeft" runat="server" text="&#x25C0;" onmousedown="javascript:toggleButton();" onmouseup="javascript:toggleButton2();" Width="64px"/>
            <asp:button ID="ButtonRigth" runat="server" text="&#x25B6;" onmousedown="javascript:toggleButton();" onmouseup="javascript:toggleButton2();" Width="64px" /><br />
            <asp:button style="text-align:center;width:40px;" ID="ButtonDown" runat="server" text="&#x25BC;" onmousedown="javascript:toggleButton();" onmouseup="javascript:toggleButton2();" />

       
        </div>
        <div style="text-align:center;width:480px;"><br><br>
             <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Button" style="visibility:hidden;" />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Button" style="visibility:hidden;" />
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Button" style="visibility:hidden;" />
            <asp:Button ID="UpButtonKey" runat="server" OnClick="UpButtonKeyOnClickDown" Text="Button" style="visibility:hidden;" />
            <asp:Button ID="LeftButtonKey" runat="server" OnClick="LeftButtonKeyOnClickDown" Text="Button" style="visibility:hidden;" />
            <asp:Button ID="RigthButtonKey" runat="server" OnClick="RigthButtonKeyOnClickDown" Text="Button" style="visibility:hidden;" />
            <asp:Button ID="DownButtonKey" runat="server" OnClick="DownButtonKeyOnClickDown" Text="Button" style="visibility:hidden;" />
        </div<%-->--%>
    </form>
</body>

</html>
<script type="text/javascript">
    function toggleButton() {
        document.getElementById("Button3").click();
    }
    function toggleButton2() {
        document.getElementById("Button4").click();
    }
    document.onkeydown = function (evt) {
        evt = evt || window.event;
        if (evt.keyCode == 40) {
            document.getElementById("DownButtonKey").click();
        }
        
    };
</script>