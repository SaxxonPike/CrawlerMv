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
            { 201, "MAP_SET     " },
            { 230, "DLY         " },
            { 231, "DLG_PIC     " },
            { 232, "DLG_MOVEPIC " },
            { 235, "AST_PRELOAD " },
            { 241, "BGM_PLAY    " },
            { 245, "BGS_PLAY    " },
            { 250, "SPK_PLAY    " },
            { 251, "SPK_STOP    " },
            { 355, "CMD_START   " },
            { 356, "MSG         " },
            { 401, "DLG         " },
            { 402, "DLG_CASE    " },
            { 404, "DLG_ENDSEL  " },
            { 411, "ELSE        " },
            { 412, "ENDIF       " },
            { 655, "CMD         " }
        };

        private static string DecodeParam(object param)
        {
            if (param == null)
                return "null";

            if (param is string)
                return $"\"{param}\"";

            return param.ToString();
        }

        public string Decode(CodeListItem item)
        {
            if (item?.Code == null)
                return string.Empty;

            var code = KnownCodes.ContainsKey(item.Code.Value)
                ? KnownCodes[item.Code.Value]
                : $"{item.Code:D12}";

            var param = item.Parameters != null && item.Parameters.Any()
                ? string.Join(", ", item.Parameters.Select(DecodeParam))
                : string.Empty;

            var indent = new string(' ', (item.Indent ?? 0) << 2);

            param = param.Replace("\n", $"\n{indent}            ");

            return $"{indent}{code}({param})";
        }
    }
}
