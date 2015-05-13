using GSoft.Dynamite.Pages;

namespace GSoft.Dynamite.Design.Contracts.Constants
{
    /// <summary>
    /// Page definitions for the design module
    /// </summary>
    public static class DesignPageInfos
    {
        #region Home pages by languages
        /// <summary>
        /// The english home page information.
        /// </summary>
        /// <returns>The page information.</returns>
        public static PageInfo HomepageEn
        {
            get
            {
                return new PageInfo()
                {
                    FileName = "Home",
                    Title = "Home",
                    IsPublished = true,
                };
            }
        }

        /// <summary>
        /// The french home page information.
        /// </summary>
        /// <returns>The page information.</returns>
        public static PageInfo HomepageFr
        {
            get
            {
                return new PageInfo()
                {
                    FileName = "Accueil",
                    Title = "Accueil",
                    IsPublished = true,
                };
            }
        }

        #endregion
    }
}
