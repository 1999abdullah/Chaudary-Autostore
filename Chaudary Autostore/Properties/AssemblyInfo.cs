using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ExecutionScope = Microsoft.VisualStudio.TestTools.UnitTesting.ExecutionScope;

[assembly: Parallelize(Workers = 1, Scope = ExecutionScope.MethodLevel)]

[assembly: AssemblyTitle("Chaudary Autostore")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Chaudary Autostore")]
[assembly: AssemblyCopyright("Copyright ©  2022")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]

[assembly: Guid("89215515-505e-4e59-b2d8-68f0a0719e3f")]

// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
