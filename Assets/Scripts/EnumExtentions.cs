using System;
using System.Linq;
public static class EnumExtentions{
    public static T GetRandomEnumValue<T>() where T : Enum => (T) Enum.GetValues(typeof(T)).OfType<Enum>().OrderBy(_ => Guid.NewGuid()).FirstOrDefault();
}

