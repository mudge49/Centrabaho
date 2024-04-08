using System.ComponentModel;
using System.Windows.Input;

namespace Centrabaho.ViewModels;

public class LoginViewModel : INotifyPropertyChanged
{
    private LoginRequestModel myLoginRequestModel = new LoginRequestModel();
    public LoginRequestModel MyLoginRequestModel
    {
        get { return myLoginRequestModel;}
        set { 
            myLoginRequestModel = value;

            OnPropertyChanged(nameof(MyLoginRequestModel));
        }
    }

    public ICommand LoginCommand {get;}

    public LoginViewModel()
    {
        LoginCommand = new Command(PerformLoginOperation);



    }

    private async void PerformLoginOperation(object obj)
    {
        //DB Operation

        var data = MyLoginRequestModel;
        

    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
