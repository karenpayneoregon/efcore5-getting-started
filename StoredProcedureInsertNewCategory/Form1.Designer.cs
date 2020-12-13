
namespace StoredProcedureInsertNewCategory
{
    partial class Form1
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
            this.NewCategoryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewCategoryButton
            // 
            this.NewCategoryButton.Location = new System.Drawing.Point(24, 22);
            this.NewCategoryButton.Name = "NewCategoryButton";
            this.NewCategoryButton.Size = new System.Drawing.Size(238, 23);
            this.NewCategoryButton.TabIndex = 0;
            this.NewCategoryButton.Text = "Perform single insert";
            this.NewCategoryButton.UseVisualStyleBackColor = true;
            this.NewCategoryButton.Click += new System.EventHandler(this.NewCategoryButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 66);
            this.Controls.Add(this.NewCategoryButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insert stored procedure";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NewCategoryButton;
    }
}

