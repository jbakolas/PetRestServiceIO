namespace PetRestServiceIOB.Resolver
{
    
    // Responsible for registering types in unity configuration by implementing IComponent
    
    public interface IRegisterComponent
    {
        
        // Register type method
        
        void RegisterType<TFrom, TTo>(bool withInterception = false) where TTo : TFrom;

        // Register type with container controlled life time manager
        
        void RegisterTypeWithControlledLifeTime<TFrom, TTo>(bool withInterception = false) where TTo : TFrom;
    }
}
