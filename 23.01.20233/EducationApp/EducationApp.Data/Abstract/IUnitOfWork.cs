using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Data.Abstract
{
    public interface IUnitOfWork :IDisposable
    {
        IStudentRepository Students { get; }
        ICategoryRepository Categories { get; } 
        ITeacherRepository Teachers { get; }
        Task SaveAsync();

    }
}
