using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Unity;

namespace WebApiUtil
{
    public class UnityFilterProvider : IFilterProvider
    {
        private readonly IUnityContainer m_Container;

        public UnityFilterProvider(IUnityContainer container)
        {
            m_Container = container;
        }

        public IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
        {
            return m_Container.ResolveAll<IFilter>().Select(filter => new FilterInfo(filter, FilterScope.Global));
        }
    }
}