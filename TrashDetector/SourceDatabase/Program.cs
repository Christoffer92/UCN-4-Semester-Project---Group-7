using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceDatabase
{
    class Program
    {
        static void Main(string[] args)
        {

            var db = new SourceDB();

            db.DatabaseExists();
        }
    }
}
