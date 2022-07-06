using BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userdal;

        public UserManager(IUserDal userdal)
        {
            _userdal = userdal;
        }

        public List<AppUser> GetList()
        {
            return _userdal.GetListAll();
        }

        public List<AppUser> GetListJoinSinif()
        {
            List<string> includes = new List<string>();
            includes.Add("Siniflar");
            return _userdal.GetListAll(includes);
        }

        public void TAdd(AppUser t)
        {
            _userdal.Insert(t);
        }

        public void TDelete(AppUser t)
        {
            _userdal.Delete(t);
        }

        public AppUser TGetById(int id)
        {
            return _userdal.GetById(id);
        }

        public void TUpdate(AppUser t)
        {
            _userdal.Update(t);
        }
    }
}
