using BlogApp.Entities.Concrete;
using BlogApp.Shared.Data.Abstract;
using BlogApp.Shared.Utilities.Result.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Entities.Dtos
{
    public class CategoryDto : DtoGetBase
    {
        public Category Category { get; set; }
        public ResultStatus resultStatus { get; set; }
    }
}
