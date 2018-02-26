﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Example3.aspx.cs" Inherits="HTML5.Introduction.Example3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SkillAssure - HTML5 Demos</title>
    <style type="text/css">
        #outer-div
        {
            font-family:Arial;             
            text-align:center;
            border:1px solid red;            
        }
        #top
        {
            font-family:Arial; 
            font-size:1.0em;            
            text-align:center;            
            border:1px solid #333;
        }
        #left
        {
            font-family:Arial; 
            font-size:1.0em;            
            text-align:center;            
            float: left;
            border:1px solid #333;
            width: 33%;
            height: 300px;
        }
        #middle
        {
            font-family:Arial; 
            font-size:1.0em;            
            text-align:center;            
            float: left;
            border:1px solid #333;
            width: 33%;
            height: 300px;
        }
        #right
        {
            font-family:Arial; 
            font-size:1.0em;            
            text-align:center;            
            float: left;
            border:1px solid #333;
            width: 33%;
            height: 300px;
        }
        #bottom
        {
            font-family:Arial; 
            font-size:1.0em;            
            text-align:center;   
            border:1px solid #333;                     
        }
        .clear
        {
            clear: both;
        }
    </style>
</head>
<body>
    <div id="tables">
        <table style="width:100%" border="1">
            <tr>
                <td colspan="3" align="center">Heading</td>
            </tr>
            <tr>
                <td style="height:300px">Left Pan</td>
                <td>Middle Pan</td>
                <td>Right Pan</td>
            </tr>
            <tr>
                <td colspan="3" align="center">Bottom</td>
            </tr>
        </table>
    </div>

  <div id="outer-div">        
        <div id="top">
            <span>Heading</span>
        </div>
        <div id="left">
            <span>Left Pan</span>
        </div>
        <div id="middle">
            <span>Middle Pan</span>
        </div>
        <div id="right">
            <span>Rigth Pan</span>
        </div>
        <div class="clear"></div>
        <div id="bottom">
            <span>Bottom</span>
        </div>
    </div>  
</body>
</html>