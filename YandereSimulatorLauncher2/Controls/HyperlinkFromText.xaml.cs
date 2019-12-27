﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace YandereSimulatorLauncher2.Controls
{
    /// <summary>
    /// Interaction logic for HyperlinkFromText.xaml
    /// </summary>
    public partial class HyperlinkFromText : UserControl
    {
        #region XAML Properties
        public static readonly DependencyProperty DisplayTextProperty = DependencyProperty.Register("DisplayText", typeof(string), typeof(HyperlinkFromText), new PropertyMetadata(string.Empty, DisplayTextChanged));
        public static readonly DependencyProperty LinkedUrlProperty = DependencyProperty.Register("LinkedUrl", typeof(string), typeof(HyperlinkFromText), new PropertyMetadata(string.Empty, LinkedUrlChanged));

        public string DisplayText
        {
            get { return (string)GetValue(DisplayTextProperty); }
            set { SetValue(DisplayTextProperty, value); }
        }

        public string LinkedUrl
        {
            get { return (string)GetValue(LinkedUrlProperty); }
            set { SetValue(LinkedUrlProperty, value); }
        }

        private static void DisplayTextChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if (obj is HyperlinkFromText)
            {
                HyperlinkFromText castControl = obj as HyperlinkFromText;
                castControl.MyDisplayText.Text = castControl.DisplayText;
            }
        }

        private static void LinkedUrlChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            // No effects
        }
        #endregion

        #region C# Properties

        private bool IsButtonPrimed { get; set; } = false;

        #endregion

        public HyperlinkFromText()
        {
            InitializeComponent();
        }

        #region Events

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            IsButtonPrimed = true;
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (IsButtonPrimed == true)
            {
                System.Diagnostics.Process.Start(LinkedUrl);
            }

            IsButtonPrimed = false;
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            IsButtonPrimed = false;
        }

        #endregion
    }
}
