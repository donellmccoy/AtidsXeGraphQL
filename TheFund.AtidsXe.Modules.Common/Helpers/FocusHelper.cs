using System;
using System.Windows;
using System.Windows.Controls;

namespace TheFund.AtidsXe.Modules.Common.Helpers
{
    public class FocusHelper
    {
        private static void OnEnsureFocusChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if ((bool) e.NewValue)
            {
                return;
            }

            if (dependencyObject is Control control)
            {
                control.Dispatcher.BeginInvoke(new Action(() => control.Focus()));
            }
        }

        public static bool GetEnsureFocus(DependencyObject dependencyObject)
        {
            return (bool)dependencyObject.GetValue(EnsureFocusProperty);
        }

        public static void SetEnsureFocus(DependencyObject dependencyObject, bool value)
        {
            dependencyObject.SetValue(EnsureFocusProperty, value);
        }

        public static readonly DependencyProperty EnsureFocusProperty =
            DependencyProperty.RegisterAttached(
                "EnsureFocus",
                typeof(bool),
                typeof(FocusHelper),
                new PropertyMetadata(OnEnsureFocusChanged));
    }
}
