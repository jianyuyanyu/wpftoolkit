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
using System.Windows;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors
{
  public class CollectionEditor : TypeEditor<CollectionControlButton>
  {
    protected override void SetValueDependencyProperty()
    {
      ValueProperty = CollectionControlButton.ItemsSourceProperty;
    }

    protected override CollectionControlButton CreateEditor()
    {
      return new PropertyGridEditorCollectionControl();
    }

    protected override void SetControlProperties( PropertyItem propertyItem )
    {

      var propertyGrid = this.GetParentPropertyGrid( propertyItem.ParentElement );
      if( propertyGrid != null )
      {
        // Use the PropertyGrid.EditorDefinitions for the CollectionControl's propertyGrid.
        this.Editor.EditorDefinitions = propertyGrid.EditorDefinitions;

        this.Editor.CollectionUpdated += this.Editor_CollectionUpdated;
      }
    }

    private PropertyGrid GetParentPropertyGrid( FrameworkElement element )
    {
      var propertyGrid = element as PropertyGrid;
      if( propertyGrid == null )
      {
        var parentPropertyItem = element as PropertyItem;
        while( ( parentPropertyItem != null ) && ( propertyGrid == null ) )
        {
          propertyGrid = parentPropertyItem.ParentElement as PropertyGrid;
          if( propertyGrid == null )
          {
            parentPropertyItem = parentPropertyItem.ParentElement as PropertyItem;
          }
        }
      }

      return propertyGrid;
    }

    private void Editor_CollectionUpdated( object sender, RoutedEventArgs e )
    {
      var propertyGridEditorCollectionControl = sender as PropertyGridEditorCollectionControl;
      if( propertyGridEditorCollectionControl != null )
      {
        var propertyItem = propertyGridEditorCollectionControl.DataContext as PropertyItem;
        if( propertyItem != null )
        {
          var propertyGrid = this.GetParentPropertyGrid( propertyItem.ParentElement );
          if( propertyGrid != null )
          {
            propertyGrid.RaiseEvent( new PropertyValueChangedEventArgs( PropertyGrid.PropertyValueChangedEvent, propertyItem, null, propertyItem.Instance ) );
          }
        }
      }
    }

    protected override void ResolveValueBinding( PropertyItem propertyItem )
    {
      var type = propertyItem.PropertyType;

      Editor.ItemsSourceType = type;

      if( type.BaseType == typeof( System.Array ) )
      {
        Editor.NewItemTypes = new List<Type>() { type.GetElementType() };
      }
      else
      {
        if( ( propertyItem.DescriptorDefinition != null )
            && ( propertyItem.DescriptorDefinition.NewItemTypes != null )
            && ( propertyItem.DescriptorDefinition.NewItemTypes.Count > 0 ) )
        {
          Editor.NewItemTypes = propertyItem.DescriptorDefinition.NewItemTypes;
        }
        else
        {
          //Check if we have a Dictionary
          var dictionaryTypes = ListUtilities.GetDictionaryItemsType( type );
          if( ( dictionaryTypes != null ) && ( dictionaryTypes.Length == 2 ) )
          {
            // A Dictionary contains KeyValuePair that can't be edited.
            // We need to create EditableKeyValuePairs.
            // Create a EditableKeyValuePair< TKey, TValue> type from dictionary generic arguments type
            var editableKeyValuePairType = ListUtilities.CreateEditableKeyValuePairType( dictionaryTypes[ 0 ], dictionaryTypes[ 1 ] );
            Editor.NewItemTypes = new List<Type>() { editableKeyValuePairType };
          }
          else
          {
            //Check if we have a list
            var listType = ListUtilities.GetListItemType( type );
            if( listType != null )
            {
              Editor.NewItemTypes = new List<Type>() { listType };
            }
            else
            {
              //Check if we have a Collection of T
              var colType = ListUtilities.GetCollectionItemType( type );
              if( colType != null )
              {
                Editor.NewItemTypes = new List<Type>() { colType };
              }
            }
          }
        }
      }

      base.ResolveValueBinding( propertyItem );
    }

  }

  public class PropertyGridEditorCollectionControl : CollectionControlButton
  {
    static PropertyGridEditorCollectionControl()
    {
      DefaultStyleKeyProperty.OverrideMetadata( typeof( PropertyGridEditorCollectionControl ), new FrameworkPropertyMetadata( typeof( PropertyGridEditorCollectionControl ) ) );
    }
  }
}
