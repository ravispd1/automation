namespace DummyFramework
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttribute(typeof(DescriptionAttribute),false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
        
        public static T ParseEnum<T>(string value)
        {
            return (T) Enum.Parse(typeof(T), value, true);
        }
    }
}
