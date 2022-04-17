using System.Windows;
using System.Windows.Controls;

namespace Lab2.Tools.Controls
{
    public partial class LabeledTextBox : UserControl
    {
        public string Caption
        {
            get
            {
                return LabelCaption.Content.ToString();
            }
            set
            {
                LabelCaption.Content = value;
            }
        }

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register
        (
            "Text",
            typeof(string),
            typeof(LabeledTextBox),
            new PropertyMetadata(null)
        );

        public LabeledTextBox()
        {
            InitializeComponent();
        }
    }
}