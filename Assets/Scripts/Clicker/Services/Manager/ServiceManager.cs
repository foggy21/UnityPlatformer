using System.Collections.Generic;

namespace Clicker.Services.Manager
{
    public class ServiceManager
    {
        private static ServiceManager _instance;
        private List<Service> _enabledServices = new();
        public List<Service> EnabledServices { get { return _enabledServices; } }
        
        private ServiceManager() {}

        public static ServiceManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ServiceManager();
            }
            return _instance;
        }

        public void AddEnabledService(Service newService)
        {
            _enabledServices.Add(newService);
        } 
    }
}
