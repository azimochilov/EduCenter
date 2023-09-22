using EduCenter.Desktop.Components.Groups;
using EduCenter.Desktop.Interfaces.Groups;
using EduCenter.Desktop.Repositories.Groups;
using EduCenter.Desktop.Windows.Groups;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EduCenter.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for GroupsPage.xaml
    /// </summary>
    public partial class GroupsPage : Page
    {
        private readonly IGroupRepository _groupRepository;
        public GroupsPage()
        {
            InitializeComponent();
            this._groupRepository = new GroupRepository();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await RefreshAsync();
        }

        public async Task RefreshAsync()
        {
            wrpGroups.Children.Clear();
            var groups = await _groupRepository.GetAllAsync(new Utils.PaginationParams()
            {
                PageNumber=1,
                PageSize=30
            });

            foreach (var group in groups)
            {
                var groupViewUserControl = new GroupViewUserControl();
                groupViewUserControl.SetData(group);
                wrpGroups.Children.Add(groupViewUserControl);
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            GroupCreateWindow groupCreateWindow = new GroupCreateWindow();
            groupCreateWindow.ShowDialog();
        }
    }
}
