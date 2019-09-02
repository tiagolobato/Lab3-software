<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content  ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="text-align:center;width:480px;"><br><br>
        <button></button>
        <asp:RadioButton runat="server" />
        <asp:Button id="btnTeste" text="&#x25C0;" runat="server" style="width:40px;" onmouseup="Button1_MouseUp" onmousedown="Button1_MouseDown" CausesValidation="False" />
  <asp:Button Text="&#x25B2;" runat="server" OnClick="Button1_Click" /><br>
  <asp:Button text="&#x25C0;" style="width:40px;" runat="server" OnClick="Button2_Click"/>
  <asp:Button text="&#x25B6;" style="width:40px;" runat="server" OnClick="Button3_Click"/>  
        <input id="Button1" type="button" value="button" /><asp:Button ID="Button2" runat="server" OnClick="Button2_Click1" Text="Button" />
        <input id="Button3" type="button" value="button" /><br>
  <asp:Button text="&#x25BC;" runat="server" OnClick="Button4_Click"/>    
        
</div>
   


</asp:Content>
