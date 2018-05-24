using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace ModelLayer
{
    [Table(Name = "ImageFiles")]
    public class ImageFile
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        [Column()]
        public string FileName { get; set; }

        [Column()]
        public string FilePath { get; set; }
    }
}
