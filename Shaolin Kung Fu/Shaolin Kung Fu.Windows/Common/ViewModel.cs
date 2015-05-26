using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using ShaolinCheck.Common;
using Shaolin_Kung_Fu.Common;

namespace Shaolin_Kung_Fu
{
    abstract class ViewModel
    {
        public MessageDialog MsgDialog { get; set; }
       // private SingletonCommon _sCommon = SingletonCommon.Instance;
        public WSContext WsContext = new WSContext();

        public SingletonCommon SCommon
        {
            get { return SingletonCommon.Instance; }
            private set { }
        }

        public abstract void SetSelectedObject(Object obj);
    }
}
