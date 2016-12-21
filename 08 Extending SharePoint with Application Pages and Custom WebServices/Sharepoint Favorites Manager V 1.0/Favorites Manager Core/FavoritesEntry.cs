using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Integrations
{
    public class FavoritesEntry
    {
        public FavoritesEntry()
        {
            topic = string.Empty;
        }

        #region Properties & Fields

        private Guid spid;

        public Guid SPID
        {
            get { return spid; }
            set { spid = value; }
        }

        private string display;

        public string Display
        {
            get { return display; }
            set { display = value; }
        }

        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        private string topic;

        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }

        private DateTime modified;

        public DateTime Modified
        {
            get { return modified; }
            set { modified = value; }
        }

        private string localPath;

        public string LocalPath
        {
            get { return localPath; }
            set { localPath = value; }
        }

        #endregion

        #region Serialization

        public static string Serialize(FavoritesEntry[] Favorites)
        {
            StringWriter writer = new StringWriter();
            XmlSerializer ser = new XmlSerializer(typeof(FavoritesEntry[]));
            ser.Serialize(writer, Favorites);
            return writer.ToString();
        }

        public static FavoritesEntry[] Deserialize(string Favorites)
        {
            XmlSerializer ser = new XmlSerializer(typeof(FavoritesEntry[]));
            StringReader reader = new StringReader(Favorites);
            return (FavoritesEntry[])ser.Deserialize(reader);
        }

        #endregion

        public static List<FavoritesEntry> GetLocalFavorites()
        {
            string FavoritesPath = Environment.GetFolderPath(Environment.SpecialFolder.Favorites);
            DirectoryInfo FavoritesDir = new DirectoryInfo(FavoritesPath);

            List<FavoritesEntry> result = new List<FavoritesEntry>();
            FavoritesEntry item;

            foreach (FileInfo file in FavoritesDir.GetFiles("*.url", SearchOption.AllDirectories))
            {
                item = new FavoritesEntry();
                item.Display = file.Name.Substring(0, file.Name.Length - 4);
                if(FavoritesPath!=file.DirectoryName)
                {
                    item.Topic = file.Directory.Name;                    
                }
                else
                {
                    item.Topic = string.Empty;
                }

                item.Url = ReadURLFromFile(file.FullName);
                item.Modified = file.LastWriteTime;
                item.LocalPath = file.FullName;
                result.Add(item);
            }
            return result;
        }

        public static string CreateLocalFavorite(FavoritesEntry Favorite)
        {
            string dir = GetFavoritesDirectory(Favorite);

            if (Directory.Exists(dir) == false)
            {
                Directory.CreateDirectory(dir);
            }

            string path = GetFavoritesPath(dir, Favorite);

            DeleteLocalFavorite(path);

            StreamWriter sw = File.CreateText(path);
            sw.WriteLine("[DEFAULT]");
            sw.WriteLine("BASEURL=" + Favorite.Url);
            sw.WriteLine("[InternetShortcut]");
            sw.WriteLine("URL=" + Favorite.Url);
            sw.WriteLine("IDList=[{000214A0-0000-0000-C000-000000000046}]");
            sw.WriteLine("Prop3=19,2");
            sw.Close();

            return path;
        }

        public static void DeleteLocalFavorite(string Path)
        {
            FileInfo f = new FileInfo(Path);    
            f.Delete();
        }
        
        public static void DeleteLocalFavorite(FavoritesEntry Favorite)
        {
            string path = GetFavoritesPath(GetFavoritesDirectory(Favorite), Favorite);
            DeleteLocalFavorite(path);
        }

        private static string ReadURLFromFile(string path)
        {
            StreamReader sr = File.OpenText(path);
            string result = string.Empty;
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                if (line.Substring(0, 3).ToLower() == "url")
                {
                    result = line.Substring(4);
                    break;
                }
            }
            sr.Dispose();

            return result;
        }

        private static string GetFavoritesDirectory(FavoritesEntry item)
        {
            string FavoritesPath = Environment.GetFolderPath(Environment.SpecialFolder.Favorites);
            return FavoritesPath + "\\" + item.Topic;
        }

        private static string GetFavoritesPath(string path, FavoritesEntry item)
        {
            if (item.Topic != string.Empty)
            {
                path += @"\";
            }

            path += item.Display + ".url";
            return path;
        }

    }
}