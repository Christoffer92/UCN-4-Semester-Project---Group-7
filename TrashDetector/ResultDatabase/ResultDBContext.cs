using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using ModelLayer;

namespace ResultDatabase
{
    public class ResultDBContext : DataContext
    {
        public static string ConnectionString = @"Data Source=" + Environment.MachineName + @"\;"
        + "Initial Catalog=TResultDatabase;"
        + "Integrated Security=True;"
        + "Connect Timeout=30;"
        + "Encrypt=False;"
        + "TrustServerCertificate=True;"
        + "ApplicationIntent=ReadWrite;"
        + "MultiSubnetFailover=False";

        public Table<ImageFile> imageFiles;
        public Table<ImageInfo> imageInfos;

        public ResultDBContext() : base(ConnectionString)
        {
        }
    }
}