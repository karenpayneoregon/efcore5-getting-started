
namespace Scaffolding
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
            this.GenerateSingleClassButton = new System.Windows.Forms.Button();
            this.TableNameListBox = new System.Windows.Forms.ListBox();
            this.ClassResultsTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // GenerateSingleClassButton
            // 
            this.GenerateSingleClassButton.Location = new System.Drawing.Point(234, 12);
            this.GenerateSingleClassButton.Name = "GenerateSingleClassButton";
            this.GenerateSingleClassButton.Size = new System.Drawing.Size(134, 23);
            this.GenerateSingleClassButton.TabIndex = 0;
            this.GenerateSingleClassButton.Text = "Generate single class";
            this.GenerateSingleClassButton.UseVisualStyleBackColor = true;
            this.GenerateSingleClassButton.Click += new System.EventHandler(this.GenerateSingleClassButton_Click);
            // 
            // TableNameListBox
            // 
            this.TableNameListBox.FormattingEnabled = true;
            this.TableNameListBox.ItemHeight = 15;
            this.TableNameListBox.Location = new System.Drawing.Point(12, 12);
            this.TableNameListBox.Name = "TableNameListBox";
            this.TableNameListBox.Size = new System.Drawing.Size(216, 154);
            this.TableNameListBox.TabIndex = 2;
            // 
            // ClassResultsTextBox
            // 
            this.ClassResultsTextBox.Location = new System.Drawing.Point(13, 178);
            this.ClassResultsTextBox.Multiline = true;
            this.ClassResultsTextBox.Name = "ClassResultsTextBox";
            this.ClassResultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ClassResultsTextBox.Size = new System.Drawing.Size(464, 280);
            this.ClassResultsTextBox.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 470);
            this.Controls.Add(this.ClassResultsTextBox);
            this.Controls.Add(this.TableNameListBox);
            this.Controls.Add(this.GenerateSingleClassButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GenerateSingleClassButton;
        private System.Windows.Forms.ListBox TableNameListBox;
        private System.Windows.Forms.TextBox ClassResultsTextBox;
    }
}

