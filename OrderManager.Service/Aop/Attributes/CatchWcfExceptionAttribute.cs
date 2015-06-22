using Aspect;
using OrderManager.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Service.Aop
{
    public class CatchWcfExceptionAttribute : ExceptionAttribute
    {

        public override Exception HandlerException(Microsoft.Practices.Unity.InterceptionExtension.IMethodInvocation input, Exception exception)
        {

            if (exception is WebFaultException<ExceptionDetail>)
                throw exception;

            if (!(exception is GenericException))
                exception = new GenericException(exception);

            ExceptionDetail detail = new ExceptionDetail(exception);


            var result = new WebFaultException<ExceptionDetail>(detail, HttpStatusCode.BadRequest);
            throw result;
        }


    }
}
