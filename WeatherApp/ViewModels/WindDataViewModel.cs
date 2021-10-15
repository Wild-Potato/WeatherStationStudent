using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Commands;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
    public class WindDataViewModel : BaseViewModel
    {
        /// TODO : Ajoutez le code nécessaire pour réussir les tests et répondre aux requis du projet
        /// 
        public IWinDataService WindDataService;

        public DelegateCommand<string> GetDataCommand { get; set; }

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

        public bool CanGetData()
        {
            if (WindDataService == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
