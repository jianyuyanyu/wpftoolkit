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
using System.Collections.Generic;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Attributes
{
  [AttributeUsage( AttributeTargets.Property, AllowMultiple = false, Inherited = true )]
  public class NewItemTypesAttribute : Attribute
  {
    public IList<Type> Types
    {
      get;
      set;
    }

    public NewItemTypesAttribute( params Type[] types )
    {
      this.Types = new List<Type>( types );
    }

    public NewItemTypesAttribute()
    {
    }
  }
}
