using AutoMapper;
using NGKS.Data.Infrastructure;
using NGKS.Data.Repositories;
using NGKS.Entities;
using NGKS.Web.Infrastructure.Core;
using NGKS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace NGKS.Web.Controllers
{
    /// <summary>
    /// Class: PostsController
    /// </summary>
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/posts")]
    public class PostsController : ApiControllerBase
    {
        /// <summary>
        /// Posts repository
        /// </summary>
        private readonly IEntityRepository<Post> _postRepository;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="postsRepository">posts repository</param>
        /// <param name="_errorsRepository">error Repository</param>
        /// <param name="_unitOfWork">unit of work</param>
        public PostsController(IEntityRepository<Post> postsRepository, IEntityRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork) : base(_errorsRepository, _unitOfWork)
        {
            _postRepository = postsRepository;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("latest")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var posts = _postRepository.GetAll().OrderByDescending(m => m.CreatedDate).Take(6).ToList();

                IEnumerable<PostViewModel> postsVM = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(posts);

                response = request.CreateResponse<IEnumerable<PostViewModel>>(HttpStatusCode.OK, postsVM);

                return response;
            });
        }
    }
}