using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestFramework.DataProvider.BackOffice
{
    public class LoginProviderBackOffice
    {
        [JsonProperty(PropertyName = "includeAttributes")]
        public string[] IncludeAttributes { get; set; } = new[] { "perm.*" };
        [JsonProperty(PropertyName = "userName")]
        public string Login { get; set; } = "admin@betlab";
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; } = "abc";
    }
}
