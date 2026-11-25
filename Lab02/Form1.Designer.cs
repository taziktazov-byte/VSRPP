namespace Lab02
{
    partial class Form1
    {
        private System.ComponentModel.IContainer? components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.miNewCanvas = new System.Windows.Forms.ToolStripMenuItem();
            this.miSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miView = new System.Windows.Forms.ToolStripMenuItem();
            this.miChangeBg = new System.Windows.Forms.ToolStripMenuItem();
            this.miToggleText = new System.Windows.Forms.ToolStripMenuItem();
            this.miClearDrawing = new System.Windows.Forms.ToolStripMenuItem();
            this.miText = new System.Windows.Forms.ToolStripMenuItem();
            this.miSetText = new System.Windows.Forms.ToolStripMenuItem();
            this.miSetFont = new System.Windows.Forms.ToolStripMenuItem();
            this.miSetTextColor = new System.Windows.Forms.ToolStripMenuItem();
            this.miDraw = new System.Windows.Forms.ToolStripMenuItem();
            this.miBrushColor = new System.Windows.Forms.ToolStripMenuItem();
            this.miBrushSize = new System.Windows.Forms.ToolStripMenuItem();
            this.miBrush2 = new System.Windows.Forms.ToolStripMenuItem();
            this.miBrush5 = new System.Windows.Forms.ToolStripMenuItem();
            this.miBrush10 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxChangeBg = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxSetText = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxSetFont = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxToggleText = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxBrushColor = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxCanvas = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCanvas)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.miFile,
                this.miView,
                this.miText,
                this.miDraw
            });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(960, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "Главное меню";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.miOpen,
                this.miNewCanvas,
                this.miSaveAs,
                this.miFileSeparator,
                this.miExit
            });
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(48, 20);
            this.miFile.Text = "Файл";
            // 
            // miOpen
            // 
            this.miOpen.Name = "miOpen";
            this.miOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.miOpen.Size = new System.Drawing.Size(230, 22);
            this.miOpen.Text = "Открыть изображение...";
            this.miOpen.Click += new System.EventHandler(this.OpenImage_Click);
            // 
            // miNewCanvas
            // 
            this.miNewCanvas.Name = "miNewCanvas";
            this.miNewCanvas.Size = new System.Drawing.Size(230, 22);
            this.miNewCanvas.Text = "Новый холст";
            this.miNewCanvas.Click += new System.EventHandler(this.NewCanvas_Click);
            // 
            // miSaveAs
            // 
            this.miSaveAs.Name = "miSaveAs";
            this.miSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.miSaveAs.Size = new System.Drawing.Size(230, 22);
            this.miSaveAs.Text = "Сохранить как...";
            this.miSaveAs.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // miFileSeparator
            // 
            this.miFileSeparator.Name = "miFileSeparator";
            this.miFileSeparator.Size = new System.Drawing.Size(227, 6);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(230, 22);
            this.miExit.Text = "Выход";
            this.miExit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // miView
            // 
            this.miView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.miChangeBg,
                this.miToggleText,
                this.miClearDrawing
            });
            this.miView.Name = "miView";
            this.miView.Size = new System.Drawing.Size(39, 20);
            this.miView.Text = "Вид";
            // 
            // miChangeBg
            // 
            this.miChangeBg.Name = "miChangeBg";
            this.miChangeBg.Size = new System.Drawing.Size(220, 22);
            this.miChangeBg.Text = "Изменить фон...";
            this.miChangeBg.Click += new System.EventHandler(this.ChangeBackground_Click);
            // 
            // miToggleText
            // 
            this.miToggleText.Checked = true;
            this.miToggleText.CheckOnClick = true;
            this.miToggleText.Name = "miToggleText";
            this.miToggleText.Size = new System.Drawing.Size(220, 22);
            this.miToggleText.Text = "Показать/скрыть надпись";
            this.miToggleText.Click += new System.EventHandler(this.ToggleText_Click);
            // 
            // miClearDrawing
            // 
            this.miClearDrawing.Name = "miClearDrawing";
            this.miClearDrawing.Size = new System.Drawing.Size(220, 22);
            this.miClearDrawing.Text = "Сбросить рисунок";
            this.miClearDrawing.Click += new System.EventHandler(this.ClearDrawing_Click);
            // 
            // miText
            // 
            this.miText.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.miSetText,
                this.miSetFont,
                this.miSetTextColor
            });
            this.miText.Name = "miText";
            this.miText.Size = new System.Drawing.Size(49, 20);
            this.miText.Text = "Текст";
            // 
            // miSetText
            // 
            this.miSetText.Name = "miSetText";
            this.miSetText.Size = new System.Drawing.Size(180, 22);
            this.miSetText.Text = "Задать текст...";
            this.miSetText.Click += new System.EventHandler(this.SetText_Click);
            // 
            // miSetFont
            // 
            this.miSetFont.Name = "miSetFont";
            this.miSetFont.Size = new System.Drawing.Size(180, 22);
            this.miSetFont.Text = "Шрифт...";
            this.miSetFont.Click += new System.EventHandler(this.SetFont_Click);
            // 
            // miSetTextColor
            // 
            this.miSetTextColor.Name = "miSetTextColor";
            this.miSetTextColor.Size = new System.Drawing.Size(180, 22);
            this.miSetTextColor.Text = "Цвет текста...";
            this.miSetTextColor.Click += new System.EventHandler(this.SetTextColor_Click);
            // 
            // miDraw
            // 
            this.miDraw.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.miBrushColor,
                this.miBrushSize
            });
            this.miDraw.Name = "miDraw";
            this.miDraw.Size = new System.Drawing.Size(80, 20);
            this.miDraw.Text = "Рисование";
            // 
            // miBrushColor
            // 
            this.miBrushColor.Name = "miBrushColor";
            this.miBrushColor.Size = new System.Drawing.Size(180, 22);
            this.miBrushColor.Text = "Цвет кисти...";
            this.miBrushColor.Click += new System.EventHandler(this.BrushColor_Click);
            // 
            // miBrushSize
            // 
            this.miBrushSize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.miBrush2,
                this.miBrush5,
                this.miBrush10
            });
            this.miBrushSize.Name = "miBrushSize";
            this.miBrushSize.Size = new System.Drawing.Size(180, 22);
            this.miBrushSize.Text = "Толщина кисти";
            // 
            // miBrush2
            // 
            this.miBrush2.Name = "miBrush2";
            this.miBrush2.Size = new System.Drawing.Size(110, 22);
            this.miBrush2.Text = "2 px";
            this.miBrush2.Click += new System.EventHandler(this.BrushSize_Click);
            // 
            // miBrush5
            // 
            this.miBrush5.Checked = true;
            this.miBrush5.Name = "miBrush5";
            this.miBrush5.Size = new System.Drawing.Size(110, 22);
            this.miBrush5.Text = "5 px";
            this.miBrush5.Click += new System.EventHandler(this.BrushSize_Click);
            // 
            // miBrush10
            // 
            this.miBrush10.Name = "miBrush10";
            this.miBrush10.Size = new System.Drawing.Size(110, 22);
            this.miBrush10.Text = "10 px";
            this.miBrush10.Click += new System.EventHandler(this.BrushSize_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.ctxOpen,
                this.ctxSaveAs,
                this.ctxSep1,
                this.ctxChangeBg,
                this.ctxSetText,
                this.ctxSetFont,
                this.ctxToggleText,
                this.ctxBrushColor
            });
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(220, 164);
            // 
            // ctxOpen
            // 
            this.ctxOpen.Name = "ctxOpen";
            this.ctxOpen.Size = new System.Drawing.Size(219, 22);
            this.ctxOpen.Text = "Открыть изображение...";
            this.ctxOpen.Click += new System.EventHandler(this.OpenImage_Click);
            // 
            // ctxSaveAs
            // 
            this.ctxSaveAs.Name = "ctxSaveAs";
            this.ctxSaveAs.Size = new System.Drawing.Size(219, 22);
            this.ctxSaveAs.Text = "Сохранить как...";
            this.ctxSaveAs.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // ctxSep1
            // 
            this.ctxSep1.Name = "ctxSep1";
            this.ctxSep1.Size = new System.Drawing.Size(216, 6);
            // 
            // ctxChangeBg
            // 
            this.ctxChangeBg.Name = "ctxChangeBg";
            this.ctxChangeBg.Size = new System.Drawing.Size(219, 22);
            this.ctxChangeBg.Text = "Изменить фон...";
            this.ctxChangeBg.Click += new System.EventHandler(this.ChangeBackground_Click);
            // 
            // ctxSetText
            // 
            this.ctxSetText.Name = "ctxSetText";
            this.ctxSetText.Size = new System.Drawing.Size(219, 22);
            this.ctxSetText.Text = "Задать текст...";
            this.ctxSetText.Click += new System.EventHandler(this.SetText_Click);
            // 
            // ctxSetFont
            // 
            this.ctxSetFont.Name = "ctxSetFont";
            this.ctxSetFont.Size = new System.Drawing.Size(219, 22);
            this.ctxSetFont.Text = "Шрифт...";
            this.ctxSetFont.Click += new System.EventHandler(this.SetFont_Click);
            // 
            // ctxToggleText
            // 
            this.ctxToggleText.Name = "ctxToggleText";
            this.ctxToggleText.Size = new System.Drawing.Size(219, 22);
            this.ctxToggleText.Text = "Показать/скрыть надпись";
            this.ctxToggleText.Click += new System.EventHandler(this.ToggleText_Click);
            // 
            // ctxBrushColor
            // 
            this.ctxBrushColor.Name = "ctxBrushColor";
            this.ctxBrushColor.Size = new System.Drawing.Size(219, 22);
            this.ctxBrushColor.Text = "Цвет кисти...";
            this.ctxBrushColor.Click += new System.EventHandler(this.BrushColor_Click);
            // 
            // pictureBoxCanvas
            // 
            this.pictureBoxCanvas.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCanvas.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBoxCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxCanvas.Location = new System.Drawing.Point(0, 24);
            this.pictureBoxCanvas.Name = "pictureBoxCanvas";
            this.pictureBoxCanvas.Size = new System.Drawing.Size(960, 564);
            this.pictureBoxCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCanvas.TabIndex = 1;
            this.pictureBoxCanvas.TabStop = false;
            this.pictureBoxCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxCanvas_Paint);
            this.pictureBoxCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxCanvas_MouseDown);
            this.pictureBoxCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxCanvas_MouseMove);
            this.pictureBoxCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBoxCanvas_MouseUp);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.lblStatus
            });
            this.statusStrip1.Location = new System.Drawing.Point(0, 588);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(960, 22);
            this.statusStrip1.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(400, 17);
            this.lblStatus.Text = "Рисуйте левой кнопкой мыши поверх изображения. ПКМ — контекстное меню.";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Изображения (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp|Все файлы (*.*)|*.*";
            this.openFileDialog1.Title = "Открыть изображение";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "PNG (*.png)|*.png|JPEG (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp";
            this.saveFileDialog1.Title = "Сохранить изображение";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(235, 240, 248);
            this.ClientSize = new System.Drawing.Size(960, 610);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.pictureBoxCanvas);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабораторная работа №2 — Графический редактор";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCanvas)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip1 = null!;
        private System.Windows.Forms.ToolStripMenuItem miFile = null!;
        private System.Windows.Forms.ToolStripMenuItem miOpen = null!;
        private System.Windows.Forms.ToolStripMenuItem miNewCanvas = null!;
        private System.Windows.Forms.ToolStripMenuItem miSaveAs = null!;
        private System.Windows.Forms.ToolStripSeparator miFileSeparator = null!;
        private System.Windows.Forms.ToolStripMenuItem miExit = null!;
        private System.Windows.Forms.ToolStripMenuItem miView = null!;
        private System.Windows.Forms.ToolStripMenuItem miChangeBg = null!;
        private System.Windows.Forms.ToolStripMenuItem miToggleText = null!;
        private System.Windows.Forms.ToolStripMenuItem miClearDrawing = null!;
        private System.Windows.Forms.ToolStripMenuItem miText = null!;
        private System.Windows.Forms.ToolStripMenuItem miSetText = null!;
        private System.Windows.Forms.ToolStripMenuItem miSetFont = null!;
        private System.Windows.Forms.ToolStripMenuItem miSetTextColor = null!;
        private System.Windows.Forms.ToolStripMenuItem miDraw = null!;
        private System.Windows.Forms.ToolStripMenuItem miBrushColor = null!;
        private System.Windows.Forms.ToolStripMenuItem miBrushSize = null!;
        private System.Windows.Forms.ToolStripMenuItem miBrush2 = null!;
        private System.Windows.Forms.ToolStripMenuItem miBrush5 = null!;
        private System.Windows.Forms.ToolStripMenuItem miBrush10 = null!;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1 = null!;
        private System.Windows.Forms.ToolStripMenuItem ctxOpen = null!;
        private System.Windows.Forms.ToolStripMenuItem ctxSaveAs = null!;
        private System.Windows.Forms.ToolStripSeparator ctxSep1 = null!;
        private System.Windows.Forms.ToolStripMenuItem ctxChangeBg = null!;
        private System.Windows.Forms.ToolStripMenuItem ctxSetText = null!;
        private System.Windows.Forms.ToolStripMenuItem ctxSetFont = null!;
        private System.Windows.Forms.ToolStripMenuItem ctxToggleText = null!;
        private System.Windows.Forms.ToolStripMenuItem ctxBrushColor = null!;
        private System.Windows.Forms.PictureBox pictureBoxCanvas = null!;
        private System.Windows.Forms.StatusStrip statusStrip1 = null!;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus = null!;
        private System.Windows.Forms.OpenFileDialog openFileDialog1 = null!;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1 = null!;
        private System.Windows.Forms.ColorDialog colorDialog1 = null!;
        private System.Windows.Forms.FontDialog fontDialog1 = null!;
    }
}
