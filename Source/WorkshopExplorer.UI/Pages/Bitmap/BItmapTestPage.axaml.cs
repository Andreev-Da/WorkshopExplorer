using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Avalonia.Controls;

namespace SteamWorkshopExplorer.Pages.Bitmap;

public partial class BitmapTestPage : UserControl
{
    public BitmapTestPage()
    {
        InitializeComponent();
    }
    //
    // protected override void OnInitialized()
    // {
    //     using Stream file = File.OpenRead(@"D:\Junk\Solutions\Bitmap.zip");
    //     ZipArchive archive = new ZipArchive(file);
    //     using Stream image = archive.Entries.First().Open();
    //     using MemoryStream memory = new MemoryStream();
    //     image.CopyTo(memory);
    //     memory.Seek(0, SeekOrigin.Begin);
    //     using Avalonia.Media.Imaging.Bitmap bitmap = new Avalonia.Media.Imaging.Bitmap(memory);
    //     this.GetControl<Image>("TestImage").Source = bitmap;
    // }
}