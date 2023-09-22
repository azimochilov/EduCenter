using EduCenter.Desktop.Constants;
using EduCenter.Desktop.Entities.Cources;
using EduCenter.Desktop.Helpers;
using EduCenter.Desktop.Interfaces.Courses;
using EduCenter.Desktop.Repositories.Courses;
using Microsoft.Win32;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

namespace EduCenter.Desktop.Windows.Courses
{
    /// <summary>
    /// Interaction logic for CourseCreateWindow.xaml
    /// </summary>
    public partial class CourseCreateWindow : Window
    {
        private readonly ICourseRepository _courseRepository;
        public CourseCreateWindow()
        {
            InitializeComponent();
            this._courseRepository = new CourseRepository();
        }

        private void btnImageSelector_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = GetImageDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string imgPath = openFileDialog.FileName;
                ImgBImage.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
            }
        }

        private OpenFileDialog GetImageDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";
            return openFileDialog;
        }

        private void btnThumbSelector_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = GetImageDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string imgPath = openFileDialog.FileName;
                ImgBThumb.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
            }
        }

        private void btnVideoSelector_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Mp4 Files (*.mp4)|*.mp4|Avi Files (*.avi)|*.avi|Mkv Files (*.mkv)|*.mkv";
            if (openFileDialog.ShowDialog() == true)
            {
                string videoPath = openFileDialog.FileName;
                MdCourseVideo.Source = new Uri(videoPath, UriKind.Relative);
                MdCourseVideo.Play();
            }
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Course course = new Course();
            course.Name = tbName.Text;

            string imagepath = ImgBImage.ImageSource.ToString();
            if (!String.IsNullOrEmpty(imagepath)) 
                course.ImagePath = await CopyImageAsync(imagepath, 
                    ContentConstants.IMAGE_CONTENTS_PATH);
            
            course.Description = new TextRange(rbDescription.Document.ContentStart, rbDescription.Document.ContentEnd).Text;

            string thumbpath = ImgBThumb.ImageSource.ToString();
            if(String.IsNullOrEmpty(thumbpath))
                course.IntroVideoThumb = await CopyImageAsync(thumbpath, 
                    ContentConstants.THUMB_CONTENTS_PATH);

            course.CreatedAt = course.UpdatedAt = TimeHelper.GetDateTime();
            
            var result = await _courseRepository.CreateAsync(course);
            if (result > 0)
            {
                MessageBox.Show("Muvaffaqqiyatli saqlandi");
                this.Close();
            }
        }

        private async Task<string> CopyImageAsync(string imgPath, string destinationDirectory)
        {
            if (!Directory.Exists(destinationDirectory))
                Directory.CreateDirectory(destinationDirectory);

            var imageName = ContentNameMaker.GetImageName(imgPath);

            string path = System.IO.Path.Combine(destinationDirectory, imageName);

            byte[] image = await File.ReadAllBytesAsync(imgPath);

            await File.WriteAllBytesAsync(path, image);

            return path;
        }
    }
}
