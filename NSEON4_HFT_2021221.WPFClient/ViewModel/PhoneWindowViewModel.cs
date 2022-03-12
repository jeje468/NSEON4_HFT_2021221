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
    public class PhoneWindowViewModel : ObservableRecipient
    {
        public RestCollection<Phone> Phones { get; set; }

        private Phone selectedPhone;

        public Phone SelectedPhone
        {
            get { return selectedPhone; }
            set 
            { 
                if (value != null)
                {
                    selectedPhone = new Phone()
                    {
                        Name = value.Name,
                        Id = value.Id,
                        Price = value.Price,
                        CameraPixels = value.CameraPixels,
                        BrandId = value.BrandId,
                        Brand = value.Brand
                    };
                    OnPropertyChanged();
                    (DeletePhoneCommand as RelayCommand).NotifyCanExecuteChanged();
                    //(UpdatePhoneCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreatePhoneCommand { get; set; }
        public ICommand DeletePhoneCommand { get; set; }
        public ICommand UpdatePhoneCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public PhoneWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Phones = new RestCollection<Phone>("http://localhost:62814/", "phone", "hub");

                CreatePhoneCommand = new RelayCommand(() =>
                {
                    Phones.Add(new Phone()
                    {
                        Name = SelectedPhone.Name,
                        Price = SelectedPhone.Price,
                        CameraPixels= SelectedPhone.CameraPixels,
                        BrandId = selectedPhone.BrandId,
                        Brand = SelectedPhone.Brand
                    });
                });

                UpdatePhoneCommand = new RelayCommand(() =>
                {
                    Phones.Update(SelectedPhone);
                });

                DeletePhoneCommand = new RelayCommand(() =>
                {
                    Phones.Delete(SelectedPhone.Id);
                },
                () =>
                {
                    return SelectedPhone != null;
                });

                SelectedPhone = new Phone();
            }
        }
    }
}
