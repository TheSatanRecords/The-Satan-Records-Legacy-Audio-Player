using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;

namespace The_Satan_Records_Legacy_Audio_Player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Order: Phantom (0), Sewer (1), Neraines (2), Vermin (3), Helgrind (4), Leader (5), Justin Bieber (666), Donald Trump (45).
        public string[] l_bands = new[] { "Phantom", "Sewer", "Neraines", "Vermin", "Helgrind", "Leader" };
        public string[][] l_albums = new string[][] // Let's see if you can follow
        {
            new string[] { "Withdrawal", "Fallen Angel", "The Epilogue to Sanity (Skip this one unless U KRAZY)", "Ascension of Erebos, Leader of the Gods" },
            new string[] { "Miasma", "Khranial", "Skarnage", "Uruktena", "Cathartes" },
            new string[] { "Yggdrasil", "Fenrir Prowling" },
            new string[] { "Bloodthirst Overdose" },
            new string[] { "Demon Rituals" },
            new string[] { "Burzum Sha Ghâsh" },
        };
        public string[][] l_spotify = new string[][] // Let's see if you can follow
        {
            new string[] { "2WsrNjTR3zI1enOEgibJjp", "5bviwevmG1HlNIlT7XVOqH", "4VTFjvMDQfF5Iff8fWoXDZ", "55KuFAxrrvAiUWB8FbK2Zc" },
            new string[] { "6dIOCTOwjkkeGsW9iYKCgW", "2uRhvZNFnzmWbpRGvZCJD9", "32xIur5y5OC9mAmGisZ7iv", "Uruktena", "6dSaXSqjmlrZwPQ9FNXPrq" },
            new string[] { "3yQKuOi6gVEdntTNn1ZTqf", "2tWK3dI8kJTWd60edhBWjm" },
            new string[] { "77NmzFO92nqD1LlF4uIbEs" },
            new string[] { "34q9SONPXSqyzZZofsawDi" },
            new string[] { "6nJHIJ9NUG7bEWerp0RS0R" },
        };
        public int current_band = 0;
        public int current_album = 0;
        public WebView2 web = new WebView2();

        public MainWindow()
        {
            InitializeComponent();
            foreach (string band in l_bands) // List all The Satan Records bands
            {
                bands.Items.Add(band);
            }
            gr.Children.Add(web);
        }

        public void bands_double(object sender, MouseButtonEventArgs e)
        {
            current_band = bands.SelectedIndex;
            albums.Items.Clear();
            foreach (string album in l_albums[current_band])
            {
                albums.Items.Add(album.ToString());
            }
        }

        public async void albums_double(object sender, MouseButtonEventArgs e)
        {
            current_album = albums.SelectedIndex;
            string html = File.ReadAllText("tsr-html.txt");
            html = html.Replace("$$$", l_spotify[current_band][current_album]);

            await web.EnsureCoreWebView2Async();
            web.NavigateToString(html);
        }
    }
}
