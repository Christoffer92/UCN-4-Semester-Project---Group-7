using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageDatabase
{
    public class StageDB
    {
        public bool DatabaseExists()
        {
            try
            {
                using (var db = new StageDBContext())
                {
                    return db.DatabaseExists();
                }
            }
            catch (Exception)
            {
                throw new Exception("No Connection to StageDatabase.");
            }
        }


        public Stream ExtractImageFile(int id)
        {
            throw new NotImplementedException();
        }
    }
}
