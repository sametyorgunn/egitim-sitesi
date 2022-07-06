using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class Lesson_icerik_Manager : ILesson_icerik_Service
    {
        ILesson_icerikDal _İcerikDal;

        public Lesson_icerik_Manager(ILesson_icerikDal icerikDal)
        {
            _İcerikDal = icerikDal;
        }

        public List<Lesson_icerik> GetBlogListWithCategory()
        {
            return _İcerikDal.GetListWithCategory();
        }

        public List<Lesson_icerik> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Lesson_icerik t)
        {
            _İcerikDal.Insert(t);
        }

        public void TDelete(Lesson_icerik t)
        {
            _İcerikDal.Delete(t);
        }

        public Lesson_icerik TGetById(int id)
        {
            return _İcerikDal.GetById(id);
        }

        public void TUpdate(Lesson_icerik t)
        {
            _İcerikDal.Update(t);
        }
    }
}
