using Gtk;
using Mono.Addins;
using MonoDevelop.Ide.Gui;

namespace MonoDevelop.AddinMaker.AddinBrowser
{
	class AddinBrowserWidget : HPaned
	{
		public AddinTreeView TreeView { get; private set; }

		public AddinBrowserWidget (AddinRegistry registry)
		{
			TreeView = new AddinTreeView (registry);

			TreeView.Tree.Selection.Mode = SelectionMode.Single;
			TreeView.WidthRequest = 300;

			Pack1 (TreeView, false, false);
			SetDetail (null);

			ShowAll ();

			TreeView.Update ();
		}

		void SetDetail (Widget detail)
		{
			var child2 = Child2;
			if (child2 != null) {
				Remove (child2);
			}

			detail = detail ?? new Label ();
			detail.WidthRequest = 300;
			detail.Show ();

			Pack2 (detail, true, false);
		}

		public void SetToolbar (DocumentToolbar toolbar)
		{
		}
	}
}
