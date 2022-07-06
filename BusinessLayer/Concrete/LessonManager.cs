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
    public class LessonManager : ILessonService
    {
        ILessonDal _lessonDal;

        public LessonManager(ILessonDal lessonDal)
        {
            _lessonDal = lessonDal;
        }

        public List<Lesson> GetList()
        {
            return _lessonDal.GetListAll();
        }

        public void TAdd(Lesson t)
        {
            _lessonDal.Insert(t);
        }

        public void TDelete(Lesson t)
        {
            _lessonDal.Delete(t);
        }

        public Lesson TGetById(int id)
        {
            return _lessonDal.GetById(id);
        }

        public void TUpdate(Lesson t)
        {
            _lessonDal.Update(t);
        }
    }
}
