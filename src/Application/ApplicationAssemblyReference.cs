using System.Reflection;

namespace Application;

public class ApplicationAssemblyReference
{
    internal static Assembly Assembly => typeof(ApplicationAssemblyReference).Assembly;
}