using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceMobile.Pages.ViewModel;

namespace ECommerceMobile.Infrastructure
{
    public class InstanceLocator
    {
        #region Properties
        public MainViewModel Main { get; set; }
        #endregion

        #region Constructor

        public InstanceLocator()
        {
            Main = new MainViewModel();
        }
        #endregion
    }
}
