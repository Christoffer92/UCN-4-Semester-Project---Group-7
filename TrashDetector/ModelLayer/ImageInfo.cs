using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{

    [Table(Name = "ImageInfos")]
    public class ImageInfo
    {

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        [Column()]
        public int ImageFileID { get; set; }


        [Column()]
        public decimal Latitiude { get; set; }

        [Column()]
        public decimal Longitude { get; set; }

        [Column()]
        public string DateCreated { get; set; }

        [Column()]
        public bool IsTrash { get; set; }
    }
}
