﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Example2.aspx.cs" Inherits="HTML5.Form.Example2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>Data List</h2>
        <hr/>
        <h4>Enter State</h4>
        <form action="#" method="get">
            <input list="state" name="state" />
            <datalist id="state">
                <option value="Andhra Pradesh"></option>
                <option value="Arunachal Pradesh"></option>
                <option value="Assam"></option>
                <option value="Bihar"></option>
                <option value="Chandigarh"></option>
                <option value="Chhattisgarh"></option>
                <option value="Delhi"></option>
                <option value="Goa"></option>
                <option value="Gujarat"></option>
                <option value="Haryana"></option>
                <option value="Jammu and Kashmir"></option>
                <option value="Karnataka"></option>
                <option value="Kerala"></option>
                <option value="Lakshadweep"></option>                
            </datalist>
            <input type="submit" />
        </form>
</body>
</html>
