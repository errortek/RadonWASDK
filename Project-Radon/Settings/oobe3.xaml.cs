﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.Windows.System;
using Windows.UI.ViewManagement;
using Windows.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Project_Radon.Settings
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class oobe3 : Page
    {
        public oobe3()
        {
            this.InitializeComponent();

            // Title bar code-behind
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;

            // Set XAML element as a drag region.
            App.Window.SetTitleBar(titleBar);
            // TODO Windows.UI.ViewManagement.ApplicationView is no longer supported. Use Microsoft.UI.Windowing.AppWindow instead. For more details see https://docs.microsoft.com/en-us/windows/apps/windows-app-sdk/migrate-to-windows-app-sdk/guides/windowing
            var ititleBar = ApplicationView.GetForCurrentView().TitleBar;
            ititleBar.ButtonBackgroundColor = Colors.Transparent;
            ititleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(oobe4), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(oobe2), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromLeft });
        }

        private void startupPageRadioButtons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (startupPageRadioButtons.SelectedIndex != 2)
            {
                startupCustomURL.IsEnabled = false;
                startupCustomURLError.Visibility = Visibility.Collapsed;
                nextbutton.IsEnabled = true;
            }
            else
            {
                startupCustomURL.IsEnabled = true;

                if (startupCustomURL.Text.Contains(".") && !startupCustomURL.Text.Contains(" "))
                {
                    startupCustomURLError.Visibility = Visibility.Collapsed;
                    startupCustomURL.IsEnabled = true;
                }

                else if (startupCustomURL.Text.Equals(""))
                {
                    startupCustomURLError.Text = "Please enter a URL.";
                    startupCustomURLError.Visibility = Visibility.Visible;
                    nextbutton.IsEnabled = false;
                }
                
                else if (startupCustomURL.Text.Equals("about:blank"))
                {
                    startupCustomURLError.Text = "Consider selecting \"Blank page\" instead.";
                    startupCustomURLError.Visibility = Visibility.Visible;
                    nextbutton.IsEnabled = false;
                }

                else
                {
                    startupCustomURLError.Text = "Invalid URL.";
                    startupCustomURLError.Visibility = Visibility.Visible;
                    nextbutton.IsEnabled = false;
                }
            }
        }

        private void startupCustomURL_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            

            if (startupCustomURL.Text.Contains(".")&&!startupCustomURL.Text.Contains(" "))
            {
                if (startupCustomURL.Text.EndsWith("."))
                {
                    startupCustomURLError.Text = "URL can't end with a period.";
                    startupCustomURLError.Visibility = Visibility.Visible;
                    nextbutton.IsEnabled = false;
                }
                else
                {
                    startupCustomURLError.Visibility = Visibility.Collapsed;
                    startupCustomURL.IsEnabled = true;
                    nextbutton.IsEnabled = true;
                }
            }

            else if(startupCustomURL.Text.Equals(""))
            {
                startupCustomURLError.Text = "Please enter a URL.";
                startupCustomURLError.Visibility = Visibility.Visible;
                nextbutton.IsEnabled = false;
            }

            else if (startupCustomURL.Text.Equals("about:blank"))
            {
                startupCustomURLError.Text = "Consider selecting \"Blank page\" instead.";
                startupCustomURLError.Visibility = Visibility.Visible;
                nextbutton.IsEnabled = false;
            }

            else 
            {
                startupCustomURLError.Text = "Invalid URL.";
                startupCustomURLError.Visibility = Visibility.Visible;
                nextbutton.IsEnabled = false;
            }
        }       
    }
}
