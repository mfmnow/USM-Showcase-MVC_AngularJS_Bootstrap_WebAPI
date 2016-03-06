using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace USM.DAL
{
	public class ScaffoldFunctions
	{
    // return string containing HTML
		static public string GetHtmlForDisplayOnEditViewAttribute(string ViewDataTypeName, string PropertyName, bool IsReadOnly)
		{
			string returnValue = String.Empty;

			Attribute displayOnEditView = null;
			Type typeModel = Type.GetType(ViewDataTypeName);
			if (typeModel != null)
			{
				displayOnEditView = (DisplayOnEditView)Attribute.GetCustomAttribute(typeModel.GetProperty(PropertyName), typeof(DisplayOnEditView));
				if (displayOnEditView == null)
				{
					if (IsReadOnly)
					{ returnValue = String.Empty; }
					else
				  { returnValue = "@Html.EditorFor(model => model." + PropertyName + ")"; }
				}
				else 
				{
					if (((DisplayOnEditView)displayOnEditView).DisplayFlag == true)
				  { returnValue = "@Html.DisplayTextFor(model => model." + PropertyName + ")"; }
					else
					{ returnValue = "@Html.EditorFor(model => model." + PropertyName + ")"; }
				}
			}

			return returnValue;
		}

		static public List<string> GetPropertyIsModifiedList(string ModelNamespace, string ModelTypeName, string ModelVariable)
		{
			List<string> OutputList = new List<string>();

			// get the properties of the model object
			string aqn = Assembly.CreateQualifiedName(ModelNamespace + ", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ModelNamespace + "." + ModelTypeName);

			// get a Type object based on the Assembly Qualified Name
			Type typeModel = Type.GetType(aqn);
			// get the properties of the type
			PropertyInfo[] typeModelProperties = typeModel.GetProperties();
	
			PersistPropertyOnEdit persistPropertyOnEdit;

			foreach (PropertyInfo propertyInfo in typeModelProperties)
			{
				persistPropertyOnEdit = (PersistPropertyOnEdit)Attribute.GetCustomAttribute(typeModel.GetProperty(propertyInfo.Name), typeof(PersistPropertyOnEdit));
				
				if (persistPropertyOnEdit == null)
				{
					OutputList.Add(ModelVariable + "Entry.Property(e => e." + propertyInfo.Name + ").IsModified = true;");
				}
				else
				{
			OutputList.Add(ModelVariable + "Entry.Property(e => e." + propertyInfo.Name + ").IsModified = " + ((PersistPropertyOnEdit)persistPropertyOnEdit).PersistPostbackDataFlag.ToString().ToLower() + ";");
				}
			}
			return OutputList;
		}

    static public List<string> GetPropertyIsModifiedList3(string ModelNamespace, string ModelTypeName, string ModelVariable)
    {
      List<string> OutputList = new List<string>();
 
      // Get the properties of the model object
      string aqn = Assembly.CreateQualifiedName(ModelNamespace + ", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ModelNamespace + "." + ModelTypeName);
 
      // Get a Type object based on the Assembly Qualified Name
      Type typeModel = Type.GetType(aqn);
      // Get the properties of the type
      PropertyInfo[] typeModelProperties = typeModel.GetProperties();
         
      PersistPropertyOnEdit persistPropertyOnEdit;
 
      foreach (PropertyInfo propertyInfo in typeModelProperties)
      {
        persistPropertyOnEdit = (PersistPropertyOnEdit)Attribute.GetCustomAttribute(
          typeModel.GetProperty(propertyInfo.Name), typeof(PersistPropertyOnEdit));
                                   
        if (persistPropertyOnEdit == null)
        {
        OutputList.Add(ModelVariable + "Entry.Property(e => e." + 
          propertyInfo.Name + ").IsModified = true;");
        }
        else
        {
        OutputList.Add(ModelVariable + "Entry.Property(e => e." + 
          propertyInfo.Name + ").IsModified = " + 
          ((PersistPropertyOnEdit)persistPropertyOnEdit).
          PersistPostbackDataFlag.ToString().ToLower() + ";");
        }
      }
      return OutputList;
    }
	}
}