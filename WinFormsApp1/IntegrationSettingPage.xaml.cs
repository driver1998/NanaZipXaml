using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace WinFormsApp1
{

    public class ContextMenuSettingItem
    {
        public string Name { get; set; } = "";
        public bool Value { get; set; }

        public ContextMenuSettingItem(string name, bool value = true)
        {
            Name = name;
            Value = value;
        }
    }

    public partial class IntegrationSettingPage : Page
    {
        public List<ContextMenuSettingItem> ContextMenuItems { get; set; }

        public IntegrationSettingPage()
        {
            ContextMenuItems = new List<ContextMenuSettingItem>
            {
                new ContextMenuSettingItem("打开压缩包"),
                new ContextMenuSettingItem("测试压缩包"),
                new ContextMenuSettingItem("提取文件..."),
                new ContextMenuSettingItem("提取到当前位置"),
                new ContextMenuSettingItem("提取到 <文件夹>"),
                new ContextMenuSettingItem("添加到压缩包..."),
                new ContextMenuSettingItem("添加到 <档案>.7z"),
                new ContextMenuSettingItem("添加到 <档案>.zip"),
                new ContextMenuSettingItem("压缩并邮寄..."),
                new ContextMenuSettingItem("压缩到 <档案>.7z 并邮寄"),
                new ContextMenuSettingItem("压缩到 <档案>.zip 并邮寄"),
                new ContextMenuSettingItem("HASH"),
            };

            this.InitializeComponent();

            btnItem.Click += async (s, e) =>
            {
                await this.contextMenuItemDialog.ShowAsync();
            };
        }
    }
}
