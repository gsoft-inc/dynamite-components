using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Binding;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.FieldTypes;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Contracts.Constants
{
    public class BaseNavigationFieldInfos
    {

        private static readonly string DateSlugFieldName = BasePublishingFieldInfos.FieldPrefix + "DateSlug";
        private static readonly string TitleSlugFieldName = BasePublishingFieldInfos.FieldPrefix + "TitleSlug";

        public BaseNavigationFieldInfos()
        {
            
        }

        /// <summary>
        /// The date slug field
        /// </summary>
        /// <returns>The DateSlug field</returns>
        public TextFieldInfo DateSlug()
        {
            return new TextFieldInfo(
                DateSlugFieldName,
                new Guid("{0D112FAD-6445-4002-8C8B-CF405F7C4935}"),
                BaseNavigationResources.FieldDateSlugName,
                BaseNavigationResources.FieldDateSlugDescription,
                BasePublishingResources.FieldGroup
                )
            {
                Required = RequiredTypes.NotRequired,
                IsHiddenInDisplayForm = true,
                IsHiddenInEditForm = true,
                IsHiddenInListSettings = true,
                IsHiddenInNewForm = true
            };
        }

        /// <summary>
        /// The title slug field
        /// </summary>
        /// <returns>The TitleSlug field</returns>
        public TextFieldInfo TitleSlug()
        {
            return new TextFieldInfo(
                TitleSlugFieldName,
                new Guid("{8D3823D9-8F02-4640-8439-BF09D0A7333F}"),
                BaseNavigationResources.FieldTitleSlugName,
                BaseNavigationResources.FieldTitleSlugDescription,
                BasePublishingResources.FieldGroup
                )
            {
                Required = RequiredTypes.NotRequired,
                IsHiddenInDisplayForm = true,
                IsHiddenInEditForm = true,
                IsHiddenInListSettings = true,
                IsHiddenInNewForm = true
            };
        }
    }
}
