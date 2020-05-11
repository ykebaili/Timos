using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using futurocom.snmp;

namespace futurocom.win32.snmp
{
    public interface IMibNavigator
    {
        void NavigateTo(string strName);
        void NavigateTo(string strModule, string strName);

        bool HasPrevious { get; }
        bool HasNext { get; }

        void GoToPrevious();
        void GoToNext();

        IDefinition GetCurrent();

        IObjectTree ObjectTree { get; }

    }
}
