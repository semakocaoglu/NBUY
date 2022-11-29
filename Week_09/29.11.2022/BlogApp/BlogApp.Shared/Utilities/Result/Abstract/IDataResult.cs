using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Shared.Utilities.Result.Abstract
{

    //out:türü ne olursa olsun döndürmeyi sağlar
    public interface IDataResult<out T> :IResult 
    {
        public T Data { get; } 
        //new DataResult<Category>(ResultStatus, category)
        //new DataResult<IList<Category>>(ResultStatus.Success, result)
    }
}
