using AppWstAcademy.ClassHelper;
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
    /// Логика взаимодействия для PageEditGradeStudent.xaml
    /// </summary>
    public partial class PageEditGradeStudent : Page
    {
        private int StudentId;

        public PageEditGradeStudent(Student student)
        {
            InitializeComponent();

            TxtName.Text = student.Name;

            StudentId = student.Id;

            ListJournal.ItemsSource = OdbConnectHelper.entObj.Journal.Where(x => x.Id == student.Id).ToList();
            ListJournal.SelectedItem = 0;
            ListJournal.Columns[0].IsReadOnly = true;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            History historyObj = new History()
            {
                IdTeacher= UserControlHelp.IdUser,
                IdStudent=StudentId,
                IdStatus=2,
                DateEvent=DateTime.Now,
            };
            OdbConnectHelper.entObj.History.Add(historyObj);
            OdbConnectHelper.entObj.SaveChanges();

            OdbConnectHelper.entObj.SaveChanges();
            MessageBox.Show(
                "Данные успешно сохранены",
                "Уведомление",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );
        }
    }
}
