using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minecraftCustomToolbox
{
    public partial class frmSettingsAdmin : Form
    {
        string? configFile;
        public frmSettingsAdmin()
        {
            InitializeComponent();
        }

        private void frmSettingsAdmin_Load(object sender, EventArgs e)
        {
            //TODO: Develop some way to enforce a minimum set of settings based on the buttons/functions developed on the screen. To avoid setting dependancy errors
            configFile = Directory.GetFiles(
                System.IO.Directory.GetDirectories(
                    System.IO.Directory.GetCurrentDirectory())
                .ToList().First(x => x.EndsWith("FileResources")))//Relative to app build
                .FirstOrDefault(x => x.EndsWith("configFile.txt"));
            if (configFile != null)
            {
                var jsonText = File.ReadAllText(configFile);
                var settings = JsonConvert.DeserializeObject<IList<minecraftToolboxSetting>>(jsonText);

                var y = typeof(minecraftToolboxSetting).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                DataColumn[] dcArr = y.Select(x => new DataColumn(x.Name)).ToArray();
                DataTable settingsDT = new DataTable();
                settingsDT.Columns.AddRange(typeof(minecraftToolboxSetting).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).Select(x => new DataColumn(x.Name)).ToArray());
                if (settings != null) settings.ToList().ForEach(x =>
                {
                    DataRow dr = settingsDT.NewRow();
                    dr["SettingName"] = x.SettingName;
                    dr["SettingValue"] = x.SettingValue;
                    //Alternatve version, more complicated. Only half-dynamic
                    //dr[typeof(minecraftToolboxSetting).GetProperties().Select(x => x.Name).First()] = x.SettingName;
                    //dr[typeof(minecraftToolboxSetting).GetProperties().Select(x => x.Name).Skip(1).First()] = x.SettingValue;
                    settingsDT.Rows.Add(dr);
                });

                dataGridView1.DataSource = settingsDT;
            }
            else
            {
                MessageBox.Show("There is no valid configuration file." + Environment.NewLine.ToString() + "One should be created.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(configFile == null))
            {
                try
                {
                    var dataToSave = JsonConvert.SerializeObject(dataGridView1.DataSource);
                    using (StreamWriter swOne = new StreamWriter(configFile))
                    {
                        swOne.Write(dataToSave.ToString());
                        swOne.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something happened, it wasn't good. This is all we know." + Environment.NewLine.ToString() + ex.Message);
                }

            }
        }
    }
    public class minecraftToolboxSetting
    {
        //TODO: Move this to a separate file, and expand namespaces
        public string? SettingName { get; set; }
        public string SettingValue { get; set; } = string.Empty;

        public minecraftToolboxSetting() { }

    }
}
