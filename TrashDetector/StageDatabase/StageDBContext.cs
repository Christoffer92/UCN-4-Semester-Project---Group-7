using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StageDatabase
{
    public class StageDBContext : DataContext
    {
        public static string ConnectionString = @"Data Source=" + Environment.MachineName + @"\;"
                                               + "Initial Catalog=TStageDatabase;"
                                               + "Integrated Security=True;"
                                               + "Connect Timeout=30;"
                                               + "Encrypt=False;"
                                               + "TrustServerCertificate=True;"
                                               + "ApplicationIntent=ReadWrite;"
                                               + "MultiSubnetFailover=False";

        //public Table<ImageFile> ImagesTable;
        //public Table<Stream> ImagesTable;

        public StageDBContext() : base(ConnectionString)
        {
        }
    }
}
