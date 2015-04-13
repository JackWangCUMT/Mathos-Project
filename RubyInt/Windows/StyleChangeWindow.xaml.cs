﻿using System.IO;
using System.Linq;
using System.Windows;
using Application = System.Windows.Forms.Application;

namespace RubyInt.Windows
{
    public partial class StyleChangeWindow
    {
        public StyleChangeWindow()
        {
            InitializeComponent();
        }

        private void StyleChangeWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            foreach (
                var style in
                    Directory.GetFiles(Settings.StyleDirectory)
                        .Where(s =>
                        {
                            var extension = Path.GetExtension(s);
                            return extension != null && extension.ToLower() == ".xshd";
                        }))
            {
                StyleBox.Items.Add(Path.GetFileNameWithoutExtension(style));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var style = StyleBox.SelectedItem.ToString().Trim().ToLower();

            File.WriteAllText(Settings.DataDirectory + "style.txt", style.Substring(style.IndexOf(':') + 1));
            Application.Restart();
            System.Windows.Application.Current.Shutdown(0);
        }
    }
}
