<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TimSach.aspx.cs" Inherits="TimSach" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DataList ID="DataList2" runat="server">
        <ItemTemplate>
            <table class="auto-style5">
                <tr>
                    <td rowspan="5" class="auto-style14">
                        <asp:Image ID="Image2" runat="server" ImageUrl='<%# "~/images/"+Eval("Hinh") %>' Width="150px" Height="200px" ImageAlign="Bottom" />
                    </td>
                    <td class="auto-style15">
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("TenSanPham") %>'></asp:Label>
                    </td>
                    <td class="auto-style12">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style15">Giá:</td>
                    <td class="auto-style12">
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("GiaSP") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15">Mô tả:</td>
                    <td class="auto-style12">Mô tả</td>
                </tr>
                <tr>
                    <td class="auto-style16">Số lượng</td>
                    <td class="auto-style13">
                        <asp:DropDownList ID="ddlSoLuong" runat="server" AutoPostBack="True">
                            <asp:ListItem Selected="True" Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                            <asp:ListItem Value="6">6</asp:ListItem>
                            <asp:ListItem Value="7">7</asp:ListItem>
                            <asp:ListItem Value="8">8</asp:ListItem>
                            <asp:ListItem Value="9">9</asp:ListItem>
                            <asp:ListItem Value="10">10</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style16">
                        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">Giỏ Hàng </asp:LinkButton>
                    </td>
                    <td class="auto-style13">&nbsp;<asp:Button ID="Button1" runat="server" Text="Mua hàng"  CommandArgument='<%# Eval("id_sanpham") %>' OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>

