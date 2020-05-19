using System;
using System.ComponentModel.Composition;
using TheFund.AtidsXe.Modules.Common.Behaviors;

namespace TheFund.AtidsXe.Modules.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    [MetadataAttribute]
    public sealed class ViewExportAttribute : ExportAttribute, IViewRegionRegistration
    {
        public ViewExportAttribute()
            : base(typeof(object))
        { }

        public ViewExportAttribute(string viewName)
            : base(viewName, typeof(object))
        { }

        public string ViewName => ContractName;

        public string RegionName { get; set; }

        public bool IsActiveOnStartUp { get; set; }
    }
}
