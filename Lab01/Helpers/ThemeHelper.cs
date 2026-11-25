using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Lab01.Helpers
{
    public static class ThemeHelper
    {
        public static void ApplyGenderTheme(Form form, string gender, params Button[] primaryButtons)
        {
            bool isFemale = string.Equals(gender, "Женский", StringComparison.OrdinalIgnoreCase);

            Color formBg = isFemale ? Color.FromArgb(255, 240, 246) : Color.FromArgb(234, 243, 255);
            Color cardBg = isFemale ? Color.FromArgb(255, 224, 236) : Color.FromArgb(214, 231, 252);
            Color accent = isFemale ? Color.FromArgb(214, 72, 128) : Color.FromArgb(42, 110, 206);
            Color textDark = isFemale ? Color.FromArgb(92, 26, 54) : Color.FromArgb(20, 48, 88);

            form.BackColor = formBg;
            form.ForeColor = textDark;

            ApplyRecursive(form.Controls, cardBg, textDark);

            foreach (var btn in primaryButtons)
            {
                btn.BackColor = accent;
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
            }
        }

        private static void ApplyRecursive(Control.ControlCollection controls, Color cardBg, Color textDark)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is GroupBox || ctrl is Panel)
                {
                    ctrl.BackColor = cardBg;
                    ctrl.ForeColor = textDark;
                }
                else if (ctrl is Label || ctrl is RadioButton || ctrl is CheckBox)
                {
                    ctrl.ForeColor = textDark;
                }

                if (ctrl.HasChildren)
                {
                    ApplyRecursive(ctrl.Controls, cardBg, textDark);
                }
            }
        }

        public static void SetAvatar(PictureBox pictureBox, string gender)
        {
            var oldImage = pictureBox.Image;
            pictureBox.Image = CreateGenderAvatar(gender, Math.Max(100, Math.Min(pictureBox.Width, pictureBox.Height)));
            oldImage?.Dispose();
        }

        public static Bitmap CreateGenderAvatar(string gender, int size = 120)
        {
            bool isFemale = string.Equals(gender, "Женский", StringComparison.OrdinalIgnoreCase);
            var bmp = new Bitmap(size, size);

            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.Transparent);

            Color circleBg = isFemale ? Color.FromArgb(248, 198, 218) : Color.FromArgb(186, 216, 250);
            Color border = isFemale ? Color.FromArgb(214, 72, 128) : Color.FromArgb(42, 110, 206);
            Color outfit = isFemale ? Color.FromArgb(224, 88, 142) : Color.FromArgb(48, 118, 212);
            Color skin = Color.FromArgb(255, 224, 196);
            Color hair = isFemale ? Color.FromArgb(128, 64, 48) : Color.FromArgb(62, 48, 42);

            float pad = 4f;
            using (var bgBrush = new SolidBrush(circleBg))
            using (var borderPen = new Pen(border, 3f))
            {
                g.FillEllipse(bgBrush, pad, pad, size - pad * 2, size - pad * 2);
                g.DrawEllipse(borderPen, pad, pad, size - pad * 2, size - pad * 2);
            }

            using var path = new GraphicsPath();
            path.AddEllipse(pad + 2, pad + 2, size - (pad + 2) * 2, size - (pad + 2) * 2);
            g.SetClip(path);

            // Shoulders / torso
            using (var outfitBrush = new SolidBrush(outfit))
            {
                g.FillEllipse(outfitBrush, size * 0.16f, size * 0.64f, size * 0.68f, size * 0.50f);
            }

            if (isFemale)
            {
                // Long hair behind head
                using var hairBrush = new SolidBrush(hair);
                g.FillEllipse(hairBrush, size * 0.24f, size * 0.16f, size * 0.52f, size * 0.58f);
            }

            // Head
            using (var skinBrush = new SolidBrush(skin))
            {
                g.FillEllipse(skinBrush, size * 0.30f, size * 0.22f, size * 0.40f, size * 0.42f);
            }

            // Top hair
            using (var hairBrush = new SolidBrush(hair))
            {
                if (isFemale)
                {
                    g.FillPie(hairBrush, size * 0.29f, size * 0.19f, size * 0.42f, size * 0.30f, 180, 180);
                }
                else
                {
                    g.FillPie(hairBrush, size * 0.29f, size * 0.19f, size * 0.42f, size * 0.26f, 180, 180);
                }
            }

            // Eyes & smile
            using (var eyeBrush = new SolidBrush(Color.FromArgb(45, 45, 55)))
            {
                float eyeY = size * 0.40f;
                float eyeR = size * 0.035f;
                g.FillEllipse(eyeBrush, size * 0.40f, eyeY, eyeR, eyeR);
                g.FillEllipse(eyeBrush, size * 0.56f, eyeY, eyeR, eyeR);
            }

            using (var smilePen = new Pen(Color.FromArgb(170, 75, 75), 2f))
            {
                g.DrawArc(smilePen, size * 0.42f, size * 0.45f, size * 0.16f, size * 0.10f, 15, 150);
            }

            if (!isFemale)
            {
                // Tie accent for male avatar
                using var tieBrush = new SolidBrush(Color.FromArgb(24, 62, 128));
                PointF[] tiePoints =
                {
                    new(size * 0.50f, size * 0.68f),
                    new(size * 0.46f, size * 0.78f),
                    new(size * 0.50f, size * 0.92f),
                    new(size * 0.54f, size * 0.78f)
                };
                g.FillPolygon(tieBrush, tiePoints);
            }

            g.ResetClip();
            return bmp;
        }
    }
}
