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
using Java.Interop;

namespace Com.Amap.Api.Maps
{
    public sealed partial class AMap : global::Java.Lang.Object
    {

        public partial interface IOnCameraChangeListener : IJavaObject, IJavaPeerable
        {

        }

    }

}