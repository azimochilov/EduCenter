using EduCenter.Desktop.Entities.Cources;
using EduCenter.Desktop.Entities.Groups;
using EduCenter.Desktop.Enums;
using EduCenter.Desktop.Helpers;
using EduCenter.Desktop.Interfaces;
using EduCenter.Desktop.Interfaces.Courses;
using EduCenter.Desktop.Interfaces.Groups;
using EduCenter.Desktop.Repositories.Courses;
using EduCenter.Desktop.Repositories.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EduCenter.Desktop.Windows.Groups
{
    /// <summary>
    /// Interaction logic for GroupCreateWindow.xaml
    /// </summary>
    public partial class GroupCreateWindow : Window
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IGroupRepository _groupRepository;
        public GroupCreateWindow()
        {
            InitializeComponent();
            this._courseRepository = new CourseRepository();
            this._groupRepository = new GroupRepository();
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var group = GetDateFromUI();
            group.Number = (short) await _groupRepository.GetLatestGroupNumberByCourseAsync(group.CourseId);
            group.Number++;
            var result = await _groupRepository.CreateAsync(group);
            if (result > 0)
            {
                MessageBox.Show("Successfully");
                this.Close();
            }
        }

        private Group GetDateFromUI()
        {
            Group group = new Group();
            group.CourseId = (long) cmbCourses.SelectedValue;
            group.Type = tbType.Text;
            group.Description = new TextRange(rbDescription.Document.ContentStart, rbDescription.Document.ContentEnd).Text;
            
            if (!String.IsNullOrEmpty(tbMaxCapacity.Text))
                group.MaxCapacity = short.Parse(tbMaxCapacity.Text);
            else group.MaxCapacity = 0;

            if (!String.IsNullOrEmpty(tbMinCapacity.Text))
                group.MinCapacity = short.Parse(tbMinCapacity.Text);
            else group.MinCapacity = 0;

            if (!String.IsNullOrEmpty(tbPrice.Text))
                group.PricePerMonth = float.Parse(tbPrice.Text);
            else group.PricePerMonth = 0;

            if (dtpStartDate.SelectedDate is not null)
                group.StartDate = DateOnly.FromDateTime(dtpStartDate.SelectedDate.Value);
            else group.StartDate = DateOnly.FromDateTime(TimeHelper.GetDateTime());

            if (dtpEndDate.SelectedDate is not null)
                group.EndDate = DateOnly.FromDateTime(dtpEndDate.SelectedDate.Value);
            else group.EndDate = DateOnly.FromDateTime(TimeHelper.GetDateTime());

            if (rbIsOnline.IsChecked!.Value) group.IsOnline = true;
            else group.IsOnline = false;

            group.CreatedAt = group.UpdatedAt = TimeHelper.GetDateTime();
            group.Status = GroupStatus.Pending;
            return group;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var courses = await _courseRepository.GetAllAsync(new Utils.PaginationParams()
            {
                PageNumber=1,
                PageSize=100
            });
            cmbCourses.ItemsSource = courses;
        }
    }
}
