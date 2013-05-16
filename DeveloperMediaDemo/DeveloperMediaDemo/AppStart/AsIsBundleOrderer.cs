using System.Collections.Generic;
using System.IO;
using System.Web.Optimization;

namespace WebNoteSinglePage.AppStart
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
        public virtual IEnumerable<FileInfo> OrderFiles(BundleContext context, IEnumerable<FileInfo> files)
        {
            return files;
        }
    }
}