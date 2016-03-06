using System;

namespace USM.DAL
{
	public class DisplayOnEditView : Attribute
	{
		public readonly bool DisplayFlag;
		public DisplayOnEditView(bool displayFlag)
		{
			this.DisplayFlag = displayFlag;
		}
	}

	public class PersistPropertyOnEdit : Attribute
	{
		public readonly bool PersistPostbackDataFlag;
		public PersistPropertyOnEdit(bool persistPostbackDataFlag)
		{
			this.PersistPostbackDataFlag = persistPostbackDataFlag;
		}
	}

    public class Unique : Attribute
    {
        public readonly bool IsUnique;
        public Unique(bool unique=true)
        {
            this.IsUnique = unique;
        }
    }

    public class Icon : Attribute
    {
        public readonly string IconName;
        public Icon(string iconName="justify")
        {
            this.IconName = iconName;
        }
    }

    public class DisplayAsRadio : Attribute
    {
        public readonly string Name1;
        public readonly string Value1;
        public readonly string Name2;
        public readonly string Value2;
        public DisplayAsRadio(string name1, string value1, string name2, string value2)
        {
            this.Name1 = name1;
            this.Value1 = value1;
            this.Name2 = name2;
            this.Value2 = value2;
        }
    }
}
