using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using SourceDatabase;
using ModelLayer;

namespace SourceDB
{
    class SourceDBContext : DataContext
    {

        public static string ConnectionString = @"Data Source=" + Environment.MachineName + @"\;"
        + "Initial Catalog=TSourceDatabase;"
        + "Integrated Security=True;"
        + "Connect Timeout=30;"
        + "Encrypt=False;"
        + "TrustServerCertificate=True;"
        + "ApplicationIntent=ReadWrite;"
        + "MultiSubnetFailover=False";

        Table<ImageFile> imageFiles;
        Table<ImageInfo> imageInfo;

        public SourceDBContext() : base(ConnectionString){
        }
    }
}
