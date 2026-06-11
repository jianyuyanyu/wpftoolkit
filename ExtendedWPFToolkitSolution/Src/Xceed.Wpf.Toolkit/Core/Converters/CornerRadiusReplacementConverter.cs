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

using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows;
using System;

namespace Xceed.Wpf.Toolkit.Core.Converters
{
  public class CornerRadiusReplacementConverter : MarkupExtension, IValueConverter
  {

    public const string Auto = "Auto";

    #region Constructors

    public CornerRadiusReplacementConverter()
    {
    }

    public CornerRadiusReplacementConverter(
      object topLeft,
      object topRight,
      object bottomRight,
      object bottomLeft )
    {
      this.TopLeft = topLeft;
      this.TopRight = topRight;
      this.BottomRight = bottomRight;
      this.BottomLeft = bottomLeft;
    }

    #endregion Constructors

    #region Properties

    public object TopLeft { get; set; } = Auto;

    public object TopRight { get; set; } = Auto;

    public object BottomRight { get; set; } = Auto;

    public object BottomLeft { get; set; } = Auto;

    #endregion Properties

    #region Implement IValueConverter

    public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
    {
      if( value is CornerRadius )
      {
        CornerRadius source = ( CornerRadius )value;

        return new CornerRadius(
          GetValue( this.TopLeft, source, source.TopLeft ),
          GetValue( this.TopRight, source, source.TopRight ),
          GetValue( this.BottomRight, source, source.BottomRight ),
          GetValue( this.BottomLeft, source, source.BottomLeft ) );
      }
      else if( value is double || value is int )
      {
        CornerRadius source = new CornerRadius( System.Convert.ToDouble( value ) );

        return new CornerRadius(
          this.GetValue( this.TopLeft, source, source.TopLeft ),
          this.GetValue( this.TopRight, source, source.TopRight ),
          this.GetValue( this.BottomRight, source, source.BottomRight ),
          this.GetValue( this.BottomLeft, source, source.BottomLeft ) );
      }

      return new CornerRadius( 0 );
    }

    public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
    {
      throw new NotImplementedException();
    }

    #endregion Implement IValueConverter

    #region Implement MarkupExtension

    public override object ProvideValue( IServiceProvider serviceProvider )
    {
      return this;
    }

    #endregion Implement MarkupExtension

    #region Methods (Private)

    private double GetValue( object operand, CornerRadius sourceCornerRadius, double autoValue )
    {
      var stringVal = operand as string;
      if( stringVal != null )
      {
        if( Auto.Equals( stringVal, StringComparison.Ordinal ) )
        {
          return autoValue;
        }
        else if( "TopLeft".Equals( stringVal, StringComparison.Ordinal ) )
        {
          return sourceCornerRadius.TopLeft;
        }
        else if( "TopRight".Equals( stringVal, StringComparison.Ordinal ) )
        {
          return sourceCornerRadius.TopRight;
        }
        else if( "BottomRight".Equals( stringVal, StringComparison.Ordinal ) )
        {
          return sourceCornerRadius.BottomRight;
        }
        else if( "BottomLeft".Equals( stringVal, StringComparison.Ordinal ) )
        {
          return sourceCornerRadius.BottomLeft;
        }
        else if( double.TryParse( stringVal, out var doubleValue ) )
        {
          return doubleValue;
        }
      }
      else if( operand is double || operand is int )
      {
        return ( double )System.Convert.ToDouble( operand );
      }

      throw new ArgumentException( "Value '" + operand + "' not recognized. Supported values are Auto, Left, Top, Right, Bottom or a double value." );
    }

    #endregion Methods (Private)

  }

}
