using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{
    public class EfLesson_icerikRepository : GenericRepository<Lesson_icerik>, ILesson_icerikDal
    {

        public List<Lesson_icerik> GetListWithCategory()
        {
           
            List<string> includes = new List<string>();
            includes.Add("Lesson");
            return this.GetListAll(includes);
        }
    }
}
