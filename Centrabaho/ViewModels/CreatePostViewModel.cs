using Centrabaho.Models;
using Centrabaho.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Centrabaho.ViewModels
{
    public class CreatePostViewModel : BindableObject
    {
        private string _title;
        private string _description;
        private int _payamount;

        public ObservableCollection<string> ImageUrls { get; set; } = new ObservableCollection<string>();

        public string Title
        {
            get
            {
                return _title;
            }
                
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public int PayAmount
        {
            get
            {
                return _payamount;
            }

            set
            {
                _payamount = value;
                OnPropertyChanged();
            }
        }

        public ICommand CreatePostCommand { get; }
        public ICommand SignOutCommand { get; }
        public ICommand AddImageCommand { get; }

        public CreatePostViewModel()
        {
            CreatePostCommand = new Command(OnCreatePost);
            SignOutCommand = new Command(async () => await OnLogout());
            AddImageCommand = new Command(async () => await AddImage());
        }

        //Saves the post to database
        private async void OnCreatePost()
        {
            var newPost = new PostData
            {
                UserId = App.CurrentUserId,
                Title = Title,
                Description = Description,
                Timestamp = DateTime.UtcNow,
                PayAmount = PayAmount,
                ImagePaths = ImageUrls.ToList()
            };
            var dbService = new LocalDbService();
            dbService.Create(newPost);
        }

        private async Task OnLogout()
        {
            App.CurrentUserId = 0;
            await Shell.Current.GoToAsync("//loginpage"); // Adjust the route based on your routing setup
        }

        private async Task AddImage()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Select an Image"
            });

            if (result != null)
            {
                ImageUrls.Add(result.FullPath);
            }
        }
    }
}
