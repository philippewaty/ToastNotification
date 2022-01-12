
namespace ToastNotificationTest
{
  partial class Form1
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
      this.button1 = new System.Windows.Forms.Button();
      this.cboColors = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.txtMessage = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtDelay = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(65, 94);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 6;
      this.button1.Text = "Show";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // cboColors
      // 
      this.cboColors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboColors.FormattingEnabled = true;
      this.cboColors.Location = new System.Drawing.Point(68, 9);
      this.cboColors.Name = "cboColors";
      this.cboColors.Size = new System.Drawing.Size(121, 21);
      this.cboColors.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(31, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Color";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 40);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(50, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Message";
      // 
      // txtMessage
      // 
      this.txtMessage.Location = new System.Drawing.Point(68, 40);
      this.txtMessage.Name = "txtMessage";
      this.txtMessage.Size = new System.Drawing.Size(327, 20);
      this.txtMessage.TabIndex = 3;
      this.txtMessage.Text = "Lorem ipsum dolor sit amet. ";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 71);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(34, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Delay";
      // 
      // txtDelay
      // 
      this.txtDelay.Location = new System.Drawing.Point(68, 68);
      this.txtDelay.Name = "txtDelay";
      this.txtDelay.Size = new System.Drawing.Size(72, 20);
      this.txtDelay.TabIndex = 5;
      this.txtDelay.Text = "2000";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(636, 263);
      this.Controls.Add(this.txtDelay);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtMessage);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.cboColors);
      this.Controls.Add(this.button1);
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.ComboBox cboColors;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtMessage;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtDelay;
  }
}

