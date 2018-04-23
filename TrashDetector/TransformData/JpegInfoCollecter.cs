using ModelLayer;
using SourceDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using StageDatabase;

namespace TransformData
{
    public class JpegInfoCollecter
    {

        private Dictionary<string, string> PropIdDictionary;

        public JpegInfoCollecter() {
            PopulatePropIdDictionary();
        }

        public void PopulatePropIdDictionary()
        {
            //This dictionary is made by looking at the table at https://msdn.microsoft.com/en-us/library/system.drawing.imaging.propertyitem.id(v=vs.110).aspx
            PropIdDictionary = new Dictionary<string, string>();
            #region Adding key value pairs
            PropIdDictionary.Add("10f", "EquipMake");
            PropIdDictionary.Add("110", "EquipModel");
            PropIdDictionary.Add("11a", "TagXResolution");
            PropIdDictionary.Add("11b", "YResolution");
            PropIdDictionary.Add("128", "ResolutionUnit");
            PropIdDictionary.Add("131", "SoftwareUsed");
            PropIdDictionary.Add("132", "DateTime");
            PropIdDictionary.Add("213", "YCbCrPositioning");
            PropIdDictionary.Add("829a", "ExposureTime");
            PropIdDictionary.Add("829d", "ExposureTime");
            PropIdDictionary.Add("8822", "ExposureProg");
            PropIdDictionary.Add("8827", "ISOSpeed");
            PropIdDictionary.Add("9000", "ISOSpeed");
            PropIdDictionary.Add("9003", "DTOrig");
            PropIdDictionary.Add("9004", "DTDigitized");
            PropIdDictionary.Add("9101", "CompConfig");
            PropIdDictionary.Add("9201", "ShutterSpeed");
            PropIdDictionary.Add("9202", "Aperture");
            PropIdDictionary.Add("9203", "Brightness");
            PropIdDictionary.Add("9207", "MeteringMode");
            PropIdDictionary.Add("9209", "Flash");
            PropIdDictionary.Add("920a", "FocalLength");
            PropIdDictionary.Add("9290", "DTSubsec");
            PropIdDictionary.Add("9291", "DTOrigSS");
            PropIdDictionary.Add("9292", "DTDigSS");
            PropIdDictionary.Add("a406", "Uknown");
            PropIdDictionary.Add("a000", "FPXVer");
            PropIdDictionary.Add("a001", "ColorSpace");
            PropIdDictionary.Add("a002", "PixXDim");
            PropIdDictionary.Add("a003", "PixYDim");
            PropIdDictionary.Add("5041", "Uknown");
            PropIdDictionary.Add("5042", "Uknown");
            PropIdDictionary.Add("a217", "SensingMethod");
            PropIdDictionary.Add("a301", "SceneType");
            PropIdDictionary.Add("a402", "Uknown");
            PropIdDictionary.Add("a403", "Uknown");
            PropIdDictionary.Add("a405", "Uknown");
            PropIdDictionary.Add("1", "GpsLatitudeRef");
            PropIdDictionary.Add("2", "GpsLatitude");
            PropIdDictionary.Add("3", "GpsLongitudeRef");
            PropIdDictionary.Add("4", "GpsLongitude");
            PropIdDictionary.Add("5", "GpsAltitudeRef");
            PropIdDictionary.Add("6", "GpsAltitude");
            PropIdDictionary.Add("7", "GpsGpsTime");
            PropIdDictionary.Add("1d", "Uknown");
            PropIdDictionary.Add("501b", "ThumbnailData");
            PropIdDictionary.Add("5023", "ThumbnailCompression");
            PropIdDictionary.Add("502d", "ThumbnailResolutionX");
            PropIdDictionary.Add("502e", "ThumbnailResolutionY");
            PropIdDictionary.Add("5030", "ThumbnailResolutionUnit");
            PropIdDictionary.Add("201", "JPEGInterFormat");
            PropIdDictionary.Add("202", "JPEGInterLength");
            PropIdDictionary.Add("5091", "ChrominanceTable");
            PropIdDictionary.Add("5090", "LuminanceTable");
            #endregion
        }

        public string ConvertExifValueToString(PropertyItem propertyItem)
        {
            //this method is made with the information on property types at: https://msdn.microsoft.com/da-dk/library/s3f49ktz.aspx
            switch (propertyItem.Type)
            {
                case 1:
                    {
                        return "unknown";
                    }
                case 2:
                    {
                        System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                        string valueStr = encoding.GetString(propertyItem.Value);
                        return valueStr;
                    }
                case 3:
                    {
                        int value = BitConverter.ToInt16(propertyItem.Value, 0);
                        return value.ToString();
                    }
                case 4:
                    {
                        return BitConverter.ToUInt32(propertyItem.Value, 0).ToString();
                    }
                case 5:
                    {
                        //System.GPS.Latitude
                        //string value1 = propertyItem.Value[0].ToString();
                        // string value2 = propertyItem.Value[1].ToString();
                        // string value3 = propertyItem.Value[2].ToString();

                        //return value1 + " ";// + value2 + " " + value3;


                        //string res = System.Text.Encoding.UTF8.GetString(propertyItem.Value);

                        //return res;


                        /*
                        /*
                            Specifies that Value data member is an array of pairs of unsigned long integers. Each pair represents a fraction; the first integer is the numerator and the second integer is the denominator. 
                         * */
                        //one pair is 4 bytes
                        // ulong value = BitConverter.ToUInt32(propertyItem.Value, 0);
                        //ulong value2 = BitConverter.ToUInt32(propertyItem.Value, 4);

                        //double value = BitConverter.ToUInt32(propertyItem.Value, 0);
                        //double value2 = BitConverter.ToUInt32(propertyItem.Value, 4);

                        // double value2 = BitConverter.ToDouble(propertyItem.Value, 0);
                        //double value2 = BitConverter.ToDouble(propertyItem.Value, 2);


                        // return value + " & " + value2;

                        //uint degreesNumerator = BitConverter.ToUInt32(propertyItem.Value, 0);
                        //uint degreesDenominator = BitConverter.ToUInt32(propertyItem.Value, 1);
                        //uint minutesNumerator = BitConverter.ToUInt32(propertyItem.Value, 2);
                        // uint minutesDenominator = BitConverter.ToUInt32(propertyItem.Value, 12);
                        //uint secondsNumerator = BitConverter.ToUInt32(propertyItem.Value, 16);
                        // uint secondsDenominator = BitConverter.ToUInt32(propertyItem.Value, 20);

                        //return degreesNumerator + "&" + degreesDenominator;

                        //BitConverter.ToUInt32(propertyItem.Value, 8);

                        // photo.exif.

                        // return BitConverter.ToUInt32(propertyItem.Value, 0) + " " + BitConverter.ToUInt32(propertyItem.Value, 1) + " " + BitConverter.ToUInt32(propertyItem.Value, 2);

                        // return DecodeRational64u(propertyItem.Value);

                        //string gpsLatitudeRef = BitConverter.ToChar(image.GetPropertyItem(1).Value, 0).ToString();
                        //string latitude = DecodeRational64u(image.GetPropertyItem(2));
                        //string gpsLongitudeRef = BitConverter.ToChar(image.GetPropertyItem(3).Value, 0).ToString();
                        //string longitude = DecodeRational64u(image.GetPropertyItem(4));
                        //Console.WriteLine("{0}\t{1} {2}, {3} {4}", file, gpsLatitudeRef, latitude, gpsLongitudeRef, longitude);

                        //8-8-8

                        uint dN = BitConverter.ToUInt32(propertyItem.Value, 0);
                        uint dD = BitConverter.ToUInt32(propertyItem.Value, 4);
                        uint dD2 = 0;


                        if (propertyItem.Id == 2 || propertyItem.Id == 3){
                            dN = BitConverter.ToUInt32(propertyItem.Value, 0);
                            dD = BitConverter.ToUInt32(propertyItem.Value, 4);
                            dD2 = BitConverter.ToUInt32(propertyItem.Value, 8);
                        }


                            return dN + " " + dD + " " + dD2;
                    }
                case 6:
                    {
                        return "unknown";
                    }
                case 7:
                    {
                        return "unknown";
                    }
                    

                default:
                    break;
            }

            return null;
        }

        public void PrintMetaData(Image image)
        {
            PropertyItem[] propItems = image.PropertyItems;

            foreach (PropertyItem propertyItem in propItems)
            {
                string idTitle = PropIdDictionary[propertyItem.Id.ToString("x")];
                string exifValue = ConvertExifValueToString(propertyItem);

                Console.WriteLine(idTitle + ": " + exifValue);
            }
        }

        public void CollectInformation()
        {
            SourceDB sourceDB = new SourceDB();

            // ImageFile imageFile = sourceDB.GetImageFile(1);

            //Image image = new Bitmap(@"C:\TrashDetector\Data\SourceDBData\SimpelExample.jpg");

            //PrintMetaData(image);

            //ExtractLocation(image1);
            
                       
   

            List<ImageFile> imageFiles = sourceDB.GetAllImageFiles();

            int i = 1;

            foreach (ImageFile imageFile in imageFiles)
                        {
                            Console.WriteLine("Inserting image: " + imageFile.FileName + " | " + i + " / " + imageFiles.Count);
                            ImageInfo imageInfo = CollectImageInfo(imageFile);
                            InsertSingleImageInfoIntoDB(imageInfo);
                            i++;
                        }
        }

        public ImageInfo CollectImageInfo(ImageFile imageFile)
        {
            Image image = new Bitmap(imageFile.FilePath);

            ImageInfo imageInfo = new ImageInfo();
            imageInfo.ImageFileID = imageFile.ID;

            try
            {
                imageInfo.Longitude = GetLongitude(image);
                imageInfo.Latitiude = GetLatitiude(image);
                imageInfo.DateCreated = GetDateCreated(image);
            }
            catch (Exception)
            {
                
            }


            return imageInfo;
        }

        private string GetDateCreated(Image image)
        {

            return ConvertExifValueToString(image.GetPropertyItem(306));

        }

        public void InsertSingleImageInfoIntoDB(ImageInfo imageInfo)
        {

            StageDB stageDB = new StageDB();
            stageDB.InsertImageInfo(imageInfo);
        }

        public decimal GetLongitude(Image image)
        {
            decimal latiti = DecodeRational64uTest(image.GetPropertyItem(2));
            return latiti;
        }

        public decimal GetLatitiude(Image image)
        {
            decimal latiti = DecodeRational64uTest(image.GetPropertyItem(4));
            return latiti;
        }

        private static void ExtractLocation(Image image)
        {

                    // GPS Tag Names
                    // http://www.sno.phy.queensu.ca/~phil/exiftool/TagNames/GPS.html

                    // Check to see if we have gps data
                    if (Array.IndexOf<int>(image.PropertyIdList, 1) != -1 &&
                        Array.IndexOf<int>(image.PropertyIdList, 2) != -1 &&
                        Array.IndexOf<int>(image.PropertyIdList, 3) != -1 &&
                        Array.IndexOf<int>(image.PropertyIdList, 4) != -1)
                    {
                        string gpsLatitudeRef = BitConverter.ToChar(image.GetPropertyItem(1).Value, 0).ToString();
                        string latitude = DecodeRational64u(image.GetPropertyItem(2));
                        string gpsLongitudeRef = BitConverter.ToChar(image.GetPropertyItem(3).Value, 0).ToString();
                        string longitude = DecodeRational64u(image.GetPropertyItem(4));
                        Console.WriteLine("\t{0} {1}, {2} {3}", gpsLatitudeRef, latitude, gpsLongitudeRef, longitude);
                    }

            decimal latiti = DecodeRational64uTest(image.GetPropertyItem(2));
            decimal longiti = DecodeRational64uTest(image.GetPropertyItem(4));

            Console.WriteLine("   Latitude:" + latiti + "   longitude:" + longiti);

            //N 57° 1' 48,6", E 9° 56' 23,6" 
            //57.030179, 9.939889
            // Decimal Degrees = Degrees + minutes/60 + seconds/3600
            // 57 + 1/60 + 48,6/3600
        }

        private static string DecodeRational64u(System.Drawing.Imaging.PropertyItem propertyItem)
        {
            uint dN = BitConverter.ToUInt32(propertyItem.Value, 0);
            uint dD = BitConverter.ToUInt32(propertyItem.Value, 4);
            uint mN = BitConverter.ToUInt32(propertyItem.Value, 8);
            uint mD = BitConverter.ToUInt32(propertyItem.Value, 12);
            uint sN = BitConverter.ToUInt32(propertyItem.Value, 16);
            uint sD = BitConverter.ToUInt32(propertyItem.Value, 20);

            decimal deg;
            decimal min;
            decimal sec;
            // Found some examples where you could get a zero denominator and no one likes to devide by zero
            if (dD > 0) { deg = (decimal)dN / dD; } else { deg = dN; }
            if (mD > 0) { min = (decimal)mN / mD; } else { min = mN; }
            if (sD > 0) { sec = (decimal)sN / sD; } else { sec = sN; }

            if (sec == 0) return string.Format("{0}° {1:0.###}'", deg, min);
            else return string.Format("{0}° {1:0}' {2:0.#}\"", deg, min, sec);
        }

        private static decimal DecodeRational64uTest(System.Drawing.Imaging.PropertyItem propertyItem)
        {
            uint dN = BitConverter.ToUInt32(propertyItem.Value, 0);
            uint dD = BitConverter.ToUInt32(propertyItem.Value, 4);
            uint mN = BitConverter.ToUInt32(propertyItem.Value, 8);
            uint mD = BitConverter.ToUInt32(propertyItem.Value, 12);
            uint sN = BitConverter.ToUInt32(propertyItem.Value, 16);
            uint sD = BitConverter.ToUInt32(propertyItem.Value, 20);

            decimal deg;
            decimal min;
            decimal sec;
            // Found some examples where you could get a zero denominator and no one likes to devide by zero
            if (dD > 0) { deg = (decimal)dN / dD; } else { deg = dN; }
            if (mD > 0) { min = (decimal)mN / mD; } else { min = mN; }
            if (sD > 0) { sec = (decimal)sN / sD; } else { sec = sN; }

            // Decimal Degrees = Degrees + minutes / 60 + seconds / 3600
            return deg + min / 60 + sec / 3600; 


            //if (sec == 0) return string.Format("{0}° {1:0.###}'", deg, min);
            //else return string.Format("{0}° {1:0}' {2:0.#}\"", deg, min, sec);
        }
    }
}








   