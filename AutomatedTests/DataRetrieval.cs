using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace AutomatedTests
{
    public class DataRetrieval
    {
        public void LoadValues(string user, string password)
        {
            XDocument doc = XDocument.Load(@"C:\Users\Bobas\Documents\Visual Studio 2012\Projects\AutomatedTests\AutomatedTests\Values.xml");
            var r = from x in doc.Descendants("credentials")
                    select new
                    {
                        userLogin = x.Element(user).Value,
                        userPassword = x.Element(password).Value
                    };

            
            WellKnownValues.user = r.ElementAt(0).userLogin;
            WellKnownValues.password = r.ElementAt(0).userPassword;
        }
    }
}
