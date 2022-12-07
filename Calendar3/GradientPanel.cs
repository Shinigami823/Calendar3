using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar3
{
    class GradientPanel : Panel
    {

        private Color _firstFillColor;
        private Color _secondFillColor;
        private LinearGradientMode _gradientDirection;

        [Description(""), DefaultValue(typeof(Color), "")]
        public Color ColorFillFirst
        {
            get => _firstFillColor;
            set => _firstFillColor = value;
        }

        [Description(""), DefaultValue(typeof(Color), "")]
        public Color ColorFillSecond
        {
            get => _secondFillColor;
            set => _secondFillColor = value;
        }

        [Description(""), DefaultValue(LinearGradientMode.ForwardDiagonal)]
        public LinearGradientMode GradientDirection
        {
            get => _gradientDirection;
            set => _gradientDirection = value;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var lgv = new LinearGradientBrush(ClientRectangle, _firstFillColor, _secondFillColor, _gradientDirection);
            var graphics = e.Graphics;
            graphics.FillRectangle(lgv, ClientRectangle);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            SetStyle(ControlStyles.ResizeRedraw, true);
            base.OnPaint(e);
        }
    }
}