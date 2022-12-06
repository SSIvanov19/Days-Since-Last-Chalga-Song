using DSLCS.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DSLCS.App.ViewModels;

public class ViewModel : INotifyPropertyChanged {
    public List<VideoVM> Data { get; set; }
    
    public ViewModel() {
        Data = new List<VideoVM>()
        {
            new VideoVM
            {
                title = "Test"

            }
        };
    }

    public event PropertyChangedEventHandler PropertyChanged;
    
    private void OnPropertyChanged([CallerMemberName] string propertyName = "") {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
