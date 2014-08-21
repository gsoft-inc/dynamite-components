using System;
using GSoft.Dynamite.Definitions;

namespace Dynamite.Demo.Intranet.Contracts.Constants
{
    public class Client1Fields
    {
        #region Field prefix

        // ReSharper disable once ConvertToConstant.Local
        private static readonly string FieldPrefix = "Client1";

        #endregion

        #region Field internal names

        private static readonly string MyColumnFieldName = FieldPrefix + "MyColumn";

        #endregion

        #region FieldInfo reference objects

        /// <summary>
        /// The navigation field information
        /// </summary>
        public static readonly FieldInfo Navigation = new FieldInfo(MyColumnFieldName, new Guid("{256DF203-3855-497F-B514-4C99D5BE79C9}"));

        #endregion
    }
}
