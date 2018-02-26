<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditFlight.aspx.cs" Inherits="HappyTripWebApp.Admin.EditFlight" %>
<%@ Import Namespace="HappyTrip.Model.Entities.AirTravel" %>
<%@ Register TagPrefix="uc" TagName="MenuC" Src="~/Admin/AdminControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .ErrorMsg
        {
            color: Red;
            display: inline;
        }
    </style>
    <script type="text/javascript">
        /// <reference path="../Scripts/jquery-1.4.1.js"/>
        function Validate() {
            var flag = true;
            if ($('#<% =txtName.ClientID%>').val() == "") {
                flag = false;
            }



            $(".ClassNoOfSeats").each(function (index, value) {
                var n = $(this).siblings("input:checked").length;
                if ($(this).val() == "" && n > 0) {
                    flag = false;
                }
            });
            if (!flag) {
                $("#validationsummary").show();
            }
            return flag;
        }
        $(document).ready(function () { $("#validationsummary").hide(); });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:MenuC id="MenuControl" runat="server" />
<br />
    <center>
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td align="right">
                    Name:<span class="ErrorMsg">*</span>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtName" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    Airline:<span class="ErrorMsg">*</span>
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlAirLine" runat="server">
                    </asp:DropDownList>
                </td>

            </tr>
            
            <tr>
                <td align="right">
                    Class/Seats<span class="ErrorMsg">*</span>
                </td>
                <td>
                    <table>
                        <tr>
                            <th>
                                Class
                            </th>
                            <th>
                            </th>
                            <th>
                                Seats
                            </th>
                        </tr>
                                               <tr>
                            <td colspan="3">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    onrowcancelingedit="GridView1_RowCancelingEdit" 
                                    onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Class">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClass" Text='<%#Eval("ClassInfo") %>'
                                                    runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                            
                                            <asp:TextBox ID="txtClass" Text='<%# ((FlightClass)Container.DataItem).ClassInfo.ToString() %>'
                                                    runat="server"  ReadOnly="true" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Seats">
                                            <ItemTemplate>
                                            <asp:Label ID="lblNoOfSeats" Text='<%#Eval("NoOfSeats") %>'
                                                    runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                            
                                            <asp:TextBox ID="txtNoOfSeats" Text='<%# ((FlightClass)Container.DataItem).NoOfSeats %>'
                                                    runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField HeaderText="Edit" ShowEditButton="True" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button Text="Update" ID="btnUpdate" 
                        runat="server" onclick="btnUpdate_Click"  />
                </td>
                <td>
                    <asp:Button Text="Cancel" ID="btnCancel" runat="server" 
                        onclick="btnCancel_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
        <asp:Label ID="lblError" runat="server" 
            Text="All mandatory fields must be filled " ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </center>

</asp:Content>
