using Aspect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Service.Aop
{
    public class InitAttribute :InitializationAttribute
    {

        public override void OnInit(Microsoft.Practices.Unity.InterceptionExtension.IMethodInvocation input)
        {
            Console.WriteLine("OnInit");
        }

        public override void OnRelease(Microsoft.Practices.Unity.InterceptionExtension.IMethodInvocation input)
        {
            Console.WriteLine("OnRelease");
        }

        public override Exception OnException(Microsoft.Practices.Unity.InterceptionExtension.IMethodInvocation input, Exception ex)
        {
            throw ex;
        }
    }
}
