using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface ILesson_icerikDal:IGenericDal<Lesson_icerik>
    {
        List<Lesson_icerik> GetListWithCategory();
    }
}
