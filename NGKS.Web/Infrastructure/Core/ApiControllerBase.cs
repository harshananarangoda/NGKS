using NGKS.Data.Infrastructure;
using NGKS.Data.Repositories;
using NGKS.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace NGKS.Web.Infrastructure.Core
{
    /// <summary>
    /// Class: ApiControllerBase
    /// </summary>
    public class ApiControllerBase : ApiController
    {

        /// <summary>
        /// Protected readonly properties
        /// </summary>
        protected readonly IEntityRepository<Error> _errorRepository;
        protected readonly IUnitOfWork _unitOfWork;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="errorsRepository">ErrorRepository</param>
        /// <param name="unitOfWork">UnitOfWork</param>
        public ApiControllerBase(IEntityRepository<Error> errorsRepository, IUnitOfWork unitOfWork)
        {
            this._errorRepository = errorsRepository;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Create HTTP response
        /// </summary>
        /// <param name="request">HTTP Request Message</param>
        /// <param name="function">Function</param>
        /// <returns>HTTP Responce Message</returns>
        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage request, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;

            try
            {
                response = function.Invoke();
            }
            catch (DbUpdateException ex)
            {
                LogError(ex);
                response = request.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                response = request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        /// <summary>
        /// Log Error
        /// </summary>
        /// <param name="ex">Exception</param>
        private void LogError(Exception ex)
        {
            try
            {
                Error _error = new Error()
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    DateTimeOccured = DateTime.Now
                };

                _errorRepository.Add(_error);
                _unitOfWork.Commit();
            }
            catch { }
        }
    }
}