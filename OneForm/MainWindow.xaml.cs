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

namespace OneForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Data data = new Data();
        public MainWindow()
        {
            InitializeComponent();
            foreach (string str in data.workshops.Keys) cbCity.Items.Add(str);
            cbCity.SelectedIndex = 0;
        }

        private void changeCBList(ComboBox cb, string key, Dictionary<String, String[]> dict)
        {
            cb.Items.Clear();
            if (!dict.ContainsKey(key)) return;
            foreach(string str in dict[key]) cb.Items.Add(str);
            cb.SelectedIndex = 0;
        }

        private void cbCity_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string key = cbCity.SelectedItem.ToString();
            changeCBList(cbWorkshop, key, data.workshops);
        }

        private void cbWorkshop_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (cbWorkshop.SelectedItem == null) return;
            string key = cbCity.SelectedItem.ToString() + ". " + cbWorkshop.SelectedItem.ToString();
            changeCBList(cbWorker, key, data.workers);
        }

        private void bAccept_Click(object sender, RoutedEventArgs e)
        {
            // Если что-то было не заполнено
            if (cbCity.SelectedItem == null) { MessageBox.Show("Город не выбран."); return; }
            if (cbWorkshop == null) { MessageBox.Show("Цех не выбран."); return; }
            if (cbWorker == null) { MessageBox.Show("Сотрудник не выбран."); return; }
            if (rbBrigadeOne.IsChecked.Value == rbBrigadeTwo.IsChecked.Value) { MessageBox.Show("Бригада не выбрана."); return; }
            if (rbShiftOne.IsChecked.Value == rbShiftTwo.IsChecked.Value) { MessageBox.Show("Смена не выбрана."); return; }

            String city = cbCity.SelectedItem.ToString();
            String workshop = cbWorkshop.SelectedItem.ToString();
            String worker = cbWorker.SelectedItem.ToString();
            int brigade = rbBrigadeOne.IsChecked.Value ? 1 : 2;
            int shift = rbShiftOne.IsChecked.Value ? 1 : 2;

            WorkerTime wt = new WorkerTime(city, workshop, worker, brigade, shift);
            Utility.saveJSON(wt, "form.json");
            MessageBox.Show("Файл form.json создан.");
        }
    }
}
