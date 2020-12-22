using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ActiveSnsUsingKakaoTalk
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            #region Style
            // Border 
            Style StyleBorder = new Style(typeof(Border));
            StyleBorder.Setters.Add(new Setter { Property = Border.BackgroundProperty, Value = Brushes.LightCyan });
            StyleBorder.Setters.Add(new Setter { Property = Border.MarginProperty, Value = new Thickness(1, 1, 1, 1) });
            StyleBorder.Setters.Add(new Setter { Property = Border.BorderThicknessProperty, Value = new Thickness(1) });
            StyleBorder.Setters.Add(new Setter { Property = Border.BorderBrushProperty, Value = Brushes.Black });
            this.Resources.Add("StyleBorder", StyleBorder);

            // Button
            Style StyleDarkButton = new Style(typeof(Button));
            StyleDarkButton.Setters.Add(new Setter { Property = Button.BackgroundProperty, Value = Brushes.DarkCyan });
            StyleDarkButton.Setters.Add(new Setter { Property = Button.BorderThicknessProperty, Value = new Thickness(1) });
            StyleDarkButton.Setters.Add(new Setter { Property = Button.HeightProperty, Value = Convert.ToDouble(25) });
            StyleDarkButton.Setters.Add(new Setter { Property = Button.MarginProperty, Value = new Thickness(1, 1, 1, 1) });
            StyleDarkButton.Setters.Add(new Setter { Property = Button.BorderBrushProperty, Value = Brushes.Black });
            StyleDarkButton.Setters.Add(new Setter { Property = Button.IsEnabledProperty, Value = false });
            this.Resources.Add("StyleButton", StyleDarkButton);

            // CheckBox
            Style StyleCheckBox = new Style(typeof(CheckBox));
            StyleCheckBox.Setters.Add(new Setter { Property = CheckBox.MarginProperty, Value = new Thickness(0, 5, 0, 0) });
            StyleCheckBox.Setters.Add(new Setter { Property = CheckBox.IsCheckedProperty, Value = true });
            this.Resources.Add("StyleCheckBox", StyleCheckBox);

            // Grid - Header
            Style StyleGrayGrid = new Style(typeof(Grid));
            StyleGrayGrid.Setters.Add(new Setter { Property = Grid.BackgroundProperty, Value = Brushes.LightGray });
            this.Resources.Add("StyleGrayGrid", StyleGrayGrid);

            // Grid - Normal
            Style StyleCyanGrid = new Style(typeof(Grid));
            StyleCyanGrid.Setters.Add(new Setter { Property = Window.BackgroundProperty, Value = Brushes.DarkCyan });
            this.Resources.Add("StyleCyanGrid", StyleCyanGrid);

            Style StyleBodyGrid = new Style(typeof(Grid));
            StyleBodyGrid.Setters.Add(new Setter { Property = Grid.BackgroundProperty, Value = Brushes.LightCyan });
            this.Resources.Add("StyleBodyGrid", StyleBodyGrid);

            // Image 
            Style StyleImage = new Style(typeof(Image));
            this.Resources.Add("StyleImage", StyleImage);

            // Label - Bold
            Style StyleBoldLabel = new Style(typeof(Label));
            StyleBoldLabel.Setters.Add(new Setter { Property = Label.FontWeightProperty, Value = FontWeights.Bold });
            StyleBoldLabel.Setters.Add(new Setter { Property = Label.FontSizeProperty, Value = Convert.ToDouble(20) });
            StyleBoldLabel.Setters.Add(new Setter { Property = Label.HorizontalContentAlignmentProperty, Value = HorizontalAlignment.Left });
            StyleBoldLabel.Setters.Add(new Setter { Property = Label.HorizontalAlignmentProperty, Value = HorizontalAlignment.Stretch });
            StyleBoldLabel.Setters.Add(new Setter { Property = Label.BackgroundProperty, Value = Brushes.Transparent });
            StyleBoldLabel.Setters.Add(new Setter { Property = Label.ForegroundProperty, Value = Brushes.Black });
            StyleBoldLabel.Setters.Add(new Setter { Property = Label.HeightProperty, Value = Convert.ToDouble(40) });
            this.Resources.Add("StyleBoldLabel", StyleBoldLabel);

            // Label - Normal
            Style StyleLabel = new Style(typeof(Label));
            StyleLabel.Setters.Add(new Setter { Property = Label.FontWeightProperty, Value = FontWeights.Normal });
            StyleLabel.Setters.Add(new Setter { Property = Label.FontSizeProperty, Value = Convert.ToDouble(12) });
            StyleLabel.Setters.Add(new Setter { Property = Label.HorizontalContentAlignmentProperty, Value = HorizontalAlignment.Right });
            StyleLabel.Setters.Add(new Setter { Property = Label.HorizontalAlignmentProperty, Value = HorizontalAlignment.Stretch });
            StyleLabel.Setters.Add(new Setter { Property = Label.BackgroundProperty, Value = Brushes.Transparent });
            StyleLabel.Setters.Add(new Setter { Property = Label.ForegroundProperty, Value = Brushes.Black });
            StyleLabel.Setters.Add(new Setter { Property = Label.HeightProperty, Value = Convert.ToDouble(30) });
            this.Resources.Add("StyleLabel", StyleLabel);

            // ListBox 
            Style StyleListBox = new Style(typeof(ListBox));
            this.Resources.Add("StyleListBox", StyleListBox);

            // PasswordBox
            Style StylePassword = new Style(typeof(PasswordBox));
            StylePassword.Setters.Add(new Setter { Property = PasswordBox.VerticalContentAlignmentProperty, Value = VerticalAlignment.Center });
            StylePassword.Setters.Add(new Setter { Property = PasswordBox.MarginProperty, Value = new Thickness(1, 1, 1, 1) });
            this.Resources.Add("StylePassword", StylePassword);

            // TextBlock
            Style StyleTextBlock = new Style(typeof(TextBlock));
            StyleTextBlock.Setters.Add(new Setter { Property = TextBlock.HorizontalAlignmentProperty, Value = HorizontalAlignment.Stretch });
            StyleTextBlock.Setters.Add(new Setter { Property = TextBlock.VerticalAlignmentProperty, Value = VerticalAlignment.Top });
            StyleTextBlock.Setters.Add(new Setter { Property = TextBlock.MarginProperty, Value = new Thickness(1, 1, 1, 1) });
            this.Resources.Add("StyleTextBlock", StyleTextBlock);

            // TextBox
            Style StyleTextBox = new Style(typeof(TextBox));
            StyleTextBox.Setters.Add(new Setter { Property = TextBox.BackgroundProperty, Value = Brushes.LightGray });
            StyleTextBox.Setters.Add(new Setter { Property = TextBox.HorizontalContentAlignmentProperty, Value = HorizontalAlignment.Left });
            StyleTextBox.Setters.Add(new Setter { Property = TextBox.VerticalContentAlignmentProperty, Value = VerticalAlignment.Center });
            this.Resources.Add("StyleTextBox", StyleTextBox);

            // TextBox - Wrapping 
            Style StyleWrappingTextBox = new Style(typeof(TextBox));
            StyleWrappingTextBox.Setters.Add(new Setter { Property = TextBox.BackgroundProperty, Value = Brushes.AntiqueWhite });
            StyleWrappingTextBox.Setters.Add(new Setter { Property = TextBox.TextWrappingProperty, Value = TextWrapping.Wrap });
            StyleWrappingTextBox.Setters.Add(new Setter { Property = TextBox.AcceptsReturnProperty, Value = true });
            StyleWrappingTextBox.Setters.Add(new Setter { Property = TextBox.HorizontalContentAlignmentProperty, Value = HorizontalAlignment.Left });
            StyleWrappingTextBox.Setters.Add(new Setter { Property = TextBox.VerticalContentAlignmentProperty, Value = VerticalAlignment.Top });
            StyleWrappingTextBox.Setters.Add(new Setter { Property = TextBox.VerticalScrollBarVisibilityProperty, Value = ScrollBarVisibility.Auto });
            StyleWrappingTextBox.Setters.Add(new Setter { Property = TextBox.HorizontalScrollBarVisibilityProperty, Value = ScrollBarVisibility.Auto });
            this.Resources.Add("StyleWrappingTextBox", StyleWrappingTextBox);

            // TreeViewItem - Bold
            Style StyleTviChapter = new Style(typeof(TreeViewItem));
            StyleTviChapter.Setters.Add(new Setter { Property = TreeViewItem.FontWeightProperty, Value = FontWeights.Bold });
            StyleTviChapter.Setters.Add(new Setter { Property = TreeViewItem.FontSizeProperty, Value = Convert.ToDouble(14) });
            StyleTviChapter.Setters.Add(new Setter { Property = TreeViewItem.HorizontalContentAlignmentProperty, Value = HorizontalAlignment.Left });
            StyleTviChapter.Setters.Add(new Setter { Property = TreeViewItem.VerticalContentAlignmentProperty, Value = VerticalAlignment.Center });
            this.Resources.Add("StyleTviChapter", StyleTviChapter);

            // TreeViewItem - Normal
            Style StyleTviSubChapter = new Style(typeof(TreeViewItem));
            StyleTviSubChapter.Setters.Add(new Setter { Property = TreeViewItem.FontWeightProperty, Value = FontWeights.Normal });
            StyleTviSubChapter.Setters.Add(new Setter { Property = TreeViewItem.FontSizeProperty, Value = Convert.ToDouble(14) });
            StyleTviSubChapter.Setters.Add(new Setter { Property = TreeViewItem.HorizontalContentAlignmentProperty, Value = HorizontalAlignment.Left });
            StyleTviSubChapter.Setters.Add(new Setter { Property = TreeViewItem.VerticalContentAlignmentProperty, Value = VerticalAlignment.Center });
            this.Resources.Add("StyleTviSubChapter", StyleTviSubChapter);

            // Stack Panel
            Style StyleGrayStackPanel = new Style(typeof(StackPanel));
            StyleGrayStackPanel.Setters.Add(new Setter { Property = Window.BackgroundProperty, Value = Brushes.LightGray });
            this.Resources.Add("StyleDarkStackPanel", StyleGrayStackPanel);

            Style StyleCyanStackPanel = new Style(typeof(StackPanel));
            StyleCyanStackPanel.Setters.Add(new Setter { Property = Window.BackgroundProperty, Value = Brushes.LightCyan });
            this.Resources.Add("StyleStackPanel", StyleCyanStackPanel);

            // Window
            Style StyleWindow = new Style(typeof(Window));
            StyleWindow.Setters.Add(new Setter { Property = Window.HeightProperty, Value = Convert.ToDouble(768) });
            StyleWindow.Setters.Add(new Setter { Property = Window.WidthProperty, Value = Convert.ToDouble(1024) });
            this.Resources.Add("StyleWindow", StyleWindow);

            #endregion


            #region ControlTemplate

            #endregion
        }
    }
}
