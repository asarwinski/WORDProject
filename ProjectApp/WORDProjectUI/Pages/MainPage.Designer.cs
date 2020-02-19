namespace WORDProjectUI.Pages
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.TabControlImages = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControlImages
            // 
            this.TabControlImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TabControlImages.ImageStream")));
            this.TabControlImages.TransparentColor = System.Drawing.Color.Transparent;
            this.TabControlImages.Images.SetKeyName(0, "calendar.png");
            this.TabControlImages.Images.SetKeyName(1, "history.png");
            this.TabControlImages.Images.SetKeyName(2, "teacher.png");
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.ImageList = this.TabControlImages;
            this.tabControl1.ItemSize = new System.Drawing.Size(40, 40);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(775, 425);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.tabPage1.ImageKey = "calendar.png";
            this.tabPage1.Location = new System.Drawing.Point(44, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(727, 417);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.ImageKey = "history.png";
            this.tabPage2.Location = new System.Drawing.Point(44, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(727, 417);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.ImageKey = "teacher.png";
            this.tabPage3.Location = new System.Drawing.Point(44, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(727, 417);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainPage";
            this.Text = "MainPage";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList TabControlImages;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
    }
}