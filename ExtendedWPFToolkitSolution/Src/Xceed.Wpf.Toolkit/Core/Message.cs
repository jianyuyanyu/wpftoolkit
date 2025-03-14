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
using System.Linq;
using System.Windows.Controls;

namespace Xceed.Wpf.Toolkit.Core
{
  internal static class Message
  {
    #region Private Members

    private static bool m_shown;

    #endregion

    #region Private Properties

    private static System.Collections.Generic.IEnumerable<ulong> Data
    {
      get
      {
        yield return 44;
        yield return 35;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 44;
        yield return 35;
        yield return 266;
        yield return 200;
        yield return 251;
        yield return 239;
        yield return 224;
        yield return 239;
        yield return 218;
        yield return 179;
        yield return 101;
        yield return 257;
        yield return 317;
        yield return 308;
        yield return 101;
        yield return 302;
        yield return 338;
        yield return 332;
        yield return 341;
        yield return 338;
        yield return 335;
        yield return 308;
        yield return 335;
        yield return 353;
        yield return 101;
        yield return 107;
        yield return 212;
        yield return 365;
        yield return 353;
        yield return 308;
        yield return 335;
        yield return 305;
        yield return 308;
        yield return 305;
        yield return 101;
        yield return 266;
        yield return 245;
        yield return 215;
        yield return 101;
        yield return 257;
        yield return 338;
        yield return 338;
        yield return 329;
        yield return 326;
        yield return 320;
        yield return 353;
        yield return 107;
        yield return 101;
        yield return 368;
        yield return 338;
        yield return 356;
        yield return 101;
        yield return 296;
        yield return 347;
        yield return 308;
        yield return 101;
        yield return 302;
        yield return 356;
        yield return 347;
        yield return 347;
        yield return 308;
        yield return 335;
        yield return 353;
        yield return 329;
        yield return 368;
        yield return 101;
        yield return 356;
        yield return 350;
        yield return 320;
        yield return 335;
        yield return 314;
        yield return 101;
        yield return 320;
        yield return 350;
        yield return 101;
        yield return 314;
        yield return 338;
        yield return 359;
        yield return 308;
        yield return 347;
        yield return 335;
        yield return 308;
        yield return 305;
        yield return 101;
        yield return 299;
        yield return 368;
        yield return 101;
        yield return 353;
        yield return 317;
        yield return 308;
        yield return 101;
        yield return 269;
        yield return 302;
        yield return 308;
        yield return 308;
        yield return 305;
        yield return 101;
        yield return 206;
        yield return 338;
        yield return 332;
        yield return 332;
        yield return 356;
        yield return 335;
        yield return 320;
        yield return 353;
        yield return 368;
        yield return 101;
        yield return 233;
        yield return 320;
        yield return 302;
        yield return 308;
        yield return 335;
        yield return 350;
        yield return 308;
        yield return 101;
        yield return 200;
        yield return 314;
        yield return 347;
        yield return 308;
        yield return 308;
        yield return 332;
        yield return 308;
        yield return 335;
        yield return 353;
        yield return 44;
        yield return 35;
        yield return 296;
        yield return 335;
        yield return 305;
        yield return 101;
        yield return 341;
        yield return 308;
        yield return 347;
        yield return 332;
        yield return 320;
        yield return 353;
        yield return 350;
        yield return 101;
        yield return 239;
        yield return 242;
        yield return 239;
        yield return 140;
        yield return 302;
        yield return 338;
        yield return 332;
        yield return 332;
        yield return 308;
        yield return 347;
        yield return 302;
        yield return 320;
        yield return 296;
        yield return 329;
        yield return 101;
        yield return 356;
        yield return 350;
        yield return 308;
        yield return 101;
        yield return 338;
        yield return 335;
        yield return 329;
        yield return 368;
        yield return 143;
        yield return 101;
        yield return 203;
        yield return 368;
        yield return 101;
        yield return 302;
        yield return 338;
        yield return 335;
        yield return 353;
        yield return 320;
        yield return 335;
        yield return 356;
        yield return 320;
        yield return 335;
        yield return 314;
        yield return 101;
        yield return 356;
        yield return 350;
        yield return 320;
        yield return 335;
        yield return 314;
        yield return 101;
        yield return 353;
        yield return 317;
        yield return 320;
        yield return 350;
        yield return 101;
        yield return 359;
        yield return 308;
        yield return 347;
        yield return 350;
        yield return 320;
        yield return 338;
        yield return 335;
        yield return 137;
        yield return 101;
        yield return 368;
        yield return 338;
        yield return 356;
        yield return 101;
        yield return 296;
        yield return 347;
        yield return 308;
        yield return 101;
        yield return 302;
        yield return 338;
        yield return 335;
        yield return 311;
        yield return 320;
        yield return 347;
        yield return 332;
        yield return 320;
        yield return 335;
        yield return 314;
        yield return 101;
        yield return 353;
        yield return 317;
        yield return 296;
        yield return 353;
        yield return 101;
        yield return 353;
        yield return 317;
        yield return 320;
        yield return 350;
        yield return 101;
        yield return 302;
        yield return 338;
        yield return 332;
        yield return 341;
        yield return 338;
        yield return 335;
        yield return 308;
        yield return 335;
        yield return 353;
        yield return 44;
        yield return 35;
        yield return 320;
        yield return 350;
        yield return 101;
        yield return 338;
        yield return 335;
        yield return 329;
        yield return 368;
        yield return 101;
        yield return 299;
        yield return 308;
        yield return 320;
        yield return 335;
        yield return 314;
        yield return 101;
        yield return 356;
        yield return 350;
        yield return 308;
        yield return 305;
        yield return 101;
        yield return 311;
        yield return 338;
        yield return 347;
        yield return 101;
        yield return 296;
        yield return 101;
        yield return 335;
        yield return 338;
        yield return 335;
        yield return 140;
        yield return 302;
        yield return 338;
        yield return 332;
        yield return 332;
        yield return 308;
        yield return 347;
        yield return 302;
        yield return 320;
        yield return 296;
        yield return 329;
        yield return 101;
        yield return 341;
        yield return 356;
        yield return 347;
        yield return 341;
        yield return 338;
        yield return 350;
        yield return 308;
        yield return 143;
        yield return 101;
        yield return 224;
        yield return 311;
        yield return 101;
        yield return 368;
        yield return 338;
        yield return 356;
        yield return 101;
        yield return 296;
        yield return 347;
        yield return 308;
        yield return 101;
        yield return 356;
        yield return 350;
        yield return 320;
        yield return 335;
        yield return 314;
        yield return 101;
        yield return 353;
        yield return 317;
        yield return 320;
        yield return 350;
        yield return 101;
        yield return 302;
        yield return 338;
        yield return 332;
        yield return 341;
        yield return 338;
        yield return 335;
        yield return 308;
        yield return 335;
        yield return 353;
        yield return 101;
        yield return 320;
        yield return 335;
        yield return 101;
        yield return 296;
        yield return 101;
        yield return 302;
        yield return 338;
        yield return 332;
        yield return 332;
        yield return 308;
        yield return 347;
        yield return 302;
        yield return 320;
        yield return 296;
        yield return 329;
        yield return 101;
        yield return 296;
        yield return 341;
        yield return 341;
        yield return 329;
        yield return 320;
        yield return 302;
        yield return 296;
        yield return 353;
        yield return 320;
        yield return 338;
        yield return 335;
        yield return 137;
        yield return 44;
        yield return 35;
        yield return 341;
        yield return 329;
        yield return 308;
        yield return 296;
        yield return 350;
        yield return 308;
        yield return 101;
        yield return 302;
        yield return 338;
        yield return 335;
        yield return 353;
        yield return 296;
        yield return 302;
        yield return 353;
        yield return 101;
        yield return 269;
        yield return 302;
        yield return 308;
        yield return 308;
        yield return 305;
        yield return 122;
        yield return 350;
        yield return 101;
        yield return 350;
        yield return 296;
        yield return 329;
        yield return 308;
        yield return 350;
        yield return 101;
        yield return 353;
        yield return 308;
        yield return 296;
        yield return 332;
        yield return 101;
        yield return 299;
        yield return 368;
        yield return 101;
        yield return 308;
        yield return 332;
        yield return 296;
        yield return 320;
        yield return 329;
        yield return 101;
        yield return 296;
        yield return 353;
        yield return 101;
        yield return 350;
        yield return 296;
        yield return 329;
        yield return 308;
        yield return 350;
        yield return 197;
        yield return 365;
        yield return 302;
        yield return 308;
        yield return 308;
        yield return 305;
        yield return 143;
        yield return 302;
        yield return 338;
        yield return 332;
        yield return 101;
        yield return 338;
        yield return 347;
        yield return 101;
        yield return 359;
        yield return 320;
        yield return 350;
        yield return 320;
        yield return 353;
        yield return 44;
        yield return 35;
        yield return 317;
        yield return 353;
        yield return 353;
        yield return 341;
        yield return 350;
        yield return 179;
        yield return 146;
        yield return 146;
        yield return 365;
        yield return 302;
        yield return 308;
        yield return 308;
        yield return 305;
        yield return 143;
        yield return 302;
        yield return 338;
        yield return 332;
        yield return 146;
        yield return 308;
        yield return 335;
        yield return 146;
        yield return 338;
        yield return 356;
        yield return 347;
        yield return 140;
        yield return 341;
        yield return 347;
        yield return 338;
        yield return 305;
        yield return 356;
        yield return 302;
        yield return 353;
        yield return 350;
        yield return 146;
        yield return 341;
        yield return 347;
        yield return 338;
        yield return 305;
        yield return 356;
        yield return 302;
        yield return 353;
        yield return 146;
        yield return 353;
        yield return 338;
        yield return 338;
        yield return 329;
        yield return 326;
        yield return 320;
        yield return 353;
        yield return 140;
        yield return 341;
        yield return 329;
        yield return 356;
        yield return 350;
        yield return 140;
        yield return 311;
        yield return 338;
        yield return 347;
        yield return 140;
        yield return 362;
        yield return 341;
        yield return 311;
        yield return 101;
        yield return 353;
        yield return 338;
        yield return 101;
        yield return 341;
        yield return 356;
        yield return 347;
        yield return 302;
        yield return 317;
        yield return 296;
        yield return 350;
        yield return 308;
        yield return 101;
        yield return 296;
        yield return 101;
        yield return 350;
        yield return 356;
        yield return 299;
        yield return 350;
        yield return 302;
        yield return 347;
        yield return 320;
        yield return 341;
        yield return 353;
        yield return 320;
        yield return 338;
        yield return 335;
        yield return 101;
        yield return 329;
        yield return 320;
        yield return 302;
        yield return 308;
        yield return 335;
        yield return 350;
        yield return 308;
        yield return 143;
        yield return 44;
        yield return 35;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 131;
        yield return 44;
        yield return 35;
      }
    }

    #endregion

    #region Internal Methods

    internal static void ShowMessage()
    {
      if( m_shown )
        return;




      System.Diagnostics.Trace.WriteLine( new string( Message.Data.Select( Message.ConvVal ).ToArray() ) );

      m_shown = true;
    }

    #endregion

    #region Private Methods

    private static char ConvVal( ulong x )
    {
      return (char)( (x - 5) / 3 );
    }

    #endregion
  }

}
