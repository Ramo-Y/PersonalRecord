namespace PersonalRecord.Infrastructure.Constants
{
    public static class DefaultConstants
    {
        public const int DEFAULT_REP_COUNT = 1;

        public const string DEFAULT_WEIGHT_UNIT = "kg";
        
        public const string DEFAULT_WEIGHT_UNIT_FORMAT = $"{UNIT_FORMAT_PREFIX}{DEFAULT_WEIGHT_UNIT}";
        
        public const string DEFAULT_DISTANCE_UNIT = "m";

        public const string DEFAULT_DATE_FORMAT = "yyyy-MM-dd";

        public const int DEFAULT_LANGUAGE = 0;

        public const string UNIT_FORMAT_PREFIX = "###.# ";
    }
}