namespace minecraftCustomToolbox
{
    partial class frmMinecraftCustomToolbox
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMinecraftCustomToolbox));
            btnNewOneblockWorld = new Button();
            groupBox1 = new GroupBox();
            btnAdministration = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnNewOneblockWorld
            // 
            btnNewOneblockWorld.BackColor = SystemColors.MenuHighlight;
            btnNewOneblockWorld.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnNewOneblockWorld.Location = new Point(6, 24);
            btnNewOneblockWorld.Name = "btnNewOneblockWorld";
            btnNewOneblockWorld.Size = new Size(80, 80);
            btnNewOneblockWorld.TabIndex = 0;
            btnNewOneblockWorld.Text = "New Oneblock World";
            btnNewOneblockWorld.UseVisualStyleBackColor = false;
            btnNewOneblockWorld.Click += btnNewOneblockWorld_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Tomato;
            groupBox1.Controls.Add(btnNewOneblockWorld);
            groupBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(289, 120);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Vanilla Tools";
            // 
            // btnAdministration
            // 
            btnAdministration.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdministration.BackColor = SystemColors.MenuHighlight;
            btnAdministration.BackgroundImage = Properties.Resources.chest1;
            btnAdministration.BackgroundImageLayout = ImageLayout.Stretch;
            btnAdministration.Location = new Point(738, 388);
            btnAdministration.Name = "btnAdministration";
            btnAdministration.Size = new Size(50, 50);
            btnAdministration.TabIndex = 999;
            btnAdministration.UseVisualStyleBackColor = false;
            btnAdministration.Click += btnAdministration_Click;
            // 
            // frmMinecraftCustomToolbox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(btnAdministration);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmMinecraftCustomToolbox";
            Text = "Minecraft Toolbox";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnNewOneblockWorld;
        private GroupBox groupBox1;
        private Button btnAdministration;
    }
}