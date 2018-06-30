using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;

namespace AMapDemo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var btnGo2DMap = FindViewById<Button>(Resource.Id.btnGo2DMap);
            btnGo2DMap.SetOnClickListener(new BtnClick(this, btnGo2DMap));

            var btnGo3DMap = FindViewById<Button>(Resource.Id.btnGo3DMap);
            btnGo3DMap.SetOnClickListener(new BtnClick(this, btnGo3DMap));

            var btnGetSha1 = FindViewById<Button>(Resource.Id.btnGetSha1);
            btnGetSha1.SetOnClickListener(new BtnClick(this, btnGetSha1));
        }

        class BtnClick : Java.Lang.Object, Android.Views.View.IOnClickListener
        {
            private readonly Button button;
            private readonly Android.Content.Context currentContext;

            public BtnClick(Android.Content.Context ctx, Button btn)
            {
                this.currentContext = ctx;
                this.button = btn;
            }

            public void OnClick(View v)
            {
                Android.Content.Intent intent = null;

                switch (this.button.Id)
                {
                    case Resource.Id.btnGo2DMap:
                        intent = new Android.Content.Intent(this.currentContext, typeof(Activites.Activity2DMap));
                        this.currentContext.StartActivity(intent);
                        break;
                    case Resource.Id.btnGo3DMap:
                        intent = new Android.Content.Intent(this.currentContext, typeof(Activites.Activity3DMap));
                        this.currentContext.StartActivity(intent);
                        break;
                    case Resource.Id.btnGetSha1:
                        var sha1 = Utils.AppUtil.GetSHA1(currentContext);
                        Toast.MakeText(currentContext, "sha1:" + sha1, ToastLength.Long).Show();
                        break;
                }
            }
        }
    }
}

