using Foundation;
using Microsoft.Maui.Handlers;

public partial class CustomLabelHandler : LabelHandler
{
    private static new IPropertyMapper<ILabel, ILabelHandler> Mapper()
    {
        var mapper = new PropertyMapper<ILabel, ILabelHandler>(LabelHandler.Mapper);
        mapper.ModifyMapping(nameof(ILabel.Text), (h, v, a) => MapText(h, v));
        return mapper;
    }

    public CustomLabelHandler() : base(Mapper()) { }

    public static new void MapText(ILabelHandler handler, ILabel label)
    {
        if (handler.PlatformView != null && label.Text != null)
            handler.PlatformView.AttributedText = new NSMutableAttributedString(label.Text);

        MapFormatting(handler, label);
    }
}