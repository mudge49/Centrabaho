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
            _connect.CreateTableAsync<UserData>();
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

        //CRUD Operations:
        //Creates a user record
        public async Task Create(UserData user)
        {
            await _connect.InsertAsync(user);
        }

        public async Task Update(UserData user)
        {
            await _connect.UpdateAsync(user);
        }

        public async Task Delete(UserData user)
        {
            await _connect.DeleteAsync(user);
        }

        //Authenticates Login Credentials
        public async Task<UserData> AuthenticateUser(string email, string password)
        {
            return await _connect.Table<UserData>()
                                 .Where(user => user.Email == email && user.Password == password)
                                 .FirstOrDefaultAsync();
        }
    }
}
