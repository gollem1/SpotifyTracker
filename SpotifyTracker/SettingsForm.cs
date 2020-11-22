using SpotifySongTracker.Properties;
using SpotifySongTracker.Writers;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SpotifySongTracker
{
    public partial class SettingsForm : Form
    {
        private static readonly Regex OnlyNumbersRegex = new Regex("[^0-9]*");

        public ISongWriter SongWriter { get; private set; }

        private string OutputTypeSetting = Properties.Settings.Default.OutputType;
        private Font FontSetting = Properties.Settings.Default.Font;
        private Color TextColorSetting = Properties.Settings.Default.TextColor;
        private Color TextBackgroundSetting = Properties.Settings.Default.TextBackground;
        private Color TextOutlineSetting = Properties.Settings.Default.TextOutline;
        private int MaxSizeSetting = Properties.Settings.Default.MaxSize;

        private ToolTip HoverToolTip = new ToolTip();

        public SettingsForm()
        {
            InitializeComponent();
            this.BackgroundColorBox.BackColor = TextBackgroundSetting;
            this.OutlineColorBox.BackColor = TextOutlineSetting;
            this.FontButton.Text = FontSetting.FontFamily.Name;
            this.MaxSizeTextBox.Text = MaxSizeSetting.ToString();

            this.OutputTypeComboBox.Items.Clear();
            this.OutputTypeComboBox.Items.AddRange(new[] { "TXT", "PNG", "GIF" });
            switch (this.OutputTypeSetting)
            {
                case "TXT":
                    this.OutputTypeComboBox.SelectedIndex = 0;
                    break;
                case "PNG":
                    this.OutputTypeComboBox.SelectedIndex = 1;
                    break;
                case "GIF":
                    this.OutputTypeComboBox.SelectedIndex = 2;
                    break;
                default:
                    break;
            }
        }

        private void OutputType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.OutputTypeSetting = (string)((ComboBox)sender).SelectedItem;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            switch (this.OutputTypeSetting)
            {
                case "TXT":
                    SongWriter = new TextSongWriter();
                    break;
                case "GIF":
                    SongWriter = new GifSongWriter();
                    break;
                case "PNG":
                    SongWriter = new PngSongWriter();
                    break;
                default:
                    throw new NotImplementedException();
            }
            Settings.Default.Font = FontSetting;
            Settings.Default.TextColor = TextColorSetting;
            Settings.Default.TextBackground = TextBackgroundSetting;
            Settings.Default.TextOutline = TextOutlineSetting;
            Settings.Default.MaxSize = MaxSizeSetting;
            Settings.Default.OutputType = OutputTypeSetting;
            Settings.Default.Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FontButton_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog
            {
                ShowColor = true,
                ShowEffects = true,
                Font = FontSetting,
                Color = TextColorSetting
            };

            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                FontSetting = fontDialog.Font;
                TextColorSetting = fontDialog.Color;
            }
            this.FontButton.Text = FontSetting.FontFamily.Name;
        }

        private void BackgroundColorBox_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog
            {
                Color = Settings.Default.TextOutline,
                AllowFullOpen = true,
                AnyColor = true,
            };

            if (cd.ShowDialog() != DialogResult.Cancel)
            {
                TextBackgroundSetting = this.BackgroundColorBox.BackColor = cd.Color;
            }
        }

        private void BackgroundTransparentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = ((CheckBox)sender).Checked;
            if (isChecked)
            {
                TextBackgroundSetting = this.BackgroundColorBox.BackColor = Color.Transparent;
            }
            else
            {
                TextBackgroundSetting = this.BackgroundColorBox.BackColor = Properties.Settings.Default.TextBackground;
            }
        }

        private void OutlineColorBox_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog
            {
                Color = Settings.Default.TextOutline,
                AllowFullOpen = true,
                AnyColor = true,
            };

            if (cd.ShowDialog() != DialogResult.Cancel)
            {
                TextOutlineSetting = this.OutlineColorBox.BackColor = cd.Color;
            }
        }

        private void OutlineTransparentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = ((CheckBox)sender).Checked;
            if (isChecked)
            {
                TextOutlineSetting = this.OutlineColorBox.BackColor = Color.Transparent;
            }
            else
            {
                TextOutlineSetting = this.OutlineColorBox.BackColor = Properties.Settings.Default.TextBackground;
            }
        }

        private void MaxSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox maxSizeTextBox = (TextBox)sender;
            if (OnlyNumbersRegex.IsMatch(maxSizeTextBox.Text))
            {
                maxSizeTextBox.Text = OnlyNumbersRegex.Replace(maxSizeTextBox.Text, "");
            }

            try
            {
                if (int.TryParse(maxSizeTextBox.Text, out int i))
                {
                    MaxSizeSetting = i;
                }
            }
            catch { }
        }

        private void FontButton_MouseEnter(object sender, EventArgs e)
        {
            this.HoverToolTip.Show($"{FontSetting.Name} {FontSetting.SizeInPoints}{(FontSetting.Bold ? ", Bold" : "")}{(FontSetting.Italic ? ", Italic" : "")}{(FontSetting.Underline ? ", Underline" : "")}, {(TextColorSetting.IsNamedColor ? TextColorSetting.Name : Convert.ToString(TextColorSetting.ToArgb(), 16))}", (IWin32Window)sender);
        }

        private void FontButton_MouseLeave(object sender, EventArgs e)
        {
            this.HoverToolTip.Hide((IWin32Window)sender);
        }
    }
}
