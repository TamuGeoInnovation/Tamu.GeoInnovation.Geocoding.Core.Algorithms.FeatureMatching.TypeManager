using System;
using System.Data;

namespace USC.GISResearchLab.Geocoding.Core.Algorithms.FeatureMatchingMethods
{



    public class FeatureMatcher
    {

        public static string FEATURE_MATCH_TYPE_NAME_EXACT = "Exact";
        public static string FEATURE_MATCH_TYPE_NAME_RELAXED = "Relaxed";
        public static string FEATURE_MATCH_TYPE_NAME_SUBSTRING = "Substring";
        public static string FEATURE_MATCH_TYPE_NAME_SOUNDEX = "Soundex";
        public static string FEATURE_MATCH_TYPE_NAME_COMPOSITE = "Composite";
        public static string FEATURE_MATCH_TYPE_NAME_NOMATCH = "No Match";
        public static string FEATURE_MATCH_TYPE_NAME_NEARBY = "Nearby";
        public static string FEATURE_MATCH_TYPE_NAME_UNKNOWN = "Unknown";

        public static DataTable GetAllFeatureMatchTypes()
        {
            DataTable ret = new DataTable();
            ret.Columns.Add(new DataColumn("id", typeof(int)));
            ret.Columns.Add(new DataColumn("name", typeof(string)));
            //ret.Columns.Add(new DataColumn("description", typeof(string)));
            ret.Columns.Add(new DataColumn("value", typeof(string)));

            //DataRow row = null;

            foreach (FeatureMatchTypes item in Enum.GetValues(typeof(FeatureMatchTypes)))
            {
                DataRow row = ret.NewRow();
                row["id"] = (int)item;
                row["name"] = GetFeatureMatchTypeName(item);
                row["value"] = item.ToString();
                ret.Rows.Add(row);
            }

            return ret;
        }

        public static string GetFeatureMatchTypeName(FeatureMatchTypes featureMatchType)
        {
            return GetFeatureMatchTypeName(featureMatchType, ";");
        }

        public static string GetFeatureMatchTypeName(FeatureMatchTypes featureMatchType, string separator)
        {
            string ret = "";

            if ((featureMatchType & FeatureMatchTypes.Composite) == FeatureMatchTypes.Composite)
            {
                ret += separator + FEATURE_MATCH_TYPE_NAME_COMPOSITE;
            }
            if ((featureMatchType & FeatureMatchTypes.Exact) == FeatureMatchTypes.Exact)
            {
                ret += separator + FEATURE_MATCH_TYPE_NAME_EXACT;
            }
            if ((featureMatchType & FeatureMatchTypes.NoMatch) == FeatureMatchTypes.NoMatch)
            {
                ret += separator + FEATURE_MATCH_TYPE_NAME_NOMATCH;
            }
            if ((featureMatchType & FeatureMatchTypes.Nearby) == FeatureMatchTypes.Nearby)
            {
                ret += separator + FEATURE_MATCH_TYPE_NAME_NEARBY;
            }
            if ((featureMatchType & FeatureMatchTypes.Relaxed) == FeatureMatchTypes.Relaxed)
            {
                ret += separator + FEATURE_MATCH_TYPE_NAME_RELAXED;
            }
            if ((featureMatchType & FeatureMatchTypes.Soundex) == FeatureMatchTypes.Soundex)
            {
                ret += separator + FEATURE_MATCH_TYPE_NAME_SOUNDEX;
            }
            if ((featureMatchType & FeatureMatchTypes.Substring) == FeatureMatchTypes.Substring)
            {
                ret += separator + FEATURE_MATCH_TYPE_NAME_SUBSTRING;
            }
            if ((featureMatchType & FeatureMatchTypes.Unknown) == FeatureMatchTypes.Unknown)
            {
                ret += separator + FEATURE_MATCH_TYPE_NAME_UNKNOWN;
            }

            if (ret.StartsWith(separator))
            {
                ret = ret.Substring(1);
            }

            return ret;
        }

        public static FeatureMatchTypes GetFeatureMatchTypeFromName(string featureMatchType)
        {
            FeatureMatchTypes ret = FeatureMatchTypes.Unknown;

            string[] values = featureMatchType.Split(',');
            for (int i = 0; i < values.Length; i++)
            {
                string value = values[i].Trim();
                if (String.Compare(value, FEATURE_MATCH_TYPE_NAME_COMPOSITE, true) == 0)
                {
                    if (ret == FeatureMatchTypes.Unknown)
                    {
                        ret = FeatureMatchTypes.Composite;
                    }
                    else
                    {
                        ret = ret | FeatureMatchTypes.Composite;
                    }
                }
                else if (String.Compare(value, FEATURE_MATCH_TYPE_NAME_EXACT, true) == 0)
                {
                    if (ret == FeatureMatchTypes.Unknown)
                    {
                        ret = FeatureMatchTypes.Exact;
                    }
                    else
                    {
                        ret = ret | FeatureMatchTypes.Exact;
                    }
                }
                else if (String.Compare(value, FEATURE_MATCH_TYPE_NAME_NOMATCH, true) == 0)
                {
                    if (ret == FeatureMatchTypes.Unknown)
                    {
                        ret = FeatureMatchTypes.NoMatch;
                    }
                    else
                    {
                        ret = ret | FeatureMatchTypes.NoMatch;
                    }
                }
                else if (String.Compare(value, FEATURE_MATCH_TYPE_NAME_NEARBY, true) == 0)
                {
                    if (ret == FeatureMatchTypes.Unknown)
                    {
                        ret = FeatureMatchTypes.Nearby;
                    }
                    else
                    {
                        ret = ret | FeatureMatchTypes.Nearby;
                    }
                }
                else if (String.Compare(value, FEATURE_MATCH_TYPE_NAME_RELAXED, true) == 0)
                {
                    if (ret == FeatureMatchTypes.Unknown)
                    {
                        ret = FeatureMatchTypes.Relaxed;
                    }
                    else
                    {
                        ret = ret | FeatureMatchTypes.Relaxed;
                    }
                }
                else if (String.Compare(value, FEATURE_MATCH_TYPE_NAME_SOUNDEX, true) == 0)
                {
                    if (ret == FeatureMatchTypes.Unknown)
                    {
                        ret = FeatureMatchTypes.Soundex;
                    }
                    else
                    {
                        ret = ret | FeatureMatchTypes.Soundex;
                    }
                }
                else if (String.Compare(value, FEATURE_MATCH_TYPE_NAME_SUBSTRING, true) == 0)
                {
                    if (ret == FeatureMatchTypes.Unknown)
                    {
                        ret = FeatureMatchTypes.Substring;
                    }
                    else
                    {
                        ret = ret | FeatureMatchTypes.Substring;
                    }
                }
                else if (String.Compare(value, FEATURE_MATCH_TYPE_NAME_UNKNOWN, true) == 0)
                {
                    ret = FeatureMatchTypes.Unknown;
                }
            }
            return ret;
        }
    }
}
