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
    /// article1.xaml 的交互逻辑
    /// </summary>
    public partial class article1 : UserControl
    {
        public article1()
        {
            InitializeComponent();
        }

        public void ChangeMouse()
        {
            tbk1.MouseEnter += tbk1_MouseEnter_1;
            tbk1.MouseLeave += tbk1_MouseLeave_1;
            tbk2.MouseEnter += tbk2_MouseEnter_1;
            tbk2.MouseLeave += tbk2_MouseLeave_1;
        }

        private void tbk1_MouseEnter_1(object sender, MouseEventArgs e)
        {
            tb1.Background = Brushes.Yellow;
        }

        private void tbk1_MouseLeave_1(object sender, MouseEventArgs e)
        {
            tb1.Background = Brushes.Transparent;
        }

        private void tbk2_MouseEnter_1(object sender, MouseEventArgs e)
        {
            tb2.Background = Brushes.Yellow;
        }

        private void tbk2_MouseLeave_1(object sender, MouseEventArgs e)
        {
            tb2.Background = Brushes.Transparent;
        }
    }
}
