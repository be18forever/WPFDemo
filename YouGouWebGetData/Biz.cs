using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace YouGouWebGetData
{
   public static class Biz
    {
        public static async void MessageTips(string message, object sender, RoutedEventArgs e)
        {
            var sampleMessageDialog = new Note
            {
                Message = { Text = message }
            };
            await DialogHost.Show(sampleMessageDialog, "RootDialog");
        }
    }
}
