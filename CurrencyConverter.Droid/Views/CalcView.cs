using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace CurrencyConverter.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class CalcView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CalcView);
        }
    }
}
