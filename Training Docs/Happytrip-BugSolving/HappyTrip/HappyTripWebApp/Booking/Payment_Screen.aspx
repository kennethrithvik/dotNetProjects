<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Payment_Screen.aspx.cs" Inherits="HappyTripWebApp.Payment_Screen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <style type="text/css">
        .errmsg
        {
            color: Red;
            visibility: hidden;</style>
    <script type="text/javascript">
            function Validate() {
                var flag = [true, true, true, true];
                var vaildated = true;
                   if (!$('#<% =chkconsent.ClientID%>').is(':checked')) {
                       $("#lblChkErrorMsg").css("visibility", "visible"); ;
                       flag[0] = false;
                   }
                   else {
                       $("#lblChkErrorMsg").css("visibility", "hidden");
                       flag[0] = true;
                   }
                   if ($('#<% =txtCard_no.ClientID%>').val() == "") {
                       $("#lblcrdNoMsg").css("visibility", "visible");
                       flag[1] = false;

                   }
                   else {
                       $("#lblcrdNoMsg").css("visibility", "hidden");
                       flag[1] = true;
                   }
                   if ($('#<% =txtcard_holder.ClientID%>').val() == "") {
                       $("#lblcrdhldrerrMsg").css("visibility", "visible"); ;
                       flag[2] = false;
                   }
                   else {
                       $("#lblcrdhldrerrMsg").css("visibility", "hidden"); ;
                       flag[2] = true;
                   }

                   if ($('#<% =txtCvv.ClientID%>').val() == "") {
                   //$(this).val().length
                       $("#lblCvvErrMsg").css("visibility", "visible"); ;
                       flag[3] = false;
                   }
                   else {
                       $("#lblCvvErrMsg").css("visibility", "hidden"); ;
                       flag[3] = true;
                   }
                   //alert("clicked");
                   //alert("flag:" + flag);
                  
                   for (var i = 0; i < flag.length; i++) {
                       if (flag[i] == false) {
                           vaildated = false;
                           break;
                        }
                   }
                  // alert("Validated" + vaildated);
                   return vaildated;

            }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="Wrapper">
        <div class="Container">
            <div id="ContentFrame" class="clearfix">
                <div id="ModifySearchWrapper">
                    <div id="SearchParams">
                        <div id="SPRow">
                            <div id="mod_link_wrapper">
                                <a class="toggle_closed" id="mod_link" title="Click here to make a new search" href="<%= ResolveClientUrl("~/Index.aspx")%>">Modify your search</a>
                            </div>
                            <ul class="inline">
                                <li class="no_border"><asp:Label ID="lblHeaderFromCity" runat="server"></asp:Label> &ndash; <asp:Label ID="lblHeaderToCity" runat="server"></asp:Label></li>
                                <li><asp:Label ID="lblHeaderDepart" runat="server"></asp:Label> <asp:Label ID="lblHeaderDateSeparator" runat="server" Visible="true"> - </asp:Label> <asp:Label ID="lblHeaderReturn" runat="server"></asp:Label>, <asp:Label runat="server" ID="lblAdults"></asp:Label> </li>
                            </ul>
                            <div id="SalesUpsell">
                                <div id="SUWrapper" class="clearfix">
                                    Prefer booking over the phone? <span class="channel phone">Call 080123456789 <span class="weak">local call from any phone</span> </span>
                                </div>
                            </div>
                        </div>
                    </div>
            </div>
        </div>
    </div>
    <div class="Container">
        <div id="ContentFrame" class="clearfix">
            <%--<div id="SearchParams" style="margin-left: 150px; margin-right: 200px;">
                <div id="SPRow">
                    <div>
                        <ul class="inline">
                            <li class="no_border">Payment</li>
                        </ul>
                    </div>
                </div>
            </div>--%>
            <form>
            <fieldset class="date" style="margin-left: 350px;">
                <asp:Label ID="lblUnSuccessful" runat="server" Text="Payment Not Successful. Please try again later." Visible="false"></asp:Label>
                <table style="text-align: left;">
                    <colgroup>
                        <col width="15%">
                    </colgroup>
                    <tbody>
                        <tr>
                            <td>
                                <label class="required">
                                    Credit card no.&nbsp;</label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" type="text" title="credit card no" name="cardno" ID="txtCard_no" />
                                <label id="lblcrdNoMsg" class="errmsg">
                                    Card number should not be empty</label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 10px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="required">
                                    Expiry date&nbsp;</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlccExpirationMonth" runat="server">
                                    <asp:ListItem Text="01" Value="01"></asp:ListItem>
                                    <asp:ListItem Text="02" Value="02"></asp:ListItem>
                                    <asp:ListItem Text="03" Value="03"></asp:ListItem>
                                    <asp:ListItem Text="04" Value="04"></asp:ListItem>
                                    <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                    <asp:ListItem Text="06" Value="06"></asp:ListItem>
                                    <asp:ListItem Text="07" Value="07"></asp:ListItem>
                                    <asp:ListItem Text="08" Value="08"></asp:ListItem>
                                    <asp:ListItem Text="09" Value="09"></asp:ListItem>
                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="11" Value="12"></asp:ListItem>
                                </asp:DropDownList>
                                <%--<select name="card_expiration_month" validate="true" id="CcExpirationMonth" etitle="Credit card expiration month "
                                    class="span required one">
                                    <option value="">Month</option>
                                    <option value="01">01</option>
                                    <option value="02">02</option>
                                    <option value="03">03</option>
                                    <option value="04">04</option>
                                    <option value="05">05</option>
                                    <option value="06">06</option>
                                    <option value="07">07</option>
                                    <option value="08">08</option>
                                    <option value="09">09</option>
                                    <option value="10">10</option>
                                    <option value="11">11</option>
                                    <option value="12">12</option>
                                </select>--%>
                                &nbsp;&nbsp;
                                <asp:DropDownList runat="server" ID="ddlccExpirationYear">
                                    <asp:ListItem Value="2013" Text="2013"></asp:ListItem>
                                    <asp:ListItem Value="2014" Text="2014"></asp:ListItem>
                                    <asp:ListItem Value="2015" Text="2015"></asp:ListItem>
                                    <asp:ListItem Value="2016" Text="2016"></asp:ListItem>
                                    <asp:ListItem Value="2017" Text="2017"></asp:ListItem>
                                    <asp:ListItem Value="2018" Text="2018"></asp:ListItem>
                                </asp:DropDownList>
                                <%--<select name="card_expiration_year" validate="true" id="CcExpirationYear" class="span required one"
                                    etitle="Credit card expiration year">
                                    <option value="">Year</option>
                                    <option value="2013">2013</option>
                                    <option value="2014">2014</option>
                                    <option value="2015">2015</option>
                                    <option value="2016">2016</option>
                                    <option value="2017">2017</option>
                                    <option value="2018">2018</option>
                                    <option value="2019">2019</option>
                                    <option value="2020">2020</option>
                                    <option value="2021">2021</option>
                                    <option value="2022">2022</option>
                                    <option value="2023">2023</option>
                                    <option value="2024">2024</option>
                                    <option value="2025">2025</option>
                                    <option value="2026">2026</option>
                                    <option value="2027">2027</option>
                                    <option value="2028">2028</option>
                                    <option value="2029">2029</option>
                                    <option value="2030">2030</option>
                                    <option value="2031">2031</option>
                                    <option value="2032">2032</option>
                                </select>--%>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 10px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="required">
                                    Card holder&nbsp;</label>
                            </td>
                            <td>
                                <asp:TextBox type="text" runat="server" title="card holder" name="cardholder" ID="txtcard_holder" />
                                <label id="lblcrdhldrerrMsg" class="errmsg">
                                    Card holder should not be empty</label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 10px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="required">
                                    Card type&nbsp;</label>
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlccCardType">
                                    <asp:ListItem Text="Visa" Value=""></asp:ListItem>
                                    <asp:ListItem Text="MasterCard" Value="01"></asp:ListItem>
                                    <asp:ListItem Text="AmericanExpress" Value="02"></asp:ListItem>
                                </asp:DropDownList>
                                <%--
                                <select name="card_expiration_month" validate="true" id="CcExpirationMonth" etitle="Credit card expiration month "
                                    class="span required one">
                                    <option value="">Visa</option>
                                    <option value="01">MasterCard</option>
                                    <option value="02">AmericanExpress</option>
                                </select>--%>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 10px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="required">
                                    CVV&nbsp;</label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtCvv" size="4" TextMode="Password" />
                                <label id="lblCvvErrMsg" class="errmsg">
                                    Cvv Should not be empty</label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 10px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <label class="required">
                                    <asp:CheckBox runat="server" ID="chkconsent" CssClass="foreign" ValidationGroup="payment"
                                        Text="" Checked="true" />
                                    &nbsp;<small>I understand and agree to the rules and restrictions of this fare, the
                                        <a class="weak">Terms &amp; Conditions</a> of Happytrip </small>
                                    <label id="lblChkErrorMsg" class="errmsg">
                                    Please accept the terms and coditions to continue
                                    </label>
                                </label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 10px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="button">
                                    <asp:Button ID="btnBook" CausesValidation="true" OnClientClick="return Validate();"
                                        ValidationGroup="payment" runat="server" Text="Make Payment" 
                                        CssClass="book booking" onclick="btnBook_Click">
                                    </asp:Button>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </fieldset>
            </form>
        </div>
    </div>
</asp:Content>
