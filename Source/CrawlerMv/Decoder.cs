using System.Collections.Generic;
using System.Linq;
using CrawlerMv.Models;

namespace CrawlerMv
{
    public class Decoder
    {
        private static readonly Dictionary<int, string> KnownCodes = new Dictionary<int, string>
        {
            { 0,   "BRK         " },
            { 101, "DLG_ICON    " },
            { 102, "DLG_SELECT  " },
            { 108, "DBG_PRINT   " },
            { 111, "IF          " },
            { 122, "FLG_SET     " },
            { 129, "PARTY_SET   " },
            { 201, "MAP_SET     " },
            { 230, "DLY         " },
            { 231, "DLG_PIC     " },
            { 232, "DLG_MOVEPIC " },
            { 235, "AST_PRELOAD " },
            { 241, "BGM_PLAY    " },
            { 242, "BGM_FADE    " },
            { 245, "BGS_PLAY    " },
            { 246, "BGS_FADE    " },
            { 249, "SFX_PLAY    " },
            { 250, "SPK_PLAY    " },
            { 251, "SPK_STOP    " },
            { 352, "MENU_SAVE   " },
            { 354, "MENU_MAIN   " },
            { 355, "CMD_START   " },
            { 356, "MSG         " },
            { 401, "DLG         " },
            { 402, "DLG_CASE    " },
            { 404, "DLG_ENDSEL  " },
            { 405, "CREDITS     " },
            { 408, "COMMENT     " },
            { 411, "ELSE        " },
            { 412, "ENDIF       " },
            { 655, "CMD         " }
        };

        private static readonly Dictionary<int, string[]> KnownParameters = new Dictionary<int, string[]>
        {
            { 111, new[] { "VarType", "Id", null, "Comparison", null } },
            { 129, new[] { "Character", "Absent", null } },
            { 201, new[] { null, "MapNumber", null, null, null, null } },
            { 230, new[] { "Msec" } }
        };

        private static string DecodeParam(object param, int code, int index, bool enable)
        {
            var prefix = string.Empty;

            if (enable && KnownParameters.ContainsKey(code))
            {
                var parameters = KnownParameters[code];
                if (index >= 0 && index < parameters.Length && parameters[index] != null)
                {
                    prefix = $"{parameters[index]}:";
                }
            }

            switch (param)
            {
                case null:
                    return $"{prefix}null";
                case string s:
                    return $"{prefix}\"{s.Replace("\"", "\\\"").Replace("\\!", "\\n")}\"";
                default:
                    return $"{prefix}{param}";
            }
        }

        public string Decode(CodeListItem item, bool namedParameters)
        {
            if (item?.Code == null)
                return string.Empty;

            var code = KnownCodes.ContainsKey(item.Code.Value)
                ? KnownCodes[item.Code.Value]
                : $"{item.Code:D12}";

            var param = item.Parameters != null && item.Parameters.Any()
                ? string.Join(", ",
                    item.Parameters.Select((p, i) => DecodeParam(p, item.Code.Value, i, namedParameters)))
                : string.Empty;

            var indent = new string(' ', (item.Indent ?? 0) << 2);

            param = param.Replace("\n", $"\n{indent}            ");

            return $"{indent}{code}({param})";
        }
    }
}