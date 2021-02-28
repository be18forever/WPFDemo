using MaterialDesignThemes.Wpf;
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
using YouGouWebGetData.Data;
using YouGouWebGetData.ViewModel;
namespace YouGouWebGetData
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<string> list = new List<string>();
            list.Add("意大利 +39");
            list.Add("葡萄牙 +351");
            list.Add("西班牙 +34");
            list.Add("法国 +33");
            list.Add("德国 +49");
            list.Add("斯洛文尼亚 +386");
            list.Add("克罗地亚 +385");
            list.Add("匈牙利 +30");
            list.Add("波兰 +48");
            list.Add("智利 +56");
            list.Add("斯洛伐克 +421");
            list.Add("罗马尼亚 +40");
            list.Add("马其他 +356");
            this.DataContext = new LoginViewModel();
            FilledComboBox.ItemsSource = list;
            GlobalData.MainWindow = this;
        }
        private void Sample2_DialogHost_OnDialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            Console.WriteLine("SAMPLE 2: Closing dialog with parameter: " + (eventArgs.Parameter ?? ""));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Biz.MessageTips("请确认", sender, e);
        }
        private void WinMove_LeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
