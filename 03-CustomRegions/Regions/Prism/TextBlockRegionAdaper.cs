using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Regions
{
    public class TextBlockRegionAdapter : RegionAdapterBase<TextBlock>
    {
        public TextBlockRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, TextBlock regionTarget)
        {
            //throw new NotImplementedException();
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (FrameworkElement element in e.NewItems)
                    {
                        regionTarget.Text += element.Name + ",";
                    }
                }
            };
        
        }

        protected override IRegion CreateRegion()
        {
            //throw new NotImplementedException();
            return new AllActiveRegion();
        }
    }
}
