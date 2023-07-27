using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventory.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        string title;

        [ObservableProperty]
        [NotifyPropertyChangedFor (nameof(IsNotLoading))]
        bool isLoading; 
        public bool IsNotLoading => !isLoading;
    }

    //public class BaseViewModel : INotifyPropertyChanged
    //{
    //    string _title;
    //    bool _isBusy;

    //    public bool IsBusy
    //    {
    //        get => _isBusy;
    //        set
    //        {
    //            if (_isBusy == value)
    //                return;
    //            _isBusy = value;
    //            OnPropertyChanged();
    //        }
    //    }

    //    public string IsTitle
    //    {
    //        get => _title;
    //        set
    //        {
    //            if (_title == value)
    //                return;
    //            _title = value;
    //            OnPropertyChanged();
    //        }
    //    }
    //    public event PropertyChangedEventHandler PropertyChanged;

    //    public void OnPropertyChanged([CallerMemberName] string name = null)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    //    }
    //}
}
