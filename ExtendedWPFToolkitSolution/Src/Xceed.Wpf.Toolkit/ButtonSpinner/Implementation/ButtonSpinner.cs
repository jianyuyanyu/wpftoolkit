﻿/*************************************************************************************
   
   Toolkit for WPF

   Copyright (C) 2007-2025 Xceed Software Inc.

   This program is provided to you under the terms of the XCEED SOFTWARE, INC.
   COMMUNITY LICENSE AGREEMENT (for non-commercial use) as published at 
   https://github.com/xceedsoftware/wpftoolkit/blob/master/license.md 

   For more features, controls, and fast professional support,
   pick up the Plus Edition at https://xceed.com/xceed-toolkit-plus-for-wpf/

   Stay informed: follow @datagrid on Twitter or Like http://facebook.com/datagrids

  ***********************************************************************************/

using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System;

namespace Xceed.Wpf.Toolkit
{
  public enum Location
  {
    Left,
    Right
  }

  [TemplatePart( Name = PART_IncreaseButton, Type = typeof( ButtonBase ) )]
  [TemplatePart( Name = PART_DecreaseButton, Type = typeof( ButtonBase ) )]
  [ContentProperty( "Content" )]
  public class ButtonSpinner : Spinner
  {
    private const string PART_IncreaseButton = "PART_IncreaseButton";
    private const string PART_DecreaseButton = "PART_DecreaseButton";

    #region Properties

    #region Public Properties

    #region AllowSpin

    public static readonly DependencyProperty AllowSpinProperty = DependencyProperty.Register( "AllowSpin", typeof( bool ), typeof( ButtonSpinner ), new UIPropertyMetadata( true, AllowSpinPropertyChanged ) );
    public bool AllowSpin
    {
      get
      {
        return ( bool )GetValue( AllowSpinProperty );
      }
      set
      {
        SetValue( AllowSpinProperty, value );
      }
    }

    private static void AllowSpinPropertyChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
    {
      ButtonSpinner source = d as ButtonSpinner;
      source.OnAllowSpinChanged( ( bool )e.OldValue, ( bool )e.NewValue );
    }

    #endregion //AllowSpin

    //[Obsolete( "ButtonSpinnerLocation is obsolete. Use SpinnerLocation instead." )]
    #region ButtonSpinnerLocation

    [Obsolete( "ButtonSpinnerLocation is obsolete. Use SpinnerLocation instead." )]
    public static readonly DependencyProperty ButtonSpinnerLocationProperty = DependencyProperty.Register( "ButtonSpinnerLocation", typeof( Location ), typeof( ButtonSpinner ), new UIPropertyMetadata( Location.Right ) );
    [Obsolete( "ButtonSpinnerLocation is obsolete. Use SpinnerLocation instead." )]
    public Location ButtonSpinnerLocation
    {
      get
      {
        return ( Location )GetValue( ButtonSpinnerLocationProperty );
      }
      set
      {
        SetValue( ButtonSpinnerLocationProperty, value );
      }
    }

    #endregion //ButtonSpinnerLocation

    #region SpinnerLocation

    public static readonly DependencyProperty SpinnerLocationProperty = DependencyProperty.Register( "SpinnerLocation", typeof( Location ), typeof( ButtonSpinner ), new UIPropertyMetadata( Location.Right ) );
    public Location SpinnerLocation
    {
      get
      {
        return ( Location )GetValue( SpinnerLocationProperty );
      }
      set
      {
        SetValue( SpinnerLocationProperty, value );
      }
    }

    #endregion //SpinnerLocation

    #region SpinnerWidth

    public static readonly DependencyProperty SpinnerWidthProperty = DependencyProperty.Register( "SpinnerWidth", typeof( double ), typeof( ButtonSpinner ), new UIPropertyMetadata( SystemParameters.VerticalScrollBarWidth ) );
    public double SpinnerWidth
    {
      get
      {
        return ( double )GetValue( SpinnerWidthProperty );
      }
      set
      {
        SetValue( SpinnerWidthProperty, value );
      }
    }

    #endregion //SpinnerWidth

    #region SpinnerHeight

    public static readonly DependencyProperty SpinnerHeightProperty = DependencyProperty.Register( "SpinnerHeight", typeof( double ), typeof( ButtonSpinner ), new UIPropertyMetadata( double.NaN ) );
    public double SpinnerHeight
    {
      get
      {
        return ( double )GetValue( SpinnerHeightProperty );
      }
      set
      {
        SetValue( SpinnerHeightProperty, value );
      }
    }

    #endregion //SpinnerHeight

    #region SpinnerDownContentTemplate

    public static readonly DependencyProperty SpinnerDownContentTemplateProperty = DependencyProperty.Register( "SpinnerDownContentTemplate", typeof( DataTemplate ), typeof( ButtonSpinner ), new UIPropertyMetadata( null ) );
    public DataTemplate SpinnerDownContentTemplate
    {
      get
      {
        return ( DataTemplate )GetValue( SpinnerDownContentTemplateProperty );
      }
      set
      {
        SetValue( SpinnerDownContentTemplateProperty, value );
      }
    }

    #endregion //SpinnerDownContentTemplate

    #region SpinnerDownDisabledContentTemplate

    public static readonly DependencyProperty SpinnerDownDisabledContentTemplateProperty = DependencyProperty.Register( "SpinnerDownDisabledContentTemplate", typeof( DataTemplate ), typeof( ButtonSpinner ), new UIPropertyMetadata( null ) );
    public DataTemplate SpinnerDownDisabledContentTemplate
    {
      get
      {
        return ( DataTemplate )GetValue( SpinnerDownDisabledContentTemplateProperty );
      }
      set
      {
        SetValue( SpinnerDownDisabledContentTemplateProperty, value );
      }
    }

    #endregion //SpinnerDownDisabledContentTemplate

    #region SpinnerUpContentTemplate

    public static readonly DependencyProperty SpinnerUpContentTemplateProperty = DependencyProperty.Register( "SpinnerUpContentTemplate", typeof( DataTemplate ), typeof( ButtonSpinner ), new UIPropertyMetadata( null ) );
    public DataTemplate SpinnerUpContentTemplate
    {
      get
      {
        return ( DataTemplate )GetValue( SpinnerUpContentTemplateProperty );
      }
      set
      {
        SetValue( SpinnerUpContentTemplateProperty, value );
      }
    }

    #endregion //SpinnerUpContentTemplate

    #region SpinnerUpDisabledContentTemplate

    public static readonly DependencyProperty SpinnerUpDisabledContentTemplateProperty = DependencyProperty.Register( "SpinnerUpDisabledContentTemplate", typeof( DataTemplate ), typeof( ButtonSpinner ), new UIPropertyMetadata( null ) );
    public DataTemplate SpinnerUpDisabledContentTemplate
    {
      get
      {
        return ( DataTemplate )GetValue( SpinnerUpDisabledContentTemplateProperty );
      }
      set
      {
        SetValue( SpinnerUpDisabledContentTemplateProperty, value );
      }
    }

    #endregion //SpinnerUpDisabledContentTemplate

    #region Content

    public static readonly DependencyProperty ContentProperty = DependencyProperty.Register( "Content", typeof( object ), typeof( ButtonSpinner ), new PropertyMetadata( null, OnContentPropertyChanged ) );
    public object Content
    {
      get
      {
        return GetValue( ContentProperty ) as object;
      }
      set
      {
        SetValue( ContentProperty, value );
      }
    }

    private static void OnContentPropertyChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
    {
      ButtonSpinner source = d as ButtonSpinner;
      source.OnContentChanged( e.OldValue, e.NewValue );
    }

    #endregion //Content

    //[Obsolete( "ShowButtonSpinner is obsolete. Use ShowSpinner instead." )]
    #region ShowButtonSpinner

    [Obsolete( "ShowButtonSpinner is obsolete. Use ShowSpinner instead." )]
    public static readonly DependencyProperty ShowButtonSpinnerProperty = DependencyProperty.Register( "ShowButtonSpinner", typeof( bool ), typeof( ButtonSpinner ), new UIPropertyMetadata( true ) );
    [Obsolete( "ShowButtonSpinner is obsolete. Use ShowSpinner instead." )]
    public bool ShowButtonSpinner
    {
      get
      {
        return ( bool )GetValue( ShowButtonSpinnerProperty );
      }
      set
      {
        SetValue( ShowButtonSpinnerProperty, value );
      }
    }

    #endregion //ShowButtonSpinner

    #region ShowSpinner

    public static readonly DependencyProperty ShowSpinnerProperty = DependencyProperty.Register( "ShowSpinner", typeof( bool ), typeof( ButtonSpinner ), new UIPropertyMetadata( true ) );

    public bool ShowSpinner
    {
      get
      {
        return ( bool )GetValue( ShowSpinnerProperty );
      }
      set
      {
        SetValue( ShowSpinnerProperty, value );
      }
    }

    #endregion //ShowSpinner

    #endregion //Properties

    #region Private Properties

    #region DecreaseButton

    private ButtonBase _decreaseButton;
    private ButtonBase DecreaseButton
    {
      get
      {
        return _decreaseButton;
      }
      set
      {
        if( _decreaseButton != null )
        {
          _decreaseButton.Click -= OnButtonClick;
        }

        _decreaseButton = value;

        if( _decreaseButton != null )
        {
          _decreaseButton.Click += OnButtonClick;
        }
      }
    }

    #endregion //DecreaseButton

    #region IncreaseButton

    private ButtonBase _increaseButton;
    private ButtonBase IncreaseButton
    {
      get
      {
        return _increaseButton;
      }
      set
      {
        if( _increaseButton != null )
        {
          _increaseButton.Click -= OnButtonClick;
        }

        _increaseButton = value;

        if( _increaseButton != null )
        {
          _increaseButton.Click += OnButtonClick;
        }
      }
    }

    #endregion //IncreaseButton

    #endregion

    #endregion

    #region Constructors

    static ButtonSpinner()
    {
      DefaultStyleKeyProperty.OverrideMetadata( typeof( ButtonSpinner ), new FrameworkPropertyMetadata( typeof( ButtonSpinner ) ) );
    }

    public ButtonSpinner()
    {

      Core.Message.ShowMessage();
    }

    #endregion //Constructors

    #region Base Class Overrides

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();

      IncreaseButton = GetTemplateChild( PART_IncreaseButton ) as ButtonBase;
      DecreaseButton = GetTemplateChild( PART_DecreaseButton ) as ButtonBase;

      SetButtonUsage();
    }

    protected override void OnMouseLeftButtonUp( MouseButtonEventArgs e )
    {
      base.OnMouseLeftButtonUp( e );

      Point mousePosition;
      if( IncreaseButton != null && IncreaseButton.IsEnabled == false )
      {
        mousePosition = e.GetPosition( IncreaseButton );
        if( mousePosition.X > 0 && mousePosition.X < IncreaseButton.ActualWidth &&
            mousePosition.Y > 0 && mousePosition.Y < IncreaseButton.ActualHeight )
        {
          e.Handled = true;
        }
      }

      if( DecreaseButton != null && DecreaseButton.IsEnabled == false )
      {
        mousePosition = e.GetPosition( DecreaseButton );
        if( mousePosition.X > 0 && mousePosition.X < DecreaseButton.ActualWidth &&
            mousePosition.Y > 0 && mousePosition.Y < DecreaseButton.ActualHeight )
        {
          e.Handled = true;
        }
      }
    }

    protected override void OnPreviewKeyDown( KeyEventArgs e )
    {
      switch( e.Key )
      {
        case Key.Up:
          {
            if( this.AllowSpin )
            {
              this.OnSpin( new SpinEventArgs( Spinner.SpinnerSpinEvent, SpinDirection.Increase ) );
              e.Handled = true;
            }

            break;
          }
        case Key.Down:
          {
            if( this.AllowSpin )
            {
              this.OnSpin( new SpinEventArgs( Spinner.SpinnerSpinEvent, SpinDirection.Decrease ) );
              e.Handled = true;
            }

            break;
          }
        case Key.Enter:
          {
            //Do not Spin on enter Key when spinners have focus
            if( ( ( this.IncreaseButton != null ) && ( this.IncreaseButton.IsFocused ) )
              || ( ( this.DecreaseButton != null ) && this.DecreaseButton.IsFocused ) )
            {
              e.Handled = true;
            }
            break;
          }
      }
    }

    protected override void OnMouseWheel( MouseWheelEventArgs e )
    {
      base.OnMouseWheel( e );

      if( !e.Handled && this.AllowSpin )
      {
        if( e.Delta != 0 )
        {
          var spinnerEventArgs = new SpinEventArgs( Spinner.SpinnerSpinEvent, ( e.Delta < 0 ) ? SpinDirection.Decrease : SpinDirection.Increase, true );
          this.OnSpin( spinnerEventArgs );
          e.Handled = spinnerEventArgs.Handled;
        }
      }
    }

    protected override void OnValidSpinDirectionChanged( ValidSpinDirections oldValue, ValidSpinDirections newValue )
    {
      SetButtonUsage();
    }


    #endregion //Base Class Overrides

    #region Event Handlers

    private void OnButtonClick( object sender, RoutedEventArgs e )
    {
      if( AllowSpin )
      {
        SpinDirection direction = sender == IncreaseButton ? SpinDirection.Increase : SpinDirection.Decrease;
        OnSpin( new SpinEventArgs( Spinner.SpinnerSpinEvent, direction ) );
      }
    }

    #endregion //Event Handlers

    #region Methods

    protected virtual void OnContentChanged( object oldValue, object newValue )
    {
    }

    protected virtual void OnAllowSpinChanged( bool oldValue, bool newValue )
    {
      SetButtonUsage();
    }

    private void SetButtonUsage()
    {
      // buttonspinner adds buttons that spin, so disable accordingly.
      if( IncreaseButton != null )
      {
        IncreaseButton.IsEnabled = AllowSpin && ( ( ValidSpinDirection & ValidSpinDirections.Increase ) == ValidSpinDirections.Increase );
      }

      if( DecreaseButton != null )
      {
        DecreaseButton.IsEnabled = AllowSpin && ( ( ValidSpinDirection & ValidSpinDirections.Decrease ) == ValidSpinDirections.Decrease );
      }
    }

    #endregion //Methods
  }
}
