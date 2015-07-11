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
	[Activity (Label = "Titles/Styled (via methods)", Theme = "@android:style/Theme.Light")]
	[IntentFilter (new[]{Intent.ActionMain}, Categories = new[]{ "mono.viewpagerindicator.sample" })]
	public class SampleTitlesStyledMethods : BaseSampleActivity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			
			SetContentView (Resource.Layout.simple_titles);
			
			mAdapter = new TestTitleFragmentAdapter (SupportFragmentManager);
			
			mPager = FindViewById<ViewPager> (Resource.Id.pager);
			mPager.Adapter = mAdapter;
			
			var indicator = FindViewById<TitlePageIndicator> (Resource.Id.indicator);
			mIndicator = indicator;
			indicator.SetViewPager (mPager);
			
			float density = Resources.DisplayMetrics.Density;
			indicator.SetBackgroundColor (Color.ParseColor ("#18FF0000"));
			indicator.FooterColor = Color.ParseColor ("#FFAA2222");
			indicator.FooterLineHeight = 1 * density; //1dp
			indicator.FooterIndicatorHeight = 3 * density; //3dp
			indicator.FooterIndicatorStyle = TitlePageIndicator.IndicatorStyle.Underline;
			indicator.TextColor = Color.ParseColor ("#AA000000");
			indicator.SelectedColor = Color.ParseColor ("#FF000000");
			indicator.SelectedBold = true;
		}
	}
}