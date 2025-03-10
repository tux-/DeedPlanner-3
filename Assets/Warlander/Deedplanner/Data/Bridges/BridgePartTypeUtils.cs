using System;
using System.Collections.Generic;
using System.Linq;

namespace Warlander.Deedplanner.Data.Bridges
{
    public static class BridgePartTypeUtils
    {
        private static Dictionary<char, BridgePartType> charToBridgePartTypes = new Dictionary<char, BridgePartType>();

        static BridgePartTypeUtils()
        {
            BridgePartType[] types = Enum.GetValues(typeof(BridgePartType)).Cast<BridgePartType>().ToArray();

            foreach (BridgePartType bridgePartType in types)
            {
                charToBridgePartTypes[bridgePartType.ToChar()] = bridgePartType;
            }
        }

        public static BridgePartType FromChar(char c)
        {
            return charToBridgePartTypes[c];
        }
        
        public static char ToChar(this BridgePartType type)
        {
            switch (type)
            {
                case BridgePartType.Floating:
                    return 'f';
                case BridgePartType.Abutment:
                    return 'a';
                case BridgePartType.Bracing:
                    return 'b';
                case BridgePartType.Crown:
                    return 'c';
                case BridgePartType.DoubleBracing:
                    return 'd';
                case BridgePartType.DoubleAbutment:
                    return 'e';
                case BridgePartType.Support:
                    return 's';
                case BridgePartType.Extension:
                    return '\n'; // It should never appear in actual save files
            }
            
            throw new ArgumentException("No letter for bridge part type: " + type);
        }

        public static BridgePartType[] DecodeSegments(string segmentsString)
        {
            return segmentsString.ToCharArray().Select(FromChar).ToArray();
        }

        public static string EncodeSegments(BridgePartType[] segments)
        {
            return new string(segments.Select(ToChar).ToArray());
        }
    }
}