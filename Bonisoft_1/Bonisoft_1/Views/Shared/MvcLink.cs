using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bonisoft_1.Views.Shared
{
    using System.Text.RegularExpressions;
    using System.Web.Mvc;
    public class MvcLink : IDisposable
    {
        internal static readonly string InnerText = "___F7ED35E0097945398D5A969F8DE2C63C___";
        private static readonly Regex RegexPattern = new Regex(@"^\s*(?<startTag>.*)\s*" + InnerText + @"\s*(?<endTag>.*)\s*$", RegexOptions.Compiled | RegexOptions.Singleline);

        private readonly ViewContext _viewContext;
        private readonly string _endTag;

        internal MvcLink(ViewContext viewContext, IHtmlString actionLink)
        {
            _viewContext = viewContext;
            var match = RegexPattern.Match(actionLink.ToHtmlString());
            if (match.Success)
            {
                var startTag = match.Groups["startTag"].Value;
                _endTag = match.Groups["endTag"].Value;
                _viewContext.Writer.Write(startTag);
            }
        }

        public void Dispose()
        {
            _viewContext.Writer.Write(_endTag);
        }
    }
}