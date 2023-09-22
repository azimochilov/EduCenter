using EduCenter.Desktop.Entities.Cources;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace EduCenter.Desktop.Components.Courses
{
    /// <summary>
    /// Interaction logic for CourseViewUserControl.xaml
    /// </summary>
    public partial class CourseViewUserControl : UserControl
    {
        public long Id { get; private set; }
        public CourseViewUserControl()
        {
            InitializeComponent();
        }

        public void SetData(Course course)
        {
            Id = course.Id;
            ImgB.ImageSource = new BitmapImage(new System.Uri(course.ImagePath, UriKind.Relative));
            lbName.Content = course.Name;
            tbDescription.Text = course.Description;
        }

        private void grMain_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show(Id.ToString());
        }
    }
}
