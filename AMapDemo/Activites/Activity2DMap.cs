using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Amap.Api.Location;
using Com.Amap.Api.Maps2d;

namespace AMapDemo.Activites
{
    [Activity(Label = "Activity2DMap")]
    public class Activity2DMap : Activity
    {
        MapView AMapView;
        AMapLocationClient LocationClient;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.layout2DMap);

            AMapView = FindViewById<MapView>(Resource.Id.AMap2DView);

            //在activity执行onCreate时执行mMapView.onCreate(savedInstanceState)，创建地图
            AMapView.OnCreate(savedInstanceState);

            InitLocation();
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
            //在activity执行onDestroy时执行mMapView.onDestroy()，销毁地图
            AMapView.OnDestroy();
            LocationClient.OnDestroy();
        }
        protected override void OnResume()
        {
            base.OnResume();
            //在activity执行onResume时执行mMapView.onResume ()，重新绘制加载地图
            AMapView.OnResume();
        }
        protected override void OnPause()
        {
            base.OnPause();
            //在activity执行onPause时执行mMapView.onPause ()，暂停地图的绘制
            AMapView.OnPause();
        }
        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            ////在activity执行onSaveInstanceState时执行mMapView.onSaveInstanceState (outState)，保存地图当前的状态
            AMapView.OnSaveInstanceState(outState);
        }


        private void InitLocation()
        {
            //声明mlocationClient对象 

            LocationClient = new AMapLocationClient(this);
            //初始化定位参数
            AMapLocationClientOption mLocationOption = new AMapLocationClientOption();
            //设置定位监听
            LocationClient.SetLocationListener(new LocationListener(this));
            //设置定位模式为高精度模式，Battery_Saving为低功耗模式，Device_Sensors是仅设备模式
            mLocationOption.SetLocationMode(AMapLocationClientOption.AMapLocationMode.HightAccuracy);
            //设置定位间隔,单位毫秒,默认为2000ms
            mLocationOption.SetInterval(2000);
            //设置定位参数
            LocationClient.SetLocationOption(mLocationOption);
            // 此方法为每隔固定时间会发起一次定位请求，为了减少电量消耗或网络流量消耗，
            // 注意设置合适的定位时间的间隔（最小间隔支持为1000ms），并且在合适时间调用stopLocation()方法来取消定位请求
            // 在定位结束后，在合适的生命周期调用onDestroy()方法
            // 在单次定位情况下，定位无论成功与否，都无需调用stopLocation()方法移除请求，定位sdk内部会移除
            //启动定位
            LocationClient.StartLocation();
        }


        class LocationListener : Java.Lang.Object, IAMapLocationListener
        {
            private readonly Android.Content.Context context;

            public LocationListener(Context ctx)
            {
                this.context = ctx;
            }

            public void OnLocationChanged(AMapLocation location)
            {
                if (location == null || location.ErrorCode == 0)
                {
                    Toast.MakeText(context, "Error:" + location.ErrorInfo, ToastLength.Long).Show();
                    return;
                }

                //定位成功回调信息
                Toast.MakeText(context, location.Address, ToastLength.Long).Show();
            }
        }

    }
}