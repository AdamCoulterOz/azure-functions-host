﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Script.Description
{
    public static class DotNetConstants
    {
        public const string PrivateAssembliesFolderName = "bin";
        public const string CompilationReferenceAssembliesFolderName = "compilationrefs";
        public const string ProjectFileName = "function.proj";
        public const string ProjectLockFileName = "project.assets.json";
        public const string FunctionsDepsFileName = "function.deps.json";

        public const string MissingFunctionEntryPointCompilationCode = "AF001";
        public const string AmbiguousFunctionEntryPointsCompilationCode = "AF002";
        public const string MissingTriggerArgumentCompilationCode = "AF003";
        public const string MissingBindingArgumentCompilationCode = "AF004";
        public const string RedundantPackageAssemblyReference = "AF005";
        public const string InvalidFileMetadataReferenceCode = "AF006";
        public const string InvalidEntryPointNameCompilationCode = "AF007";
        public const string AsyncVoidCode = "AF008";

        public const string DefaultWindowsRID = "win10";
        public const string DefaultOSXRID = "osx.10.12";
        public const string DefaultLinuxRID = "linux";

        public static string[] FrameworkReferences = new[]
        {
            "Microsoft.CSharp",
            "Microsoft.Net.Http.Headers",
            "Microsoft.VisualBasic",
            "Microsoft.Win32.Primitives",
            "Microsoft.Win32.Registry",
            "mscorlib",
            "netstandard",
            "SOS.NETCore",
            "System",
            "System.AppContext",
            "System.Buffers",
            "System.Collections",
            "System.Collections.Concurrent",
            "System.Collections.Immutable",
            "System.Collections.NonGeneric",
            "System.Collections.Specialized",
            "System.ComponentModel",
            "System.ComponentModel.Annotations",
            "System.ComponentModel.DataAnnotations",
            "System.ComponentModel.EventBasedAsync",
            "System.ComponentModel.Primitives",
            "System.ComponentModel.TypeConverter",
            "System.Composition.AttributedModel",
            "System.Composition.Convention",
            "System.Composition.Hosting",
            "System.Composition.Runtime",
            "System.Composition.TypedParts",
            "System.Configuration",
            "System.Configuration.ConfigurationManager",
            "System.Console",
            "System.Core",
            "System.Data",
            "System.Data.Common",
            "System.Data.SqlClient",
            "System.Diagnostics.Contracts",
            "System.Diagnostics.Debug",
            "System.Diagnostics.DiagnosticSource",
            "System.Diagnostics.FileVersionInfo",
            "System.Diagnostics.PerformanceCounter",
            "System.Diagnostics.Process",
            "System.Diagnostics.StackTrace",
            "System.Diagnostics.TextWriterTraceListener",
            "System.Diagnostics.Tools",
            "System.Diagnostics.TraceSource",
            "System.Diagnostics.Tracing",
            "System.Drawing",
            "System.Drawing.Primitives",
            "System.Dynamic.Runtime",
            "System.Globalization",
            "System.Globalization.Calendars",
            "System.Globalization.Extensions",
            "System.IdentityModel.Tokens.Jwt",
            "System.Interactive.Async",
            "System.IO",
            "System.IO.Abstractions",
            "System.IO.Compression",
            "System.IO.Compression.Brotli",
            "System.IO.Compression.FileSystem",
            "System.IO.Compression.ZipFile",
            "System.IO.FileSystem",
            "System.IO.FileSystem.AccessControl",
            "System.IO.FileSystem.DriveInfo",
            "System.IO.FileSystem.Primitives",
            "System.IO.FileSystem.Watcher",
            "System.IO.IsolatedStorage",
            "System.IO.MemoryMappedFiles",
            "System.IO.Pipelines",
            "System.IO.Pipes",
            "System.IO.Pipes.AccessControl",
            "System.IO.UnmanagedMemoryStream",
            "System.Linq",
            "System.Linq.Expressions",
            "System.Linq.Parallel",
            "System.Linq.Queryable",
            "System.Memory",
            "System.Net",
            "System.Net.Http",
            "System.Net.Http.Formatting",
            "System.Net.HttpListener",
            "System.Net.Mail",
            "System.Net.NameResolution",
            "System.Net.NetworkInformation",
            "System.Net.Ping",
            "System.Net.Primitives",
            "System.Net.Requests",
            "System.Net.Security",
            "System.Net.ServicePoint",
            "System.Net.Sockets",
            "System.Net.WebClient",
            "System.Net.WebHeaderCollection",
            "System.Net.WebProxy",
            "System.Net.WebSockets",
            "System.Net.WebSockets.Client",
            "System.Net.WebSockets.WebSocketProtocol",
            "System.Numerics",
            "System.Numerics.Vectors",
            "System.ObjectModel",
            "System.Private.CoreLib",
            "System.Private.DataContractSerialization",
            "System.Private.Uri",
            "System.Private.Xml",
            "System.Private.Xml.Linq",
            "System.Reactive.Core",
            "System.Reactive.Interfaces",
            "System.Reactive.Linq",
            "System.Reactive.PlatformServices",
            "System.Reflection",
            "System.Reflection.DispatchProxy",
            "System.Reflection.Emit",
            "System.Reflection.Emit.ILGeneration",
            "System.Reflection.Emit.Lightweight",
            "System.Reflection.Extensions",
            "System.Reflection.Metadata",
            "System.Reflection.Primitives",
            "System.Reflection.TypeExtensions",
            "System.Resources.Reader",
            "System.Resources.ResourceManager",
            "System.Resources.Writer",
            "System.Runtime",
            "System.Runtime.CompilerServices.Unsafe",
            "System.Runtime.CompilerServices.VisualC",
            "System.Runtime.Extensions",
            "System.Runtime.Handles",
            "System.Runtime.InteropServices",
            "System.Runtime.InteropServices.RuntimeInformation",
            "System.Runtime.InteropServices.WindowsRuntime",
            "System.Runtime.Loader",
            "System.Runtime.Numerics",
            "System.Runtime.Serialization",
            "System.Runtime.Serialization.Formatters",
            "System.Runtime.Serialization.Json",
            "System.Runtime.Serialization.Primitives",
            "System.Runtime.Serialization.Xml",
            "System.Security",
            "System.Security.AccessControl",
            "System.Security.Claims",
            "System.Security.Cryptography.Algorithms",
            "System.Security.Cryptography.Cng",
            "System.Security.Cryptography.Csp",
            "System.Security.Cryptography.Encoding",
            "System.Security.Cryptography.OpenSsl",
            "System.Security.Cryptography.Pkcs",
            "System.Security.Cryptography.Primitives",
            "System.Security.Cryptography.ProtectedData",
            "System.Security.Cryptography.X509Certificates",
            "System.Security.Cryptography.Xml",
            "System.Security.Permissions",
            "System.Security.Principal",
            "System.Security.Principal.Windows",
            "System.Security.SecureString",
            "System.ServiceModel.Web",
            "System.ServiceProcess",
            "System.Spatial",
            "System.Text.Encoding",
            "System.Text.Encoding.CodePages",
            "System.Text.Encoding.Extensions",
            "System.Text.Encodings.Web",
            "System.Text.RegularExpressions",
            "System.Threading",
            "System.Threading.Channels",
            "System.Threading.Overlapped",
            "System.Threading.Tasks",
            "System.Threading.Tasks.Dataflow",
            "System.Threading.Tasks.Extensions",
            "System.Threading.Tasks.Parallel",
            "System.Threading.Thread",
            "System.Threading.ThreadPool",
            "System.Threading.Timer",
            "System.Transactions",
            "System.Transactions.Local",
            "System.ValueTuple",
            "System.Web",
            "System.Web.HttpUtility",
            "System.Windows",
            "System.Xml",
            "System.Xml.Linq",
            "System.Xml.ReaderWriter",
            "System.Xml.Serialization",
            "System.Xml.XDocument",
            "System.Xml.XmlDocument",
            "System.Xml.XmlSerializer",
            "System.Xml.XPath",
            "System.Xml.XPath.XDocument",
            "System.Xml.XPath.XmlDocument",
            "WindowsBase"
        };
    }
}