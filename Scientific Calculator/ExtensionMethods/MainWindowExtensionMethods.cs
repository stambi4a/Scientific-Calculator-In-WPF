namespace Scientific_Calculator.ExtensionMethods
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;

    public static class MainWindowExtensionMethods
    {
        public static T GetChildOfType<T>(this DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) return null;

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                var result = (child as T) ?? GetChildOfType<T>(child);
                if (result != null) return result;
            }

            return null;
        }


        public static void FindVisualChildren<T>(this ICollection<T> children, DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                var brethren = LogicalTreeHelper.GetChildren(depObj);
                var brethrenOfType = LogicalTreeHelper.GetChildren(depObj).OfType<T>();
                foreach (var childOfType in brethrenOfType)
                {
                    children.Add(childOfType);
                }

                foreach (var rawChild in brethren)
                {
                    if (rawChild is DependencyObject)
                    {
                        var child = rawChild as DependencyObject;
                        FindVisualChildren<T>(children, child);
                    }
                }
            }
        }
    }
}
