<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="json2.aspx.cs" Inherits="WebApplication2.json2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        student = new Object();
        student.id = "1000";
        student.Name = "Kenneth";

        //Constructor 
        function Student(id1, name1,m1,m2,m3) {
            this.id = id1;
            this.name = name1;
            this.sub1 = m1;
            this.sub2 = m2;
            this.sub3 = m3;
            this.getTotalMarks = function() {
                 return this.sub1 + this.sub2 + this.sub3;
            }

        }
        var s2 = new Student(101, "kenneth", 10, 101, 10);

        window.onload=function init() {
            var s1 = new Student(101, "kenneth");
            console.log(s1);
        }

        //Object Literal
        var stud= {
            name: "Kenneth",
            age: 21,
            dob: '4-oct-1993'
        }
        document.write(stud.name+"  "+stud.dob);



        //Anonymous Function
        var add=function(a, b) {
            return a + b;
        }
        document.write("<br/>" + add(3, 5));

        //Method Invocation Pattern
        var emp= {
            name: "kenneth",
            getName:function() {
                return this.name;
            },
            age: 24,
            isadult: function ()
            {
                if (this.age > 18)
                    return false;
                else
                    return true;
            }
        }
        document.write("<br/>" + emp.isadult);



       
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
