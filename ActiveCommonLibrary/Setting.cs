using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;

namespace ActiveCommonLibrary
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
                new DefaultValue() { KeyName="BizTalkServer",       KeyValue=SettingDefault.BizTalkAPIServer},
                new DefaultValue() { KeyName="BizTalkUserId",       KeyValue=SettingDefault.BizTalkUserID},
                new DefaultValue() { KeyName="BizTalkPassword",     KeyValue=SettingDefault.BizTalkPassword},
                new DefaultValue() { KeyName="BizTalkToken",        KeyValue=SettingDefault.BizTalkToken },
                new DefaultValue() { KeyName="BizTalkExpire",       KeyValue=SettingDefault.BizTalkExpire},

                new DefaultValue() { KeyName="BizTalkAttachPath",   KeyValue=SettingDefault.BizTalkAttachPath},
                new DefaultValue() { KeyName="BizTalkEmail",        KeyValue=SettingDefault.BizTalkEmail},
                new DefaultValue() { KeyName="BizTalkTelephone",    KeyValue=SettingDefault.BizTalkTelephone},
                new DefaultValue() { KeyName="CountryCode",         KeyValue=SettingDefault.CountryCode},
                
                new DefaultValue() { KeyName="SenderKey",           KeyValue=SettingDefault.SenderKey },
                new DefaultValue() { KeyName="Organization",        KeyValue=SettingDefault.Organization },
                new DefaultValue() { KeyName="AdFlag",              KeyValue=SettingDefault.AdFlag },
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

    internal static class SettingDefault : object
    {
        public const string AppName = @"ActiveSnsUsingKakaoTalk";
        public const string AppVersion = @"202012.001";
        public const string AppSettingPath = @"C:\Active\";
        public const string AppCreateBy = @"home21cc@gmail.com";
        public const string AppCreateDate = @"20201221";
        public const string AppJsonFileName = @"ActiveSnsUsingKakaoTolk.json";

        public const string Adminstartor = @"home21cc@gmail.com";
        public const string AdminPassword = @"800022";
        public const string BizTalkAPIServer = @"https://www.biztalk-api.com";
        public const string BizTalkUserID = @"tkbend";
        public const string BizTalkPassword = @"28fb33ae1e734429d896dd5901cc90978da559e1";
        public const string BizTalkToken = @"";
        public const string BizTalkExpire = @"1440";
        public const string BizTalkAttachPath = @"C:\PAYLIST\";
        public const string BizTalkEmail = @"support@biztalk.co.kr";
        public const string BizTalkTelephone = @"02-552-0093";
        

        public const string CountryCode = "82";
        public const string SenderKey = "";
        public const string Organization = "총무";
        public const string AdFlag = "N";
        public const string Wide = "N";
    }
}
