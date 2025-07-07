﻿using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Forms; // Добавь ссылку на System.Windows.Forms
using System.Windows.Input;
using MessageBox = System.Windows.MessageBox;

namespace StylishDownloader
{
    public partial class CustomMessageBox : Window
    {
        public CustomMessageBox(string message)
        {
            InitializeComponent();
            MessageTextBlock.Text = message;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true; // Позволит вызвать ShowDialog и проверить результат
            this.Close();
        }

        // Статический метод для удобного вызова
        public static void Show(string message, Window owner = null)
        {
            var box = new CustomMessageBox(message);
            if (owner != null)
            {
                box.Owner = owner;
            }
            box.ShowDialog();
        }
    }
}
