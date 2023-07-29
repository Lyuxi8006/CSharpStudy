using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPF_DataTemplate
{
    class MyDeataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            if (element != null && item is Product p) 
            {
                if (p.Dep == Dep.Dairy)
                {
                    return element.FindResource("MyProdDT") as DataTemplate;
                }   
                else if(p.Dep == Dep.Candy)
                {
                    return element.FindResource("MyProdDTWithEnum") as DataTemplate;
                }
                else if (p.Dep == Dep.Soda)
                {
                    return element.FindResource("MyProdDT2") as DataTemplate;
                }
            }
            return element.FindResource("MyProdDTWithEnum") as DataTemplate;
        }
    }
}
