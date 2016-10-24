public class CreateSelectList
{
        public static IList<SelectListItem> From<T>()
        {
            Type t = typeof(T);
            if (t.IsEnum)
            {
                var values = from Enum e in Enum.GetValues(t)
                             select new SelectListItem()
                             {
                                 Text = e.GetDescription(),
                                 Value = Convert.ToInt32(Enum.Parse(t, e.ToString())).ToString()
                             };
                return values.ToList();
            }
            return null;
        }

        public static IList<SelectListItem> From<T>(IQueryable<T> Source, Func<T, object> Value, Func<T, string> Text)
        {
            var q = from T item in Source
                    select new SelectListItem()
                    {
                        Text = Text(item),
                        Value = Value(item).ToString()
                    };
            return q.ToList();
        }
}


public static class Extensions
{
        public static String GetDescription(this Enum enumVal)
        {
            if (enumVal == null) return "";
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? ((DescriptionAttribute)attributes[0]).Description.ToString() : enumVal.ToString();
        }
}
