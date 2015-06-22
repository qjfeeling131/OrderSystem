using Aspect;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using OrderManager.Manager;

namespace OrderManager.Service
{
    public class UnityContainerRegister : IUnityContanierRegister
    {
        public void Register(IUnityContainer container)
        {
            _container = container;
            RegistNSetInterceptor<IOrderManger, OrderManger>(); 
            RegistNSetInterceptor<IUserManager, UserManager>();
            RegistNSetInterceptor<ILogManager, LogManager>(); 
            RegistNSetInterceptor<IOrderService, OrderService>();
            RegistNSetInterceptor<IUserService, UserService>();
            

        }

        #region private 
        private IUnityContainer _container;

        /// <summary>
        /// RegisterType
        /// </summary>
        /// <typeparam name="I">Interface</typeparam>
        /// <typeparam name="T">Instance Class</typeparam>
        private void RegistNSetInterceptor<I, T>()
                where T : I
        {
            _container.RegisterType<I, T>(new HierarchicalLifetimeManager())
                        .AddNewExtension<Interception>()
                        .Configure<Interception>()
                        .SetInterceptorFor<I>(new InterfaceInterceptor());
        } 
        #endregion
    }
}
