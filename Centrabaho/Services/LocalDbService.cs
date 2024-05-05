using Centrabaho.Models;
using SQLite;

namespace Centrabaho.Services
{
    public class LocalDbService
    {
        private const string DB_NAME = "Centrabaho.db3";
        private readonly SQLiteAsyncConnection _connect;

        //Connects the app to the database
        public LocalDbService()
        {
            _connect = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connect.CreateTableAsync<UserData>().Wait();
            _connect.CreateTableAsync<PostData>().Wait();
        }

        public async Task<List<PostData>> GetPosts()
        {
            return await _connect.Table<PostData>().OrderByDescending(post => post.Timestamp).ToListAsync();
        }

        //CRUD Operations:

        //Creates a user record
        public async Task Create(UserData user)
        {
            await _connect.InsertAsync(user);
        }

        //Creates a post record
        public async Task Create(PostData post)
        {
            await _connect.InsertAsync(post);
        }

        //Returns a list of users from table userdata
        public async Task<List<UserData>> GetUsers()
        {
            return await _connect.Table<UserData>().ToListAsync();
        }

        //Returns a specific user from their ID
        public async Task<UserData> GetUserById(int id)
        {
            return await _connect.Table<UserData>().Where(x => x.UserId == id).FirstOrDefaultAsync();
        }

        //Updates user record
        public async Task Update(UserData user)
        {
            await _connect.UpdateAsync(user);
        }

        //Updates post record
        public async Task Update(PostData post)
        {
            await _connect.UpdateAsync(post);
        }

        //Deletes user record
        public async Task Delete(UserData user)
        {
            await _connect.DeleteAsync(user);
        }

        //Deletes post record
        public async Task Delete(PostData post)
        {
            await _connect.DeleteAsync(post);
        }

        //Deletes all users in the database. Admin only
        public async Task DeleteAllUsers()
        {
            await _connect.DeleteAllAsync<UserData>();
        }

        //Deletes all posts in the database. Admin only
        public async Task DeleteAllPosts()
        {
            await _connect.DeleteAllAsync<PostData>();
        }

        //Authenticates Login Credentials
        public async Task<UserData> AuthenticateUser(string email, string password)
        {

            var authenticate = await _connect.Table<UserData>()
                                 .Where(user => user.Email == email && user.Password == password)
                                 .FirstOrDefaultAsync();
            if(authenticate != null)
            {
                App.CurrentUserId = authenticate.UserId;
            }
            return authenticate;
        }
    }
}
