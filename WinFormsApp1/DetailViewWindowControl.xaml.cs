using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Text;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;

namespace WinFormsApp1
{
    public partial class DetailViewWindowControl : UserControl
    {
        public List<string> Strings = new()
        {
            "大小",
            "压缩后大小",
            "文件夹",
            "文件",
            "------------------------",
            "路径",
            "类型",
            "物理大小",
            "CPU",
            "64 位",
            "特征",
            "创建时间",
            "文件头大小",
            "校验和",
            "名称",
            "Image Size",
            "Section Alignment",
            "File Alignment",
            "Code Size",
            "Initialized Data Size",
            "Uninitialized Data Size",
            "Linker Version",
            "OS Version",
            "Image Version",
            "Subsystem Version",
            "Subsystem",
            "DLL Characteristics",
            "Stack Reserve",
            "Stack Commit",
            "Heap Reserve",
            "Heap Commit",
            "Image Base",
            "注释",
            "------------------------",
            "------------------------",
            "路径"
        };

        public List<string> Values = new()
        {
            "14 163 808",
            "14 163 808",
            "4",
            "14",
            "",
            @"C:\windows\system32\shell32.dll",
            "PE",
            "14 164 544",
            "ARM64",
            "+",
            "Executable DLL LargeAddress",
            "1978-01-11 22:46:32",
            "1 024",
            "14228472",
            "SHELL32.DLL",
            "14106624",
            "4096",
            "512",
            "10812928",
            "3269120",
            "0",
            "14.38",
            "10.0",
            "10.0",
            "10.0",
            "Windows GUI",
            "HighEntropyVA Relocated NX-Compatible GuardCF",
            "262144",
            "4096",
            "1048576",
            "4096",
            "6442450944",
            "FileVersion: 10.0.26100.560\nFileVersion: 10.0.26100.560 (WinBuild.160101.0800)\nProductVersion: 10.0.26100.560\nCompanyName: Microsoft Corporation\nFileDescription: Windows Shell Common Dll\nInternalName: SHELL32\nLegalCopyright: © Microsoft Corporation. All rights reserved.\nOriginalFilename: SHELL32.DLL\nProductName: Microsoft® Windows® Operating System",
            "",
            "",
            @".rsrc\TYPELIB\1",
            ""
        };

        public List<KeyValuePair<string, string>> keyValuePairs = new();

        const string Separator = "------------------------";

        public DetailViewWindowControl()
        {
            this.InitializeComponent();
            for (int i = 0; i < Strings.Count; i++)
            {
                if (Strings[i] == Separator)
                {
                    if (i > 0 && Strings[i-1] == Separator)
                    {
                        continue;
                    }
                    this.textBlock.Blocks.Add(new Paragraph());
                    continue;
                }
                var keyPara = new Paragraph()
                {
                    FontWeight = FontWeights.SemiBold,
                    Inlines = {
                        new Run { Text = Strings[i] }
                    }
                };
                var valuePara = new Paragraph()
                {
                    Margin = new Windows.UI.Xaml.Thickness(8, 0, 0, 8),
                    Inlines = {
                        new Run { Text = Values[i] }
                    }
                };

                this.textBlock.Blocks.Add(keyPara);
                this.textBlock.Blocks.Add(valuePara);
            }

            
        }
    }
}
