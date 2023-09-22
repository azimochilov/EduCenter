using EduCenter.Desktop.Components.Courses;
using EduCenter.Desktop.Interfaces.Courses;
using EduCenter.Desktop.Repositories.Courses;
using EduCenter.Desktop.Utils;
using EduCenter.Desktop.Windows.Courses;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EduCenter.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for CoursesPage.xaml
    /// </summary>
    public partial class CoursesPage : Page
    {
        private readonly ICourseRepository _courseRepository;
        public CoursesPage()
        {
            InitializeComponent();
            this._courseRepository = new CourseRepository();
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CourseCreateWindow courseCreateWindow = new CourseCreateWindow();
            courseCreateWindow.ShowDialog();
            await RefreshAsync();
        }

        private async Task RefreshAsync()
        {
            wrpCourses.Children.Clear();
            PaginationParams paginationParams = new PaginationParams()
            {
                PageNumber = 1,
                PageSize = 30
            };
            var courses = await _courseRepository.GetAllAsync(paginationParams);

            foreach (var course in courses)
            {
                CourseViewUserControl courseViewUserControl = new CourseViewUserControl();
                courseViewUserControl.SetData(course);
                wrpCourses.Children.Add(courseViewUserControl);
            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await RefreshAsync();
        }
    }
}
