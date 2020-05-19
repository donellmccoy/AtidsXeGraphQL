using System.Windows;
using System.Windows.Controls;
using TheFund.AtidsXe.Modules.Search.Models;

namespace TheFund.AtidsXe.Modules.Search.StyleSelectors
{
    public class InUseStyleSelector : StyleSelector
    {
        public Style InUseStyle { get; set; }

        public Style NormalStyle { get; set; }

        public override Style SelectStyle(object item, DependencyObject container)
        {
            if (item is FileReferenceListItemViewModel listItem)
            {
                return listItem.IsInUse ? InUseStyle : NormalStyle;
            }

            return null;
        }
    }
}
