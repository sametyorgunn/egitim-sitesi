using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ILesson_icerik_Service:IGenericService<Lesson_icerik>
    {
        List<Lesson_icerik> GetBlogListWithCategory();
    }
}
