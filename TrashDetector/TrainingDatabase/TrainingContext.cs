using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using ModelLayer;

namespace TrainingDatabase
{
    public class TrainingDBContext : DataContext
    {

        public static string ConnectionString = @"Data Source=" + Environment.MachineName + @"\;"
        + "Initial Catalog=TTrainingDatabase;"
        + "Integrated Security=True;"
        + "Connect Timeout=30;"
        + "Encrypt=False;"
        + "TrustServerCertificate=True;"
        + "ApplicationIntent=ReadWrite;"
        + "MultiSubnetFailover=False";

        public Table<ImageFile> imageFiles;

        public TrainingDBContext() : base(ConnectionString)
        {
        }
    }
}
