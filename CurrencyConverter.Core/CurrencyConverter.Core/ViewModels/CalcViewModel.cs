using CurrencyConverter.Core.Services;
using MvvmCross.Core.ViewModels;
using System;
using System.Threading.Tasks;

namespace CurrencyConverter.Core.ViewModels
{
    public class CalcViewModel
        : MvxViewModel
    {
        private IMvxCommand _calcValue;
        private IConversorService _conversorService;
        public CalcViewModel(IConversorService conversorService)
        {
            _calcValue = new MvxCommand(async () => await ExecuteValueConvert());
            _conversorService = conversorService;
        }

        public IMvxCommand CalcValue
        {
            get
            {
                return _calcValue;
            }
        }

        private double _value;

        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                RaisePropertyChanged(() => Value);

            }
        }

        private double _result;

        public double Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                RaisePropertyChanged(() => Result);
            }
        }

        //private void ConvertValue() => Result = _conversorService.Convert(Value);

        async Task ExecuteValueConvert()
        {
            Result = await _conversorService.Convert(Value);
        }
    }
}
