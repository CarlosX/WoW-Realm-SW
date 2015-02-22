using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WoW_Realm_SW.Properties;

namespace WoW_Realm_SW
{
    class MyFunctions
    {
        public static string GetAppVersion()
        {
            string version = "0";
            try
            {
                WebClient client = new WebClient();
                Stream stream = client.OpenRead(Settings.Default["version_url"].ToString());
                StreamReader reader = new StreamReader(stream);
                string version_data = reader.ReadToEnd();
                reader.Close();
                stream.Close();

                version = version_data.Substring(version_data.IndexOf("Version = ") + "Version = ".Length);
            }
            catch { }
            return version;
        }

        public static string base64Encode(string data)
        {
            try
            {
                byte[] encData_byte = new byte[data.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(data);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception e)
            {
                throw new Exception("Error in base64Encode" + e.Message);
            }
        }

        public static string base64Decode(string sData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(sData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
    }
}
