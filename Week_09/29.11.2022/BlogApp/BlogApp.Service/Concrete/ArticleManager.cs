using BlogApp.Data.Abstract;
using BlogApp.Entities.Concrete;
using BlogApp.Entities.Dtos;
using BlogApp.Service.Abstract;
using BlogApp.Shared.Utilities.Result.Abstract;
using BlogApp.Shared.Utilities.Result.ComplexTypes;
using BlogApp.Shared.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArticleManager (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName)
        {
            await _unitOfWork.Articles.AddAsync(new Article
            {
                Title=articleAddDto.Title,
                Content=articleAddDto.Content,
                Thumbnail=articleAddDto.Thumbnail,  
                Date=articleAddDto.Date,    
                SeoAuthor=articleAddDto.SeoAuthor,
                SeoDescription=articleAddDto.SeoDescription,
                SeoTags=articleAddDto.SeoTags,
                CategoryId=articleAddDto.CategoryId,
                CreatedDate = DateTime.Now,
                CreatedByName=createdByName,
                ModifiedDate = DateTime.Now,
                ModifiedByName = createdByName,
                IsDeleted = false
            }).ContinueWith(t=>_unitOfWork.SaveAsync());
            //await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, $"{articleAddDto.Title}");

        }

        public Task<IDataResult<ArticleListDto>> GetAllByNonDeleted()
        {
            var article = await _unitOfWork.Articles.GetAsync(a => a.Id == CategoryId, a => a.Id == UserId);
            if (CategoryId != null)
            {
                return new DataResult<Article>(ResultStatus.Success, article);

            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Hiç makale bulunamadı", null);

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive()
        {
            var article = await _u
        }

        public Task<IDataResult<ArticleDto>> GetArticle(int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ArticleDto>> GetArticle()
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            throw new NotImplementedException();
        }
    }

        public Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ArticleDto>> GetArticle(int articleId)
        {
            throw new NotImplementedException();
        }

       

        public Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            throw new NotImplementedException();
        }
    }
