namespace InventoryApp.Framwork
{
    partial class ViewBase
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonBar = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ButtonBar
            // 
            this.ButtonBar.BackColor = System.Drawing.Color.Gainsboro;
            this.ButtonBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ButtonBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonBar.Location = new System.Drawing.Point(0, 282);
            this.ButtonBar.Name = "ButtonBar";
            this.ButtonBar.Size = new System.Drawing.Size(615, 37);
            this.ButtonBar.TabIndex = 0;
            this.ButtonBar.Visible = false;
            // 
            // ViewBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ButtonBar);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ViewBase";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(615, 319);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ButtonBar;
    }
}
