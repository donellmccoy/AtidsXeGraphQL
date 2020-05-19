using System.Windows;
using System.Windows.Controls;

namespace TheFund.AtidsXe.Modules.Navigation.TemplateSelectors
{
    public class OutlookBarContentTemplateSeletor : DataTemplateSelector
    {
        public DataTemplate OutlookBarContentTemplate { get; set; }

        public DataTemplate EmptyContentTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {

            return base.SelectTemplate(item, container);
        }
    }
}