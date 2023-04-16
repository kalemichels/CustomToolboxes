using System.CodeDom;
using System.ComponentModel.DataAnnotations;
using System.Data;
using reflect = System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.ObjectiveC;
using System.Windows.Forms;

using Newtonsoft.Json;

namespace Utilities.JSONSettingsManager
{
    public class JSONSettingsManager
    {
        public string? configFile { get; set; }
        public string jsonFile { get; set; }
        public Type jsonTemplate { get; set; }

        public JSONSettingsManager() { }

        public JSONSettingsManager(string? configFile, Type sample) { this.configFile = configFile; jsonTemplate = sample; }

        public DataTable getConfigSettings()
        {
            DataTable settingsDT = new DataTable();
            var jsonText = File.ReadAllText(configFile);
            settingsDT.Columns.AddRange(jsonTemplate.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).Select(x => new DataColumn(x.Name)).ToArray());
            //TODO: Is there a way to utilize the 'sample' to populate in place of 'dynamic'?
            var settings = JsonConvert.DeserializeObject<IList<dynamic>>(jsonText);

            settingsDT = (DataTable?)JsonConvert.DeserializeObject(jsonText, (typeof(DataTable))) ?? settingsDT;

            return settingsDT;
        }
        public void showConfigSettings()
        {
            var settings = getConfigSettings();

            frmSettings.Show(settings);
        }

    }
    public partial class frmSettings : Form
    {
        public string? response;
        private DataGridView dataGridView1;
        private Button button1;
        public frmSettings()
        {
            dataGridView1 = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(554, 312);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(572, 44);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            //TODO: reimplement save button within utility
            //button1.Click += button1_Click;
            // 
            // frmSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(661, 392);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "frmSettings";
            Text = "frmSettings";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }
        public static void Show(DataTable data)
        {
            using (var frmInstance = new frmSettings())
            {
                frmInstance.dataGridView1.DataSource = data;
                frmInstance.ShowDialog();
            }
        }
        public void UpdateResponse(object? sender, EventArgs e)
        {
            if (!(sender == null)) response = ((TextBox)sender).Text;
        }
        public void SubmitForm(object? sender, EventArgs e)
        {
            this.Close();
        }
        public void CancelForm(object? sender, EventArgs e)
        {
            response = null;
            this.Close();
        }

    }
}