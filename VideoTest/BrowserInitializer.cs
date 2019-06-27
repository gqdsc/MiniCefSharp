using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using CefSharp;

namespace VideoTest
{
    class BrowserInitializer
    {
        /// <summary>
        /// Initialize third part folder
        /// </summary>
        public static void Initialize()
        {
            DecompressFolder();
            InitializeCefSharp();
        }

        private static void DecompressFolder()
        {
            var cefSharpFolder = Path.Combine(Environment.CurrentDirectory, "CefSharp");
            //var browserDat = Path.Combine(Environment.CurrentDirectory, "Browser.dat");
            //CompressHelper.CompressFolder(cefSharpFolder, browserDat, CompressionLevel.Ultra);
            if (!Directory.Exists(cefSharpFolder))
            {
                var targetDat = Path.Combine(Environment.CurrentDirectory, "Browser.dat");
                CompressHelper.DeCompress(targetDat, Environment.CurrentDirectory);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void InitializeCefSharp()
        {
            var settings = new CefSettings();
            settings.BrowserSubprocessPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "CefSharp",
                Environment.Is64BitProcess ? "x64" : "x86",
                "CefSharp.BrowserSubprocess.exe");
            settings.CefCommandLineArgs.Add("no-proxy-server", "1");
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;

#if DEBUG
            settings.RemoteDebuggingPort = 8088;
#endif
            Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: null);
        }

        public static Assembly Resolver(object sender, ResolveEventArgs args)
        {
            if (args.Name.StartsWith("CefSharp"))
            {
                var assemblyName = args.Name.Split(new[] { ',' }, 2)[0] + ".dll";
                var archSpecificPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "CefSharp",
                    Environment.Is64BitProcess ? "x64" : "x86",
                    assemblyName);

                return File.Exists(archSpecificPath)
                    ? Assembly.LoadFile(archSpecificPath)
                    : null;
            }

            return null;
        }

    }
}
