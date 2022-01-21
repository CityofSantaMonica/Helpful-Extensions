using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using static Lombiq.HelpfulExtensions.Extensions.Widgets.WidgetTypes;

namespace Lombiq.HelpfulExtensions.Extensions.Widgets
{
    public class Migrations : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public Migrations(IContentDefinitionManager contentDefinitionManager) =>
            _contentDefinitionManager = contentDefinitionManager;

        public int Create()
        {
            _contentDefinitionManager.AlterTypeDefinition(ContainerWidget, builder => builder
                .Securable()
                .Stereotype("Widget")
                .WithPart("TitlePart", part => part.WithPosition("0"))
                .WithPart("FlowPart", part => part.WithPosition("1"))
            );

            _contentDefinitionManager.AlterTypeDefinition(HtmlWidget, builder => builder
                .Securable()
                .Stereotype("Widget")
                .WithPart("HtmlBodyPart", part => part
                    .WithDisplayName("HTML Body")
                    .WithSettings(new ContentTypePartSettings
                    {
                        Editor = "Trumbowyg",
                    })
                )
            );

            _contentDefinitionManager.AlterTypeDefinition(LiquidWidget, builder => builder
                .Securable()
                .Stereotype("Widget")
                .WithPart("LiquidPart", part => part
                    .WithDisplayName("Liquid Part")
                )
            );

            _contentDefinitionManager.AlterTypeDefinition(MainMenuWidget, builder => builder
                .Securable()
                .Stereotype("Widget")
            );

            return 3;
        }

        public int UpdateFrom1()
        {
            _contentDefinitionManager.AlterTypeDefinition(ContainerWidget, builder => builder
                .WithPart("TitlePart", part => part.WithPosition("0"))
                .WithPart("FlowPart", part => part.WithPosition("1"))
            );

            return 2;
        }

        public int UpdateFrom2()
        {
            _contentDefinitionManager.AlterTypeDefinition(MainMenuWidget, builder => builder
                .Securable()
                .Stereotype("Widget")
            );

            return 3;
        }
    }
}
