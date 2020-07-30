using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

namespace DocumentCategoriesWidget.Models.Widgets
{
    public class DocumentCategoriesWidgetProperties : IWidgetProperties
    {
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Category name separator", DefaultValue = ";", Order = 0)]
        public string Separator { get; set; }

        [EditingComponent(TextAreaComponent.IDENTIFIER, Label = "Content before", Order = 1)]
        public string ContentBefore { get; set; }

        [EditingComponent(TextAreaComponent.IDENTIFIER, Label = "Content after", Order = 2)]
        public string ContentAfter { get; set; }
    }
}
