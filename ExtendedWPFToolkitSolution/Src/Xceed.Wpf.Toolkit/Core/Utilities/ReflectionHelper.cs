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

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace Xceed.Wpf.Toolkit.Core.Utilities
{
  internal static class ReflectionHelper
  {
    [System.Diagnostics.Conditional( "DEBUG" )]
    internal static void ValidatePublicPropertyName( object sourceObject, string propertyName )
    {
      if( sourceObject == null )
        throw new ArgumentNullException( "sourceObject" );

      if( propertyName == null )
        throw new ArgumentNullException( "propertyName" );

      System.Diagnostics.Debug.Assert( sourceObject.GetType().GetProperty( propertyName, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.FlattenHierarchy | System.Reflection.BindingFlags.Public ) != null,
        string.Format( "Public property {0} not found on object of type {1}.", propertyName, sourceObject.GetType().FullName ) );
    }

    [System.Diagnostics.Conditional( "DEBUG" )]
    internal static void ValidatePropertyName( object sourceObject, string propertyName )
    {
      if( sourceObject == null )
        throw new ArgumentNullException( "sourceObject" );

      if( propertyName == null )
        throw new ArgumentNullException( "propertyName" );

      System.Diagnostics.Debug.Assert( sourceObject.GetType().GetProperty( propertyName, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.FlattenHierarchy | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic ) != null,
        string.Format( "Public property {0} not found on object of type {1}.", propertyName, sourceObject.GetType().FullName ) );
    }

    internal static bool TryGetEnumDescriptionAttributeValue( Enum enumeration, out string description )
    {
      try
      {
        FieldInfo fieldInfo = enumeration.GetType().GetField( enumeration.ToString() );
        DescriptionAttribute[] attributes = fieldInfo.GetCustomAttributes( typeof( DescriptionAttribute ), true ) as DescriptionAttribute[];
        if( ( attributes != null ) && ( attributes.Length > 0 ) )
        {
          description = attributes[ 0 ].Description;
          return true;
        }
      }
      catch
      {
      }

      description = String.Empty;
      return false;
    }

    [DebuggerStepThrough]
    internal static string GetPropertyOrFieldName( MemberExpression expression )
    {
      string propertyOrFieldName;
      if( !ReflectionHelper.TryGetPropertyOrFieldName( expression, out propertyOrFieldName ) )
        throw new InvalidOperationException( "Unable to retrieve the property or field name." );

      return propertyOrFieldName;
    }

    [DebuggerStepThrough]
    internal static string GetPropertyOrFieldName<TMember>( Expression<Func<TMember>> expression )
    {
      string propertyOrFieldName;
      if( !ReflectionHelper.TryGetPropertyOrFieldName( expression, out propertyOrFieldName ) )
        throw new InvalidOperationException( "Unable to retrieve the property or field name." );

      return propertyOrFieldName;
    }

    [DebuggerStepThrough]
    internal static bool TryGetPropertyOrFieldName( MemberExpression expression, out string propertyOrFieldName )
    {
      propertyOrFieldName = null;

      if( expression == null )
        return false;

      propertyOrFieldName = expression.Member.Name;

      return true;
    }

    [DebuggerStepThrough]
    internal static bool TryGetPropertyOrFieldName<TMember>( Expression<Func<TMember>> expression, out string propertyOrFieldName )
    {
      propertyOrFieldName = null;

      if( expression == null )
        return false;

      return ReflectionHelper.TryGetPropertyOrFieldName( expression.Body as MemberExpression, out propertyOrFieldName );
    }

    public static bool IsPublicInstanceProperty( Type type, string propertyName )
    {
      BindingFlags flags = ( System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.FlattenHierarchy | System.Reflection.BindingFlags.Public );
      return type.GetProperty( propertyName, flags ) != null;
    }
  }
}
