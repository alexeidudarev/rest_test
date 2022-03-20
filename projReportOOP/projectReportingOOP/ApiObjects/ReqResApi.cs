using NUnit.Framework;
using projectReportingOOP.BasePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectReportingOOP.ApiObjects
{
    public class ReqResApi : BaseApiObjects
    {
        public void getAllUsers()
        {
            var data = getData();
        }
    }
}
