using BlogProject.Business.Abstract;
using BlogProject.Core.DataAccess;
using BlogProject.DataAccess.Abstract;
using BlogProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Business.Concrete
{
    public class CommentManager : GenericManager<Comment>, ICommentService
    {
        private readonly IGenericDal<Comment> _genericDal;
        private readonly ICommentDal _commentDal;
        public CommentManager(IGenericDal<Comment> genericDal, ICommentDal commentDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _commentDal = commentDal;
        }

        public async Task<Comment> GetCommentByIdWithArticleAsync(int id)
        {
            return await _commentDal.GetCommentByIdWithArticleAsync(id);
        }

        public async Task<List<Comment>> GetCommentsWithArticleAsync()
        {
            return await _commentDal.GetCommentsWithArticleAsync();
        }
    }
}
