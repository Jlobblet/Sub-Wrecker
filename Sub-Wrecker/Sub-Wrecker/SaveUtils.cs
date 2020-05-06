using System.IO;
using System.IO.Compression;
using System.Xml.Linq;

namespace Sub_Wrecker
{
    internal class SaveUtils
    {
        public static XDocument LoadSub(string fileName)
        {
            using (FileStream originalFileStream = new FileStream(fileName, FileMode.Open))
            {
                using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                {
                    XDocument doc = XDocument.Load(decompressionStream);
                    return doc;
                }
            }
        }

        public static void SaveSub(XDocument sub, string fileName)
        {
            string temp = Path.GetTempFileName();
            File.WriteAllText(temp, sub.ToString());
            byte[] b;
            using (FileStream fs = new FileStream(temp, FileMode.Open))
            {
                b = new byte[fs.Length];
                fs.Read(b, 0, (int)fs.Length);
            }
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            using (GZipStream gz = new GZipStream(fs, CompressionMode.Compress, false))
            {
                gz.Write(b, 0, b.Length);
            }
        }
    }
}
