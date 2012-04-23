using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FundDataMaintenance.Helpers
{
    public class TrimModelBinder : DefaultModelBinder
    {
        protected override void SetProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, System.ComponentModel.PropertyDescriptor propertyDescriptor, object value)
        {
            if(propertyDescriptor.PropertyType.Equals(typeof(string)))
            {
                var stringObj = value as string;
                if(!string.IsNullOrEmpty(stringObj))
                {
                    stringObj = stringObj.Trim();
                }
                value = stringObj;
            }
            base.SetProperty(controllerContext, bindingContext, propertyDescriptor, value);
        }
    }
}