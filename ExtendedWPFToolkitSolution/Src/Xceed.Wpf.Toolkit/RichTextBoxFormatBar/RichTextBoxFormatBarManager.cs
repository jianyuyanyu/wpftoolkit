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

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Core;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit
{
  public class RichTextBoxFormatBarManager : DependencyObject
  {
    #region Members

    private global::System.Windows.Controls.RichTextBox m_richTextBox;
    private UIElementAdorner<Control> m_adorner;
    private IRichTextBoxFormatBar m_toolbar;
    private Window m_parentWindow;
    private const double m_hideAdornerDistance = 150d;

    #endregion //Members

    #region Properties

    #region FormatBar

    public static readonly DependencyProperty FormatBarProperty = DependencyProperty.RegisterAttached( "FormatBar", typeof( IRichTextBoxFormatBar ), typeof( RichTextBox ), new PropertyMetadata( null, OnFormatBarPropertyChanged ) );
    public static void SetFormatBar( UIElement element, IRichTextBoxFormatBar value )
    {
      element.SetValue( FormatBarProperty, value );
    }
    public static IRichTextBoxFormatBar GetFormatBar( UIElement element )
    {
      return ( IRichTextBoxFormatBar )element.GetValue( FormatBarProperty );
    }

    private static void OnFormatBarPropertyChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
    {
      global::System.Windows.Controls.RichTextBox rtb = d as global::System.Windows.Controls.RichTextBox;
      if( rtb == null )
        throw new Exception( "A FormatBar can only be applied to a RichTextBox." );

      RichTextBoxFormatBarManager manager = new RichTextBoxFormatBarManager();
      manager.AttachFormatBarToRichtextBox( rtb, e.NewValue as IRichTextBoxFormatBar );
    }

    #endregion //FormatBar

    public bool IsAdornerVisible
    {
      get
      {
        return m_adorner.Visibility == Visibility.Visible;
      }
    }


#endregion //Properties

    #region Event Handlers

    void RichTextBox_MouseButtonUp( object sender, MouseButtonEventArgs e )
    {
      if( e.ChangedButton == MouseButton.Left && e.LeftButton == MouseButtonState.Released )
      {
        if( !m_richTextBox.IsReadOnly )
        {
          TextRange selectedText = new TextRange( m_richTextBox.Selection.Start, m_richTextBox.Selection.End );
#if !VS2008
          if( selectedText.Text.Length > 0 && !String.IsNullOrWhiteSpace( selectedText.Text ) )
          {
            this.ShowAdorner();
          }
#else
      if (selectedText.Text.Length > 0 && !String.IsNullOrEmpty(selectedText.Text))
      {
        this.ShowAdorner();
      }
#endif
          else
          {
            {
              this.HideAdorner();
            }
          }
          e.Handled = true;
        }
      }
    }

    private void OnPreviewMouseMoveParentWindow( object sender, MouseEventArgs e )
    {

      Point p = e.GetPosition( m_adorner );
      double maxDist = 0d;
      bool preventDisplayFadeOut = ( ( m_adorner.Child != null ) && ( m_adorner.Child is IRichTextBoxFormatBar ) )
                                  ? ( ( IRichTextBoxFormatBar )m_adorner.Child ).PreventDisplayFadeOut
                                  : false;

      //Mouse is inside FormatBar: Nothing to do.

      if( preventDisplayFadeOut ||
          ( p.X >= 0 ) && ( p.X <= m_adorner.ActualWidth ) && ( p.Y >= 0 ) && ( p.Y <= m_adorner.ActualHeight ) )
      {
        return;
      }
      //Mouse is too much outside FormatBar: Close it.
      else if( ( p.X < -m_hideAdornerDistance ) || ( p.X > m_adorner.ActualWidth + m_hideAdornerDistance ) || ( p.Y < -m_hideAdornerDistance ) || ( p.Y > m_adorner.ActualHeight + m_hideAdornerDistance ) )
      {
        this.HideAdorner();
      }
      //Mouse is just outside FormatBar: Vary its opacity.
      else
      {
        if( p.X < 0 )
          maxDist = -p.X;
        else if( p.X > m_adorner.ActualWidth )
          maxDist = p.X - m_adorner.ActualWidth;

        if( p.Y < 0 )
          maxDist = Math.Max( maxDist, -p.Y );
        else if( p.Y > m_adorner.ActualHeight )
          maxDist = Math.Max( maxDist, p.Y - m_adorner.ActualHeight );

        m_adorner.Opacity = 1d - ( Math.Min( maxDist, 100d ) / 100d );
      }
    }

    void RichTextBox_TextChanged( object sender, TextChangedEventArgs e )
    {
      //This fixes the bug when applying text transformations the text would lose it's highlight. That was because the RichTextBox was losing focus,
      //so we just give it focus again and it seems to do the trick of re-highlighting it.
      if( !m_richTextBox.IsFocused && !m_richTextBox.Selection.IsEmpty )
        m_richTextBox.Focus();
    }

    void RichTextBox_Loaded( object sender, RoutedEventArgs e )
    {
    }

    void RichTextBox_GotFocus( object sender, RoutedEventArgs e )
    {
    }


#endregion //Event Handlers

    #region Methods

    private bool IsCursorInsideWord()
    {
      if( m_richTextBox?.Selection?.Start == null )
        return false;

      TextPointer caretPosition = m_richTextBox.Selection.Start;

      string charBefore = caretPosition.GetTextInRun( LogicalDirection.Backward );
      string charAfter = caretPosition.GetTextInRun( LogicalDirection.Forward );

      bool hasWordCharBefore = !string.IsNullOrEmpty( charBefore ) &&
                              charBefore.Length > 0 &&
                              char.IsLetterOrDigit( charBefore[ charBefore.Length - 1 ] );

      bool hasWordCharAfter = !string.IsNullOrEmpty( charAfter ) &&
                             charAfter.Length > 0 &&
                             char.IsLetterOrDigit( charAfter[ 0 ] );

      return hasWordCharBefore || hasWordCharAfter;
    }


    private void AttachFormatBarToRichtextBox( global::System.Windows.Controls.RichTextBox richTextBox, IRichTextBoxFormatBar formatBar )
    {
      m_richTextBox = richTextBox;
      //we cannot use the PreviewMouseLeftButtonUp event because of selection bugs.
      //we cannot use the MouseLeftButtonUp event because it is handled by the RichTextBox and does not bubble up to here, so we must
      //add a hander to the MouseUpEvent using the Addhandler syntax, and specify to listen for handled events too.
      m_richTextBox.AddHandler( Mouse.MouseUpEvent, new MouseButtonEventHandler( this.RichTextBox_MouseButtonUp ), true );
      m_richTextBox.TextChanged += this.RichTextBox_TextChanged;
      m_richTextBox.Loaded += this.RichTextBox_Loaded;
      m_richTextBox.GotFocus += this.RichTextBox_GotFocus;
      m_adorner = new UIElementAdorner<Control>( m_richTextBox );

      formatBar.Target = m_richTextBox;
      m_toolbar = formatBar;

      {
        this.HideAdorner();
      }
    }


    private void ShowAdorner()
    {
      if( m_adorner.Visibility == Visibility.Visible )
      {
        this.HideAdorner();
      }

      this.VerifyAdornerLayer();

      Control adorningEditor = m_toolbar as Control;

      if( m_adorner.Child == null )
      {
        m_adorner.Child = adorningEditor;
      }

      adorningEditor.ApplyTemplate();
      m_toolbar.Update();

      m_adorner.Visibility = Visibility.Visible;

      {
        this.MousePositionFormatBar( adorningEditor );
      }

      m_parentWindow = TreeHelper.FindParent<Window>( m_adorner );
      if( m_parentWindow != null
        )
      {
        Mouse.AddMouseMoveHandler( m_parentWindow, this.OnPreviewMouseMoveParentWindow );
      }
    }

    private void MousePositionFormatBar( Control adorningEditor )
    {
      Point mousePosition = Mouse.GetPosition( m_richTextBox );

      var left = mousePosition.X;
      var top = mousePosition.Y;

      // Top boundary
      if( top < 0 )
      {
        top = 5d;
      }

      // Left boundary
      if( left < 0 )
      {
        left = 5d;
      }

      // Right boundary
      if( left + adorningEditor.ActualWidth > m_richTextBox.ActualWidth - 10d )
      {
        left = m_richTextBox.ActualWidth - adorningEditor.ActualWidth - 10d;
      }

      // Bottom boundary
      if( top + adorningEditor.ActualHeight > m_richTextBox.ActualHeight - 10d )
      {
        top = m_richTextBox.ActualHeight - adorningEditor.ActualHeight - 10d;
      }

      m_adorner.SetOffsets( left, top );
    }



















    private bool VerifyAdornerLayer()
    {
      if( m_adorner.Parent != null )
      {
        return true;
      }

      AdornerLayer layer = AdornerLayer.GetAdornerLayer( m_richTextBox );
      if( layer == null )
      {
        return false;
      }

      layer.Add( m_adorner );
      return true;
    }

    private void HideAdorner()
    {

      if( this.IsAdornerVisible )
      {
        m_adorner.Visibility = Visibility.Collapsed;
        if( m_parentWindow != null )
        {
          Mouse.RemoveMouseMoveHandler( m_parentWindow, this.OnPreviewMouseMoveParentWindow );
        }
      }
    }

    #endregion //Methods
  }
}
