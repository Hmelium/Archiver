using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace Archiver
{

    public partial class MainWindow : Window
    {

        private System.Windows.Forms.NotifyIcon m_notifyIcon;
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Minimized;

            m_notifyIcon = new System.Windows.Forms.NotifyIcon();
            m_notifyIcon.BalloonTipTitle = "Архиватор ";
            m_notifyIcon.BalloonTipText = "Архиватор работает в фоновом режиме";

            m_notifyIcon.Text = "Архиватор в трее";
            m_notifyIcon.Icon = new System.Drawing.Icon(@"c:\quicktime.ico");
            m_notifyIcon.Click += new EventHandler(m_notifyIcon_Click);
        }
        private WindowState m_storedWindowState = WindowState.Normal;

        void OnStateChanged(object sender, EventArgs args)
        {
            if (WindowState == WindowState.Minimized)
            {
                Hide();
                if (m_notifyIcon != null)
                    m_notifyIcon.ShowBalloonTip(2000);
            }
            else
                m_storedWindowState = WindowState;
        }
        void OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            CheckTrayIcon();
        }
        void m_notifyIcon_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = m_storedWindowState;
        }
        void CheckTrayIcon()
        {
            ShowTrayIcon(!IsVisible);
        }
        void ShowTrayIcon(bool show)
        {
            if (m_notifyIcon != null)
                m_notifyIcon.Visible = show;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            m_notifyIcon.Dispose();
            m_notifyIcon = null;
        }
        private void ZippingButton_Click(object sender, RoutedEventArgs e)
        {
            ZippingWindow zipping = new ZippingWindow();
            zipping.Show();
            Close();
        }

        private void UnzippingButton_Click(object sender, RoutedEventArgs e)
        {
            UnzippingWindow unzipping = new UnzippingWindow();
            unzipping.Show();
            Close();
        }
    }
}
