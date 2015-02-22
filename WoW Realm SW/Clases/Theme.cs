// Theme by Mavaamarten
// Ripped by COB
// Fixed for NET 2.0 By Doddy Hackman
// Theme Base 1.5.4
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Collections;

namespace Theme
{
    internal partial class MephobiaTheme : ThemeContainer154
    {
        // Fields
        private bool _ShowIcon;
        private Color Accent;
        private Color Border;
        private Color TextColor;
        private Color TitleBottom;
        private Color TitleTop;

        // Methods
        public MephobiaTheme()
        {
            this.Header = 30;
            this.SetColor("Titlebar Gradient Top", 0x3f, 0x3f, 0x3f);
            this.SetColor("Titlebar Gradient Bottom", 20, 20, 20);
            this.SetColor("Text", 170, 170, 170);
            this.SetColor("Accent", 180, 0x1a, 0x20);
            this.SetColor("Border", Color.Black);
            this.TransparencyKey = Color.Fuchsia;
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.Font = new Font("Segoe UI", 9f);
        }

        protected override void ColorHook()
        {
            this.TitleTop = this.GetColor("Titlebar Gradient Top");
            this.TitleBottom = this.GetColor("Titlebar Gradient Bottom");
            this.TextColor = this.GetColor("Text");
            this.Accent = this.GetColor("Accent");
            this.Border = this.GetColor("Border");
        }

        protected override void PaintHook()
        {
            base.G.Clear(this.Border);
            Rectangle rect = new Rectangle(1, 1, this.Width - 2, 0x23);
            LinearGradientBrush brush = new LinearGradientBrush(rect, this.TitleTop, this.TitleBottom, 90f);
            base.G.FillPath(brush, this.CreateRound(1, 1, this.Width - 2, 0x23, 7));
            base.G.DrawPath(new Pen(Color.FromArgb(15, Color.White), 1f), this.CreateRound(1, 1, this.Width - 3, 0x23, 7));
            base.G.FillPath(new SolidBrush(this.BackColor), this.CreateRound(1, 0x20, this.Width - 2, this.Height - 0x21, 7));
            base.G.DrawPath(new Pen(Color.FromArgb(15, Color.White), 1f), this.CreateRound(1, 0x20, this.Width - 3, this.Height - 0x22, 7));
            rect = new Rectangle(1, 0x20, this.Width - 2, 3);
            base.G.FillRectangle(new SolidBrush(this.Border), rect);
            Point point = new Point(1, 0x1f);
            Point point2 = new Point(this.Width - 2, 0x1f);
            base.G.DrawLine(new Pen(Color.FromArgb(15, Color.White)), point, point2);
            ColorBlend blend = new ColorBlend(3);
            blend.Colors = new Color[] { Color.Black, this.Accent, Color.Black };
            blend.Positions = new float[] { 0f, 0.5f, 1f };
            rect = new Rectangle(1, 0x21, this.Width - 2, 2);
            this.DrawGradient(blend, rect, 0f);
            point2 = new Point(1, 0x23);
            point = new Point(this.Width - 2, 0x23);
            base.G.DrawLine(new Pen(this.BackColor), point2, point);
            point2 = new Point(1, 0x23);
            point = new Point(this.Width - 2, 0x23);
            base.G.DrawLine(new Pen(Color.FromArgb(15, Color.White)), point2, point);
            if (this._ShowIcon)
            {
                rect = new Rectangle(11, 8, 0x10, 0x10);
                base.G.DrawIcon(this.FindForm().Icon, rect);
                point2 = new Point(0x20, 8);
                base.G.DrawString(this.FindForm().Text, this.Font, new SolidBrush(this.TextColor), (PointF)point2);
            }
            else
            {
                point2 = new Point(13, 8);
                base.G.DrawString(this.FindForm().Text, this.Font, new SolidBrush(this.TextColor), (PointF)point2);
            }
            this.DrawPixel(Color.Fuchsia, 0, 0);
            this.DrawPixel(Color.Fuchsia, 1, 0);
            this.DrawPixel(Color.Fuchsia, 2, 0);
            this.DrawPixel(Color.Fuchsia, 3, 0);
            this.DrawPixel(Color.Fuchsia, 0, 1);
            this.DrawPixel(Color.Fuchsia, 0, 2);
            this.DrawPixel(Color.Fuchsia, 0, 3);
            this.DrawPixel(Color.Fuchsia, 1, 1);
            this.DrawPixel(Color.Fuchsia, this.Width - 1, 0);
            this.DrawPixel(Color.Fuchsia, this.Width - 2, 0);
            this.DrawPixel(Color.Fuchsia, this.Width - 3, 0);
            this.DrawPixel(Color.Fuchsia, this.Width - 4, 0);
            this.DrawPixel(Color.Fuchsia, this.Width - 1, 1);
            this.DrawPixel(Color.Fuchsia, this.Width - 1, 2);
            this.DrawPixel(Color.Fuchsia, this.Width - 1, 3);
            this.DrawPixel(Color.Fuchsia, this.Width - 2, 1);
            this.DrawPixel(Color.Fuchsia, 0, this.Height);
            this.DrawPixel(Color.Fuchsia, 1, this.Height);
            this.DrawPixel(Color.Fuchsia, 2, this.Height);
            this.DrawPixel(Color.Fuchsia, 3, this.Height);
            this.DrawPixel(Color.Fuchsia, 0, this.Height - 1);
            this.DrawPixel(Color.Fuchsia, 0, this.Height - 2);
            this.DrawPixel(Color.Fuchsia, 0, this.Height - 3);
            this.DrawPixel(Color.Fuchsia, 1, this.Height - 1);
            this.DrawPixel(Color.Fuchsia, this.Width - 1, this.Height);
            this.DrawPixel(Color.Fuchsia, this.Width - 2, this.Height);
            this.DrawPixel(Color.Fuchsia, this.Width - 3, this.Height);
            this.DrawPixel(Color.Fuchsia, this.Width - 4, this.Height);
            this.DrawPixel(Color.Fuchsia, this.Width - 1, this.Height - 1);
            this.DrawPixel(Color.Fuchsia, this.Width - 1, this.Height - 2);
            this.DrawPixel(Color.Fuchsia, this.Width - 1, this.Height - 3);
            this.DrawPixel(Color.Fuchsia, this.Width - 2, this.Height - 1);
        }

        // Properties
        public bool ShowIcon
        {
            get
            {
                return this._ShowIcon;
            }
            set
            {
                this._ShowIcon = value;
                this.Invalidate();
            }
        }
    }

    internal class MephobiaButton : ThemeControl154
    {
        // Fields
        private Color G1;
        private Color G2;
        private Color TC;

        // Methods
        public MephobiaButton()
        {
            this.SetColor("Gradient Top", 40, 40, 40);
            this.SetColor("Gradient Bottom", 20, 20, 20);
            this.SetColor("Text", 170, 170, 170);
        }

        protected override void ColorHook()
        {
            this.G1 = this.GetColor("Gradient Top");
            this.G2 = this.GetColor("Gradient Bottom");
            this.TC = this.GetColor("Text");
        }

        protected override void PaintHook()
        {
            Rectangle rectangle;
            base.G.Clear(this.BackColor);
            base.G.SmoothingMode = SmoothingMode.HighQuality;
            switch (base.State)
            {
                case MouseState.None:
                    {
                        rectangle = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                        LinearGradientBrush brush = new LinearGradientBrush(rectangle, this.G1, this.G2, 90f);
                        base.G.FillPath(brush, this.CreateRound(0, 0, this.Width - 1, this.Height - 1, 5));
                        base.G.DrawPath(Pens.Black, this.CreateRound(0, 0, this.Width - 1, this.Height - 1, 5));
                        base.G.DrawPath(new Pen(Color.FromArgb(15, Color.White)), this.CreateRound(1, 1, this.Width - 3, this.Height - 3, 5));
                        break;
                    }
                case MouseState.Over:
                    {
                        rectangle = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                        LinearGradientBrush brush2 = new LinearGradientBrush(rectangle, this.G1, this.G2, 90f);
                        base.G.FillPath(brush2, this.CreateRound(0, 0, this.Width - 1, this.Height - 1, 5));
                        base.G.FillPath(new SolidBrush(Color.FromArgb(7, Color.White)), this.CreateRound(0, 0, this.Width - 1, this.Height - 1, 5));
                        base.G.DrawPath(Pens.Black, this.CreateRound(0, 0, this.Width - 1, this.Height - 1, 5));
                        base.G.DrawPath(new Pen(Color.FromArgb(15, Color.White)), this.CreateRound(1, 1, this.Width - 3, this.Height - 3, 5));
                        break;
                    }
                case MouseState.Down:
                    {
                        rectangle = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                        LinearGradientBrush brush3 = new LinearGradientBrush(rectangle, this.G1, this.G2, 90f);
                        base.G.FillPath(brush3, this.CreateRound(0, 0, this.Width - 1, this.Height - 1, 5));
                        base.G.FillPath(new SolidBrush(Color.FromArgb(20, Color.Black)), this.CreateRound(0, 0, this.Width - 1, this.Height - 1, 5));
                        base.G.DrawPath(Pens.Black, this.CreateRound(0, 0, this.Width - 1, this.Height - 1, 5));
                        base.G.DrawPath(new Pen(Color.FromArgb(15, Color.White)), this.CreateRound(1, 1, this.Width - 3, this.Height - 3, 5));
                        break;
                    }
            }
            rectangle = new Rectangle(0, 0, this.Width - 1, this.Height);
            StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            base.G.DrawString(this.Text, this.Font, new SolidBrush(this.TC), rectangle, format);
        }
    }

    [DefaultEvent("CheckedChanged")]
    internal class MephobiaCheckBox : ThemeControl154
    {
        // Fields
        private bool _Checked;
        private Color Border;
        private Color C1;
        private Color C2;
        private CheckedChangedEventHandler CheckedChangedEvent;
        private Color Glow;
        private Color TC;
        private Color UC1;
        private Color UC2;
        private int X;

        // Events
        public event CheckedChangedEventHandler CheckedChanged;

        // Methods
        public MephobiaCheckBox()
        {
            this.LockHeight = 0x10;
            this.SetColor("Border", Color.Black);
            this.SetColor("Checked1", 180, 0x1a, 0x20);
            this.SetColor("Checked2", 200, 180, 0x1a, 0x20);
            this.SetColor("Unchecked1", 30, 30, 30);
            this.SetColor("Unchecked2", 0x19, 0x19, 0x19);
            this.SetColor("Glow", 15, Color.White);
            this.SetColor("Text", 170, 170, 170);
        }



        protected override void ColorHook()
        {
            this.C1 = this.GetColor("Checked1");
            this.C2 = this.GetColor("Checked2");
            this.UC1 = this.GetColor("Unchecked1");
            this.UC2 = this.GetColor("Unchecked2");
            this.Border = this.GetColor("Border");
            this.Glow = this.GetColor("Glow");
            this.TC = this.GetColor("Text");
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            this._Checked = !this._Checked;
            CheckedChangedEventHandler checkedChangedEvent = this.CheckedChangedEvent;
            if (checkedChangedEvent != null)
            {
                checkedChangedEvent(this);
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.X = e.Location.X;
            this.Invalidate();
        }

        protected override void PaintHook()
        {
            base.G.Clear(this.BackColor);
            if (this._Checked)
            {
                this.DrawGradient(this.C1, this.C2, 1, 1, 14, 14);
                Point point = new Point(-3, -1);
                base.G.DrawString("a", new Font("Marlett", 13f), Brushes.Black, (PointF)point);
            }
            else
            {
                this.DrawGradient(this.UC1, this.UC2, 1, 1, 14, 14, 90f);
            }
            if ((base.State == MouseState.Over) & (this.X < 0x10))
            {
                if (this._Checked)
                {
                    base.G.FillRectangle(new SolidBrush(this.Glow), 1, 1, 14, 14);
                }
                else
                {
                    base.G.FillRectangle(new SolidBrush(Color.FromArgb(10, this.Glow)), 1, 1, 14, 14);
                }
            }
            this.DrawBorders(new Pen(this.Border), 0, 0, 0x10, 0x10, 1);
            this.DrawText(new SolidBrush(this.TC), HorizontalAlignment.Left, 20, 0);
        }

        // Properties
        public bool Checked
        {
            get
            {
                return this._Checked;
            }
            set
            {
                this._Checked = value;
                this.Invalidate();
            }
        }

        // Nested Types
        public delegate void CheckedChangedEventHandler(object sender);
    }

    internal class MephobiaComboBox : ComboBox
    {
        // Fields
        private GraphicsPath CreateRoundPath;
        private Rectangle CreateRoundRectangle;
        private int X;

        // Methods
        public MephobiaComboBox()
        {
            base.DropDownClosed += new EventHandler(this.GhostComboBox_DropDownClosed);
            base.TextChanged += new EventHandler(this.GhostCombo_TextChanged);
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            this.ForeColor = Color.FromArgb(170, 170, 170);
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.ItemHeight = 0x11;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }



        public GraphicsPath CreateRound(Rectangle r, int slope)
        {
            this.CreateRoundPath = new GraphicsPath(FillMode.Winding);
            this.CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180f, 90f);
            this.CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270f, 90f);
            this.CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0f, 90f);
            this.CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90f, 90f);
            this.CreateRoundPath.CloseFigure();
            return this.CreateRoundPath;
        }

        public GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
        {
            this.CreateRoundRectangle = new Rectangle(x, y, width, height);
            return this.CreateRound(this.CreateRoundRectangle, slope);
        }

        private void GhostCombo_TextChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void GhostComboBox_DropDownClosed(object sender, EventArgs e)
        {
            this.DropDownStyle = ComboBoxStyle.Simple;
            Application.DoEvents();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                Rectangle rectangle = new Rectangle
                {
                    X = e.Bounds.X,
                    Y = e.Bounds.Y,
                    Width = e.Bounds.Width - 1,
                    Height = e.Bounds.Height - 1
                };
                e.DrawBackground();
                if ((e.State == (DrawItemState.NoFocusRect | DrawItemState.NoAccelerator | DrawItemState.Focus | DrawItemState.Selected)) | (e.State == (DrawItemState.Focus | DrawItemState.Selected)))
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(70, 70, 70)), e.Bounds);
                    e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, Brushes.White, (float)e.Bounds.X, (float)e.Bounds.Y);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(this.BackColor), e.Bounds);
                    e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, Brushes.White, (float)e.Bounds.X, (float)e.Bounds.Y);
                }
                base.OnDrawItem(e);
            }
        }

        protected override void OnDropDownClosed(EventArgs e)
        {
            base.OnDropDownClosed(e);
            this.X = -1;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.X = -1;
            this.Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.X = e.Location.X;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.DropDownStyle != ComboBoxStyle.DropDownList)
            {
                this.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            Bitmap image = new Bitmap(this.Width, this.Height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.Clear(this.BackColor);
            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush brush = new LinearGradientBrush(rect, Color.FromArgb(40, 40, 40), Color.FromArgb(20, 20, 20), 90f);
            graphics.FillPath(brush, this.CreateRound(0, 0, this.Width - 1, this.Height - 1, 5));
            if (this.X > (this.Width - 0x1a))
            {
                rect = new Rectangle(this.Width - 0x19, 2, 0x18, this.Height - 4);
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(5, Color.White)), rect);
            }
            graphics.DrawPath(Pens.Black, this.CreateRound(0, 0, this.Width - 1, this.Height - 1, 5));
            graphics.DrawPath(new Pen(Color.FromArgb(15, Color.White)), this.CreateRound(1, 1, this.Width - 3, this.Height - 3, 5));
            Point point = new Point(this.Width - 0x19, 0);
            Point point2 = new Point(this.Width - 0x19, this.Height);
            graphics.DrawLine(Pens.Black, point, point2);
            point2 = new Point(this.Width - 0x18, 2);
            point = new Point(this.Width - 0x18, this.Height - 3);
            graphics.DrawLine(new Pen(Color.FromArgb(15, Color.White)), point2, point);
            point2 = new Point(this.Width - 0x1a, 2);
            point = new Point(this.Width - 0x1a, this.Height - 3);
            graphics.DrawLine(new Pen(Color.FromArgb(15, Color.White)), point2, point);
            int num = (int)Math.Round((double)graphics.MeasureString(" ... ", this.Font).Height);
            if (this.SelectedIndex != -1)
            {
                graphics.DrawString((this.Items[this.SelectedIndex]).ToString(), this.Font, new SolidBrush(this.ForeColor), 4f, (float)((this.Height / 2) - (num / 2)));
            }
            else if ((this.Items != null) & (this.Items.Count > 0))
            {
                graphics.DrawString((this.Items[0]).ToString(), this.Font, new SolidBrush(this.ForeColor), 4f, (float)((this.Height / 2) - (num / 2)));
            }
            else
            {
                graphics.DrawString(" Select Account ", this.Font, new SolidBrush(this.ForeColor), 4f, (float)((this.Height / 2) - (num / 2)));
            }
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            Point[] pointArray = new Point[3];
            point2 = new Point(this.Width - 0x12, 9);
            pointArray[0] = point2;
            point = new Point(this.Width - 10, 9);
            pointArray[1] = point;
            Point point3 = new Point(this.Width - 14, 14);
            pointArray[2] = point3;
            Point[] points = pointArray;
            graphics.FillPolygon(new SolidBrush(Color.FromArgb(170, 170, 170)), points);
            e.Graphics.DrawImage((Image)image.Clone(), 0, 0);

            graphics.Dispose();
            image.Dispose();
        }

        public Point[] Triangle(Point Location, Size Size)
        {
            return new Point[] { Location, new Point(Location.X + Size.Width, Location.Y), new Point(Location.X + (Size.Width / 2), Location.Y + Size.Height), Location };
        }
    }

    internal class MephobiaControlBox_TwoButtons : ThemeControl154
    {
        // Fields
        private Color G1;
        private Color G2;
        private Color G3;
        private Color I;
        private Color O;
        private int X;

        // Methods
        public MephobiaControlBox_TwoButtons()
        {
            this.SetColor("Gradient Top", 0x3e, 0x3e, 0x3e);
            this.SetColor("Gradient Middle", 0x2c, 0x2c, 0x2c);
            this.SetColor("Gradient Bottom", 0x1b, 0x1b, 0x1b);
            this.SetColor("Icons", 170, 170, 170);
            this.SetColor("Outline", 90, Color.Black);
            Size size = new Size(0x35, 0x1c);
            this.Size = size;
            this.Anchor = AnchorStyles.Right | AnchorStyles.Top;
        }

        protected override void ColorHook()
        {
            this.G1 = this.GetColor("Gradient Top");
            this.G2 = this.GetColor("Gradient Middle");
            this.G3 = this.GetColor("Gradient Bottom");
            this.I = this.GetColor("Icons");
            this.O = this.GetColor("Outline");
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (this.X < 30)
            {
                this.FindForm().WindowState = FormWindowState.Minimized;
            }
            else if (this.X > 30)
            {
                this.FindForm().Close();
            }
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            this.Top = 2;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.X = e.Location.X;
            this.Invalidate();
        }

        protected override void PaintHook()
        {
            base.G.Clear(this.BackColor);
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            LinearGradientBrush brush = new LinearGradientBrush(rect, this.G1, this.G2, 90f);
            ColorBlend blend = new ColorBlend(3);
            blend.Colors = new Color[] { this.G1, this.G2, this.G3 };
            blend.Positions = new float[] { 0f, 0.5f, 1f };
            brush.InterpolationColors = blend;
            rect = new Rectangle(0, 0, this.Width, this.Height);
            base.G.FillRectangle(brush, rect);
            base.G.SmoothingMode = SmoothingMode.HighQuality;
            if (base.State == MouseState.Over)
            {
                if (this.X < 30)
                {
                    base.G.FillPath(new SolidBrush(Color.FromArgb(20, Color.Black)), this.CreateRound(4, 4, 0x16, 0x12, 6));
                    base.G.DrawPath(new Pen(this.O), this.CreateRound(4, 4, 0x16, 0x12, 6));
                }
                else if (this.X > 30)
                {
                    base.G.FillPath(new SolidBrush(Color.FromArgb(20, Color.Black)), this.CreateRound(0x1b, 4, 0x17, 0x12, 6));
                    base.G.DrawPath(new Pen(this.O), this.CreateRound(0x1b, 4, 0x17, 0x12, 6));
                }
            }
            else if (base.State == MouseState.Down)
            {
                if (this.X < 30)
                {
                    base.G.FillPath(new SolidBrush(Color.FromArgb(70, Color.Black)), this.CreateRound(4, 4, 0x16, 0x12, 6));
                    base.G.DrawPath(new Pen(this.O), this.CreateRound(4, 4, 0x16, 0x12, 6));
                }
                else if (this.X > 30)
                {
                    base.G.FillPath(new SolidBrush(Color.FromArgb(70, Color.Black)), this.CreateRound(0x1b, 4, 0x17, 0x12, 6));
                    base.G.DrawPath(new Pen(this.O), this.CreateRound(0x1b, 4, 0x17, 0x12, 6));
                }
            }
            Point point = new Point(8, 7);
            base.G.DrawString("0", new Font("Marlett", 10f), new SolidBrush(this.I), (PointF)point);
            point = new Point(0x1f, 7);
            base.G.DrawString("r", new Font("Marlett", 10f), new SolidBrush(this.I), (PointF)point);
        }
    }

    internal class MephobiaGroupBox : ThemeContainer154
    {
        // Fields
        private Color B;
        private Color G1;
        private Color G2;
        private Color TC;

        // Methods
        public MephobiaGroupBox()
        {
            this.ControlMode = true;
            this.SetColor("Gradient Top", 40, 40, 40);
            this.SetColor("Gradient Bottom", 20, 20, 20);
            this.SetColor("Text", 170, 170, 170);
            this.SetColor("Border", Color.Black);
        }

        protected override void ColorHook()
        {
            this.G1 = this.GetColor("Gradient Top");
            this.G2 = this.GetColor("Gradient Bottom");
            this.TC = this.GetColor("Text");
            this.B = this.GetColor("Border");
        }

        protected override void PaintHook()
        {
            base.G.Clear(this.BackColor);
            base.G.SmoothingMode = SmoothingMode.HighQuality;
            base.G.DrawPath(new Pen(this.B), this.CreateRound(0, 0, this.Width - 1, this.Height - 1, 7));
            Rectangle rect = new Rectangle(0, 0, this.Width - 1, 0x1b);
            LinearGradientBrush brush = new LinearGradientBrush(rect, this.G1, this.G2, 90f);
            base.G.FillPath(brush, this.CreateRound(0, 0, this.Width - 1, 0x1b, 7));
            base.G.DrawPath(new Pen(this.B), this.CreateRound(0, 0, this.Width - 1, 0x1b, 7));
            base.G.SmoothingMode = SmoothingMode.None;
            rect = new Rectangle(1, 0x18, this.Width - 2, 10);
            base.G.FillRectangle(new SolidBrush(this.BackColor), rect);
            Point point = new Point(0, 0x18);
            Point point2 = new Point(this.Width, 0x18);
            base.G.DrawLine(new Pen(this.B), point, point2);
            point2 = new Point(2, 0x17);
            point = new Point(this.Width - 3, 0x17);
            base.G.DrawLine(new Pen(Color.FromArgb(15, Color.White)), point2, point);
            point2 = new Point(7, 5);
            base.G.DrawString(this.Text, this.Font, new SolidBrush(this.TC), (PointF)point2);
            base.G.SmoothingMode = SmoothingMode.HighQuality;
            base.G.DrawPath(new Pen(Color.FromArgb(15, Color.White)), this.CreateRound(1, 1, this.Width - 3, this.Height - 3, 7));
        }
    }

    internal class MephobiaListbox : ListBox
    {
        // Fields

        // Methods
        public MephobiaListbox()
        {
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.BorderStyle = BorderStyle.None;
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.ItemHeight = 20;
            this.ForeColor = Color.FromArgb(170, 170, 170);
            this.BackColor = Color.FromArgb(0x16, 0x16, 0x16);
            this.IntegralHeight = false;
        }


        public void CustomPaint()
        {
            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            this.CreateGraphics().DrawRectangle(Pens.Black, rect);
            rect = new Rectangle(1, 1, this.Width - 3, this.Height - 3);
            this.CreateGraphics().DrawRectangle(new Pen(Color.FromArgb(0x2b, 0x2b, 0x2b)), rect);
            rect = new Rectangle(0, 0, 1, 1);
            this.CreateGraphics().FillRectangle(new SolidBrush(this.BackColor), rect);
            rect = new Rectangle(this.Width - 1, this.Height - 1, 1, 1);
            this.CreateGraphics().FillRectangle(new SolidBrush(this.BackColor), rect);
            rect = new Rectangle(0, this.Height - 1, 1, 1);
            this.CreateGraphics().FillRectangle(new SolidBrush(this.BackColor), rect);
            rect = new Rectangle(this.Width - 1, 0, 1, 1);
            this.CreateGraphics().FillRectangle(new SolidBrush(this.BackColor), rect);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            try
            {
                if (e.Index >= 0)
                {
                    Rectangle bounds;
                    e.DrawBackground();
                    Point location = new Point(e.Bounds.Left, e.Bounds.Top + 2);
                    Size size = new Size(this.Bounds.Width, 0x10);
                    Rectangle rectangle = new Rectangle(location, size);
                    e.DrawFocusRectangle();
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    {
                        Point point2 = new Point(e.Bounds.Location.X + 2, e.Bounds.Location.Y);
                        size = new Size(e.Bounds.Width - 4, e.Bounds.Height);
                        Rectangle rect = new Rectangle(point2, size);
                        LinearGradientBrush brush = new LinearGradientBrush(rect, Color.FromArgb(170, 15, 0x16), Color.FromArgb(130, 15, 0x16), 90f);
                        e.Graphics.FillRectangle(new SolidBrush(this.BackColor), e.Bounds);
                        e.Graphics.FillRectangle(brush, rect);
                        brush.Dispose();
                        bounds = e.Bounds;
                        e.Graphics.DrawString(" " + this.Items[e.Index].ToString(), this.Font, Brushes.White, (float)e.Bounds.X, (float)(bounds.Y + 1));
                    }
                    else
                    {
                        bounds = e.Bounds;
                        e.Graphics.DrawString(" " + this.Items[e.Index].ToString(), this.Font, new SolidBrush(this.ForeColor), (float)e.Bounds.X, (float)(bounds.Y + 1));
                    }
                    bounds = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                    e.Graphics.DrawRectangle(Pens.Black, bounds);
                    bounds = new Rectangle(1, 1, this.Width - 3, this.Height - 3);
                    e.Graphics.DrawRectangle(new Pen(Color.FromArgb(0x2b, 0x2b, 0x2b)), bounds);
                    bounds = new Rectangle(0, 0, 1, 1);
                    e.Graphics.FillRectangle(new SolidBrush(this.BackColor), bounds);
                    bounds = new Rectangle(this.Width - 1, this.Height - 1, 1, 1);
                    e.Graphics.FillRectangle(new SolidBrush(this.BackColor), bounds);
                    bounds = new Rectangle(0, this.Height - 1, 1, 1);
                    e.Graphics.FillRectangle(new SolidBrush(this.BackColor), bounds);
                    bounds = new Rectangle(this.Width - 1, 0, 1, 1);
                    e.Graphics.FillRectangle(new SolidBrush(this.BackColor), bounds);
                    base.OnDrawItem(e);
                }
            }
            catch { }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 15)
            {
                this.CustomPaint();
            }
        }
    }

    internal class MephobiaProgressBar : ThemeControl154
    {
        // Fields
        private int _Maximum = 100;
        private int _Minimum;
        private int _Value;
        private Color Edge;
        private Color G1;
        private double ROffset;

        // Methods
        public MephobiaProgressBar()
        {
            this.SetColor("Color", 180, 0x1a, 0x20);
            this.SetColor("Edge", Color.Black);
        }

        protected override void ColorHook()
        {
            this.G1 = this.GetColor("Color");
            this.Edge = this.GetColor("Edge");
        }

        private void Increment(int amount)
        {
            this.Value += amount;
        }

        protected override void OnAnimation()
        {
            base.OnAnimation();
            if (this.ROffset < 7.0)
            {
                this.ROffset += 0.2;
            }
            else
            {
                this.ROffset = 0.0;
            }
            this.Invalidate();
        }

        protected override void PaintHook()
        {
            Point point;
            base.G.Clear(this.BackColor);
            Rectangle rect = new Rectangle(1, 1, (int)Math.Round((double)(((((double)this.Width) / ((double)this.Maximum)) * this.Value) - 1.0)), this.Height - 2);
            LinearGradientBrush brush = new LinearGradientBrush(rect, Color.FromArgb(180, this.G1), this.G1, 0f);
            HatchBrush brush2 = new HatchBrush(HatchStyle.ForwardDiagonal, Color.FromArgb(20, Color.Black), Color.Transparent);
            if (this.Value > 1)
            {
                base.G.FillPath(Brushes.Black, this.CreateRound(1, 1, (int)Math.Round((double)(((((double)this.Width) / ((double)this.Maximum)) * this.Value) - 1.0)), this.Height - 2, 5));
                base.G.FillPath(brush, this.CreateRound(1, 1, (int)Math.Round((double)(((((double)this.Width) / ((double)this.Maximum)) * this.Value) - 1.0)), this.Height - 2, 5));
                point = new Point((int)Math.Round(-this.ROffset), 0);
                base.G.RenderingOrigin = point;
                base.G.FillPath(brush2, this.CreateRound(1, 1, (int)Math.Round((double)(((((double)this.Width) / ((double)this.Maximum)) * this.Value) - 1.0)), this.Height - 2, 5));
                point = new Point((int)Math.Round((double)(-this.ROffset + 1.0)), 0);
                base.G.RenderingOrigin = point;
                base.G.FillPath(brush2, this.CreateRound(1, 1, (int)Math.Round((double)(((((double)this.Width) / ((double)this.Maximum)) * this.Value) - 1.0)), this.Height - 2, 5));
                point = new Point((int)Math.Round((double)(-this.ROffset + 2.0)), 0);
                base.G.RenderingOrigin = point;
                base.G.FillPath(brush2, this.CreateRound(1, 1, (int)Math.Round((double)(((((double)this.Width) / ((double)this.Maximum)) * this.Value) - 1.0)), this.Height - 2, 5));
                base.G.FillPath(new SolidBrush(Color.FromArgb(0x23, Color.Black)), this.CreateRound(1, (int)Math.Round((double)(((double)this.Height) / 2.0)), (int)Math.Round((double)(((((double)this.Width) / ((double)this.Maximum)) * this.Value) - 1.0)), (int)Math.Round((double)(((double)this.Height) / 2.0)), 5));
            }
            point = new Point((int)Math.Round((double)(((((double)this.Width) / ((double)this.Maximum)) * this.Value) - 1.0)), 2);
            Point point2 = new Point((int)Math.Round((double)(((((double)this.Width) / ((double)this.Maximum)) * this.Value) - 1.0)), this.Height - 2);
            base.G.DrawLine(new Pen(this.Edge), point, point2);
            base.G.SmoothingMode = SmoothingMode.HighQuality;
            base.G.DrawPath(new Pen(this.Edge), this.CreateRound(1, 1, this.Width - 2, this.Height - 2, 5));
            base.G.DrawPath(new Pen(Color.FromArgb(10, Color.White)), this.CreateRound(2, 2, this.Width - 4, this.Height - 4, 5));
        }

        // Properties
        public bool Animated
        {
            get
            {
                return this.IsAnimated;
            }
            set
            {
                this.IsAnimated = value;
                this.Invalidate();
            }
        }

        public int Maximum
        {
            get
            {
                return this._Maximum;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }
                this._Maximum = value;
                if (value < this._Value)
                {
                    this._Value = value;
                }
                if (value < this._Minimum)
                {
                    this._Minimum = value;
                }
                this.Invalidate();
            }
        }

        public int Minimum
        {
            get
            {
                return this._Minimum;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }
                this._Minimum = value;
                if (value > this._Value)
                {
                    this._Value = value;
                }
                if (value > this._Maximum)
                {
                    this._Maximum = value;
                }
                this.Invalidate();
            }
        }

        public int Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                if ((value > this._Maximum) || (value < this._Minimum))
                {
                    throw new Exception("Property value is not valid.");
                }
                this._Value = value;
                this.Invalidate();
            }
        }
    }

    [DefaultEvent("CheckedChanged")]
    internal class MephobiaRadiobutton : ThemeControl154
    {
        // Fields
        private CheckedChangedEventHandler CheckedChangedEvent;
        private bool _Checked;
        private Color Border;
        private Color C1;
        private Color C2;
        private Color Glow;
        private Color TC;
        private Color UC1;
        private Color UC2;
        private int X;

        // Events
        public event CheckedChangedEventHandler CheckedChanged;

        // Methods
        public MephobiaRadiobutton()
        {
            this.LockHeight = 0x10;
            this.SetColor("Border", Color.Black);
            this.SetColor("Checked1", 180, 0x1a, 0x20);
            this.SetColor("Checked2", 200, 180, 0x1a, 0x20);
            this.SetColor("Unchecked1", 30, 30, 30);
            this.SetColor("Unchecked2", 0x19, 0x19, 0x19);
            this.SetColor("Glow", 15, Color.White);
            this.SetColor("Text", 170, 170, 170);
        }



        protected override void ColorHook()
        {
            this.C1 = this.GetColor("Checked1");
            this.C2 = this.GetColor("Checked2");
            this.UC1 = this.GetColor("Unchecked1");
            this.UC2 = this.GetColor("Unchecked2");
            this.Border = this.GetColor("Border");
            this.Glow = this.GetColor("Glow");
            this.TC = this.GetColor("Text");
        }

        private void InvalidateControls()
        {
            if (this.IsHandleCreated && this._Checked)
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = this.Parent.Controls.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        Control current = (Control)enumerator.Current;
                        if ((((current == this) || !(current is MephobiaRadiobutton)) ? 0 : 1) != 0)
                        {
                            ((MephobiaRadiobutton)current).Checked = false;
                        }
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
            }
        }

        protected override void OnCreation()
        {
            this.InvalidateControls();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!this._Checked)
            {
                this.Checked = true;
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.X = e.Location.X;
            this.Invalidate();
        }

        protected override void PaintHook()
        {
            Rectangle rectangle;
            Rectangle rectangle2;
            base.G.Clear(this.BackColor);
            base.G.SmoothingMode = SmoothingMode.HighQuality;
            if (this._Checked)
            {
                rectangle = new Rectangle(0, 0, 15, 15);
                rectangle2 = new Rectangle(0, 0, 15, 15);
                base.G.FillEllipse(new LinearGradientBrush(rectangle, this.C1, this.C2, 90f), rectangle2);
            }
            else
            {
                rectangle2 = new Rectangle(0, 0, 15, 15);
                rectangle = new Rectangle(0, 0, 15, 15);
                base.G.FillEllipse(new LinearGradientBrush(rectangle2, this.UC1, this.UC2, 90f), rectangle);
            }
            if ((base.State == MouseState.Over) & (this.X < 0x10))
            {
                if (this.Checked)
                {
                    base.G.FillEllipse(new SolidBrush(this.Glow), 0, 0, 15, 15);
                }
                else
                {
                    base.G.FillEllipse(new SolidBrush(Color.FromArgb(10, this.Glow)), 0, 0, 15, 15);
                }
            }
            rectangle2 = new Rectangle(0, 0, 15, 15);
            base.G.DrawEllipse(new Pen(this.Border), rectangle2);
            this.DrawText(new SolidBrush(this.TC), HorizontalAlignment.Left, 20, 0);
        }

        // Properties
        public bool Checked
        {
            get
            {
                return this._Checked;
            }
            set
            {
                this._Checked = value;
                this.InvalidateControls();
                CheckedChangedEventHandler checkedChangedEvent = this.CheckedChangedEvent;
                if (checkedChangedEvent != null)
                {
                    checkedChangedEvent(this);
                }
                this.Invalidate();
            }
        }

        // Nested Types
        public delegate void CheckedChangedEventHandler(object sender);
    }

    internal class MephobiaSeparator : ThemeControl154
    {
        // Fields
        private Color Accent;
        private Color Border;

        // Methods
        public MephobiaSeparator()
        {
            this.SetColor("Border", Color.Black);
            this.SetColor("Accent", 180, 0x1a, 0x20);
            this.LockHeight = 5;
        }

        protected override void ColorHook()
        {
            this.Border = this.GetColor("Border");
            this.Accent = this.GetColor("Accent");
        }

        protected override void PaintHook()
        {
            base.G.Clear(this.BackColor);
            Point point = new Point(0, 0);
            Point point2 = new Point(this.Width, 0);
            base.G.DrawLine(new Pen(Color.FromArgb(10, Color.White)), point, point2);
            point2 = new Point(0, 1);
            point = new Point(this.Width, 1);
            base.G.DrawLine(new Pen(this.Border), point2, point);
            ColorBlend blend = new ColorBlend(3);
            blend.Colors = new Color[] { Color.Black, this.Accent, Color.Black };
            blend.Positions = new float[] { 0f, 0.5f, 1f };
            Rectangle r = new Rectangle(1, 2, this.Width - 2, 2);
            this.DrawGradient(blend, r, 0f);
            point2 = new Point(0, 4);
            point = new Point(this.Width, 4);
            base.G.DrawLine(new Pen(Color.FromArgb(10, Color.White)), point2, point);
        }
    }

    internal class MephobiaTabcontrol : TabControl
    {
        // Fields
        private Pen Border;

        // Methods
        public MephobiaTabcontrol()
        {
            this.Border = Pens.Black;
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            this.DoubleBuffered = true;
            this.SizeMode = TabSizeMode.Fixed;
            Size size = new Size(0x2c, 0x88);
            this.ItemSize = size;
        }


        protected override void CreateHandle()
        {
            base.CreateHandle();
            this.Alignment = TabAlignment.Left;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle tabRect;
            Point point4;
            Point point5;
            Size size3;
            StringFormat format;
            Bitmap image = new Bitmap(this.Width, this.Height);
            Graphics graphics = Graphics.FromImage(image);
            try
            {
                this.SelectedTab.BackColor = Color.FromArgb(30, 30, 30);
            }
            catch { }
            graphics.Clear(Color.FromArgb(30, 30, 30));
            Point point = new Point(this.ItemSize.Height + 3, 0);
            Point location = new Point(this.ItemSize.Height + 3, 0x3e7);
            graphics.DrawLine(this.Border, point, location);
            Size itemSize = this.ItemSize;
            location = new Point(itemSize.Height + 2, 0);
            point = new Point(this.ItemSize.Height + 2, 0x3e7);
            graphics.DrawLine(new Pen(Color.FromArgb(15, Color.White)), location, point);
            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            graphics.DrawRectangle(this.Border, rect);
            rect = new Rectangle(1, 1, this.Width - 3, this.Height - 3);
            graphics.DrawRectangle(new Pen(Color.FromArgb(15, Color.White)), rect);
            int num = this.TabCount - 1;
            int index = 0;
        Label_0147:
            if (index > num)
            {
                e.Graphics.DrawImage((Image)image.Clone(), 0, 0);
                graphics.Dispose();
                image.Dispose();
                return;
            }
            if (index == this.SelectedIndex)
            {
                Rectangle rectangle2;
                Point point3;
                if (index == -1)
                {
                    point = this.GetTabRect(index).Location;
                    point3 = new Point(this.GetTabRect(index).Location.X - 2, point.Y - 2);
                    itemSize = new Size(this.GetTabRect(index).Width + 3, this.GetTabRect(index).Height + 1);
                    rectangle2 = new Rectangle(point3, itemSize);
                }
                else
                {
                    tabRect = this.GetTabRect(index);
                    point = new Point(tabRect.Location.X - 2, this.GetTabRect(index).Location.Y - 2);
                    itemSize = new Size(this.GetTabRect(index).Width + 3, this.GetTabRect(index).Height);
                    rectangle2 = new Rectangle(point, itemSize);
                }
                ColorBlend blend = new ColorBlend();
                blend.Colors = new Color[] { Color.FromArgb(40, 40, 40), Color.FromArgb(30, 30, 30), Color.FromArgb(20, 20, 20) };
                blend.Positions = new float[] { 0f, 0.5f, 1f };
                LinearGradientBrush brush = new LinearGradientBrush(rectangle2, Color.Black, Color.Black, 90f)
                {
                    InterpolationColors = blend
                };
                graphics.FillRectangle(brush, rectangle2);
                graphics.DrawRectangle(this.Border, rectangle2);
                tabRect = new Rectangle(rectangle2.Location.X + 1, rectangle2.Location.Y + 1, rectangle2.Width - 2, rectangle2.Height - 2);
                graphics.DrawRectangle(new Pen(Color.FromArgb(15, Color.White)), tabRect);
                location = this.GetTabRect(index).Location;
                point = new Point(this.GetTabRect(index).Location.X - 2, location.Y - 2);
                itemSize = new Size(this.GetTabRect(index).Width + 3, this.GetTabRect(index).Height + 1);
                rectangle2 = new Rectangle(point, itemSize);
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                Point[] pointArray = new Point[3];
                itemSize = this.ItemSize;
                tabRect = this.GetTabRect(index);
                point3 = tabRect.Location;
                location = new Point(itemSize.Height - 3, point3.Y + 20);
                pointArray[0] = location;
                point = this.GetTabRect(index).Location;
                point4 = new Point(this.ItemSize.Height + 4, point.Y + 14);
                pointArray[1] = point4;
                size3 = this.ItemSize;
                point5 = new Point(size3.Height + 4, this.GetTabRect(index).Location.Y + 0x1b);
                pointArray[2] = point5;
                Point[] points = pointArray;
                graphics.DrawPolygon(new Pen(Color.FromArgb(15, Color.White), 3f), points);
                graphics.FillPolygon(new SolidBrush(Color.FromArgb(30, 30, 30)), points);
                graphics.DrawPolygon(this.Border, points);
                if (this.ImageList != null)
                {
                    try
                    {
                        if (this.ImageList.Images[this.TabPages[index].ImageIndex] != null)
                        {
                            point5 = rectangle2.Location;
                            point4 = new Point(point5.X + 8, rectangle2.Location.Y + 6);
                            graphics.DrawImage(this.ImageList.Images[this.TabPages[index].ImageIndex], point4);
                            format = new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Center
                            };
                            graphics.DrawString("      " + this.TabPages[index].Text, this.Font, Brushes.DimGray, rectangle2, format);
                        }
                        else
                        {
                            format = new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Center
                            };
                            graphics.DrawString(this.TabPages[index].Text, this.Font, Brushes.White, rectangle2, format);
                        }
                        goto Label_09D5;
                    }
                    catch
                    {
                        format = new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        };
                        graphics.DrawString(this.TabPages[index].Text, this.Font, Brushes.White, rectangle2, format);
                        goto Label_09D5;
                    }
                }
                format = new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                };
                graphics.DrawString(this.TabPages[index].Text, this.Font, Brushes.White, rectangle2, format);
            }
            else
            {
                tabRect = this.GetTabRect(index);
                point5 = tabRect.Location;
                Point point6 = this.GetTabRect(index).Location;
                point4 = new Point(point5.X - 1, point6.Y - 1);
                size3 = new Size(this.GetTabRect(index).Width + 2, this.GetTabRect(index).Height);
                Rectangle layoutRectangle = new Rectangle(point4, size3);
                point5 = new Point(layoutRectangle.Right, layoutRectangle.Top);
                point6 = new Point(layoutRectangle.Right, layoutRectangle.Bottom);
                graphics.DrawLine(this.Border, point5, point6);
                point5 = new Point(layoutRectangle.Right - 1, layoutRectangle.Top);
                point6 = new Point(layoutRectangle.Right - 1, layoutRectangle.Bottom);
                graphics.DrawLine(new Pen(Color.FromArgb(0x2b, 0x2b, 0x2b)), point5, point6);
                if (this.ImageList != null)
                {
                    try
                    {
                        if (this.ImageList.Images[this.TabPages[index].ImageIndex] != null)
                        {
                            point5 = layoutRectangle.Location;
                            point4 = new Point(point5.X + 8, layoutRectangle.Location.Y + 6);
                            graphics.DrawImage(this.ImageList.Images[this.TabPages[index].ImageIndex], point4);
                            format = new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Center
                            };
                            graphics.DrawString("      " + this.TabPages[index].Text, this.Font, new SolidBrush(Color.FromArgb(170, 170, 170)), layoutRectangle, format);
                        }
                        else
                        {
                            format = new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Center
                            };
                            graphics.DrawString(this.TabPages[index].Text, this.Font, new SolidBrush(Color.FromArgb(170, 170, 170)), layoutRectangle, format);
                        }
                        goto Label_09D5;
                    }
                    catch
                    {
                        format = new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        };
                        graphics.DrawString(this.TabPages[index].Text, this.Font, new SolidBrush(Color.FromArgb(170, 170, 170)), layoutRectangle, format);
                        goto Label_09D5;
                    }
                }
                format = new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                };
                graphics.DrawString(this.TabPages[index].Text, this.Font, new SolidBrush(Color.FromArgb(170, 170, 170)), layoutRectangle, format);
            }
        Label_09D5:
            index++;
            goto Label_0147;
        }

        public Brush ToBrush(Color color)
        {
            return new SolidBrush(color);
        }

        public Pen ToPen(Color color)
        {
            return new Pen(color);
        }
    }

    [DefaultEvent("TextChanged")]
    internal class MephobiaTextBox : ThemeControl154
    {
        // Fields
        private int _MaxLength = 0x7fff;
        private bool _Multiline;
        private bool _ReadOnly;
        private HorizontalAlignment _TextAlign = HorizontalAlignment.Left;
        private bool _UseSystemPasswordChar;
        private Color Background;
        private TextBox Base = new TextBox();
        private Color Border;

        // Methods
        public MephobiaTextBox()
        {
            this.Base.Font = this.Font;
            this.Base.Text = this.Text;
            this.Base.MaxLength = this._MaxLength;
            this.Base.Multiline = this._Multiline;
            this.Base.ReadOnly = this._ReadOnly;
            this.Base.UseSystemPasswordChar = this._UseSystemPasswordChar;
            this.Base.BorderStyle = BorderStyle.None;
            Point point = new Point(4, 4);
            this.Base.Location = point;
            this.Base.Width = this.Width - 10;
            if (this._Multiline)
            {
                this.Base.Height = this.Height - 11;
            }
            else
            {
                this.LockHeight = this.Base.Height + 11;
            }
            this.Base.TextChanged += new EventHandler(this.OnBaseTextChanged);
            this.Base.KeyDown += new KeyEventHandler(this.OnBaseKeyDown);
            this.SetColor("Text", 170, 170, 170);
            this.SetColor("Background", 0x16, 0x16, 0x16);
            this.SetColor("Border", 0, 0, 0);
        }

        protected override void ColorHook()
        {
            this.Background = this.GetColor("Background");
            this.Border = this.GetColor("Border");
            this.Base.ForeColor = this.GetColor("Text");
            this.Base.BackColor = this.Background;
        }

        private void OnBaseKeyDown(object sender, KeyEventArgs e)
        {
            if (((!e.Control || (e.KeyCode != Keys.A)) ? 0 : 1) != 0)
            {
                this.Base.SelectAll();
                e.SuppressKeyPress = true;
            }
        }

        private void OnBaseTextChanged(object sender, EventArgs e)
        {
            this.Text = this.Base.Text;
        }

        protected override void OnCreation()
        {
            if (!this.Controls.Contains(this.Base))
            {
                this.Controls.Add(this.Base);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            Point point = new Point(5, 5);
            this.Base.Location = point;
            this.Base.Width = this.Width - 5;
            if (this._Multiline)
            {
                this.Base.Height = this.Height - 5;
            }
            base.OnResize(e);
        }

        protected override void PaintHook()
        {
            base.G.Clear(this.BackColor);
            base.G.SmoothingMode = SmoothingMode.HighQuality;
            base.G.FillPath(new SolidBrush(this.Background), this.CreateRound(0, 0, this.Width - 1, this.Height - 1, 6));
            base.G.DrawPath(new Pen(Color.FromArgb(15, Color.White)), this.CreateRound(1, 1, this.Width - 3, this.Height - 3, 6));
            base.G.DrawPath(new Pen(this.Border), this.CreateRound(0, 0, this.Width - 1, this.Height - 1, 6));
        }

        // Properties
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                if (this.Base != null)
                {
                    this.Base.Font = value;
                    Point point = new Point(3, 5);
                    this.Base.Location = point;
                    this.Base.Width = this.Width - 6;
                    if (!this._Multiline)
                    {
                        this.LockHeight = this.Base.Height + 11;
                    }
                }
            }
        }

        public int MaxLength
        {
            get
            {
                return this._MaxLength;
            }
            set
            {
                this._MaxLength = value;
                if (this.Base != null)
                {
                    this.Base.MaxLength = value;
                }
            }
        }

        public bool Multiline
        {
            get
            {
                return this._Multiline;
            }
            set
            {
                this._Multiline = value;
                if (this.Base != null)
                {
                    this.Base.Multiline = value;
                    if (value)
                    {
                        this.LockHeight = 0;
                        this.Base.Height = this.Height - 11;
                    }
                    else
                    {
                        this.LockHeight = this.Base.Height + 11;
                    }
                }
            }
        }

        public string PasswordChar
        {
            get
            {
                return this.Base.PasswordChar.ToString();
            }
            set
            {
                this.Base.PasswordChar = (value).ToCharArray()[0];
            }
        }

        public bool ReadOnly
        {
            get
            {
                return this._ReadOnly;
            }
            set
            {
                this._ReadOnly = value;
                if (this.Base != null)
                {
                    this.Base.ReadOnly = value;
                }
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                if (this.Base != null)
                {
                    this.Base.Text = value;
                }
            }
        }

        public HorizontalAlignment TextAlign
        {
            get
            {
                return this._TextAlign;
            }
            set
            {
                this._TextAlign = value;
                if (this.Base != null)
                {
                    this.Base.TextAlign = value;
                }
            }
        }

        public bool UseSystemPasswordChar
        {
            get
            {
                return this._UseSystemPasswordChar;
            }
            set
            {
                this._UseSystemPasswordChar = value;
                if (this.Base != null)
                {
                    this.Base.UseSystemPasswordChar = value;
                }
            }
        }
    }
}
