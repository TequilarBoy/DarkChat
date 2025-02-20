using DarkChat.Helpers;
using DarkClient.Unit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DarkChat
{
    public static class Settings
    {
        public static string Version { private set; get; } = "v1.3.3";
        // Private key content
        public static string privKey { set; get; } = "";
        // Public key content
        public static string pubKey { set; get; } = "";
        // Default private key path
        public static string keyPath { set; get; } = "";
        // Default public key path
        public static string pubKeyPath { set; get; } = "";
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
        // Mutant name 
        public static string mutexName = "DarkChatMutex";

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
                { "PubKeyPath", Settings.pubKeyPath },
                { "PubKey", Settings.pubKey },
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

        public static bool ReadKeysPair()
        {
            try
            {
                var rsa = ClientsHive.GetHive.rsa;

                if (string.IsNullOrEmpty(Settings.privKey))
                {
                    if (File.Exists(Settings.keyPath))
                    {
                        Settings.privKey = IO.ReadTextFile(Settings.keyPath);
                    }
                    else
                    {
                        return false;
                    }
                }
                if (!rsa.IsPkcs1PrivateKey(Settings.privKey))
                {
                    return false;
                }

                if (string.IsNullOrEmpty(Settings.pubKey))
                {
                    if (File.Exists(Settings.pubKeyPath))
                    {
                        Settings.pubKey = IO.ReadTextFile(Settings.pubKeyPath);
                    }
                    else
                    {
                        return false;
                    }
                }
                if (!rsa.IsPkcs1PublicKey(Settings.pubKey))
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                return false;
            }
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
                Settings.pubKey = dictSettings["PubKey"].ToString();
                Settings.pubKeyPath = dictSettings["PubKeyPath"].ToString();

                var rsa = ClientsHive.GetHive.rsa;

                if (!rsa.IsPkcs1PrivateKey(Settings.privKey))
                {
                    if (!File.Exists(Settings.keyPath))
                    {
                        Logger.Log("Wrong keys pair, regenerate it");
                        SettingLoadUINotify(false);
                        return false;
                    }
                    // Read the key again and check
                    Settings.privKey = IO.ReadTextFile(Settings.keyPath);

                    if (!rsa.IsPkcs1PrivateKey(Settings.privKey))
                    {
                        Logger.Log("Wrong keys pair, regenerate it");
                        SettingLoadUINotify(false);
                        return false;
                    }
                }

                if (!rsa.IsPkcs1PublicKey(Settings.pubKey))
                {
                    if (!File.Exists(Settings.pubKeyPath))
                    {
                        Logger.Log("Wrong keys pair, regenerate it");
                        SettingLoadUINotify(false);
                        return false;
                    }
                    // Read the key again and check
                    Settings.pubKey = IO.ReadTextFile(Settings.pubKeyPath);

                    if (!rsa.IsPkcs1PublicKey(Settings.pubKey))
                    {
                        Logger.Log("Wrong keys pair, regenerate it");
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

        public static void InitSettings()
        {
            try
            {
                // Keep singleton
                if (Settings.singleServer)
                {
                    if (!MutexControl.CreateMutex())
                    {
                        Environment.Exit(0);
                    }
                }
                // Set Autostartup
                if (Settings.autoStart)
                {
                    Install.Autostartup();
                }
            }
            catch { }
        }
        
    }
}
