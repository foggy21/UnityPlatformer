using Clicker.Services.Manager;
using Clicker.Services;
using UnityEngine;
using UnityEngine.Events;

namespace Clicker.Core
{
    public class GameManager : MonoBehaviour
    {
        private ServiceManager _serviceManager;
        
        public delegate void ClickHandler();
        public static event ClickHandler OnClick;
        
        private void Start()
        {
            _serviceManager = ServiceManager.GetInstance();
        }

        public void Click()
        {
            OnClick?.Invoke();
            foreach (Service service in _serviceManager.EnabledServices)
            {
                service.Perform();
            }
        }
    }
}
