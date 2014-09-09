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
    /// article4.xaml 的交互逻辑
    /// </summary>
    public partial class article4 : UserControl
    {
        public article4()
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
            tbk4.MouseEnter += tbk4_MouseEnter;
            tbk4.MouseLeave += tbk4_MouseLeave;
            tbk5.MouseEnter += tbk5_MouseEnter;
            tbk5.MouseLeave += tbk5_MouseLeave;
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
            tb9.Background = Brushes.Yellow;
            tb10.Background = Brushes.Yellow;
            tb11.Background = Brushes.Yellow;
            tb12.Background = Brushes.Yellow;
            tb13.Background = Brushes.Yellow;
            tb14.Background = Brushes.Yellow;
            tb15.Background = Brushes.Yellow;
            tb16.Background = Brushes.Yellow;
        }

        private void tbk3_MouseLeave(object sender, MouseEventArgs e)
        {
            tb6.Background = Brushes.Transparent;
            tb7.Background = Brushes.Transparent;
            tb8.Background = Brushes.Transparent;
            tb9.Background = Brushes.Transparent;
            tb10.Background = Brushes.Transparent;
            tb11.Background = Brushes.Transparent;
            tb12.Background = Brushes.Transparent;
            tb13.Background = Brushes.Transparent;
            tb14.Background = Brushes.Transparent;
            tb15.Background = Brushes.Transparent;
            tb16.Background = Brushes.Transparent;
        }

        private void tbk4_MouseEnter(object sender, MouseEventArgs e)
        {
            tb17.Background = Brushes.Yellow;
            tb18.Background = Brushes.Yellow;
            tb19.Background = Brushes.Yellow;
        }

        private void tbk4_MouseLeave(object sender, MouseEventArgs e)
        {
            tb17.Background = Brushes.Transparent;
            tb18.Background = Brushes.Transparent;
            tb19.Background = Brushes.Transparent;
        }

        private void tbk5_MouseEnter(object sender, MouseEventArgs e)
        {
            tb20.Background = Brushes.Yellow;
        }

        private void tbk5_MouseLeave(object sender, MouseEventArgs e)
        {
            tb20.Background = Brushes.Transparent;
        }
    }
}
