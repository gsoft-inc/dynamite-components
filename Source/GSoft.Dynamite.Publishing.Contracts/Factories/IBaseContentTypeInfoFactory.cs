using GSoft.Dynamite.Definitions;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.Contracts.Factories
{
    public interface IBaseContentTypeInfoFactory
    {
        void CreateContentType(SPContentTypeCollection contentTypeCollection, ContentTypeInfo contentType);
    }
}
