using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;
using Windows.Storage;

namespace Retirement_Countdown_Clock_Core.uk.co.vsf.retirement.repository
{
    public class ApplicationDataContainerRepository
    {
        //private const string KEY_CONTAINER = "RetirementCountdownCalculator";

        protected Windows.Storage.ApplicationDataContainer GetLocalSettings()
        {
            return Windows.Storage.ApplicationData.Current.LocalSettings;
        }

        /*private bool IsContainerPresent()
        {
           return GetLocalSettings().Containers.ContainsKey(KEY_CONTAINER);
        }

        private void CreateContainer()
        {
            if (IsContainerPresent())
            {
                return;
            }

            GetLocalSettings().CreateContainer(KEY_CONTAINER, ApplicationDataCreateDisposition.Always);
        }

        private ApplicationDataContainer GetContainer()
        {
            return GetLocalSettings().Containers[KEY_CONTAINER];
        }

        public object RetrieveValue(string key)
        {
            return GetContainer().Values[key];
        }

        public void StoreValue(string key, object value)
        {
            CreateContainer();
            GetContainer().Values[key] = value;
        }*/
    }
}
