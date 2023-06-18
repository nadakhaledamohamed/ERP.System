using Microsoft.Extensions.Localization;
//using Microsoft.Identity.Client;
using System.Reflection;

namespace Web.ERP.Languages
{
    public class ResourceWeb { }
    public class ResourceWebServices
    {
       private readonly IStringLocalizer _localizer;

        public ResourceWebServices(IStringLocalizerFactory factory)
        {
            //var type = typeof(ResourceWeb);
            var assemblyName = new AssemblyName(typeof(ResourceWeb).GetTypeInfo().Assembly.FullName!);
            _localizer = factory.Create(nameof(ResourceWeb), assemblyName.Name!);

        }
        public LocalizedString GetResource(string key)
        {
            return _localizer[key];
        }
        public LocalizedString this[string name]
        {
            get
            {
                var resFormat = GetResource(name);
                return new LocalizedString(name, resFormat ?? name, resFormat == null);
            }
        }
    }
}
