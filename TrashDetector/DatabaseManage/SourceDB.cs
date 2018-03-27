using System;
using ModelLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManage
{
    public class SourceDB
    {
        public bool DatabaseExists()
        {
            try
            {
                using (var db = new SourceDBContext())
                {
                    return db.DatabaseExists();
                }
            }
            catch (Exception)
            {
                throw new Exception("No Connection to the Database.");
            }
        }

        public Image InsertImage(Image image)
        {
            Console.WriteLine(image.Longtitude);
            using (var db = new SourceDBContext())
            {
                db.Images.InsertOnSubmit(image);
                db.SubmitChanges();
            }
            return image;
        }

    }
}
