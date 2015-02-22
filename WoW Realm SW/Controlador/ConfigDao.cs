using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WoW_Realm_SW.Controlador
{
    public class ConfigDao
    {
        private static string xml_filename = "";
        public static XmlDocument doc = new XmlDocument();
        public static XmlNodeList RealmNameNodes;
        public static XmlNodeList RealmlistNodes;
        public static XmlNodeList RealmlistPathNodes;
        public static XmlNodeList WoWExePathNodes;
        public static XmlNodeList UsernameNodes;
        public static XmlNodeList PasswordNodes;

        public static List<string> RealmNames = new List<string>();
        public static List<string> RealmlistAddresses = new List<string>();
        public static List<string> RealmlistPaths = new List<string>();
        public static List<string> WoWExePaths = new List<string>();

        public static List<string> Usernames = new List<string>();
        public static List<string> Passwords = new List<string>();
        

        // this store structure Realm Name, Realmlist Address
        public static Dictionary<string, string> RealmlistAddressDataList = new Dictionary<string, string>();
        // this store structure Realm Name, realmlist.wtf path
        public static Dictionary<string, string> RealmlistPathDataList = new Dictionary<string, string>();
        // this store structure Realm Name, Wow.exe path
        public static Dictionary<string, string> WoWExePathDataList = new Dictionary<string, string>();
        // this store structure Account Name, Account Password
        public static Dictionary<string, string> AccountsDataList = new Dictionary<string, string>();

        public static void Load(string file)
        {
            xml_filename = file;    
            doc.Load(xml_filename);
            RealmlistAddressDataList.Clear();
            RealmlistPathDataList.Clear();
            WoWExePathDataList.Clear();

            // Node Lists
            RealmNameNodes = doc.SelectNodes("ServerInfo/Realm/Name");
            RealmlistNodes = doc.SelectNodes("ServerInfo/Realm/Realmlist");
            RealmlistPathNodes = doc.SelectNodes("ServerInfo/Realm/rPath");
            WoWExePathNodes = doc.SelectNodes("ServerInfo/Realm/wPath");

            UsernameNodes = doc.SelectNodes("ServerInfo/Account/Username");
            PasswordNodes = doc.SelectNodes("ServerInfo/Account/Password");

            //- Realmlist Addresses id:1
            foreach (XmlNode temp_realmlist1 in RealmlistNodes)
            {
                ConfigDao.RealmlistAddresses.Add(temp_realmlist1.InnerText);
            }

            //- Realmlist Paths id:2
            foreach (XmlNode temp_realmlist2 in RealmlistPathNodes)
            {
                ConfigDao.RealmlistPaths.Add(temp_realmlist2.InnerText);
            }

            //- WoW Exe Paths id:3
            foreach (XmlNode temp_realmlist3 in WoWExePathNodes)
            {
                ConfigDao.WoWExePaths.Add(temp_realmlist3.InnerText);
            }

            //- Realm Names id:1
            foreach (XmlNode Realm in RealmNameNodes)
            {
                ConfigDao.RealmNames.Add(Realm.InnerText);
            }

            //- Realm Names & Realmlist Addresses id:1
            for (int i = 0; i < RealmNames.Count(); i++)
            {
                try
                {
                    ConfigDao.RealmlistAddressDataList.Add(RealmNames[i], RealmlistAddresses[i]);
                }
                catch (ArgumentException) { }
            }

            //- Realm Names & Realmlist Paths id:2
            for (int i = 0; i < ConfigDao.RealmlistPaths.Count(); i++)
            {
                try
                {
                    RealmlistPathDataList.Add(RealmNames[i], RealmlistPaths[i]);
                }
                catch (ArgumentException) { }
            }

            //- Realm Names & WoW Exe Paths id:3
            for (int i = 0; i < ConfigDao.WoWExePaths.Count(); i++)
            {
                try
                {
                    WoWExePathDataList.Add(RealmNames[i], WoWExePaths[i]);
                }
                catch (ArgumentException) { }
            }

            /* ACC Load */
            ConfigDao.AccountsDataList.Clear();

            //- Account Usernames
            foreach (XmlNode temp_username1 in UsernameNodes)
            {
                Usernames.Add(temp_username1.InnerText);
            }

            //- Account Passwords
            foreach (XmlNode temp_password1 in PasswordNodes)
            {
                Passwords.Add(temp_password1.InnerText);
            }

            //- Account Usernames & Passwords
            for (int i = 0; i < Usernames.Count(); i++)
            {
                try
                {
                    AccountsDataList.Add(Usernames[i], Passwords[i]);
                }
                catch (ArgumentException) { }
            }



        }
    }
}
