using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WebApp.Data.Enum
{
    public enum Color
    {
        [Description("Màu trắng")]
        White,
        [Description("Màu xanh da trời")]
        Blue,
        [Description("Màu đỏ")]
        Red,
        [Description("Màu xanh")]
        Green,
    }
}
