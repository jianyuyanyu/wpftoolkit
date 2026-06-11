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

using System.Windows.Media;
using System.Windows;

namespace Xceed.Wpf.Toolkit.Core
{
  public class AppearanceProperties
  {
    #region OuterCornerRadiusProperty

    public static CornerRadius GetOuterCornerRadius( DependencyObject obj )
    {
      return ( CornerRadius )obj.GetValue( OuterCornerRadiusProperty );
    }

    public static void SetOuterCornerRadius( DependencyObject obj, CornerRadius value )
    {
      obj.SetValue( OuterCornerRadiusProperty, value );
    }

    public static readonly DependencyProperty OuterCornerRadiusProperty =
        DependencyProperty.RegisterAttached(
          "OuterCornerRadius",
          typeof( CornerRadius ),
          typeof( AppearanceProperties ),
          new FrameworkPropertyMetadata( new CornerRadius( 0.0 ) ) );

    #endregion OuterCornerRadiusProperty


    #region ContentMarginProperty

    public static Thickness GetContentMargin( DependencyObject obj )
    {
      return ( Thickness )obj.GetValue( ContentMarginProperty );
    }

    public static void SetContentMargin( DependencyObject obj, Thickness value )
    {
      obj.SetValue( ContentMarginProperty, value );
    }

    public static readonly DependencyProperty ContentMarginProperty =
        DependencyProperty.RegisterAttached(
          "ContentMargin",
          typeof( Thickness ),
          typeof( AppearanceProperties ),
          new FrameworkPropertyMetadata( new Thickness( 0.0 ) ) );

    #endregion InnerBorderThicknessProperty


    #region HeaderForegroundProperty

    public static Brush GetHeaderForeground( DependencyObject obj )
    {
      return ( Brush )obj.GetValue( HeaderForegroundProperty );
    }

    public static void SetHeaderForeground( DependencyObject obj, Brush value )
    {
      obj.SetValue( HeaderForegroundProperty, value );
    }

    public static readonly DependencyProperty HeaderForegroundProperty =
        DependencyProperty.RegisterAttached(
          "HeaderForeground",
          typeof( Brush ),
          typeof( AppearanceProperties ),
          new FrameworkPropertyMetadata( ( Brush )( new SolidColorBrush( Colors.Black ).GetAsFrozen() ) ) );

    #endregion HeaderForegroundProperty


    #region HeaderFontWeightProperty

    public static FontWeight GetHeaderFontWeight( DependencyObject obj )
    {
      return ( FontWeight )obj.GetValue( HeaderFontWeightProperty );
    }

    public static void SetHeaderFontWeight( DependencyObject obj, FontWeight value )
    {
      obj.SetValue( HeaderFontWeightProperty, value );
    }

    public static readonly DependencyProperty HeaderFontWeightProperty =
        DependencyProperty.RegisterAttached(
          "HeaderFontWeight",
          typeof( FontWeight ),
          typeof( AppearanceProperties ),
          new FrameworkPropertyMetadata( FontWeights.Normal ) );

    #endregion HeaderFontWeightProperty
  }

}
