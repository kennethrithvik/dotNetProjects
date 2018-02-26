﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Example1.aspx.cs" Inherits="HTML5._01._Introduction.Example1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SkillAssure - HTML5 Demos</title>
    <style type="text/css">
        #outer-div
        {
            font-family:Arial; 
            font-size:1.8em;
            background-color: #808080;
            text-align:center;
        }
        #inner-div
        {
            font-family:Arial; 
            font-size:1.0em;
            background-color: #ffd800;
            text-align:center;
            color:#fff;
        }
    </style>
</head>
<body>    
    <div style="text-align:center; 
         border-bottom:1px solid #333; 
         font-family:Arial; font-size:2.3em">
        Welcome to HTML5        
    </div>
    <div id="outer-div">
        <span>This is outer div</span>
        <div id="inner-div">
            <span>This is inner Div</span>
        </div>
    </div>    
    <footer>
        <span>Copyrights - 2014. All rights reserverd to SkillAssure.</span>
    </footer>
</body>
</html>
