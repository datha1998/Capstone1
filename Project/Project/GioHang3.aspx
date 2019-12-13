<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GioHang3.aspx.cs" Inherits="GioHang3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"><Columns>
    <asp:TemplateField HeaderText="Xóa">
    <ItemTemplate>
    <asp:CheckBox ID="CheckBox1" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("id_sanpham") %>' />
        </ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="TenSanPham" HeaderText="Tên hàng" />
<asp:BoundField DataField="GiaSP" HeaderText="Đơn giá" />
<asp:TemplateField HeaderText="Số lượng">
<ItemTemplate>
<asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("soluong")%>'></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="thanhtien" HeaderText="Thành tiền" />
</Columns>
</asp:GridView>
<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
&nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Xóa"
/>
&nbsp;<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Sửa"
/>
</asp:Content>

