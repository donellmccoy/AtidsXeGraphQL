using System.Windows;
using System.Windows.Controls;
using TheFund.AtidsXe.Modules.Navigation.ViewModels.ChainOfTitles;
using TheFund.AtidsXe.Modules.Navigation.ViewModels.Names;
using TheFund.AtidsXe.Modules.Navigation.ViewModels.Policies;
using TheFund.AtidsXe.Modules.Navigation.ViewModels.Properties;

namespace TheFund.AtidsXe.Modules.Navigation.TemplateSelectors
{
    public class NavigationTemplateSelector : DataTemplateSelector
    {
        #region Policy Templates

        public HierarchicalDataTemplate PolicySearchGroupTemplate { get; set; }

        public DataTemplate PolicySearchLegalTemplate { get; set; }

        #endregion

        #region Property Templates

        public HierarchicalDataTemplate PropertySearchGroupTemplate { get; set; }

        public HierarchicalDataTemplate PropertySearchLegalTemplate { get; set; }

        public DataTemplate PropertySearchTemplate { get; set; }

        #endregion

        #region Chain Of Title Templates

        public HierarchicalDataTemplate ChainOfTitlesGroupTemplate { get; set; }

        public DataTemplate ChainOfTitleTemplate { get; set; }

        #endregion

        #region Name Search Templates

        public HierarchicalDataTemplate NameSearchGroupTemplate { get; set; }

        #endregion

        #region Methods

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null || container == null)
            {

            }

            switch (item)
            {
                case PolicySearchGroupTreeViewModel _:
                    return PolicySearchGroupTemplate;
                case PropertySearchGroupTreeViewModel _:
                    return PropertySearchGroupTemplate;
                case ChainOfTitleGroupTreeViewModel _:
                    return ChainOfTitlesGroupTemplate;
                case NameSearchGroupTreeViewModel _:
                    return NameSearchGroupTemplate;
                default:
                    return base.SelectTemplate(item, container);
            }
        }

        #endregion
    }
}