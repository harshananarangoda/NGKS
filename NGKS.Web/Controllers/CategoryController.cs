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
    /// Class: CategoryController
    /// </summary>
    [Authorize(Roles = "Admin")]
    [Route("api/categories")]
    public class CategoryController : ApiControllerBase
    {
        /// <summary>
        /// Category Repository
        /// </summary>
        private IEntityRepository<Category> _categoryRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="categoryRepository">Category Repository</param>
        /// <param name="_errorRepository">Error Repository</param>
        /// <param name="_unitOfWork">Unit Of work</param>
        public CategoryController(IEntityRepository<Category> categoryRepository, IEntityRepository<Error> _errorRepository, IUnitOfWork _unitOfWork) : base(_errorRepository,_unitOfWork)
        {
            this._categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Get Categories
        /// </summary>
        /// <param name="request">HTTP Request</param>
        /// <returns>Http Response Message</returns>
        [AllowAnonymous]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () => 
            {
                HttpResponseMessage response = null;
                var categories = _categoryRepository.GetAll().ToList();

                IEnumerable<CategoryViewModel> categoryVM = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);

                response = request.CreateResponse<IEnumerable<CategoryViewModel>>(HttpStatusCode.OK, categoryVM);

                return response;
            });
        }

    }
}