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

namespace Xceed.Wpf.Toolkit.Core.Utilities
{
  internal static class DateTimeUtilities
  {
    public static DateTime GetContextNow( DateTimeKind kind )
    {
      if( kind == DateTimeKind.Unspecified )
        return DateTime.SpecifyKind( DateTime.Now, DateTimeKind.Unspecified );

      return ( kind == DateTimeKind.Utc )
        ? DateTime.UtcNow
        : DateTime.Now;
    }

    public static bool IsSameDate( DateTime? date1, DateTime? date2 )
    {
      if( date1 == null || date2 == null )
        return false;

      return ( date1.Value.Date == date2.Value.Date );
    }
  }
}
