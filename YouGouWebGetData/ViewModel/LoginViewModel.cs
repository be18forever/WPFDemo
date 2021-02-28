using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;
using YouGouWebGetData.Common;
using YouGouWebGetData.Data;
using YouGouWebGetData.Helpers;
using YouGouWebGetData.Model;
namespace YouGouWebGetData.ViewModel
{
   public class LoginViewModel:NotifyBase
    {
        public CommandBase CloseWindowCommand { get; set; }
        public CommandBase LoginCommand { get; set; }
        public LoginModel LoginModel { get; set; } = new LoginModel();
        private string _errorMessage;

   

        private string _processVisible;

        public string ProcessVisible
        {
            get { return _processVisible; }
            set { _processVisible = value; this.DoNofity(); }
        }


        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value;this.DoNofity(); }
        }
        public LoginViewModel()
        {
            //关闭窗口方法 
            this.CloseWindowCommand = new CommandBase();
            this.CloseWindowCommand.DoExecute = new Action<object>((o) =>
              {
                  (o as MainWindow).Close();
              });
            this.CloseWindowCommand.DoCanExecute = new Func<object, bool>((o) => { return true; });
            //登录方法
            this.LoginCommand = new CommandBase();
            this.LoginCommand.DoExecute = new Action<object>(DoLogin);
            this.LoginCommand.DoCanExecute = new Func<object, bool>((o) => { return true; });
        }
        BackgroundWorker backgroundWorker;
        public MainWindow thisWindow = GlobalData.MainWindow;
        private void DoLogin(object o)
        {
            this.ErrorMessage = "";
            thisWindow = GlobalData.MainWindow;
            thisWindow.ShowProgress.Visibility = Visibility.Visible;
            //LoginModel.UserName = "602504863";
            //LoginModel.Password = "111111";
            //LoginModel.Country = "西班牙+34";

            if (string.IsNullOrEmpty( LoginModel.UserName))
            {
                this.ErrorMessage = "请输入用户名";
                thisWindow.ShowProgress.Visibility = Visibility.Collapsed;
                return;
            }
            if (string.IsNullOrEmpty(LoginModel.Password))
            {
                this.ErrorMessage = "请输入密码";
                thisWindow.ShowProgress.Visibility = Visibility.Collapsed;
                return;
            }
            if (string.IsNullOrEmpty(LoginModel.Country))
            {
                this.ErrorMessage = "请选择国家";
                thisWindow.ShowProgress.Visibility = Visibility.Collapsed;
                return;
            }

            Action action = this.YouGouGet;

            action.BeginInvoke(null, null);
        }
        private   void YouGouGet()
        {
            YouGouHelper.Test();
            thisWindow.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
             {
                 thisWindow.ShowProgress.Visibility = Visibility.Collapsed;

             });
        }
 


    }
}
