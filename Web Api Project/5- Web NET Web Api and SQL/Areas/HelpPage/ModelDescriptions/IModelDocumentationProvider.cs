using System;
using System.Reflection;

namespace _5__Web_NET_Web_Api_and_SQL.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}