using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * For Windows Version List
 * 
 * http://prajwaldesai.com/windows-operating-system-version-numbers/
 */

namespace DelWall
{
    class WinVerCheck
    {
        public string winVerCheck(string versionValue) {

            switch(versionValue)
            {
                case "6.0.6001":
                    return "Windows Server 2008";
                case "6.1.7600.16385":
                case "6.1.7601":
                    return "Windows 7";
                case "6.1.8400":
                    return "Windows Home Server 2011";
                case "6.2.9200":
                    return "Windows 8";
                case "6.3.9200":
                case "6.3.9600":
                    return "Windows 8.1";
                case "10.0.10240":
                    return "Windows 10";
                default:
                    return "No Version Detected"
            }
        }
    }
}
