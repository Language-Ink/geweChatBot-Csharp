using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JinianNet.JNTemplate;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.Reflection;

namespace GeweChatMoYuHelper.wx_bot.util
{
    public class JNTemplateHelper
    {
        // 支持解析 R.xxx.yyy[0].zzz  这样的路径 
        private static readonly Regex TemplatePattern = new Regex(@"\{\{\{R\.([^\}]+)\}\}\}", RegexOptions.Compiled);

        public static string Render( string template, string json)
        {
            try
            {
                // 解析JSON数据 
                var root = JToken.Parse(json);

                // 替换所有模板占位符 
                return TemplatePattern.Replace(template, match =>
                {
                    string path = match.Groups[1].Value;
                    try
                    {
                        // 将 R.xxx.yyy[0]  转换为 JSONPath 格式 $.xxx.yyy[0] 
                        string jsonPath = ConvertToJsonPath(path);
                        var token = root.SelectToken(jsonPath);
                        return token?.ToString() ?? string.Empty;
                    }
                    catch
                    {
                        return string.Empty; // 路径无效时返回空字符串 
                    }
                });
            }
            catch (Exception ex)
            {
                return $"模板渲染错误: {ex.Message}";
            }
        }

        // 将 R.xxx.yyy[0].zzz  转换为 $.xxx.yyy[0].zzz  
        private static string ConvertToJsonPath(string path)
        {
            var segments = path.Split('.');
            var jsonPath = new StringBuilder("$");

            foreach (var segment in segments)
            {
                if (segment.EndsWith("]"))
                {
                    // 处理数组索引，如 items[0]
                    int bracketIndex = segment.IndexOf('[');
                    string prop = segment.Substring(0, bracketIndex);
                    string index = segment.Substring(bracketIndex);

                    jsonPath.Append($".{prop}{index}");
                }
                else
                {
                    jsonPath.Append($".{segment}");
                }
            }

            return jsonPath.ToString();
        }



        public static string ReplaceTokens(string templateText, string root)
        {


            // 创建模板引擎实例
            var engine = Engine.CreateTemplate(templateText);

            // 解析模板
          //  Template template = engine.Parse(templateText);

            // 解析JSON数据
            JObject jsonObject = JObject.Parse(root);

            // 自定义函数来处理不限层级的属性访问
            Func<string, object> getValue = path =>
            {
                string[] parts = path.Split('.');
                JToken current = jsonObject;
                foreach (string part in parts)
                {
                    if (part=="R")
                    {
                        continue;
                    }
                    if (current == null)
                    {
                        continue;
                    }

                    if (current is JObject jobject)
                    {
                        current = jobject[part];
                    }
                    else if (current is JArray jarray && int.TryParse(part, out int index) && index >= 0 && index < jarray.Count)
                    {
                        current = jarray[index];
                    }
                    else
                    {
                        current = null;
                        break;
                    }
                }
                return current;
            };


            // 替换模板中的占位符
            string result = Regex.Replace(templateText, @"\{\{([^}]+)\}\}", match =>
            {
                string path = match.Groups[1].Value;
                object value = getValue(path);
                return value?.ToString() ?? string.Empty;
            });
            return result;
            /*
            dynamic dynObj = JsonConvert.DeserializeObject(root);
            dynamic R = dynObj;

            return Regex.Replace(template, @"\{\{([^}]+)\}\}", match =>
            {
                string path = match.Groups[1].Value;
                return GetValue(R, path)?.ToString() ?? string.Empty;
            });*/
        }


    }
}
