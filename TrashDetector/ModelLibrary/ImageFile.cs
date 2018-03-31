using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace ModelLibrary
{
    [Table(Name = "images")]
    public class ImageFile 
    {
        //Image file field will be done later.

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }


        [Column()]
        public Stream fileStream;




        [Column()]
        public string Longtitude { get; set; }

        [Column()]
        private string Latitude { get; set; }

        
    }
}
