using DarkChat.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkChat
{
    public static class Settings
    {
        public static string Version { private set; get; } = "v1.2.0";
        // Private key content
        public static string privKey { set; get; } = "";
        // Default private key path
        public static string keyPath { set; get; } = "";
        // Singleton server mode
        public static bool singleServer = false;
        // If auto start after restarting the host
        public static bool autoStart = false;
        // Default bind port
        public static int port = 0;
        // Default bind ip
        public static string ip = "";
        // Default config file path
        public static string configPath = "darkconfig.json";

        public static event Action<bool> OnSettingLoadUINotify;

        public static bool WriteSettings(string path)
        {
            var dictSettings = new Dictionary<string, object>()
            {
                { "Version", Settings.Version },
                { "IP", Settings.ip },
                { "Port", Settings.port },
                { "KeyPath", Settings.keyPath },
                { "PrivKey", Settings.privKey },
                { "AutoStart", Settings.autoStart },
                { "SingleServer", Settings.singleServer }
            };
            string jsonConfig = JsonConvert.SerializeObject(dictSettings, Formatting.Indented);

            return IO.WriteTextFile(path, jsonConfig);
        }

        public static void SettingLoadUINotify(bool loadok)
        {
            OnSettingLoadUINotify?.Invoke(loadok);
        }

        public static bool ReadSettings(string path)
        {
            string keyPath = string.Empty;

            try
            {
                if (null == path || !File.Exists(path))
                {
                    string defaultConfigPath = Settings.configPath;
                    // If config file doesn't exist, find the default path
                    if (!File.Exists(defaultConfigPath))
                    {
                        Logger.Log("Can't find the config file, generate it first.");
                        SettingLoadUINotify(false);
                        return false;
                    }
                    else
                    {
                        keyPath = defaultConfigPath;
                    }
                }
                else
                {
                    keyPath = path;
                }

                string jsonConfig = File.ReadAllText(keyPath, Encoding.UTF8);

                var dictSettings = JsonConvert.DeserializeObject<Dictionary<string, object> >(jsonConfig);

                if (Settings.Version != dictSettings["Version"].ToString())
                {
                    Logger.Log("The version of the configuration file does not match, regenerate it");
                    SettingLoadUINotify(false);
                    return false;
                }

                Settings.privKey = dictSettings["PrivKey"].ToString();
                Settings.autoStart = Convert.ToBoolean(dictSettings["AutoStart"]);
                Settings.singleServer = Convert.ToBoolean(dictSettings["SingleServer"]);
                Settings.port = Convert.ToInt32(dictSettings["Port"]);
                Settings.ip = dictSettings["IP"].ToString();
                Settings.keyPath = dictSettings["KeyPath"].ToString();

                if (!Settings.privKey.StartsWith("-----BEGIN PUBLIC KEY-----") ||
                    !Settings.privKey.EndsWith("-----END PUBLIC KEY-----\r\n"))
                {
                    if (!File.Exists(Settings.keyPath))
                    {
                        Logger.Log("The version of the configuration file does not match, regenerate it");
                        SettingLoadUINotify(false);
                        return false;
                    }
                    // Read the key again and check
                    Settings.privKey = IO.ReadTextFile(Settings.keyPath);
                    if (!Settings.privKey.StartsWith("-----BEGIN PUBLIC KEY-----") ||
                    !Settings.privKey.EndsWith("-----END PUBLIC KEY-----\r\n"))
                    {
                        Logger.Log("The version of the configuration file does not match, regenerate it");
                        SettingLoadUINotify(false);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            SettingLoadUINotify(true);
            Logger.Log("Load configuration successfully");

            return true;
        }
        
    }
}
