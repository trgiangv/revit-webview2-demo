using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Threading;


namespace RevitWebView2Demo
{
    public partial class WebView2Window : Window
    {        public WebView2Window()
        {
            InitializeComponent();
              // Get the path to the HTML file relative to the assembly location
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string assemblyDir = Path.GetDirectoryName(assemblyLocation);
            string htmlPath = Path.Combine(assemblyDir, Constants.WebPath);
            
            // Convert to absolute path and create file URI
            string absolutePath = Path.GetFullPath(htmlPath);
            Uri fileUri = new Uri($"file:///{absolutePath.Replace('\\', '/')}");
            
            var win = new WebViewPage
            {
                webView =
                {
                    Source = fileUri
                }
            };
            mainwindow.Content = win;
        }

        private void WebView2Window_OnClosing(object sender, CancelEventArgs e)
        {
            ShowWebView2Window.Win = null;
        }
    }
}