using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Medigenda
{
    public class Lib
    {

        //Source : http://mag.autumn.org/Content.modf?id=20150819134833
        private static T find<T>(DependencyObject root, Func<T, bool> checker = null) where T : DependencyObject
            {
                if (root == null) return null;
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(root); i++)
                {
                    var r = VisualTreeHelper.GetChild(root, i);
                    var r1 = r as T;
                    if (r1 != null)
                    {
                        if (checker == null) return r1;
                        if (checker(r1)) return r1;
                    }
                    var r2 = find<T>(r, checker);
                    if (r2 != null) return r2;
                }
                return null;
            }
            public static void FixContentDialogForConstructor(ContentDialog dialog)
            {
                dialog.MaxHeight = double.PositiveInfinity;
                dialog.MaxWidth = double.PositiveInfinity;
                dialog.Loaded += (sender, e) =>
                {
                    Grid mainGrid = (Grid)dialog.Content;
                    var largeRect = new Rectangle();
                    largeRect.Width = 1;
                    largeRect.Height = 1;
                    largeRect.Fill = new SolidColorBrush(Colors.Transparent);
                    mainGrid.Children.Insert(0, largeRect);
                };
            }
        }
    }

