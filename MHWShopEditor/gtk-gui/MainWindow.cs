
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;

	private global::Gtk.Action FileAction;

	private global::Gtk.Action SaveAction;

	private global::Gtk.Action OpenAction;

	private global::Gtk.Action SaveAction1;

	private global::Gtk.VBox vbox1;

	private global::Gtk.MenuBar menubar2;

	private global::Gtk.VBox vbox4;

	private global::Gtk.HBox hbox1;

	private global::Gtk.Label label1;

	private global::Gtk.Entry entry2;

	private global::Gtk.HBox hbox2;

	private global::Gtk.ScrolledWindow GtkScrolledWindow;

	private global::Gtk.TreeView treeview1;

	private global::Gtk.VBox vbox2;

	private global::Gtk.VBox vbox3;

	private global::Gtk.Button button6;

	private global::Gtk.Button button7;

	private global::Gtk.Button button8;

	private global::Gtk.ScrolledWindow GtkScrolledWindow1;

	private global::Gtk.TreeView treeview2;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup("Default");
		this.FileAction = new global::Gtk.Action("FileAction", global::Mono.Unix.Catalog.GetString("File"), null, null);
		this.FileAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Open");
		w1.Add(this.FileAction, null);
		this.SaveAction = new global::Gtk.Action("SaveAction", global::Mono.Unix.Catalog.GetString("Save"), null, null);
		this.SaveAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Save");
		w1.Add(this.SaveAction, null);
		this.OpenAction = new global::Gtk.Action("OpenAction", global::Mono.Unix.Catalog.GetString("Open"), null, null);
		this.OpenAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Open");
		w1.Add(this.OpenAction, null);
		this.SaveAction1 = new global::Gtk.Action("SaveAction1", global::Mono.Unix.Catalog.GetString("Save"), null, null);
		this.SaveAction1.ShortLabel = global::Mono.Unix.Catalog.GetString("Save");
		w1.Add(this.SaveAction1, null);
		this.UIManager.InsertActionGroup(w1, 0);
		this.AddAccelGroup(this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString("<ui><menubar name=\'menubar2\'><menu name=\'FileAction\' action=\'FileAction\'><menuite" +
				"m name=\'OpenAction\' action=\'OpenAction\'/><menuitem name=\'SaveAction1\' action=\'Sa" +
				"veAction1\'/></menu></menubar></ui>");
		this.menubar2 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget("/menubar2")));
		this.menubar2.Name = "menubar2";
		this.vbox1.Add(this.menubar2);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.menubar2]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.vbox4 = new global::Gtk.VBox();
		this.vbox4.Name = "vbox4";
		this.vbox4.Spacing = 6;
		// Container child vbox4.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.label1 = new global::Gtk.Label();
		this.label1.Name = "label1";
		this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Search");
		this.hbox1.Add(this.label1);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.label1]));
		w3.Position = 0;
		w3.Expand = false;
		w3.Fill = false;
		// Container child hbox1.Gtk.Box+BoxChild
		this.entry2 = new global::Gtk.Entry();
		this.entry2.CanFocus = true;
		this.entry2.Name = "entry2";
		this.entry2.IsEditable = true;
		this.entry2.InvisibleChar = '•';
		this.hbox1.Add(this.entry2);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.entry2]));
		w4.Position = 1;
		this.vbox4.Add(this.hbox1);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbox1]));
		w5.Position = 0;
		w5.Expand = false;
		w5.Fill = false;
		this.vbox1.Add(this.vbox4);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.vbox4]));
		w6.Position = 1;
		w6.Expand = false;
		w6.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox2 = new global::Gtk.HBox();
		this.hbox2.HeightRequest = 500;
		this.hbox2.Name = "hbox2";
		this.hbox2.Spacing = 6;
		// Container child hbox2.Gtk.Box+BoxChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.treeview1 = new global::Gtk.TreeView();
		this.treeview1.CanFocus = true;
		this.treeview1.Name = "treeview1";
		this.GtkScrolledWindow.Add(this.treeview1);
		this.hbox2.Add(this.GtkScrolledWindow);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.GtkScrolledWindow]));
		w8.Position = 0;
		// Container child hbox2.Gtk.Box+BoxChild
		this.vbox2 = new global::Gtk.VBox();
		this.vbox2.Name = "vbox2";
		this.vbox2.Spacing = 6;
		// Container child vbox2.Gtk.Box+BoxChild
		this.vbox3 = new global::Gtk.VBox();
		this.vbox3.Name = "vbox3";
		this.vbox3.Spacing = 6;
		// Container child vbox3.Gtk.Box+BoxChild
		this.button6 = new global::Gtk.Button();
		this.button6.CanFocus = true;
		this.button6.Name = "button6";
		this.button6.UseUnderline = true;
		this.button6.Label = global::Mono.Unix.Catalog.GetString(">>>");
		this.vbox3.Add(this.button6);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.button6]));
		w9.Position = 0;
		w9.Expand = false;
		w9.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.button7 = new global::Gtk.Button();
		this.button7.CanFocus = true;
		this.button7.Name = "button7";
		this.button7.UseUnderline = true;
		this.button7.Label = global::Mono.Unix.Catalog.GetString("<<<");
		this.vbox3.Add(this.button7);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.button7]));
		w10.Position = 1;
		w10.Expand = false;
		w10.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.button8 = new global::Gtk.Button();
		this.button8.CanFocus = true;
		this.button8.Name = "button8";
		this.button8.UseUnderline = true;
		this.button8.Label = global::Mono.Unix.Catalog.GetString("GtkButton");
		this.vbox3.Add(this.button8);
		global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.button8]));
		w11.Position = 2;
		w11.Expand = false;
		w11.Fill = false;
		this.vbox2.Add(this.vbox3);
		global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.vbox3]));
		w12.Position = 1;
		w12.Expand = false;
		w12.Fill = false;
		this.hbox2.Add(this.vbox2);
		global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.vbox2]));
		w13.Position = 1;
		w13.Expand = false;
		w13.Fill = false;
		// Container child hbox2.Gtk.Box+BoxChild
		this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow();
		this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
		this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
		this.treeview2 = new global::Gtk.TreeView();
		this.treeview2.CanFocus = true;
		this.treeview2.Name = "treeview2";
		this.GtkScrolledWindow1.Add(this.treeview2);
		this.hbox2.Add(this.GtkScrolledWindow1);
		global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.GtkScrolledWindow1]));
		w15.Position = 2;
		this.vbox1.Add(this.hbox2);
		global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox2]));
		w16.Position = 2;
		this.Add(this.vbox1);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 663;
		this.DefaultHeight = 597;
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
		this.OpenAction.Activated += new global::System.EventHandler(this.OpenFile);
		this.SaveAction1.Activated += new global::System.EventHandler(this.SaveFile);
		this.entry2.Activated += new global::System.EventHandler(this.SearchInput);
		this.button6.Clicked += new global::System.EventHandler(this.Button_AddToOutBox);
		this.button7.Clicked += new global::System.EventHandler(this.Button_RemoveFromOutBox);
	}
}
