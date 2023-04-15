using System.CodeDom;

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
                .ToList().First(x => x.EndsWith("FileResources")))
                .First(x => x.EndsWith("OneBlock1.19.zip"));
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
                    catch(Exception ex) 
                    {
                        MessageBox.Show("There was a failure in the world build. Please review the error." + Environment.NewLine.ToString() + ex.Message);
                    }
                }
            }
        }
    }

    public partial class frmTextMessageBox : Form
    {
        public string response;
        public frmTextMessageBox(string message)
        {
            Text = "Prompt";
            Label lblOne = new Label();
            lblOne.Text = message;
            lblOne.Location = new System.Drawing.Point(5, this.Top + 5);
            lblOne.Size = new System.Drawing.Size(300, 23);


            TextBox txOne = new TextBox();
            txOne.Location = new System.Drawing.Point(5, Top + 25);
            txOne.Size = new System.Drawing.Size(100, 23);
            txOne.TabIndex = 0;
            txOne.TextChanged += UpdateResponse;

            Button btnSubmit = new Button();
            btnSubmit.Size = new System.Drawing.Size(40, 40);
            btnSubmit.Location = new System.Drawing.Point(5, Bottom - btnSubmit.Size.Height - 50);
            btnSubmit.Text = "Ok";
            btnSubmit.Click += CloseForm;

            Controls.Add(lblOne);
            Controls.Add(txOne);
            Controls.Add(btnSubmit);

        }
        public void UpdateResponse(object sender, EventArgs e)
        {
            response = ((TextBox)sender).Text;
        }
        public void CloseForm(object sender, EventArgs e)
        {
            var x = 0;
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

}