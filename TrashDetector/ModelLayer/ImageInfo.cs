using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{

    [Table(Name = "ImageInfoTable")]
    public class ImageInfo
    {

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        [Column()]
        public int ImageFileID { get; set; }

        [Column()]
        public string LocationPoint { get; set; }

        [Column()]
        public bool IsTrash { get; set; }
    }
}
