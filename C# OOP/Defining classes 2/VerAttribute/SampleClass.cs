using System;

// 11. Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods 
// and holds a version in the format major.minor (e.g. 2.11). Apply the version attribute to a sample class and display its version at runtime.

[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method,
    AllowMultiple = false)]

public class Version : System.Attribute
{
    public int Major { get; private set; }
    public int Minor { get; private set; }

    public Version(int major, int minor)
    {
        this.Major = major;
        this.Minor = minor;
    }
}

[Version(3, 2)]
class SampleClass
{
    static void Main()
    {
        Type type = typeof(SampleClass);
        object[] attributes = type.GetCustomAttributes(false);

        foreach (Version attrib in attributes)
        {
            Console.WriteLine("The version of SampleClass is {0}.{1}", attrib.Major, attrib.Minor);
        }
    }
}
