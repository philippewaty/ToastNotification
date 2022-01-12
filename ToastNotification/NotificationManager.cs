//http://www.codeproject.com/Articles/442983/Android-Style-Toast-Notification-for-NET
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ToastNotification
{
  public static class NotificationManager
  {
    //Timers
    static Timer tmrAnimation;

    static Timer tmrDelay;
    //Control where the message will be displayed.

    static ExtendedControl displaycontrol = new ExtendedControl();
    //Some property variables.
    static Color GlowColor = Color.Blue;
    static float alphaval = 0;
    static float incr = 0.1F;
    static bool isVisible = false;
    static SizeF textSize;
    static string msg = "";

    static Control prnt;
    static Font textFont;
    #region "eventhandlers"

    //Handles the paint event of the display control.
    private static void Control_Paint(object sender, PaintEventArgs pe)
    {
      //This BITMAP object will hold the appearance of the notification dialog.
      //Why paint in bitmap? because we will set its opacity and paint it on the control later with a specified alpha.
      Bitmap img = new Bitmap(displaycontrol.Width, displaycontrol.Height);
      Graphics e = Graphics.FromImage(img);

      //Set smoothing.
      e.SmoothingMode = SmoothingMode.AntiAlias;

      //Prepare drawing tools.
      Brush bru = new SolidBrush(Color.FromArgb(50, GlowColor));
      Pen pn = new Pen(bru, 6);
      GraphicsPath gp = new GraphicsPath();

      //Make connecting edges rounded.
      pn.LineJoin = LineJoin.Round;

      //Draw borders
      //Outmost, 50 alpha
      gp.AddRectangle(new Rectangle(3, 3, displaycontrol.Width - 10, displaycontrol.Height - 10));
      e.DrawPath(pn, gp);

      //level 3, A bit solid
      gp.Reset();
      gp.AddRectangle(new Rectangle(5, 5, displaycontrol.Width - 14, displaycontrol.Height - 14));
      e.DrawPath(pn, gp);

      //level 2, a bit more solid
      gp.Reset();
      gp.AddRectangle(new Rectangle(7, 7, displaycontrol.Width - 18, displaycontrol.Height - 18));
      e.DrawPath(pn, gp);

      //level 1, more solidness
      gp.Reset();
      gp.AddRectangle(new Rectangle(9, 9, displaycontrol.Width - 22, displaycontrol.Height - 22));
      e.DrawPath(pn, gp);

      //Draw Content Rectangle.
      gp.Reset();
      bru = new SolidBrush(Color.FromArgb(7, 7, 7));
      pn = new Pen(bru, 5);
      pn.LineJoin = LineJoin.Round;
      gp.AddRectangle(new Rectangle(8, 8, displaycontrol.Width - 20, displaycontrol.Height - 20));
      e.DrawPath(pn, gp);
      e.FillRectangle(bru, new Rectangle(9, 9, displaycontrol.Width - 21, displaycontrol.Height - 21));

      //Set COLORMATRIX (RGBAw).
      //Matrix [3,3] will be the Alpha. Alpha is in float, 0(transparent) - 1(opaque).
      ColorMatrix cma = new ColorMatrix();
      cma.Matrix33 = alphaval;
      ImageAttributes imga = new ImageAttributes();
      imga.SetColorMatrix(cma);

      //Draw the notification message..
      StringFormat sf = new StringFormat();
      sf.Alignment = StringAlignment.Center;
      sf.LineAlignment = StringAlignment.Center;
      e.DrawString(msg, textFont, new SolidBrush(Color.FromArgb(247, 247, 247)), new Rectangle(9, 9, displaycontrol.Width - 21, displaycontrol.Height - 21), sf);

      //Now, draw the content on the control.
      pe.Graphics.DrawImage(img, new Rectangle(0, 0, displaycontrol.Width, displaycontrol.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imga);

      //Free the memory.
      cma = null;
      sf.Dispose();
      imga.Dispose();
      e.Dispose();
      img.Dispose();
      bru.Dispose();
      pn.Dispose();
      gp.Dispose();

    }

    //Handles the window animation.
    private static void tmr_tick(object sender, EventArgs e)
    {
      if ((incr > 0))
      {
        if ((alphaval < 1))
        {
          if ((alphaval + incr <= 1))
          {
            alphaval += incr;
            displaycontrol.Refresh();
          }
          else
          {
            alphaval = 1;
            displaycontrol.Refresh();
            tmrAnimation.Enabled = false;
            tmrDelay.Enabled = true;
          }
        }
      }
      else
      {
        if ((alphaval > 0))
        {
          if ((alphaval + incr >= 0))
          {
            alphaval += incr;
            displaycontrol.Refresh();
          }
          else
          {
            alphaval = 0;
            tmrAnimation.Enabled = false;
            tmrDelay.Tick -= tmrDelay_tick;
            tmrDelay.Tick -= tmr_tick;
            tmrAnimation.Dispose();
            tmrDelay.Dispose();
            displaycontrol.Dispose();
            incr = 0.1F;
            isVisible = false;
          }
        }
      }
    }

    //handles the delay.
    private static void tmrDelay_tick(object sender, EventArgs e)
    {
      incr = -0.1F;
      tmrAnimation.Enabled = true;
      tmrDelay.Enabled = false;
    }

    #endregion

    #region "Function"

    /// <summary>
    /// Shows the message to the user.
    /// </summary>
    /// <param name="Message">The message to show.</param>
    /// <param name="glw">Color of the glow.</param>
    /// <param name="delay">The time before the message to disappear, in Milliseconds.</param>
    /// <remarks></remarks>
    public static void Show(Control Parent, string Message, Color glw, int delay, Font displayTextFont)
    {
      if (!(isVisible))
      {
        isVisible = true;
        prnt = Parent;
        textFont = displayTextFont;
        msg = Message;
        //Set up notification window.
        displaycontrol = new ExtendedControl();
        displaycontrol.IsTransparent = true;
        displaycontrol.Paint += Control_Paint;

        //Measure message
        textSize = displaycontrol.CreateGraphics().MeasureString(Message, textFont);
        displaycontrol.Height = 25 + (int)textSize.Height;
        displaycontrol.Width = 35 + (int)textSize.Width;
        if ((textSize.Width > Parent.Width - 100))
        {
          displaycontrol.Width = Parent.Width - 100;
          int hf = (int)textSize.Width / (Parent.Width - 100);
          displaycontrol.Height += ((int)textSize.Height * hf);
        }

        //Position control in parent
        displaycontrol.Left = (Parent.Width - displaycontrol.Width) / 2;
        displaycontrol.Top = (Parent.Height - displaycontrol.Height) - 50;
        Parent.Controls.Add(displaycontrol);
        displaycontrol.BringToFront();
        GlowColor = glw;

        //Set up animation
        tmrAnimation = new Timer();
        tmrAnimation.Interval = 15;
        tmrAnimation.Tick += tmr_tick;
        tmrAnimation.Enabled = true;

        tmrDelay = new Timer();
        tmrDelay.Tick += tmrDelay_tick;
        tmrDelay.Interval = delay;

      }
      else
      {
        tmrDelay.Stop();
        tmrDelay.Start();
      }
    }

    #endregion
  }
}
