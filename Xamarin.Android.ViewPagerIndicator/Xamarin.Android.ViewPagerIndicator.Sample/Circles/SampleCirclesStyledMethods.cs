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
using Android.Support.V4.View;
using Android.Graphics;
using Com.Viewpagerindicator;

namespace Xamarin.Android.ViewPagerIndicator.Sample
{
	[Activity (Label = "Circles/Styled (via methods)", Theme = "@android:style/Theme.Light")]
	[IntentFilter (new[]{Intent.ActionMain}, Categories = new[]{ "mono.viewpagerindicator.sample" })]	
	public class SampleCirclesStyledMethods : BaseSampleActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			
			SetContentView (Resource.Layout.themed_circles);
		
			mAdapter = new TestFragmentAdapter (SupportFragmentManager);
			
			mPager = FindViewById<ViewPager> (Resource.Id.pager);
			mPager.Adapter = mAdapter;
			
			var indicator = FindViewById<CirclePageIndicator> (Resource.Id.indicator);
			mIndicator = indicator;
			indicator.SetViewPager (mPager);
			
			float density = Resources.DisplayMetrics.Density;
			indicator.SetBackgroundColor (Color.ParseColor ("#FFCCCCCC"));
			indicator.Radius = 10 * density;
			indicator.PageColor = Color.ParseColor ("#880000FF");
			indicator.FillColor = Color.ParseColor ("#FF888888");
			indicator.StrokeColor = Color.ParseColor ("#FF000000");
			indicator.StrokeWidth = 2 * density;
		}
	}
}

