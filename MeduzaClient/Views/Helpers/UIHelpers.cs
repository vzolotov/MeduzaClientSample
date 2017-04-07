using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace MeduzaClient.Views.Helpers
{
    public static class UIHelpers
    {
        public static IEnumerable<T> GetAllChildren<T>(this UIElement frameworkElement) where T : UIElement
        {
            if (frameworkElement == null)
            {
                yield break;
            }

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(frameworkElement); i++)
            {
                var _Child = VisualTreeHelper.GetChild(frameworkElement, i);
                if (_Child is T)
                {
                    yield return (_Child as T);
                }
                var control = _Child as UIElement;
                foreach (var child in GetAllChildren<T>(control))
                {
                    yield return child;
                }
            }
        }
    }
}
