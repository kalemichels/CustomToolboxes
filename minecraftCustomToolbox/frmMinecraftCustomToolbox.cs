using System.CodeDom;
using Utilities.JSONSettingsManager;

namespace minecraftCustomToolbox
{
    public partial class frmMinecraftCustomToolbox : Form
    {
        public frmMinecraftCustomToolbox()
        {
            InitializeComponent();
        }

        private void btnNewOneblockWorld_Click(object sender, EventArgs e)
        {


            var oneblockTemplate = Directory.GetFiles(
                System.IO.Directory.GetDirectories(
                    System.IO.Directory.GetCurrentDirectory())
                .ToList().First(x => x.EndsWith("FileResources")))//Relative to app build
                .First(x => x.EndsWith("OneBlock1.19.zip"));

            //TODO: Develop accessible logic to read settings without having to be on the admin form.
            //TODO: Implement usage of the settings
            if (oneblockTemplate != null)
            {
                var newWorldName = TextMessageBox.Show("What would you like to call the new world?");
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\saves\\tmp\\");
                //C:\Users\miche\AppData\Roaming\.minecraft\saves
                if (newWorldName != null)
                {
                    try
                    {
                        System.IO.Compression.ZipFile.ExtractToDirectory(oneblockTemplate, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\saves\\tmp\\");
                        System.IO.Directory.Move(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\saves\\tmp\\OneBlock Reborn 1.19.3", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\saves\\" + newWorldName);
                        MessageBox.Show("Successfully created your new OneBlock World {0}!", newWorldName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There was a failure in the world build. Please review the error." + Environment.NewLine.ToString() + ex.Message);
                    }
                    int i = 0;
                }
                else
                {
                    MessageBox.Show("New world was cancelled.");
                }
            }
        }

        private void btnAdministration_Click(object sender, EventArgs e)
        {
            var configFile = Directory.GetFiles(
            System.IO.Directory.GetDirectories(
                System.IO.Directory.GetCurrentDirectory())
            .ToList().First(x => x.EndsWith("FileResources")))//Relative to app build
            .FirstOrDefault(x => x.EndsWith("configFile.txt"));


            var passwordInput = TextMessageBox.Show("What is the admin password?");
            if (passwordInput == "ThisPasswordIsSecure")
            {
                var x = new JSONSettingsManager(configFile, typeof(minecraftToolboxSetting));
                x.showConfigSettings();
                //var adminForm = new frmSettingsAdmin();
                //adminForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No, that is incorrect.");
            }
        }
    }
    #region Custom Message Boxes
    public partial class frmTextMessageBox : Form
    {
        public string? response;
        public frmTextMessageBox(string message)
        {
            Text = "Prompt";
            Label lblOne = new Label();
            lblOne.Text = message;
            lblOne.Location = new System.Drawing.Point(5, this.Top + 5);
            lblOne.Size = new System.Drawing.Size(300, 23);
            //Set size relative to the 'largest' expected object on the screen, with a minimum width of 100
            this.Size = new System.Drawing.Size(Math.Max(lblOne.Width + 20, 100), 200);


            TextBox txOne = new TextBox();
            txOne.Location = new System.Drawing.Point(5, Top + 25);
            txOne.Size = new System.Drawing.Size(100, 23);
            txOne.TabIndex = 0;
            txOne.TextChanged += UpdateResponse;

            Button btnSubmit = new Button();
            btnSubmit.Text = "Ok";
            btnSubmit.Size = new System.Drawing.Size((btnSubmit.Text.Length * 10) + 10, 40);
            btnSubmit.Location = new System.Drawing.Point(5, Bottom - btnSubmit.Size.Height - 50);
            btnSubmit.Click += SubmitForm;

            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Location = new System.Drawing.Point(btnSubmit.Location.X + btnSubmit.Width + 10, Bottom - btnSubmit.Size.Height - 50);
            btnCancel.Size = new System.Drawing.Size((btnCancel.Text.Length * 10) + 10, 40);
            btnCancel.Click += CancelForm;

            Controls.Add(lblOne);
            Controls.Add(txOne);
            Controls.Add(btnSubmit);
            Controls.Add(btnCancel);
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
    public static class TextMessageBox
    {
        public static string Show(string message)
        {
            using (var frmInstance = new frmTextMessageBox(message))
            {
                frmInstance.ShowDialog();
                return frmInstance.response;
            }
        }
    }
    #endregion

}