using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using NSEON4_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NSEON4_HFT_2021221.WPFClient.ViewModel
{
    public class HeadquarterWindowViewModel : ObservableRecipient
    {
        public RestCollection<Headquarter> Headquarters { get; set; }

        private Headquarter selectedHeadquarter;

        public Headquarter SelectedHeadquarter
        {
            get { return selectedHeadquarter; }
            set 
            { 
                if (value != null)
                {
                    selectedHeadquarter = new Headquarter()
                    {
                        Id = value.Id,
                        City = value.City,
                        BrandId = value.BrandId,
                        CountryId = value.CountryId,
                        Brand = value.Brand,
                        Country = value.Country
                    };
                    OnPropertyChanged();
                    (DeleteHeadquarterCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateHeadquarterCommand { get; set; }
        public ICommand DeleteHeadquarterCommand { get; set; }
        public ICommand UpdateHeadquarterCommand { get; set; }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public HeadquarterWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Headquarters = new RestCollection<Headquarter>("http://localhost:62814/", "headquarter", "hub");

                CreateHeadquarterCommand = new RelayCommand(() =>
                {
                    Headquarters.Add(new Headquarter()
                    {
                        City = selectedHeadquarter.City,
                        BrandId = selectedHeadquarter.BrandId,
                        CountryId = SelectedHeadquarter.CountryId,
                        Brand = selectedHeadquarter.Brand,
                        Country = selectedHeadquarter.Country
                    });
                });

                UpdateHeadquarterCommand = new RelayCommand(() =>
                {
                    Headquarters.Update(SelectedHeadquarter);
                });

                DeleteHeadquarterCommand = new RelayCommand(() =>
                {
                    Headquarters.Delete(SelectedHeadquarter.Id);
                },
                () =>
                {
                    return SelectedHeadquarter != null;
                });

                SelectedHeadquarter = new Headquarter();

            }
        }
    }
}
