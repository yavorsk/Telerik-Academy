using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace SoftwareAcademy
{
    public interface ITeacher
    {
        string Name { get; set; }
        void AddCourse(ICourse course);
        string ToString();
    }

    public interface ICourse
    {
        string Name { get; set; }
        ITeacher Teacher { get; set; }
        void AddTopic(string topic);
        string ToString();
    }

    public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }

    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }

    public interface ICourseFactory
    {
        ITeacher CreateTeacher(string name);
        ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);
        IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
    }

    public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            return new Teacher(name);
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            return new LocalCourse(name, teacher, lab);
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            return new OffsiteCourse(name, teacher, town);
        }
    }

    public class SoftwareAcademyCommandExecutor
    {
        static void Main()
        {
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using SoftwareAcademy;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }

    public abstract class Course : ICourse
    {
        private string name;

        public string Name 
        { 
            get { return this.name; } 

            set
            {
                if (value != null)
	            {
                    this.name = value;
	            }
                else
	            {
                    throw new ArgumentNullException();
	            }
            }
        }

        public ITeacher Teacher { get; set; }
        private List<string> topics;

        public Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
            topics = new List<string>();
        }

        public void AddTopic(string topic)
        {
            this.topics.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(this.GetType().Name + ": ");

            result.AppendFormat("Name={0}; ", this.Name);

            if (this.Teacher != null)
            {
                result.AppendFormat("Teacher={0}; ", this.Teacher.Name);
            }

            if (this.topics.Count > 0)
            {
                result.AppendFormat("Courses=[");
                for (int i = 0; i < this.topics.Count; i++)
                {
                    if (i == this.topics.Count - 1)
                    {
                        result.Append(this.topics[i]);
                        result.Append("]; ");
                    }
                    else
                    {
                        result.AppendFormat("{0}, ", this.topics[i]);
                    }
                }
            }

            if (this is LocalCourse)
            {
                result.AppendFormat("Lab={0};", ((ILocalCourse)this).Lab);
            }

            if (this is OffsiteCourse)
            {
                result.AppendFormat("Town={0};", ((IOffsiteCourse)this).Town);
            }

            return result.ToString();
        }
    }

    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

	    public string Lab
	    {
		    get 
            { 
                return this.lab;
            }
		    set 
            { 
                if (value != null)
	            {
		            this.lab = value;
	            }
                else
            	{
                    throw new ArgumentNullException();
	            }

            }
	    }

        public LocalCourse(string name, ITeacher teacher, string lab)
            : base(name, teacher)
        {
            this.Lab = lab;
        }
    }

    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;

	    public string Town
	    {
		    get 
            { 
                return this.town;
            }
		    set 
            { 
                if (value != null)
	            {
		            this.town = value;
	            }
                else
            	{
                    throw new ArgumentNullException();
	            }

            }
	    }

        public OffsiteCourse(string name, ITeacher teacher, string town)
            : base(name, teacher)
        {
            this.Town = town;
        }
    }

    public class Teacher : ITeacher
    {
        private string name;

        public string Name
        { 
            get {return this.name;} 

            set
            {
                if (value != null)
	            {
                    this.name = value;
	            }
                else
	            {
                    throw new ArgumentNullException();
	            }
            }
        }

        private List<ICourse> courses;

        public Teacher(string name)
        {
            this.Name = name;
            courses = new List<ICourse>();
        }

        public void AddCourse(ICourse course)
        {
            this.courses.Add(course);
        }

        public override string ToString()
        {
           StringBuilder result = new StringBuilder();

           result.Append("Teacher: ");

           result.AppendFormat("Name={0};", this.Name);

           if (this.courses.Count > 0)
           {
               result.AppendFormat(" Courses=[");
               for (int i = 0; i < this.courses.Count; i++)
               {
                   if (i == this.courses.Count - 1)
                   {
                       result.Append(this.courses[i].Name);
                       result.Append("]; ");
                   }
                   else
                   {
                       result.AppendFormat("{0}, ", this.courses[i].Name);
                   }
               }
           }

           return result.ToString();
        }
    }
}
