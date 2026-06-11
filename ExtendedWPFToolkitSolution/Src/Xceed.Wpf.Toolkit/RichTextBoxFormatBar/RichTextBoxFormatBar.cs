/*************************************************************************************
   
   Toolkit for WPF

   Copyright (C) 2007-2025 Xceed Software Inc.

   This program is provided to you under the terms of the XCEED SOFTWARE, INC.
   COMMUNITY LICENSE AGREEMENT (for non-commercial use) as published at 
   https://github.com/xceedsoftware/wpftoolkit/blob/master/license.md 

   For more features, controls, and fast professional support,
   pick up the Plus Edition at https://xceed.com/xceed-toolkit-plus-for-wpf/

   Stay informed: follow @datagrid on Twitter or Like http://facebook.com/datagrids

  ***********************************************************************************/

using System.Linq;
using System.Windows.Controls;
using System.Windows;
using Xceed.Wpf.Toolkit.Core.Utilities;
using System.Windows.Media;
using System.Windows.Documents;
using System.Windows.Controls.Primitives;
using Xceed.Wpf.Toolkit.Core;


namespace Xceed.Wpf.Toolkit
{ 
  public class RichTextBoxFormatBar : Control, IRichTextBoxFormatBar
  {
    #region Members
    private ComboBox m_cmbFontFamilies;
    private ComboBox m_cmbFontSizes;
    private ColorPicker m_cmbFontBackgroundColor;
    private ColorPicker m_cmbFontColor;

    private ToggleButton m_btnNumbers;
    private ToggleButton m_btnBullets;
    private ToggleButton m_btnBold;
    private ToggleButton m_btnItalic;
    private ToggleButton m_btnUnderline;
    private ToggleButton m_btnAlignLeft;
    private ToggleButton m_btnAlignCenter;
    private ToggleButton m_btnAlignRight;

    private Thumb m_dragWidget;
    private bool m_waitingForMouseOver;
    #endregion

    #region Properties

    public static double[] FontSizes
    {
      get
      {
        return new double[] {
                3.0, 4.0, 5.0, 6.0, 6.5, 7.0, 7.5, 8.0, 8.5, 9.0, 9.5,
                10.0, 10.5, 11.0, 11.5, 12.0, 12.5, 13.0, 13.5, 14.0, 15.0,
                16.0, 17.0, 18.0, 19.0, 20.0, 22.0, 24.0, 26.0, 28.0, 30.0,
                32.0, 34.0, 36.0, 38.0, 40.0, 44.0, 48.0, 52.0, 56.0, 60.0, 64.0, 68.0, 72.0, 76.0,
                80.0, 88.0, 96.0, 104.0, 112.0, 120.0, 128.0, 136.0, 144.0
                };
      }
    }















    #endregion

    #region Constructors

    static RichTextBoxFormatBar()
    {
      DefaultStyleKeyProperty.OverrideMetadata( typeof( RichTextBoxFormatBar ), new FrameworkPropertyMetadata( typeof( RichTextBoxFormatBar ) ) );
    }

    public RichTextBoxFormatBar()
    {

      Core.Message.ShowMessage();
    }

    #endregion //Constructors

    #region Base Class Overrides


    #endregion

    #region Event Handlers

    private void FontFamily_SelectionChanged( object sender, SelectionChangedEventArgs e )
    {
      if( e.AddedItems.Count == 0 )
        return;

      var editValue = FontUtilities.GetFontFamily( ( string )e.AddedItems[ 0 ] );
      this.ApplyPropertyValueToSelectedText( TextElement.FontFamilyProperty, editValue );
      m_waitingForMouseOver = true;
    }

    private void FontSize_SelectionChanged( object sender, SelectionChangedEventArgs e )
    {
      if( e.AddedItems.Count == 0 )
        return;

      this.ApplyPropertyValueToSelectedText( TextElement.FontSizeProperty, e.AddedItems[ 0 ] );
      m_waitingForMouseOver = true;
    }

    void FontColor_SelectedColorChanged( object sender, RoutedPropertyChangedEventArgs<Color?> e )
    {
      Color? selectedColor = ( Color? )e.NewValue;
      this.ApplyPropertyValueToSelectedText( TextElement.ForegroundProperty, selectedColor.HasValue ? new SolidColorBrush( selectedColor.Value ) : null );
      m_waitingForMouseOver = true;
    }

    private void FontBackgroundColor_SelectedColorChanged( object sender, RoutedPropertyChangedEventArgs<Color?> e )
    {
      Color? selectedColor = ( Color? )e.NewValue;
      this.ApplyPropertyValueToSelectedText( TextElement.BackgroundProperty, selectedColor.HasValue ? new SolidColorBrush( selectedColor.Value ) : null );
      m_waitingForMouseOver = true;
    }

    private void Bullets_Clicked( object sender, RoutedEventArgs e )
    {
      if( this.BothSelectionListsAreChecked() && ( m_btnNumbers != null ) )
      {
        m_btnNumbers.IsChecked = false;
      }
    }

    private void Numbers_Clicked( object sender, RoutedEventArgs e )
    {
      if( this.BothSelectionListsAreChecked() && ( m_btnBullets != null ) )
      {
        m_btnBullets.IsChecked = false;
      }
    }

    private void DragWidget_DragDelta( object sender, DragDeltaEventArgs e )
    {
      this.ProcessMove( e );
    }

    protected override void OnMouseEnter( System.Windows.Input.MouseEventArgs e )
    {
      base.OnMouseEnter( e );
      m_waitingForMouseOver = false;
    }

    #endregion //Event Handlers

    #region Methods

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();

      if( m_dragWidget != null )
      {
        m_dragWidget.DragDelta -= new DragDeltaEventHandler( this.DragWidget_DragDelta );
      }

      if( m_cmbFontFamilies != null )
      {
        m_cmbFontFamilies.SelectionChanged -= new SelectionChangedEventHandler( this.FontFamily_SelectionChanged );
      }

      if( m_cmbFontSizes != null )
      {
        m_cmbFontSizes.SelectionChanged -= new SelectionChangedEventHandler( this.FontSize_SelectionChanged );
      }

      if( m_btnBullets != null )
      {
        m_btnBullets.Click -= new RoutedEventHandler( this.Bullets_Clicked );
      }

      if( m_btnNumbers != null )
      {
        m_btnNumbers.Click -= new RoutedEventHandler( this.Numbers_Clicked );
      }

      if( m_cmbFontBackgroundColor != null )
      {
        m_cmbFontBackgroundColor.SelectedColorChanged -= new RoutedPropertyChangedEventHandler<Color?>( this.FontBackgroundColor_SelectedColorChanged );
      }

      if( m_cmbFontColor != null )
      {
        m_cmbFontColor.SelectedColorChanged -= new RoutedPropertyChangedEventHandler<Color?>( this.FontColor_SelectedColorChanged );
      }

      this.GetTemplateComponent( ref m_cmbFontFamilies, "_cmbFontFamilies" );
      this.GetTemplateComponent( ref m_cmbFontSizes, "_cmbFontSizes" );
      this.GetTemplateComponent( ref m_cmbFontBackgroundColor, "_cmbFontBackgroundColor" );
      this.GetTemplateComponent( ref m_cmbFontColor, "_cmbFontColor" );
      this.GetTemplateComponent( ref m_btnNumbers, "_btnNumbers" );
      this.GetTemplateComponent( ref m_btnBullets, "_btnBullets" );
      this.GetTemplateComponent( ref m_btnBold, "_btnBold" );
      this.GetTemplateComponent( ref m_btnItalic, "_btnItalic" );
      this.GetTemplateComponent( ref m_btnUnderline, "_btnUnderline" );
      this.GetTemplateComponent( ref m_btnAlignLeft, "_btnAlignLeft" );
      this.GetTemplateComponent( ref m_btnAlignCenter, "_btnAlignCenter" );
      this.GetTemplateComponent( ref m_btnAlignRight, "_btnAlignRight" );
      this.GetTemplateComponent( ref m_dragWidget, "_dragWidget" );

      if( m_dragWidget != null )
      {
        m_dragWidget.DragDelta += new DragDeltaEventHandler( DragWidget_DragDelta );
      }

      if( m_cmbFontFamilies != null )
      {
        m_cmbFontFamilies.ItemsSource = FontUtilities.Families.OrderBy( fontFamily => FontUtilities.GetFontFamilyName( fontFamily ) ).Select( fontFamily => FontUtilities.GetFontFamilyName( fontFamily ) );
        m_cmbFontFamilies.SelectionChanged += new SelectionChangedEventHandler( this.FontFamily_SelectionChanged );
      }

      if( m_cmbFontSizes != null )
      {
        m_cmbFontSizes.ItemsSource = FontSizes;
        m_cmbFontSizes.SelectionChanged += new SelectionChangedEventHandler( this.FontSize_SelectionChanged );
      }

      if( m_btnBullets != null )
      {
        m_btnBullets.Click += new RoutedEventHandler( this.Bullets_Clicked );
      }

      if( m_btnNumbers != null )
      {
        m_btnNumbers.Click += new RoutedEventHandler( this.Numbers_Clicked );
      }

      if( m_cmbFontBackgroundColor != null )
      {
        m_cmbFontBackgroundColor.SelectedColorChanged += new RoutedPropertyChangedEventHandler<Color?>( this.FontBackgroundColor_SelectedColorChanged );
      }

      if( m_cmbFontColor != null )
      {
        m_cmbFontColor.SelectedColorChanged += new RoutedPropertyChangedEventHandler<Color?>( FontColor_SelectedColorChanged );
      }

      this.Update();
    }

    private void GetTemplateComponent<T>( ref T partMember, string partName ) where T : class
    {
      partMember = ( this.Template != null )
        ? this.Template.FindName( partName, this ) as T
        : null;
    }

    private void UpdateToggleButtonState()
    {
      this.UpdateItemCheckedState( m_btnBold, TextElement.FontWeightProperty, FontWeights.Bold );
      this.UpdateItemCheckedState( m_btnItalic, TextElement.FontStyleProperty, FontStyles.Italic );
      this.UpdateItemCheckedState( m_btnUnderline, Inline.TextDecorationsProperty, TextDecorations.Underline );

      this.UpdateItemCheckedState( m_btnAlignLeft, Paragraph.TextAlignmentProperty, TextAlignment.Left );
      this.UpdateItemCheckedState( m_btnAlignCenter, Paragraph.TextAlignmentProperty, TextAlignment.Center );
      this.UpdateItemCheckedState( m_btnAlignRight, Paragraph.TextAlignmentProperty, TextAlignment.Right );
    }

    void UpdateItemCheckedState( ToggleButton button, DependencyProperty formattingProperty, object expectedValue )
    {
      object currentValue = DependencyProperty.UnsetValue;
      if( ( this.Target != null ) && ( this.Target.Selection != null ) )
      {
        currentValue = this.Target.Selection.GetPropertyValue( formattingProperty );
      }

      if( currentValue == DependencyProperty.UnsetValue )
        return;

      if( button != null )
      {
        button.IsChecked = ( currentValue == null )
                            ? false
                            : currentValue != null && currentValue.Equals( expectedValue );
      }
    }

    private void UpdateSelectedFontFamily()
    {
      object value = DependencyProperty.UnsetValue;
      if( ( this.Target != null ) && ( this.Target.Selection != null ) )
      {
        value = this.Target.Selection.GetPropertyValue( TextElement.FontFamilyProperty );
      }

      if( value == DependencyProperty.UnsetValue )
        return;

      FontFamily currentFontFamily = ( FontFamily )value;
      if( ( currentFontFamily != null ) && ( m_cmbFontFamilies != null ) )
      {
        m_cmbFontFamilies.SelectedItem = FontUtilities.GetFontFamilyName( currentFontFamily );
      }
    }

    private void UpdateSelectedFontSize()
    {
      object value = DependencyProperty.UnsetValue;
      if( ( this.Target != null ) && ( this.Target.Selection != null ) )
      {
        value = this.Target.Selection.GetPropertyValue( TextElement.FontSizeProperty );
      }

      if( value == DependencyProperty.UnsetValue )
        return;

      if( m_cmbFontSizes != null )
      {
        m_cmbFontSizes.SelectedValue = value;
      }
    }

    private void UpdateFontColor()
    {
      object value = DependencyProperty.UnsetValue;
      if( ( this.Target != null ) && ( this.Target.Selection != null ) )
      {
        value = this.Target.Selection.GetPropertyValue( TextElement.ForegroundProperty );
      }

      if( value == DependencyProperty.UnsetValue )
        return;

      Color? currentColor = ( ( value == null )
                              ? null
                              : ( Color? )( ( SolidColorBrush )value ).Color );
      if( m_cmbFontColor != null )
      {
        m_cmbFontColor.SelectedColor = currentColor;
      }
    }

    private void UpdateFontBackgroundColor()
    {
      object value = DependencyProperty.UnsetValue;
      if( ( this.Target != null ) && ( this.Target.Selection != null ) )
      {
        value = this.Target.Selection.GetPropertyValue( TextElement.BackgroundProperty );
      }

      if( value == DependencyProperty.UnsetValue )
        return;

      Color? currentColor = ( ( value == null )
                              ? null
                              : ( Color? )( ( SolidColorBrush )value ).Color );
      if( m_cmbFontBackgroundColor != null )
      {
        m_cmbFontBackgroundColor.SelectedColor = currentColor;
      }
    }

    private void UpdateSelectionListType()
    {
      if( ( m_btnNumbers == null ) || ( m_btnBullets == null ) )
        return;

      //uncheck both
      m_btnBullets.IsChecked = false;
      m_btnNumbers.IsChecked = false;

      Paragraph startParagraph = ( ( this.Target != null ) && ( this.Target.Selection != null ) )
                                  ? this.Target.Selection.Start.Paragraph
                                  : null;
      Paragraph endParagraph = ( ( this.Target != null ) && ( this.Target.Selection != null ) )
                                ? this.Target.Selection.End.Paragraph
                                : null;
      if( startParagraph != null && endParagraph != null && ( startParagraph.Parent is ListItem ) && ( endParagraph.Parent is ListItem ) && object.ReferenceEquals( ( ( ListItem )startParagraph.Parent ).List, ( ( ListItem )endParagraph.Parent ).List ) )
      {
        TextMarkerStyle markerStyle = ( ( ListItem )startParagraph.Parent ).List.MarkerStyle;
        if( markerStyle == TextMarkerStyle.Disc )
        {
          m_btnBullets.IsChecked = true;
        }
        else if( markerStyle == TextMarkerStyle.Decimal )
        {
          m_btnNumbers.IsChecked = true;
        }
      }
    }

    private bool BothSelectionListsAreChecked()
    {
      return ( ( m_btnBullets != null ) && ( m_btnBullets.IsChecked == true ) )
          && ( ( m_btnNumbers != null ) && ( m_btnNumbers.IsChecked == true ) );
    }

    void ApplyPropertyValueToSelectedText( DependencyProperty formattingProperty, object value )
    {
      if( ( this.Target == null ) || ( this.Target.Selection == null ) )
        return;

      SolidColorBrush solidColorBrush = value as SolidColorBrush;
      if( ( solidColorBrush != null ) && solidColorBrush.Color.Equals( Colors.Transparent ) )
      {
        this.Target.Selection.ApplyPropertyValue( formattingProperty, null );
      }
      else
      {
        this.Target.Selection.ApplyPropertyValue( formattingProperty, value );
      }
    }

    private void ProcessMove( DragDeltaEventArgs e )
    {
      AdornerLayer layer = AdornerLayer.GetAdornerLayer( this.Target );
      UIElementAdorner<Control> adorner = layer.GetAdorners( this.Target ).OfType<UIElementAdorner<Control>>().First();
      adorner.SetOffsets( adorner.OffsetLeft + e.HorizontalChange, adorner.OffsetTop + e.VerticalChange );
    }

    #endregion //Methods

    #region IRichTextBoxFormatBar Interface

    #region Target

    public static readonly DependencyProperty TargetProperty = DependencyProperty.Register( nameof( Target ), typeof( global::System.Windows.Controls.RichTextBox ), typeof( RichTextBoxFormatBar ), new PropertyMetadata( null, OnRichTextBoxPropertyChanged ) );
    public global::System.Windows.Controls.RichTextBox Target
    {
      get { return ( global::System.Windows.Controls.RichTextBox )GetValue( TargetProperty ); }
      set { SetValue( TargetProperty, value ); }
    }

    private static void OnRichTextBoxPropertyChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
    {
      RichTextBoxFormatBar formatBar = d as RichTextBoxFormatBar;
    }

    #endregion //Target

    public bool PreventDisplayFadeOut
    {
      get
      {
        return ( ( ( m_cmbFontFamilies != null ) && m_cmbFontFamilies.IsDropDownOpen )
              || ( ( m_cmbFontSizes != null ) && m_cmbFontSizes.IsDropDownOpen )
              || ( ( m_cmbFontBackgroundColor != null ) && m_cmbFontBackgroundColor.IsOpen )
              || ( ( m_cmbFontColor != null ) && m_cmbFontColor.IsOpen )
              || m_waitingForMouseOver );
      }
    }

    public void Update()
    {
      this.UpdateToggleButtonState();
      this.UpdateSelectedFontFamily();
      this.UpdateSelectedFontSize();
      this.UpdateFontColor();
      this.UpdateFontBackgroundColor();
      this.UpdateSelectionListType();
    }

    #endregion
  }
}
