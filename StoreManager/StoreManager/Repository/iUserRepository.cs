using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreManager.Models;

namespace StoreManager.Repository
{
        public interface iUserRepository
        {
            Task Add(Users users);

            Task<Boolean> CheckExist(string Name);

            List<Users> GetAll();

            Boolean CheckLogin(string Name, string Password);


        }

        public class UserRepository : iUserRepository
        {
            private StoreManagerDbContext Db;

            public UserRepository(StoreManagerDbContext _Db)
            {
                this.Db = _Db;
            }

            public async Task Add(Users users)
            {
                Db.Add(users);
                await Db.SaveChangesAsync();
            }

            public async Task<bool> CheckExist(string Name)
            {
                Users temp = await Db.Users.FindAsync(Name);
                bool a = (temp != null) ? true : false;
                return a;
            }

            public bool CheckLogin(string Name, string Password)
            {
                Users temp = Db.Users.FirstOrDefault(x => x.userName == Name && x.userPassword == Password);
                if (temp != null)
                    return true;
                return false;
            }

            public List<Users> GetAll()
            {
                List<Users> temp = Db.Users.ToList();
                return temp;
            }
        }
}
