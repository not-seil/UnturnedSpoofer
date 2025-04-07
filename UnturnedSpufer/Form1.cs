using System;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace UnturnedSpufer
{
    public partial class Form1 : Form
    {
        private static Random random = new Random();
        private static string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Изменение MachineGuid
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                using (RegistryKey registryKey = baseKey.OpenSubKey(@"SOFTWARE\Microsoft\Cryptography", true))
                {
                    if (registryKey == null)
                    {
                        AppendText("Не удалось открыть раздел реестра...");
                        return;
                    }

                    object guidValue = registryKey.GetValue("MachineGuid");
                    if (guidValue == null)
                    {
                        AppendText("Не найден MachineGuid в реестре...");
                        return;
                    }

                    string oldGuid = guidValue.ToString();
                    string newGUID = GetNewGUID(oldGuid);
                    registryKey.SetValue("MachineGuid", newGUID);
                    Console.Beep();
                    AppendText($"MachineGuid изменен:\nБыло: {oldGuid}\nСтало: {newGUID}");
                }
            }
            catch (UnauthorizedAccessException)
            {
                AppendText("Нет прав для изменения реестра. Запустите программу от имени администратора...");
            }
            catch (Exception ex)
            {
                AppendText($"Ошибка при изменении MachineGuid: {ex.Message}");
            }

            try
            {
                // Изменение CloudStorageHash
                using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64)
                    .OpenSubKey("SOFTWARE\\Smartly Dressed Games\\Unturned", true))
                {
                    if (registryKey == null)
                    {
                        AppendText("Не удалось открыть раздел реестра Unturned...");
                        return;
                    }

                    var cloudStorageValue = registryKey.GetValue("CloudStorageHash_h1878083263") as byte[];
                    if (cloudStorageValue == null)
                    {
                        AppendText("CloudStorageHash не найден...");
                        return;
                    }

                    string originalString = new string(cloudStorageValue.Where(b => b > 0).Select(b => (char)b).ToArray());
                    string newString = RandomString(originalString.Length);
                    byte[] newValue = newString.Select(c => (byte)c).Concat(new byte[] { 0 }).ToArray();

                    registryKey.SetValue("CloudStorageHash_h1878083263", newValue);
                    Console.Beep();
                    AppendText("CloudStorageHash updated...");
                }
            }
            catch (Exception ex)
            {
                AppendText($"Ошибка при изменении CloudStorageHash: {ex.Message}");
            }

            try
            {
                // Изменение ItemStoreCache
                using (RegistryKey steamKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                    .OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam App 304930", false))
                {
                    if (steamKey == null)
                    {
                        AppendText("Не найден раздел реестра Steam App 304930...");
                        return;
                    }

                    string installLocation = steamKey.GetValue("InstallLocation") as string;
                    if (string.IsNullOrEmpty(installLocation))
                    {
                        AppendText("Не найден путь установки Unturned...");
                        return;
                    }

                    string path = Path.Combine(installLocation, "Cloud", "ConvenientSavedata.json");
                    if (!File.Exists(path))
                    {
                        AppendText("Файл ConvenientSavedata.json не найден...");
                        return;
                    }

                    ConfigClass configClass = JsonConvert.DeserializeObject<ConfigClass>(File.ReadAllText(path));
                    if (configClass.Strings.TryGetValue("ItemStoreCache", out string text))
                    {
                        string value = RandomString(text.Length);
                        configClass.Strings["ItemStoreCache"] = value;
                        File.WriteAllText(path, JsonConvert.SerializeObject(configClass, Formatting.Indented));
                        Console.Beep();
                        AppendText("ItemStorageHash updated...");
                        Console.Beep();
                        MessageBox.Show("Cleaned");
                    }
                    else
                    {
                        AppendText("ItemStoreCache не найден в ConvenientSavedata.json");
                    }
                }
            }
            catch (Exception ex)
            {
                AppendText($"Ошибка при изменении ItemStoreCache: {ex.Message}");
            }
        }

        private void AppendText(string text)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke(new Action<string>(AppendText), text);
            }
            else
            {
                textBox1.AppendText(Environment.NewLine + text);
            }
        }

        private static string GetNewGUID(string old)
        {
            if (!string.IsNullOrEmpty(old))
            {
                string[] array = old.Split('-');
                if (array.Length > 0)
                {
                    array[0] = RandomString(array[0].Length);
                    return string.Join("-", array);
                }
            }
            return RandomString(36);
        }
        private void label2_Click(object sender, EventArgs e)
        {
            // Обработчик клика по метке (оставлен пустым)
        }
        private void label_Click(object sender, EventArgs e)
        {
            // Ваш код обработки
        }
        private static string RandomString(int length)
        {
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

    public class ConfigClass
    {
        public System.Collections.Generic.Dictionary<string, string> Strings { get; set; }
    }
}