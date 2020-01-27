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

namespace Com.Autonavi.Base.AE.Gmap.Gloverlay
{
    public partial class CrossVectorOverlay : global::Com.Autonavi.Base.AE.Gmap.Gloverlay.BaseMapOverlay, global::Com.Autonavi.Amap.Mapcore.Interfaces.ICrossVectorOverlay
    {

        public void SetVisible(bool p0)
        {
            this.Visible = p0;
        }

    }
}