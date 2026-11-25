using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Lab02
{
    public partial class Form1 : Form
    {
        private Bitmap _originalBitmap = null!;
        private Bitmap _workingBitmap = null!;

        private bool _isDrawing;
        private Point _lastImagePoint;
        private Color _brushColor = Color.Crimson;
        private float _brushSize = 5f;

        private string _overlayText = "Графический редактор WinForms";
        private Font _overlayFont = new("Segoe UI", 22f, FontStyle.Bold);
        private Color _overlayTextColor = Color.DarkBlue;
        private bool _showText = true;

        public Form1()
        {
            InitializeComponent();
            CreateBlankCanvas(900, 560);
            UpdateStatus();
        }

        private void CreateBlankCanvas(int width, int height)
        {
            _originalBitmap?.Dispose();
            _workingBitmap?.Dispose();

            _originalBitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            using (var g = Graphics.FromImage(_originalBitmap))
            {
                g.Clear(Color.White);
            }

            _workingBitmap = (Bitmap)_originalBitmap.Clone();
            pictureBoxCanvas.Image = _workingBitmap;
        }

        private void OpenImage_Click(object? sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                using var loaded = new Bitmap(openFileDialog1.FileName);
                _originalBitmap?.Dispose();
                _workingBitmap?.Dispose();

                _originalBitmap = new Bitmap(loaded);
                _workingBitmap = new Bitmap(loaded);
                pictureBoxCanvas.Image = _workingBitmap;
                UpdateStatus($"Открыт файл: {Path.GetFileName(openFileDialog1.FileName)}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось открыть изображение: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NewCanvas_Click(object? sender, EventArgs e)
        {
            CreateBlankCanvas(900, 560);
            UpdateStatus("Создан новый чистый холст.");
        }

        private void SaveAs_Click(object? sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                using var exportBitmap = new Bitmap(_workingBitmap);
                if (_showText && !string.IsNullOrWhiteSpace(_overlayText))
                {
                    using var g = Graphics.FromImage(exportBitmap);
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    DrawOverlayText(g, new RectangleF(0, 0, exportBitmap.Width, exportBitmap.Height));
                }

                string ext = Path.GetExtension(saveFileDialog1.FileName).ToLowerInvariant();
                ImageFormat format = ext switch
                {
                    ".jpg" or ".jpeg" => ImageFormat.Jpeg,
                    ".bmp" => ImageFormat.Bmp,
                    _ => ImageFormat.Png
                };

                exportBitmap.Save(saveFileDialog1.FileName, format);
                UpdateStatus($"Сохранено: {Path.GetFileName(saveFileDialog1.FileName)}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Exit_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void ChangeBackground_Click(object? sender, EventArgs e)
        {
            colorDialog1.Color = BackColor;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                BackColor = colorDialog1.Color;
                UpdateStatus("Цвет фона формы изменён.");
            }
        }

        private void ToggleText_Click(object? sender, EventArgs e)
        {
            if (sender == ctxToggleText)
            {
                miToggleText.Checked = !miToggleText.Checked;
            }
            _showText = miToggleText.Checked;
            pictureBoxCanvas.Invalidate();
            UpdateStatus(_showText ? "Надпись отображается." : "Надпись скрыта.");
        }

        private void ClearDrawing_Click(object? sender, EventArgs e)
        {
            _workingBitmap.Dispose();
            _workingBitmap = (Bitmap)_originalBitmap.Clone();
            pictureBoxCanvas.Image = _workingBitmap;
            pictureBoxCanvas.Invalidate();
            UpdateStatus("Рисунок сброшен к исходному изображению.");
        }

        private void SetText_Click(object? sender, EventArgs e)
        {
            using var prompt = new TextPromptForm(_overlayText);
            if (prompt.ShowDialog(this) == DialogResult.OK)
            {
                _overlayText = prompt.InputText;
                pictureBoxCanvas.Invalidate();
                UpdateStatus("Текст надписи обновлён.");
            }
        }

        private void SetFont_Click(object? sender, EventArgs e)
        {
            fontDialog1.Font = _overlayFont;
            fontDialog1.Color = _overlayTextColor;
            fontDialog1.ShowColor = true;
            if (fontDialog1.ShowDialog(this) == DialogResult.OK)
            {
                _overlayFont = fontDialog1.Font;
                _overlayTextColor = fontDialog1.Color;
                pictureBoxCanvas.Invalidate();
                UpdateStatus($"Шрифт изменён: {_overlayFont.Name}, {_overlayFont.Size} pt.");
            }
        }

        private void SetTextColor_Click(object? sender, EventArgs e)
        {
            colorDialog1.Color = _overlayTextColor;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                _overlayTextColor = colorDialog1.Color;
                pictureBoxCanvas.Invalidate();
                UpdateStatus("Цвет текста изменён.");
            }
        }

        private void BrushColor_Click(object? sender, EventArgs e)
        {
            colorDialog1.Color = _brushColor;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                _brushColor = colorDialog1.Color;
                UpdateStatus();
            }
        }

        private void BrushSize_Click(object? sender, EventArgs e)
        {
            miBrush2.Checked = sender == miBrush2;
            miBrush5.Checked = sender == miBrush5;
            miBrush10.Checked = sender == miBrush10;

            if (sender == miBrush2) _brushSize = 2f;
            else if (sender == miBrush10) _brushSize = 10f;
            else _brushSize = 5f;

            UpdateStatus();
        }

        private void PictureBoxCanvas_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            if (TryTranslateZoomPoint(e.Location, out Point imagePoint))
            {
                _isDrawing = true;
                _lastImagePoint = imagePoint;
            }
        }

        private void PictureBoxCanvas_MouseMove(object? sender, MouseEventArgs e)
        {
            if (!_isDrawing || e.Button != MouseButtons.Left)
            {
                return;
            }

            if (TryTranslateZoomPoint(e.Location, out Point currentImagePoint))
            {
                using (var g = Graphics.FromImage(_workingBitmap))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    using var pen = new Pen(_brushColor, _brushSize)
                    {
                        StartCap = LineCap.Round,
                        EndCap = LineCap.Round
                    };
                    g.DrawLine(pen, _lastImagePoint, currentImagePoint);
                }

                _lastImagePoint = currentImagePoint;
                pictureBoxCanvas.Invalidate();
            }
        }

        private void PictureBoxCanvas_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDrawing = false;
            }
        }

        private void PictureBoxCanvas_Paint(object? sender, PaintEventArgs e)
        {
            if (!_showText || string.IsNullOrWhiteSpace(_overlayText))
            {
                return;
            }

            RectangleF targetRect = GetZoomedImageRectangle();
            if (targetRect.Width > 0 && targetRect.Height > 0)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                DrawOverlayText(e.Graphics, targetRect);
            }
        }

        private void DrawOverlayText(Graphics g, RectangleF bounds)
        {
            using var brush = new SolidBrush(_overlayTextColor);
            using var format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Far
            };
            var textRect = new RectangleF(bounds.X + 12, bounds.Y + 12, bounds.Width - 24, bounds.Height - 24);
            g.DrawString(_overlayText, _overlayFont, brush, textRect, format);
        }

        private RectangleF GetZoomedImageRectangle()
        {
            if (_workingBitmap == null || pictureBoxCanvas.ClientSize.Width <= 0 || pictureBoxCanvas.ClientSize.Height <= 0)
            {
                return RectangleF.Empty;
            }

            float imgW = _workingBitmap.Width;
            float imgH = _workingBitmap.Height;
            float boxW = pictureBoxCanvas.ClientSize.Width;
            float boxH = pictureBoxCanvas.ClientSize.Height;

            float scale = Math.Min(boxW / imgW, boxH / imgH);
            float drawW = imgW * scale;
            float drawH = imgH * scale;
            float offsetX = (boxW - drawW) / 2f;
            float offsetY = (boxH - drawH) / 2f;

            return new RectangleF(offsetX, offsetY, drawW, drawH);
        }

        private bool TryTranslateZoomPoint(Point controlPoint, out Point imagePoint)
        {
            RectangleF rect = GetZoomedImageRectangle();
            if (rect.Width <= 0 || rect.Height <= 0 || !rect.Contains(controlPoint))
            {
                imagePoint = Point.Empty;
                return false;
            }

            int x = (int)((controlPoint.X - rect.X) * _workingBitmap.Width / rect.Width);
            int y = (int)((controlPoint.Y - rect.Y) * _workingBitmap.Height / rect.Height);
            x = Math.Clamp(x, 0, _workingBitmap.Width - 1);
            y = Math.Clamp(y, 0, _workingBitmap.Height - 1);

            imagePoint = new Point(x, y);
            return true;
        }

        private void UpdateStatus(string? prefix = null)
        {
            string brushInfo = $"Кисть: {_brushSize:0} px, цвет {_brushColor.Name}";
            lblStatus.Text = string.IsNullOrEmpty(prefix)
                ? $"ЛКМ — рисование поверх изображения | {brushInfo} | ПКМ — меню"
                : $"{prefix} | {brushInfo}";
        }
    }
}
