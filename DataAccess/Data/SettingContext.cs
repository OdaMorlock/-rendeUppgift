using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DataAccess.Data
{
    public static class SettingContext
    {
        private static string fileName = "settings.json";
        private static Settings _settings { get; set; }


        public static async Task CreateSettingsFile()
        {
            FileInfo fInfo = new FileInfo(fileName);
            if (fInfo.Exists)
            {
                StorageFile storageFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName);
            }

        }

        public static async Task GetSettingsInfo()
        {


            StorageFile settingsFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);

            _settings = JsonConvert.DeserializeObject<Settings>(await FileIO.ReadTextAsync(settingsFile));
        }

        public static async Task<IEnumerable<string>> GetStatus()
        {
            var list = new List<string>();




            foreach (var status in _settings.status)
            {
                list.Add(status);
            }



            return list;
        }
        public static int GetMaxItemsCount()
        {
            return _settings.maxItemsCount;
        }
    }

    public class Settings
    {
        public string[] status { get; set; }
        public int maxItemsCount { get; set; }
    }
}