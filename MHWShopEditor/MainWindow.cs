using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using MHWShopEditor.Data;
using Gtk;
using System.IO;

public partial class MainWindow : Gtk.Window
{
    private static List<MHWShopEditor.Models.Item> listBoxIn = new List<MHWShopEditor.Models.Item>();
    private static List<MHWShopEditor.Models.Item> listBoxOut = new List<MHWShopEditor.Models.Item>();

    private static Gtk.ListStore inListStore = new Gtk.ListStore(typeof(string));
    private static Gtk.ListStore outListStore = new Gtk.ListStore(typeof(string));

    private static string selectedItemIn;
    private static string selectedItemOut;

    //public event PropertyChangedEventHandler PropertyChanged;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();

        //Tree View 1 Stuff
        var inListColumn = new Gtk.TreeViewColumn
        {
            Title = "Available Items"
        };

        var inListCell = new Gtk.CellRendererText();

        inListColumn.PackStart(inListCell, true);

        treeview1.AppendColumn(inListColumn);

        inListColumn.AddAttribute(inListCell, "text", 0);

        treeview1.Model = inListStore;

        //Tree View 2 Stuff
        var outListColumn = new Gtk.TreeViewColumn
        {
            Title = "Shop Items"
        };

        var outListCell = new Gtk.CellRendererText();

        outListColumn.PackStart(outListCell, true);

        treeview2.AppendColumn(outListColumn);
        outListColumn.AddAttribute(outListCell, "text", 0);

        treeview2.Model = outListStore;

        PopulateDefaultBoxes();

        //Events
        treeview1.Selection.Changed += InRowChange;
        treeview2.Selection.Changed += OutRowChange;
    }

    private void PopulateDefaultBoxes()
    {
        listBoxIn = Constants.MasterList;
        listBoxOut.Clear();
        Refresh();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void OpenFile(object sender, EventArgs e)
    {
        var dlg = new FileChooserDialog("Select Shop File", null, FileChooserAction.Open, "Open", ResponseType.Accept, "Cancel", ResponseType.Cancel);
        var response = (Gtk.ResponseType)dlg.Run();
        if (response == Gtk.ResponseType.Accept)
        {
            var fileName = dlg.Filename;
            byte[] input = System.IO.File.ReadAllBytes(fileName);
            byte[] buffer = new byte[2];
            List<string> items = new List<string>();
            for (int i = 10; i < input.Length - 1; i += 12)
            {
                buffer[0] = input[i + 1];
                buffer[1] = input[i];
                items.Add(BitConverter.ToString(buffer).Replace("-", ""));
            }
            dlg.Destroy();
            PopulateOutBox(items);
        }
    }

    protected async void SaveFile(object sender, EventArgs e)
    {
        Stream fs;
        //Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog()
        var dlg = new FileChooserDialog("Save Shop File", null, FileChooserAction.Save, "Save", ResponseType.Accept, "Cancel", ResponseType.Cancel);
        var response = (Gtk.ResponseType)dlg.Run();

        if (response == Gtk.ResponseType.Accept)
        {
            var fileName = dlg.Filename;
            if (!string.IsNullOrEmpty(fileName))
            {
                fs = File.Create(fileName);
                //Properties.Settings.Default.SaveDirectory = System.IO.Path.GetDirectoryName(dlg.FileName);
                //Properties.Settings.Default.Save();
                byte[] header = new byte[] { 0x18, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                byte[] buffer = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                List<byte> items = header.ToList();
                foreach (MHWShopEditor.Models.Item item in listBoxOut)
                {
                    string hex = item.Key.Substring(4);
                    items.Add(Convert.ToByte(int.Parse(hex.Substring(2), System.Globalization.NumberStyles.HexNumber)));
                    items.Add(Convert.ToByte(int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber)));
                    items.AddRange(buffer);
                }
                byte[] output = items.ToArray();
                await fs.WriteAsync(output, 0, output.Length);
                fs.Close();
                dlg.Destroy();
            }
        }
    }

    private void PopulateOutBox(List<string> items)
    {
        var newList = new List<MHWShopEditor.Models.Item>();
        foreach (var item in items)
        {
            Console.WriteLine("Looking for key: " + item);
            var name = Constants.MasterList.Where(x => x.Key == "item" + item).SingleOrDefault();
            if (name != null) newList.Add(name);
        }
        listBoxOut = newList;
        foreach (var x in listBoxOut) Console.WriteLine(x.Value);
        Refresh();
    }

    private void TooManyItemsError()
    {
        var msg = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, "Too many items in the output box! Can't load this preset,");
    }

    public void Refresh()
    {
        //Sort lists
        SortLists();

        //outList
        outListStore.Clear();
        foreach (var outItem in listBoxOut)
        {
            outListStore.AppendValues(outItem.Value);
        }

        //inList
        inListStore.Clear();
        IntersectLists();
        foreach (var inItem in listBoxIn)
        {
            inListStore.AppendValues(inItem.Value);
        }
    }

    protected void SearchInput(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(entry2.Text.Trim()))
        {
            var input = entry2.Text;
            var filteredInput = listBoxIn.Where(x => x.Value.ToLower().Contains(input.ToLower())).ToList();
            listBoxIn = filteredInput;
        }
        else listBoxIn = Constants.MasterList;

        Refresh();
    }

    private void IntersectLists()
    {
        //Remove outBox items from inBox
        foreach (var outItem in listBoxOut)
        {
            listBoxIn.Remove(outItem);
        }
    }

    protected void Button_AddToOutBox(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(selectedItemIn)) return;
        //Find Item
        var addItem = listBoxIn.FirstOrDefault(x => x.Value.ToLower() == selectedItemIn.ToLower());
        if (addItem != null)
        {
            listBoxOut.Add(addItem);
        }

        Refresh();
    }

    protected void Button_RemoveFromOutBox(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(selectedItemOut)) return;
        //Find Item
        var remItem = listBoxOut.FirstOrDefault(x => x.Value.ToLower() == selectedItemOut.ToLower());
        if (remItem != null)
        {
            listBoxOut.Remove(remItem);
            listBoxIn.Add(remItem);
        }

        Refresh();
    }

    private static void InRowChange(object o, EventArgs args)
    {
        selectedItemIn = HandleRowChange(o, args);
    }

    private static void OutRowChange(object o, EventArgs args)
    {
        selectedItemOut = HandleRowChange(o, args);
    }

    private static string HandleRowChange(object o, EventArgs args)
    {
        if (((TreeSelection)o).GetSelected(out TreeModel model, out TreeIter iter))
        {
            return model.GetValue(iter, 0).ToString();
        }
        return string.Empty;
    }

    private static void SortLists()
    {
        listBoxIn = listBoxIn.OrderBy(x => x.Value).ToList();
        listBoxOut = listBoxOut.OrderBy(x => x.Value).ToList();
    }
}
