using Android.App;
using Android.OS;
using CSharpExtendedCommands.DataTypeExtensions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Xamarin.Forms;
using static CSharpExtendedCommands.Maths;
namespace Get_Root_Of
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public static Activity AppContext { get; set; }
        public List<Item> listItems { get; private set; }
        public MainPage()
        {
            InitializeComponent();
            listItems = new List<Item>();
            listItems.AddRange(new Item[] { "" });
            BindingContext = this;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
        Thread t;
        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcRoot();
        }
        void GetRoot()
        {
            Looper.Prepare();
            if (!(!string.IsNullOrEmpty(entryBox.Text) && !(string.IsNullOrEmpty(indexBox.Text))) && entryBox.Text != "0")
                return;
            var et = entryBox.Text;
            var entry = et.ToLong();
            var root = RootOfAsString(entry, indexBox.Text.ToInt(), 13);
            listItems[0] = entry > 0 ? root : "Invalid entry or value to big";
            Device.BeginInvokeOnMainThread(delegate ()
            {
                list.ItemsSource = null;
                list.ItemsSource = listItems;
            });
        }
        void CalcRoot()
        {
            t?.Abort();
            t = new Thread(new ThreadStart(GetRoot));
            t.Start();
        }
        private void indexBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcRoot();
        }
    }
    public class Item
    {
        public Item(string v)
        {
            Value = v;
        }

        public string Value { get; }

        public override string ToString()
        {
            return Value;
        }
        public static bool operator ==(Item v1, string v2)
        {
            return v1.Value == v2;
        }
        public static bool operator !=(Item v1, string v2)
        {
            return !(v1 == v2);
        }
        public static implicit operator Item(string v)
        {
            return new Item(v);
        }
    }
}
