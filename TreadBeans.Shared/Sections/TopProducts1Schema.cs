using System;
using AppStudio.DataProviders;

namespace TreadBeans.Sections
{
    /// <summary>
    /// Implementation of the TopProducts1Schema class.
    /// </summary>
    public class TopProducts1Schema : SchemaBase
    {

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }
    }
}
