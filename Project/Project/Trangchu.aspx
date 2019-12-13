<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Trangchu.aspx.cs" Inherits="Trangchu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style3 {
            width: 100%;
            text-align: center;
        }
        .auto-style5 {
            text-align: center;
        }
        .auto-style6 {
            text-decoration: none;
            color: #000000;
        }
        .auto-style8 {
            height: 22px;
            text-align: center;
        }
        .auto-style9 {
            text-decoration: none;
            color: #FF0000;
        }
        </style>
        <title>Trang chủ</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:DataList ID="DataList2" runat="server"  DataSourceID="SqlDataSource1" RepeatColumns="4" RepeatDirection="Horizontal" style="margin-left:35px" CellSpacing="80">
        <ItemTemplate>
            <table class="auto-style3">
                <tr>
                    <td id="hinh">
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("id_sanpham") %>' ImageUrl='<%# "~/images/"+ Eval("Hinh") %>' Width="150px" Height="200px" OnClick="ImageButton1_Click"  ImageAlign="Middle"  />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("id_sanpham") %>' CssClass="auto-style6" Text='<%# Eval("TenSanPham") %>' OnClick="LinkButton1_Click"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("GiaSP") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("id_sanpham") %>'  CssClass="auto-style9" OnClick="LinkButton2_Click">Chi tiết</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [SanPham]"></asp:SqlDataSource>
    
</asp:Content>

