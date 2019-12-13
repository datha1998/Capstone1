<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GioHang2.aspx.cs" Inherits="GioHang2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"><Columns>
    <asp:TemplateField>
    <ItemTemplate>
        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("id_sanpham") %>' OnClick="LinkButton2_Click">Xóa</asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="id_sanpham" HeaderText="Tên hàng" />
    <asp:BoundField DataField="GiaSP" HeaderText="Đơn giá" />
    <asp:TemplateField HeaderText="Số lượng">
    <ItemTemplate>
        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("soluong")%>'></asp:TextBox>
        <asp:Button ID="Button1" runat="server" CommandArgument='<%#Eval("id_sanpham") %>' OnClick="Button1_Click" Text="Sửa" />
    </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="thanhtien" HeaderText="Thành tiền" /></Columns>
    </asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>

