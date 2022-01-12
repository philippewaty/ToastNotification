using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToastNotificationTest
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      ToastNotification.NotificationManager.Show(this, txtMessage.Text, (Color)cboColors.SelectedItem, Convert.ToInt32(txtDelay.Text), new System.Drawing.Font(this.Font.Name, 10));
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      cboColors.Items.Add(Color.Red);
      cboColors.Items.Add(Color.Blue);
      cboColors.Items.Add(Color.Yellow);
      cboColors.Items.Add(Color.Green);
      cboColors.SelectedIndex = 0;
    }
  }
}
