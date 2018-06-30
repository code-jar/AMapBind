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
using Java.Security;

namespace AMapDemo.Utils
{
    public class AppUtil
    {

        public static string GetSHA1(Android.Content.Context ctx)
        {
            string result = string.Empty;
            try
            {
                var info = ctx.PackageManager.GetPackageInfo(ctx.PackageName, Android.Content.PM.PackageInfoFlags.Signatures);
                var cert = info.Signatures[0].ToByteArray();
                var md = MessageDigest.GetInstance("SHA1");
                var publicKey = md.Digest(cert);
                Java.Lang.StringBuffer hexString = new Java.Lang.StringBuffer();
                for (int i = 0; i < publicKey.Length; i++)
                {
                    string appendString = new Java.Lang.String(String.Format("{0:X}", (0xFF & publicKey[i]))).ToUpperCase(Java.Util.Locale.Us);

                    if (appendString.Length == 1)
                    {
                        hexString.Append("0");
                    }

                    hexString.Append(appendString);
                    hexString.Append(":");
                }

                result = hexString.ToString();
                result = result.Substring(0, result.Length - 1);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return result;
        }

        public static string ConvertStringToHex(string strASCII, string separator = null)
        {
            StringBuilder sbHex = new StringBuilder();
            foreach (char chr in strASCII)
            {
                sbHex.Append(String.Format("{0:X2}", Convert.ToInt32(chr)));
                sbHex.Append(separator ?? string.Empty);
            }
            return sbHex.ToString();
        }

        public static string ConvertHexToString(string HexValue, string separator = null)
        {
            HexValue = string.IsNullOrEmpty(separator) ? HexValue : HexValue.Replace(string.Empty, separator);
            StringBuilder sbStrValue = new StringBuilder();
            while (HexValue.Length > 0)
            {
                sbStrValue.Append(Convert.ToChar(Convert.ToUInt32(HexValue.Substring(0, 2), 16)).ToString());
                HexValue = HexValue.Substring(2);
            }
            return sbStrValue.ToString();
        }

    }
}