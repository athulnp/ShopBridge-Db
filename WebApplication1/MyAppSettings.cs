using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Site
{
    public class MyAppSettings
    {
        public const string SectionName = "ConnectionString";
        public string ShopBridgeDb { get; set; }
    }
}
