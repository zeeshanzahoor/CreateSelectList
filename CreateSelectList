
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
