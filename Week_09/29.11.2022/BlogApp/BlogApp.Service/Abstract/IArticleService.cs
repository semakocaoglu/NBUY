using BlogApp.Entities.Concrete;
using BlogApp.Entities.Dtos;
using BlogApp.Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Abstract
{
    public interface IArticleService
    {
        //Get, GetAll, Add, Delete, Update, HardDelete, GetAllByNonDeleted, GetAllByNonDeletedAndActive, GetAllByCategory(categoryId)

        Task<IDataResult<ArticleDto>> GetArticle(int articleId);
        Task<IDataResult<ArticleDto>> GetArticle();

        Task<IDataResult<ArticleListDto>> GetAllByNonDeleted();
        Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive();
        Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName);
        Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName);
    }
}
