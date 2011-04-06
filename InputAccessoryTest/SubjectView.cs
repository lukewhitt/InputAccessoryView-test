using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

namespace InputAccessoryTest 
{
	public class SubjectView : UIViewController
	{
		~SubjectView()
		{
			Console.WriteLine("**Subject View's Destructor called**");
		}
		
		public SubjectView ()
		{
		}
		
		private UITextField field1, field2, field3;
		
		public override void LoadView ()
		{
			base.LoadView ();
			// Init view
			UINavigationBar navBar = new UINavigationBar(new RectangleF(0,0,320,44));
			UIBarButtonItem dismissBtn = new UIBarButtonItem("Dismiss", UIBarButtonItemStyle.Bordered, delegate{
				DismissModalViewControllerAnimated(true);
			});
			UINavigationItem navItem = new UINavigationItem("Hullo");
			navItem.SetLeftBarButtonItem(dismissBtn, true);
			navBar.SetItems(new UINavigationItem[1] { navItem }, true);
			View.AddSubview(navBar);
			
			field1 = new UITextField(new RectangleF(10,60,150,27));
			field1.BorderStyle = UITextBorderStyle.RoundedRect;
			View.AddSubview(field1);
			field2 = new UITextField(new RectangleF(10,90,150,27));
			field2.BorderStyle = UITextBorderStyle.RoundedRect;
			View.AddSubview(field2);
			field3 = new UITextField(new RectangleF(10,120,150,27));
			field3.BorderStyle = UITextBorderStyle.RoundedRect;
			View.AddSubview(field3);
		}
		
		bool accessoryViewInit = false;
		UIView accessoryView = new UIView(new RectangleF(0,0,320,30));
		
		public override UIView InputAccessoryView 
		{
			get 
			{
				if (!accessoryViewInit)
				{
					accessoryView.BackgroundColor = UIColor.FromRGBA(0.0f, 0.0f, 0.0f, 0.5f);
					UIButton dismiss = new UIButton(new RectangleF(50,1, 200, 28));
					dismiss.BackgroundColor = UIColor.Blue;
					dismiss.SetTitle("Close Keyboard", UIControlState.Normal);
					dismiss.TouchUpInside += delegate(object sender, EventArgs e) {
						field1.ResignFirstResponder();
						field2.ResignFirstResponder();
						field3.ResignFirstResponder();
					};
					accessoryView.AddSubview(dismiss);
				}
				
				return accessoryView;
			}
		}
	}
}

