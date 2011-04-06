using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

namespace InputAccessoryTest
{
	public class RootView : UIViewController
	{
		public RootView ()
		{
		}
		
		public override void LoadView ()
		{
			base.LoadView ();
			UIButton modalButton = new UIButton(new RectangleF(30,120,250,220));
			modalButton.SetTitle("Touch me", UIControlState.Normal);
			modalButton.BackgroundColor = UIColor.Red;
			modalButton.TouchUpInside += delegate(object sender, EventArgs e) {
				PresentModalViewController(new SubjectView(), true);
			};
			View.AddSubview(modalButton);
			
		}
	}
}

