using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NSEON4_HFT_2021221.WPFClient.ViewModel
{
    public class MainWindowViewModel
    {
        public ICommand ViewPhonesCommand { get; set; }
        public ICommand ViewBrandsCommand { get; set; }
        public ICommand ViewHeadquartersCommand { get; set; }

        public MainWindowViewModel()
        {
            ViewPhonesCommand = new RelayCommand(
                () => { PhoneWindow pw = new PhoneWindow();
                    pw.Show();
                });

            ViewBrandsCommand = new RelayCommand(
                () => {
                    BrandWindow bw = new BrandWindow();
                    bw.Show();
                });

            ViewHeadquartersCommand = new RelayCommand(
                () =>
                {
                    HeadquarterWindow hw = new HeadquarterWindow();
                    hw.Show();
                });
        }
    }
}
