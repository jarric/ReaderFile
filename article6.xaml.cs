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

namespace ReaderFile
{
    /// <summary>
    /// article6.xaml 的交互逻辑
    /// </summary>
    public partial class article6 : UserControl
    {
        public article6()
        {
            InitializeComponent();
        }

        public void ChangeMouse()
        {
            tbk1.MouseEnter += tbk1_MouseEnter;
            tbk1.MouseLeave += tbk1_MouseLeave;
            tbk2.MouseEnter += tbk2_MouseEnter;
            tbk2.MouseLeave += tbk2_MouseLeave;
            tbk3.MouseEnter += tbk3_MouseEnter;
            tbk3.MouseLeave += tbk3_MouseLeave;
        }

        private void tbk1_MouseEnter(object sender, MouseEventArgs e)
        {
            tb1.Background = Brushes.Yellow;
            tb2.Background = Brushes.Yellow;
        }

        private void tbk1_MouseLeave(object sender, MouseEventArgs e)
        {
            tb1.Background = Brushes.Transparent;
            tb2.Background = Brushes.Transparent;
        }

        private void tbk2_MouseEnter(object sender, MouseEventArgs e)
        {
            tb3.Background = Brushes.Yellow;
            tb4.Background = Brushes.Yellow;
            tb5.Background = Brushes.Yellow;
        }

        private void tbk2_MouseLeave(object sender, MouseEventArgs e)
        {
            tb3.Background = Brushes.Transparent;
            tb4.Background = Brushes.Transparent;
            tb5.Background = Brushes.Transparent;
        }

        private void tbk3_MouseEnter(object sender, MouseEventArgs e)
        {
            tb6.Background = Brushes.Yellow;
            tb7.Background = Brushes.Yellow;
            tb8.Background = Brushes.Yellow;
        }

        private void tbk3_MouseLeave(object sender, MouseEventArgs e)
        {
            tb6.Background = Brushes.Transparent;
            tb7.Background = Brushes.Transparent;
            tb8.Background = Brushes.Transparent;
        }
    }
}
