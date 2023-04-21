using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Code
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        CultureInfo culture = new CultureInfo("en-US");
        //TextBox chỉ cho phép nhập số từ 0-9
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        //TextBox chỉ cho phép nhập số từ 0-9
        private void TextBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        //TextBox chỉ cho phép nhập số từ 0-9
        private void TextBox_PreviewTextInput_2(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rdbResident.IsChecked==true)
            {
                rdbNotResident.IsEnabled = false;
                txblResult.Text = TinhThueTNCNCuTru().ToString("c",culture);
            }
            else
            {
                rdbResident.IsEnabled = false;
                txtIncomeNotTax.IsEnabled = false;
                txtNumberOfDependentPeople.IsEnabled = false;
                txblResult.Text = TinhThueTNCNKhongCuTru().ToString("c", culture);
            }
        }
        #region Cư trú
        public double TinhThuNhapChiuThueTNCN()
        {
            return Int32.Parse(txtIncome.Text) - Int32.Parse(txtIncomeNotTax.Text);
        }
        public double TinhCacKhoanGiamTru()
        {
            return 11 + (4.4 * Int32.Parse(txtNumberOfDependentPeople.Text)) + TinhThuNhapChiuThueTNCN() *0.08;
        }
        public double TinhThuNhapTinhThueTNCN()
        {
            return TinhThuNhapChiuThueTNCN() - TinhCacKhoanGiamTru();
        }
        public double TinhThueTNCNCuTru()
        {
            if(TinhThuNhapTinhThueTNCN()>=1000000||TinhThuNhapTinhThueTNCN()<=5000000)
            {
                return TinhThuNhapTinhThueTNCN() * 0.05;
            }
            else if(TinhThuNhapTinhThueTNCN()>5000000||TinhThuNhapTinhThueTNCN()<=10000000)
            {
                return TinhThuNhapTinhThueTNCN() * (0.1-0.25);
            }
            else if (TinhThuNhapTinhThueTNCN() > 10000000 || TinhThuNhapTinhThueTNCN() <= 18000000)
            {
                return TinhThuNhapTinhThueTNCN() * (0.15-0.75);
            }
            else if (TinhThuNhapTinhThueTNCN() > 18000000 || TinhThuNhapTinhThueTNCN() <= 32000000)
            {
                return TinhThuNhapTinhThueTNCN() * (0.2-1.65);
            }
            else if (TinhThuNhapTinhThueTNCN() > 32000000 || TinhThuNhapTinhThueTNCN() <= 52000000)
            {
                return TinhThuNhapTinhThueTNCN() * (0.25 - 3.25);
            }
            else if (TinhThuNhapTinhThueTNCN() > 52000000 || TinhThuNhapTinhThueTNCN() <= 80000000)
            {
                return TinhThuNhapTinhThueTNCN() * (0.3 - 5.85);
            }
            else
            {
                return TinhThuNhapTinhThueTNCN() * (0.35 - 9.85);
            }
        }
        #endregion
        #region Không cư trú
        public double TinhThueTNCNKhongCuTru()
        {
            return 0.2 * Int32.Parse(txtIncome.Text);
        }
        #endregion
        private void TextBox_PreviewTextInput_3(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtThuNhapGiam_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
