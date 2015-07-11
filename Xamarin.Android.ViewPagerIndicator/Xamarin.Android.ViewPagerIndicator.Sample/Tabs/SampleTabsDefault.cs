using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V4.App;
using Com.Viewpagerindicator;

using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;

namespace Xamarin.Android.ViewPagerIndicator.Sample
{
	[Activity (Label = "Tabs/Default", Theme = "@style/Theme.PageIndicatorDefaults")]
	[IntentFilter (new[]{Intent.ActionMain}, Categories = new[]{ "mono.viewpagerindicator.sample" })]
	public class SampleTabsDefault : BaseSampleActivity
	{
		public static string[] CONTENT = new string[] { "Recent", "Artists", "Albums", "Songs", "Playlists", "Genres" };

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.simple_tabs);
	
			mAdapter = new GoogleMusicAdapter (SupportFragmentManager);
	
			mPager = FindViewById<ViewPager> (Resource.Id.pager);
			mPager.Adapter = mAdapter;
	
			mIndicator = FindViewById<TabPageIndicator> (Resource.Id.indicator);
			mIndicator.SetViewPager (mPager);
		}
		
		public class GoogleMusicAdapter : TestFragmentAdapter
		{
			public GoogleMusicAdapter (FragmentManager fm) : base(fm)
			{
			}
			
			public override Fragment GetItem (int position)
			{
				return new TestFragment (SampleTabsDefault.CONTENT [position % SampleTabsDefault.CONTENT.Length]);
			}
			
			public override int Count {
				get {
					return SampleTabsDefault.CONTENT.Length;
				}
			}

			public string GetTitle (int position)
			{
				return  SampleTabsDefault.CONTENT [position % SampleTabsDefault.CONTENT.Length].ToUpper ();
			}
		}
	}
}


