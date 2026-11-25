using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab02
{
    public sealed class TextPromptForm : Form
    {
        private readonly TextBox _txtInput;

        public string InputText => _txtInput.Text;

        public TextPromptForm(string initialText)
        {
            Text = "Задать текст надписи";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(380, 128);

            var lbl = new Label
            {
                Text = "Введите текст, который будет отображён поверх изображения:",
                Location = new Point(14, 14),
                AutoSize = true
            };

            _txtInput = new TextBox
            {
                Text = initialText,
                Location = new Point(14, 40),
                Size = new Size(350, 25)
            };

            var btnOk = new Button
            {
                Text = "ОК",
                DialogResult = DialogResult.OK,
                Location = new Point(204, 82),
                Size = new Size(76, 30)
            };

            var btnCancel = new Button
            {
                Text = "Отмена",
                DialogResult = DialogResult.Cancel,
                Location = new Point(288, 82),
                Size = new Size(76, 30)
            };

            AcceptButton = btnOk;
            CancelButton = btnCancel;

            Controls.Add(lbl);
            Controls.Add(_txtInput);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
        }
    }
}
