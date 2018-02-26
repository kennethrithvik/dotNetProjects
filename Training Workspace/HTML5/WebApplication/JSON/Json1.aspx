<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Json1.aspx.cs" Inherits="WebApplication2.Json1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Simple Json</title>
    <script>
        var student = [
            { "id": 101, "Name": "Kenneth1", "Marks": [{ "sub": 100 }, { "sub": 100 }, { "sub": 100 }] },
            { "id": 102, "Name": "Kenneth2", "Marks": [{ "sub": 100 }, { "sub": 100 }, { "sub": 100 }] },
            { "id": 103, "Name": "Kenneth3", "Marks": [{ "sub": 100 }, { "sub": 100 }, { "sub": 100 }] },
            { "id": 104, "Name": "Kenneth4", "Marks": [{ "sub": 100 }, { "sub": 100 }, { "sub": 100 }] },
            { "id": 105, "Name": "Kenneth5", "Marks": [{ "sub": 100 }, { "sub": 100 }, { "sub": 100 }] }
            ];
        window.onload=function init() {
            //document.write("ID:" + student.id + "<br> Name: " + student.Name);
            var a = document.getElementById('tab');
            var str="";
            for (var j = 0; j < student.length; j++)
            {
                str+="<tr><td>" +student[j].id+"</td><td>"+ student[j].Name+"</td>";

                for (var i = 0; i < student[j].Marks.length; i++)
                {
                    str+="<td>" + student[j].Marks[i].sub+"</td>";
                }
                str += "</tr>";
               
            }
            a.innerHTML += str;
            console.log(student);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="tabdiv">
        <table id="tab" border="2px">
            <tr>
                <th>ID</th>
                <th>Name</th>
                <th>Sub1</th>
                <th>Sub2</th>
                <th>Sub3</th>
            </tr>

        </table>
    
    </div>
    </form>
</body>
</html>
