<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sanpham.aspx.cs" Inherits="Sanpham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style5 {
            width:100%;
            text-align:center;
       
        }
        .auto-style6 {
            text-align: center;
      
        }
        .auto-style7 {
            font-size:14px;
           font-weight:bold;            
            text-decoration: none;
            color:black;
        }
        .auto-style8 {
           
            text-decoration: none;
            color: black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:DataList ID="DataList2" runat="server"  RepeatColumns="3" RepeatDirection="Horizontal" style="margin-left:35px" CellSpacing="80" >
        <ItemStyle HorizontalAlign="Center" />
        <ItemTemplate>
            <table class="auto-style5">
                <tr>
                    <td>
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# "~/images/"+Eval("Hinh") %>' CommandArgument='<%# Eval("id_sanpham") %>' Width="150px" Height="200px" OnClick="ImageButton1_Click"  ImageAlign="Middle"  />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("id_sanpham") %>' CssClass="auto-style7" Text='<%# Eval("TenSanPham")  %>' OnClick="LinkButton1_Click"></asp:LinkButton>
                    </td>
                </tr>

                 <tr>

                    <td class="auto-style6">
                        <asp:Label ID="Label6" runat="server" Text="Tác giả:" Font-Size="10px"></asp:Label>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Tacgia") %>' Font-Size="10px"></asp:Label>
                    </td>
                </tr>

                    <td class="auto-style6">
                         <asp:Label ID="Label4" runat="server" Text="Giá:" Font-Size="10px"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("GiaSP") %>' Font-Size="10px" ForeColor="#cc3300" ></asp:Label>
                        <asp:Label ID="Label5" runat="server" Text="VND" Font-Size="10px "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        <asp:LinkButton ID="LinkButton2" runat="server"  CommandArgument='<%# Eval("id_sanpham") %>' CssClass="auto-style8" OnClick="LinkButton2_Click" Font-Underline="True" Font-Size="Small">Chi tiết</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [donhang]"></asp:SqlDataSource>

</asp:Content>

