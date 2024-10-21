using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Extensions
{
    public static class AbsoluteLayoutExtensions
    {
        public static void Add(this AbsoluteLayout absoluteLayout, IView view, Rect bounds, AbsoluteLayoutFlags flags = AbsoluteLayoutFlags.None)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            if (bounds.IsEmpty)
                throw new ArgumentNullException(nameof(bounds));

            absoluteLayout.Add(view);
            absoluteLayout.SetLayoutBounds(view, bounds);
            absoluteLayout.SetLayoutFlags(view, flags);
        }

        public static void Add(this AbsoluteLayout absoluteLayout, IView view, Point position)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            if (position.IsEmpty)
                throw new ArgumentNullException(nameof(position));

            absoluteLayout.Add(view);
            absoluteLayout.SetLayoutBounds(view, new Rect(position.X, position.Y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
        }
    }
}
