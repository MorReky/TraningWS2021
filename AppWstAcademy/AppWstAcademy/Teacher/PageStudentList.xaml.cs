using AppWstAcademy.DataFilesApp;
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

namespace AppWstAcademy.Teacher
{
    /// <summary>
    /// Логика взаимодействия для PageStudentList.xaml
    /// </summary>
    public partial class PageStudentList : Page
    {
        public PageStudentList()
        {
            InitializeComponent();


            CmbSelectionGroup.SelectedValuePath = "Id";
            CmbSelectionGroup.DisplayMemberPath = "Name";
            CmbSelectionGroup.ItemsSource = OdbConnectHelper.entObj.NameGroup.ToList();
            //Как реализовать пустое подменю в комбобокс?

            GridList.ItemsSource = OdbConnectHelper.entObj.Student.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        //private void BtnSearch_Click(object sender, RoutedEventArgs e)
        //{
        //    int SelectedGroup = Convert.ToInt32(CmbSelectionGroup.SelectedValue) - 1;

        //    GridList.ItemsSource = OdbConnectHelper.entObj.Student.Where(x => x.IdNameGroup == SelectedGroup).ToList();
        //    GridList.SelectedIndex = 0;

        //}
        //Не поняла. ЧТо за парамтеры которые он принимает в методе?
        //sender на конкретную кнопку?
        private void BtnProfile_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageJournalStudent((sender as Button).DataContext as Student));
        }

        private void CmbSelectionGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectedGroup = Convert.ToInt32(CmbSelectionGroup.SelectedValue);
            GridList.ItemsSource = OdbConnectHelper.entObj.Student.Where(x => x.IdNameGroup == SelectedGroup).ToList();
            GridList.SelectedIndex = 0;
        }
    }
}
