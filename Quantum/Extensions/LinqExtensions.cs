using System;
using System.Collections.Generic;
using System.Linq;
using Quantum.DOM;
using Quantum.HTML;

namespace Quantum.Extensions
{
    public static class LinqExtensions
    {
        public static List<Element> GraphLookup(this List<HTMLElement> elements)
        {
            var result = new List<Element>();

            FindChildInDepth(elements.Select(x => x as Element).ToList(), result);

            return result;
        }

        private static void FindChildInDepth(List<Element> elements, List<Element> result)
        {
            foreach (var element in elements)
            {
                if (element != null)
                {
                    result.Add(element);

                    if (element.Children.Count != 0)
                    {
                        FindChildInDepth(element.Children, result);
                    }
                }
            }
        }
    }
}