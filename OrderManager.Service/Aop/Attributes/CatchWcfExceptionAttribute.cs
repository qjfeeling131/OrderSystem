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
            {

                string note = FormmatException(exception.StackTrace,exception.Message);
                ExceptionLog.Write(note);
                throw exception;
            }
            if (!(exception is GenericException))
            {
                exception = new GenericException(exception);
                string notepad = FormmatException(exception.StackTrace, exception.Message);
                ExceptionLog.Write(notepad);
            }
            ExceptionDetail detail = new ExceptionDetail(exception);

            var result = new WebFaultException<ExceptionDetail>(detail, HttpStatusCode.BadRequest);

            throw result;
        }

        private string FormmatException(string StackTrace, string Message)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("------------------【{0}】------------------", DateTime.Now));
            sb.Append("\r\n");
            //sb.Append("【Source】：" + Source); sb.Append("\r\n");
            sb.Append("【Message】：" + Message); sb.Append("\r\n");
            sb.Append("【StackTrace】：" + StackTrace); sb.Append("\r\n");
            return sb.ToString();
        }

    }


}
