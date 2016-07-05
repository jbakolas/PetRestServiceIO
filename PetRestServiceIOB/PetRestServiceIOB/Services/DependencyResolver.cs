using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using BusinessServices;
using PetRestServiceIOB.Resolver;
using IComponent = System.ComponentModel.IComponent;

namespace PetRestServiceIOB.Services
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IUserServices, UserServices>();
            registerComponent.RegisterType<ITokenServices, TokenServices>();

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ISite Site { get; set; }
        public event EventHandler Disposed;
    }
}
