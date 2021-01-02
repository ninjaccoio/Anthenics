using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Anthenics.Converters
{
    public class IdToCustomerConverter : IValueConverter
    {
        private object IdToCustomer(object value)
        {
            return "Cliente Fake";
            //throw new NotImplementedException();
            //throw new NotImplementedException();
            /*
            clifor clifor = new clifor();
            Task.Run(async () => { clifor = await App.Database.GetcliforAsync((int)value); }).Wait();
            return clifor.R_Sociale;
            */
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value != null)
            {
                return IdToCustomer(value);
            }
            else
                return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
