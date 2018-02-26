using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Reflections
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Type mathtType = myAssembly.GetType("Reflections.MathClass");

            MemberInfo[] allMembers = mathtType.GetMembers();
            foreach (var item in allMembers)
            {
                if (item.Name.ToLower() == "add")
                {
                    Attribute at=item.GetCustomAttribute(typeof(BugAttribute));
                    BugAttribute b = at as BugAttribute;
                    Console.WriteLine(b.GetBug());
                }
            }

            Console.ReadLine();
        }

        public void new1()
        {
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Console.WriteLine(myAssembly.FullName);

            AssemblyName aname = myAssembly.GetName();
            Console.WriteLine(aname.Name);

            Version ver = aname.Version;
            Console.WriteLine(ver.Major + "  " + ver.Minor);

            AssemblyName[] anames = myAssembly.GetReferencedAssemblies();
            Console.WriteLine("\nReference assemblies");
            foreach (var item in anames)
            {
                Console.WriteLine(item.FullName);
            }


            Type[] asmtypes = myAssembly.GetTypes();
            Console.WriteLine("\nAll Types");
            foreach (var item in asmtypes)
            {
                Console.WriteLine(item.FullName);
                if (item.FullName == "Reflections.MathClass")
                {
                    Console.WriteLine();
                    MemberInfo[] allmembers = item.GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic);
                    foreach (var item1 in allmembers)
                    {
                        Console.WriteLine(item1.MemberType + "  " + item1.Name);
                    }
                    Console.WriteLine();
                }
            }


            Type mathtType = myAssembly.GetType("Reflections.MathClass");
            MethodInfo multiply = mathtType.GetMethod("Multiply");
            //Console.WriteLine(multiply.GetParameters().Length);

            object[] mparams = { 1, 2, 3 };
            Console.WriteLine(multiply.Invoke(null, mparams));

            object myobj = System.Activator.CreateInstance(mathtType);
            PropertyInfo num1 = mathtType.GetProperty("Num1");
            num1.SetValue(myobj, 100);
            FieldInfo num2 = mathtType.GetField("Num2");
            num2.SetValue(myobj, 200);
            MethodInfo add = mathtType.GetMethod("Add");
            Console.WriteLine(add.Invoke(myobj, null));
        }
    }
}
