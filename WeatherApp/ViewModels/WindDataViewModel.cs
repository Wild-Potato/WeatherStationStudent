using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.ViewModels
{
    public class WindDataViewModel : BaseViewModel
    {
        /// TODO : Ajoutez le code nécessaire pour réussir les tests et répondre aux requis du projet
        /// 
        public double KPHtoMPS(double kph)
        {
            double mps = kph * 1000 / 3600;
            
            mps = Math.Round(mps, 2);

            return mps;
        }

        public double MPStoKPH(double mps)
        {
            double kph = mps * 3600 / 1000;

            return kph;
        }

    }
}
