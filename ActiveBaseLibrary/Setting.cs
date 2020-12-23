using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;

namespace ActiveBaseLibrary
{
    internal class DefaultValue : object
    {
        public string KeyName { get; set; }
        public string KeyValue { get; set; }
    }


    public class Setting : object, IDisposable
    {
        public Setting()
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(SettingDefault.AppSettingPath);
                if (info.Exists == false)
                {
                    info.Create();
                }

                FileInfo file = new FileInfo(setFilePath);
                if (file.Exists == false)
                {
                    CreateSettingFile(SelectDefaultValue());
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public string GetDefaultValue(string keyName)
        {
            try
            {
                if (File.Exists(setFilePath))
                {
                    string setValue = File.ReadAllText(setFilePath);
                    List<DefaultValue> setting = JsonConvert.DeserializeObject<List<DefaultValue>>(setValue);
                    foreach (DefaultValue item in setting)
                    {
                        if (item.KeyName == keyName)
                        {
                            return item.KeyValue;
                        }
                    }
                }
                return null;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public bool SetDefaultValue(string keyName, string keyValue)
        {
            try
            {
                if (File.Exists(setFilePath))
                {
                    string setValue = File.ReadAllText(setFilePath);
                    List<DefaultValue> setting = JsonConvert.DeserializeObject<List<DefaultValue>>(setValue);
                    foreach (DefaultValue item in setting)
                    {
                        if (item.KeyName == keyName)
                        {
                            item.KeyValue = keyValue;
                        }
                    }
                    string saveValue = JsonConvert.SerializeObject(setting);
                    File.WriteAllText(setFilePath, saveValue);
                    return true;
                }
                return false;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return false;
            }
        }

        public void Dispose()
        {
        }

        private readonly string setFilePath = Path.Combine(SettingDefault.AppSettingPath
            , SettingDefault.AppJsonFileName);

        private List<DefaultValue> SelectDefaultValue()
        {
            List<DefaultValue> result = new List<DefaultValue>
            {
                new DefaultValue() { KeyName="AppName",             KeyValue=SettingDefault.AppName},
                new DefaultValue() { KeyName="AppVersion",          KeyValue=SettingDefault.AppVersion},
                new DefaultValue() { KeyName="AppSetPath",          KeyValue=SettingDefault.AppSettingPath},
                new DefaultValue() { KeyName="AppCreateBy",         KeyValue=SettingDefault.AppCreateBy},
                new DefaultValue() { KeyName="AppCreateDate",       KeyValue=SettingDefault.AppCreateDate},
                new DefaultValue() { KeyName="AppJsonFileName",     KeyValue=SettingDefault.AppJsonFileName},
                new DefaultValue() { KeyName="Administrator",       KeyValue=SettingDefault.Adminstartor},
                new DefaultValue() { KeyName="AdminPassword",       KeyValue=SettingDefault.AdminPassword},
                new DefaultValue() { KeyName="KakaoTalkServer",     KeyValue=SettingDefault.KakaoTalkAPIServer},
                new DefaultValue() { KeyName="KakaoTalkId",         KeyValue=SettingDefault.KakaoTalkID},
                new DefaultValue() { KeyName="KakaoTalkPassword",   KeyValue=SettingDefault.KakaoTalkPassword},
                new DefaultValue() { KeyName="KakaoTalkExpire",     KeyValue=SettingDefault.KakaoTalkExpire},
                new DefaultValue() { KeyName="KakaoTalkEmail",      KeyValue=SettingDefault.KakaoTalkEmail},
                new DefaultValue() { KeyName="KakaoTalkTelephone",  KeyValue=SettingDefault.KakaoTalkTelephone},

                new DefaultValue() { KeyName="CountryCode",         KeyValue=SettingDefault.CountryCode },
                new DefaultValue() { KeyName="SenderKey",           KeyValue=SettingDefault.SenderKey },
                new DefaultValue() { KeyName="OrgCode",             KeyValue=SettingDefault.OrgCode },
                new DefaultValue() { KeyName="AdFlg",               KeyValue=SettingDefault.AdFlag },
                new DefaultValue() { KeyName="Wide",                KeyValue=SettingDefault.Wide },
            };
            return result;
        }
        private void CreateSettingFile(List<DefaultValue> jSettings)
        {
            try
            {
                if (File.Exists(setFilePath) == false)
                {
                    string setValue = JsonConvert.SerializeObject(jSettings);
                    File.WriteAllText(setFilePath, setValue);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }




    }
}
