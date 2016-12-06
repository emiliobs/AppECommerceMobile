using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceMobile.Pages.ViewModel
{
    public class LoginViewModel
    {
        #region Properties
        public string User { get; set; }

        public string Password { get; set; }

        public bool IsRemembered { get; set; }
        #endregion

    }
}
