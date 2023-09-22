using System.Windows.Controls;
using System.Windows.Media;

namespace EduCenter.Desktop.Components
{
    /// <summary>
    /// Interaction logic for StatusUserControl.xaml
    /// </summary>
    public partial class StatusUserControl : UserControl
    {
        public StatusUserControl()
        {
            InitializeComponent();
        }

        public void SetStatus(string status)
        {
            tbTitle.Content = status;
            if(status == "Pending")
            {
                string color = "#E7B27E";
                brBackground.Background = (SolidColorBrush) new BrushConverter().ConvertFromString(color);
            }
            else if(status == "Started")
            {
                string color = "#48B56D";
                brBackground.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(color);
            }
            else if(status == "Stopped")
            {
                string color = "#CA4339";
                brBackground.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(color);
            }
            else if(status == "Graduated")
            {
                string color = "#9457EB";
                brBackground.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(color);
            }
        }
    }
}
