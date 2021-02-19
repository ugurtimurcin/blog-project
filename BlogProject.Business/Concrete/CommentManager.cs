using BlogProject.Business.Abstract;
using BlogProject.Core.DataAccess;
using BlogProject.Core.Utilities.Results.Abstract;
using BlogProject.Core.Utilities.Results.Concrete;
using BlogProject.DataAccess.Abstract;
using BlogProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public async Task<IResult> AddAsync(Comment entity)
        {
            await _commentDal.AddAsync(entity);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Comment entity)
        {
            await _commentDal.DeleteAsync(entity);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<Comment>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Comment>>(await _commentDal.GetAllAsync());
        }

        public async Task<IDataResult<Comment>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<Comment>(await _commentDal.GetByIdAsync(id));
        }

        public async Task<IDataResult<Comment>> GetCommentByIdWithArticleAsync(int id)
        {
            return new SuccessDataResult<Comment>(await _commentDal.GetCommentByIdWithArticleAsync(id));
        }

        public async Task<IDataResult<List<Comment>>> GetCommentsWithArticleAsync()
        {
            return new SuccessDataResult<List<Comment>>(await _commentDal.GetCommentsWithArticleAsync());
        }

        public async Task<IResult> UpdateAsync(Comment entity)
        {
            await _commentDal.UpdateAsync(entity);
            return new SuccessResult();
        }
    }
}
