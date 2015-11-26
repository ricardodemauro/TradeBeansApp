using System;
using AppStudio.DataProviders;

namespace TreadBeans.Sections
{
    /// <summary>
    /// Implementation of the OurProducts1Schema class.
    /// </summary>
    public class OurProducts1Schema : SchemaBase
    {

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }
    }
}
