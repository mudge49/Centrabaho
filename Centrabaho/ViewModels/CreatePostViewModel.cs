using Centrabaho.Models;
using Centrabaho.Services;
using System;
using System.Collections.Generic;
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

        public ICommand CreatePostCommand { get; }

        public CreatePostViewModel()
        {
            CreatePostCommand = new Command(OnCreatePost);
        }

        //Saves the post to database
        private async void OnCreatePost()
        {
            await new LocalDbService().Create(new PostData
            {
                UserId = App.CurrentUserId,
                Title = Title,
                Description = Description,
                Timestamp = DateTime.UtcNow
            });
        }
    }
}
