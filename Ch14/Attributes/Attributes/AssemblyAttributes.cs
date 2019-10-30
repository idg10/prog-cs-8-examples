using System.Runtime.CompilerServices;

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage(
    "StyleCop.CSharp.NamingRules",
    "SA1313:Parameter names should begin with lower-case letter",
    Justification = "Triple underscore acceptable for unused lambda parameter",
    Scope = "member",
    Target = "~M:Idg.Examples.SomeMethod")]

[assembly: InternalsVisibleTo("ImageManagement.Tests")]
[assembly: InternalsVisibleTo("ImageServices.Tests")]