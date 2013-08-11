using System.Collections.Generic;
using System.IO;
using System.Web.Optimization;

namespace DeveloperMediaDemo.AppStart
{
    /// <summary>
    /// Will ensure bundles are included in the order you register them
    /// 
    /// The default orderer generally respects the order of the includes
    /// but it promotes a few special files to the top, i.e. jquery which
    /// should be loaded AFTER require.js
    /// </summary>
    public class AsIsBundleOrderer : IBundleOrderer
    {
        public virtual IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }
}