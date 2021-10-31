using MyCoffeeApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyCoffeeApp.Cells
{
    public class CoffeeDataTemplateSelector : DataTemplateSelector
    {
        public CoffeeDataTemplateSelector()
        {

        }
        public DataTemplate Normal { get; set; }
        public DataTemplate Special { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            //var coffee = (Coffee)item; 

            //return coffee.Roaster == "Yes Plz" ? Special : Normal;


            // enable code above for true data template selectors
            return Normal;
        }
    }
}
