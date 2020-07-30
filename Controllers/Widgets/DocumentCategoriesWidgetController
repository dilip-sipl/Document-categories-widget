using CMS.DocumentEngine;
using DocumentCategoriesWidget.Controllers.Widgets;
using DocumentCategoriesWidget.Models.Widgets;
using DocumentCategoriesWidget.ViewModels.Widgets;
using Kentico.PageBuilder.Web.Mvc;
using System.Linq;
using System.Web.Mvc;

[assembly: RegisterWidget("SIPL.DocumentCategories", typeof(DocumentCategoriesWidgetController), "Document categories", Description = "Displays the current document categories", IconClass = "icon-square")]
namespace DocumentCategoriesWidget.Controllers.Widgets
{
    public class DocumentCategoriesWidgetController : WidgetController<DocumentCategoriesWidgetProperties>
    {
        // GET: DisplayCategories
        public ActionResult Index()
        {
            var properties = GetProperties();

            string categories = "";
            string nodeAliasPath = System.Web.HttpContext.Current.Request.RawUrl;
            if (!string.IsNullOrEmpty(nodeAliasPath))
            {
                var page = DocumentHelper.GetDocuments()
                                         .Path(nodeAliasPath)
                                         .OnCurrentSite()
                                         .TopN(1)
                                         .FirstOrDefault();



                if (page != null)
                {
                    categories = GetCategories(page.DocumentID, properties.Separator, properties.ContentBefore, properties.ContentAfter);
                }
            }

            return PartialView("Widgets/_DisplayCategories", new DocumentCategoriesWidgetViewModel
            {
                DocumentCategories = categories,
            });
        }

        /// <summary>
        /// Get the document categories and applies the separator
        /// </summary>
        /// <param name="documentID"></param>
        /// <param name="separator"></param>
        /// <param name="contentBefore"></param>
        /// <param name="contentAfter"></param>
        /// <returns></returns>
        public string GetCategories(int documentID, string separator, string contentBefore, string contentAfter)
        {
            string categorieNames = "";
            var documentCategories = DocumentCategoryInfoProvider.GetDocumentCategories(documentID)
                                                                  .Columns("CMS_Category.CategoryID, CategoryDisplayName");

            if (documentCategories != null && documentCategories.Count > 0)
            {
                categorieNames = contentBefore;
                int i = 0;
                foreach (var cat in documentCategories)
                {
                    if (i > 0)
                        categorieNames += separator;

                    categorieNames += cat.CategoryDisplayName;
                    i++;
                }

                categorieNames += contentAfter;
            }

            return categorieNames;
        }
    }
}
