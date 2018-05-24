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

    //This class contains all fields equal to the columns in a filetable in sql.


    [Table(Name = "imagesTable")]
    public class ImageFile 
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public Guid stream_id { get; set; }

        [Column()]
        public Byte[] file_stream;

        [Column()]
        public string name;

        [Column()]
        public Byte[] path_locator;

        [Column()]
        public Byte[] parent_path_locator;

        [Column()]
        public string file_type;

        [Column()]
        public string cached_file_size;

        [Column()]
        public DateTimeOffset creation_time;

        [Column()]
        public DateTimeOffset last_access_time;

        [Column()]
        public bool is_directory;

        [Column()]
        public bool is_offline;

        [Column()]
        public bool is_hidden;

        [Column()]
        public bool is_readonly;

        [Column()]
        public bool is_archive;

        [Column()]
        public bool is_system;

        [Column()]
        public bool is_temporary;
        
    }
}
