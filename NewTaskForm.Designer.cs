namespace Reminder_desktop_application
{
    partial class NewTaskForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewTaskForm));
            this.reminderBox = new MetroFramework.Controls.MetroTextBox();
            this.reminderDecription = new MetroFramework.Controls.MetroLabel();
            this.startingTimeLabel = new MetroFramework.Controls.MetroLabel();
            this.startingTimePicker = new System.Windows.Forms.DateTimePicker();
            this.cancelLink = new MetroFramework.Controls.MetroLink();
            this.saveLink = new MetroFramework.Controls.MetroLink();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.SuspendLayout();
            // 
            // reminderBox
            // 
            this.reminderBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.reminderBox.CustomButton.Image = null;
            this.reminderBox.CustomButton.Location = new System.Drawing.Point(98, 2);
            this.reminderBox.CustomButton.Name = "";
            this.reminderBox.CustomButton.Size = new System.Drawing.Size(133, 133);
            this.reminderBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.reminderBox.CustomButton.TabIndex = 1;
            this.reminderBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.reminderBox.CustomButton.UseSelectable = true;
            this.reminderBox.CustomButton.Visible = false;
            this.reminderBox.Lines = new string[0];
            this.reminderBox.Location = new System.Drawing.Point(10, 39);
            this.reminderBox.MaxLength = 32767;
            this.reminderBox.Multiline = true;
            this.reminderBox.Name = "reminderBox";
            this.reminderBox.PasswordChar = '\0';
            this.reminderBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.reminderBox.SelectedText = "";
            this.reminderBox.SelectionLength = 0;
            this.reminderBox.SelectionStart = 0;
            this.reminderBox.ShortcutsEnabled = true;
            this.reminderBox.Size = new System.Drawing.Size(234, 138);
            this.reminderBox.TabIndex = 3;
            this.reminderBox.UseSelectable = true;
            this.reminderBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.reminderBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // reminderDecription
            // 
            this.reminderDecription.AutoSize = true;
            this.reminderDecription.Location = new System.Drawing.Point(9, 17);
            this.reminderDecription.Name = "reminderDecription";
            this.reminderDecription.Size = new System.Drawing.Size(146, 19);
            this.reminderDecription.TabIndex = 4;
            this.reminderDecription.Text = "Descripcion de la tarea:";
            // 
            // startingTimeLabel
            // 
            this.startingTimeLabel.AutoSize = true;
            this.startingTimeLabel.Location = new System.Drawing.Point(36, 198);
            this.startingTimeLabel.Name = "startingTimeLabel";
            this.startingTimeLabel.Size = new System.Drawing.Size(124, 19);
            this.startingTimeLabel.TabIndex = 7;
            this.startingTimeLabel.Text = "La tarea empieza a:";
            // 
            // startingTimePicker
            // 
            this.startingTimePicker.CustomFormat = "HH:mm";
            this.startingTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startingTimePicker.Location = new System.Drawing.Point(182, 199);
            this.startingTimePicker.MinDate = new System.DateTime(2016, 11, 5, 0, 0, 0, 0);
            this.startingTimePicker.Name = "startingTimePicker";
            this.startingTimePicker.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.startingTimePicker.ShowUpDown = true;
            this.startingTimePicker.Size = new System.Drawing.Size(62, 20);
            this.startingTimePicker.TabIndex = 10;
            // 
            // cancelLink
            // 
            this.cancelLink.Image = ((System.Drawing.Image)(resources.GetObject("cancelLink.Image")));
            this.cancelLink.ImageSize = 40;
            this.cancelLink.Location = new System.Drawing.Point(186, 276);
            this.cancelLink.Margin = new System.Windows.Forms.Padding(2);
            this.cancelLink.Name = "cancelLink";
            this.cancelLink.Size = new System.Drawing.Size(58, 59);
            this.cancelLink.TabIndex = 2;
            this.cancelLink.Text = "Cancelar";
            this.cancelLink.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cancelLink.UseSelectable = true;
            this.cancelLink.Click += new System.EventHandler(this.cancelLink_Click);
            // 
            // saveLink
            // 
            this.saveLink.Image = ((System.Drawing.Image)(resources.GetObject("saveLink.Image")));
            this.saveLink.ImageSize = 40;
            this.saveLink.Location = new System.Drawing.Point(115, 276);
            this.saveLink.Margin = new System.Windows.Forms.Padding(2);
            this.saveLink.Name = "saveLink";
            this.saveLink.Size = new System.Drawing.Size(64, 59);
            this.saveLink.TabIndex = 1;
            this.saveLink.Text = "Guardar";
            this.saveLink.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.saveLink.UseSelectable = true;
            this.saveLink.Click += new System.EventHandler(this.saveLink_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(36, 235);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(85, 19);
            this.metroLabel1.TabIndex = 11;
            this.metroLabel1.Text = "Recordarme:";
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 23;
            this.metroComboBox1.Items.AddRange(new object[] {
            "diariamente",
            "semanalmente",
            "mensualmente"});
            this.metroComboBox1.Location = new System.Drawing.Point(125, 231);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(121, 29);
            this.metroComboBox1.TabIndex = 13;
            this.metroComboBox1.UseSelectable = true;
            // 
            // NewTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 353);
            this.Controls.Add(this.metroComboBox1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.startingTimePicker);
            this.Controls.Add(this.startingTimeLabel);
            this.Controls.Add(this.reminderDecription);
            this.Controls.Add(this.reminderBox);
            this.Controls.Add(this.cancelLink);
            this.Controls.Add(this.saveLink);
            this.MaximizeBox = false;
            this.Name = "NewTaskForm";
            this.Resizable = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLink saveLink;
        private MetroFramework.Controls.MetroLink cancelLink;
        private MetroFramework.Controls.MetroTextBox reminderBox;
        private MetroFramework.Controls.MetroLabel reminderDecription;
        private MetroFramework.Controls.MetroLabel startingTimeLabel;
        private System.Windows.Forms.DateTimePicker startingTimePicker;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
    }
}