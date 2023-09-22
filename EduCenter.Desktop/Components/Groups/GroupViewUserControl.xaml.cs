using EduCenter.Desktop.ViewModels.Groups;
using System.Windows.Controls;

namespace EduCenter.Desktop.Components.Groups
{
    /// <summary>
    /// Interaction logic for GroupViewUserControl.xaml
    /// </summary>
    public partial class GroupViewUserControl : UserControl
    {
        public GroupViewUserControl()
        {
            InitializeComponent();
        }

        public void SetData(GroupViewModel groupViewModel)
        {
            lbName.Content = groupViewModel.Name;
            lbStudentsCount.Content = groupViewModel.CountStudents;
            lbStartDate.Content = groupViewModel.StartDate.ToString();
            lbEndDate.Content = groupViewModel.EndDate.ToString();
            lbPrice.Content = groupViewModel.PricePerMonth;
            cmpStatus.SetStatus(groupViewModel.Status.ToString());
        }
    }
}
