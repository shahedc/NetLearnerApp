using HtmlAgilityPack;
using MariGold.OpenXHTML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace DocMaker.Utils
{
    internal class DocEngine
    {
        public static void MakeDoc(string pageUrl, bool showHtml = false)
        {
            // Get HTML from website
            string htmlContent = string.Empty;
            Console.WriteLine($"Source: {pageUrl}");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(pageUrl);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                htmlContent = reader.ReadToEnd();
            }
            string outputFileName = request.RequestUri.AbsolutePath.Substring(1);
            if (showHtml)
                Console.WriteLine(htmlContent);

            // load HTML content, fix formatting
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlContent);
            //FixImageDimensions(htmlDoc);

            DeleteHtmlContent(htmlDoc, "//footer[@class=\"entry-meta\"]");
            DeleteHtmlContent(htmlDoc, "//div[@id=\"comments\"]");
            DeleteHtmlContent(htmlDoc, "//nav[@class=\"nav-single\"]");

            string htmlNodeContent = FixCodeFormatting(htmlDoc);

            // Write html node's content to text file.
            File.WriteAllText(@"HtmlContent.txt", htmlNodeContent);

            Console.WriteLine("Making your document...");

            // Create DOCX file
            WordDocument wordDoc = new WordDocument($"{outputFileName}.docx");
            wordDoc.Process(new HtmlParser(htmlNodeContent));
            wordDoc.Save();
            Console.WriteLine($"Output: {outputFileName}.docx");
        }

        private static void DeleteHtmlContent(HtmlDocument htmlDoc, string nodeSelector)
        {
            HtmlNode htmlNode = htmlDoc.DocumentNode.SelectSingleNode(nodeSelector);
            htmlNode.Remove();
        }

        private static string FixCodeFormatting(HtmlDocument htmlDoc)
        {
            // look for <pre> tags which contain code snippets 
            var preNodes = htmlDoc.DocumentNode.SelectNodes("//pre");

            if (preNodes != null)
            {
                foreach (HtmlNode htmlPreNode in preNodes)
                {
                    // replace doc's \n newlines with HTML breaks
                    // ... as Environment.NewLine doesn't seem to work (?)
                    var replacedText = htmlPreNode.InnerText
                        .Replace("\n", "<br />");

                    var TextWithFormatting = "<span style=\"color: #808080;font-family: Courier New;\">"
                        + replacedText + "</span>";

                    htmlPreNode.ParentNode.ReplaceChild(
                        HtmlTextNode.CreateNode(
                            TextWithFormatting), htmlPreNode);
                }

            }

            HtmlNode htmlNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"content\"]");
            string htmlNodeContent = (htmlNode == null) ? "Error, id not found" : htmlNode.InnerHtml;

            return htmlNodeContent;
        }

        private static void FixImageDimensions(HtmlDocument htmlDoc)
        {
            // look for <img> tags which contain code snippets 
            var imgNodes = htmlDoc.DocumentNode.SelectNodes("//img");
            foreach (HtmlNode htmlImgNode in imgNodes)
            {
                if (htmlImgNode.Attributes["class"] != null)
                    htmlImgNode.Attributes["class"].Remove();

                if (htmlImgNode.Attributes["srcset"] != null)
                    htmlImgNode.Attributes["srcset"].Remove();

                if (htmlImgNode.Attributes["sizes"] != null)
                    htmlImgNode.Attributes["sizes"].Remove();

                if (htmlImgNode.Attributes["width"] != null)
                    htmlImgNode.Attributes["width"].Remove();

                if (htmlImgNode.Attributes["height"] != null)
                    htmlImgNode.Attributes["height"].Remove();

                //Create new style attribute to set width?
                HtmlAttribute styleAttribute = htmlDoc.CreateAttribute("style");
                styleAttribute.Value = "width:100px";
                htmlImgNode.Attributes.Add(styleAttribute);

            }
        }
    }
}
