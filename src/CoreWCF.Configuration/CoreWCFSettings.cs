using System;
using System.ComponentModel;

namespace CoreWCF.WebService.Configuration
{
    public class CoreWCFSettings
    {
        [TypeConverter(typeof(UriTypeConverter))]
        public Uri Api
        {
            get;
            set;
        }

        [TypeConverter(typeof(UriTypeConverter))]
        public Uri ContactCenter
        {
            get;
            set;
        }
    }
}
