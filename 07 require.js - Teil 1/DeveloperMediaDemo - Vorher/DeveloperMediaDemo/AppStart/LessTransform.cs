using System;
using System.Globalization;
using System.Web.Optimization;
using dotless.Core.configuration;

namespace DeveloperMediaDemo.AppStart
{
    public class LessTransform : IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse response)
        {
            bool debugMode = !BundleTable.EnableOptimizations;

            var config = new DotlessConfiguration
            {
                Debug = debugMode,
                MinifyOutput = !debugMode,
                CacheEnabled = !debugMode,
            };

            string content = dotless.Core.Less.Parse(response.Content, config);

            response.ContentType = "text/css";
            response.Content = string.Format(CultureInfo.InvariantCulture, "/* dotLess - Debug: {0} - Date: {1:yyyy-MM-dd HH:mm:ss} */\n\n{2}", debugMode, DateTime.Now, content);
        }
    }
}