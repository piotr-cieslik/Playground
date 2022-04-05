namespace CSharp8
{
    public static class PatternMatching
    {
        public static string SwitchExpression(Color color) =>
            color switch
            {
                Color.Red => "Red",
                Color.Green => "Green",
                Color.Blue => "Blue",
                _ => "?"
            };

        public static string PropertyPatterns(Point point) =>
            point switch
            {
                { X: 10 } => "X equal to 10",
                _ => "X not equal to 10",
            };

        public static string TuplePatterns(Point point, Color color) =>
            (point, color) switch
            {
                ({ X: 10 }, Color.Red) => "X equals 10 and color is red.",
                _ => "Other case"
            };
    }
}