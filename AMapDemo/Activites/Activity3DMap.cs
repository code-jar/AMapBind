using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Amap.Api.Maps;
using Com.Amap.Api.Maps.Model;

namespace AMapDemo.Activites
{
    [Activity(Label = "Activity3DMap")]
    public class Activity3DMap : Activity
    {
        MapView AMapView = null;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.layout3DMap);

            AMapView = FindViewById<MapView>(Resource.Id.AMap3DView);
            AMapView.OnCreate(savedInstanceState);

            InitMapView();
        }

        private void InitMapView()
        {
            var aMap = AMapView.Map;

            // 显示实时交通状况
            aMap.TrafficEnabled = true;
            //地图模式可选类型：MAP_TYPE_NORMAL,MAP_TYPE_SATELLITE,MAP_TYPE_NIGHT
            // 卫星地图模式
            aMap.MapType = AMap.MapTypeSatellite;

            var uiSettings = aMap.UiSettings;

            //设置默认定位按钮是否显示，非必需设置。
            uiSettings.MyLocationButtonEnabled = true;
            //控制比例尺控件是否显示
            uiSettings.ZoomControlsEnabled = false;
            //显示指南针
            uiSettings.CompassEnabled = true;

            MyLocationStyle myLocationStyle = new MyLocationStyle();
            //定位一次，且将视角移动到地图中心点
            myLocationStyle.InvokeMyLocationType(MyLocationStyle.LocationTypeLocate);
            //设置是否显示定位小蓝点
            myLocationStyle.ShowMyLocation(true);
            //设置连续定位模式下的定位间隔，只在连续定位模式下生效，单次定位模式下不会生效。单位为毫秒。
            myLocationStyle.InvokeInterval(2000);
            //设置定位蓝点的Style
            aMap.MyLocationStyle = myLocationStyle;

            aMap.SetOnMyLocationChangeListener(new AMapLocationChange(this));

            // 设置为true表示启动显示定位蓝点，false表示隐藏定位蓝点并不进行定位，默认是false
            aMap.MyLocationEnabled = true;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            AMapView.OnDestroy();
        }
        protected override void OnResume()
        {
            base.OnResume();
            AMapView.OnResume();
        }
        protected override void OnPause()
        {
            base.OnPause();
            AMapView.OnPause();
        }
        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            AMapView.OnSaveInstanceState(outState);
        }

        class AMapLocationChange : Java.Lang.Object, Com.Amap.Api.Maps.AMap.IOnMyLocationChangeListener
        {
            private readonly Android.Content.Context context;

            public AMapLocationChange(Context ctx)
            {
                this.context = ctx;
            }

            public void OnMyLocationChange(Location location)
            {
                Toast.MakeText(context, $"Latitude:{location.Latitude},Longitude:{location.Longitude},errorCode:{location.Extras.GetInt("errorCode")}", ToastLength.Long).Show();
            }
        }

    }
}