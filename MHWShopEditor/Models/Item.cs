using System;
namespace MHWShopEditor.Models
{
    public class Item
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public int Hex { get { return Convert.ToInt32(this.Key.Substring(4), 16); } }
        public override string ToString()
        {
            return Value;
        }
    }
}
