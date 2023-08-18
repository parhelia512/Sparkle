using System.Numerics;
using Raylib_cs;
using Sparkle.csharp.graphics.util;
using Sparkle.csharp.gui.elements.data;

namespace Sparkle.csharp.gui.elements; 

public class LabelElement : GuiElement {
    
    public Font Font;
    public float Rotation;
    public Color Color;
    public Color HoverColor;
    
    public string Text;
    public float FontSize;
    public int Spacing;
    
    protected float CalcFontSize { get; private set; }

    public LabelElement(string name, LabelData data, Vector2 position, Func<bool>? clickClickFunc = null) : base(name, position, data.Size, clickClickFunc) {
        this.Font = data.Font;
        this.Rotation = data.Rotation;
        this.Color = data.Color;
        this.HoverColor = data.HoverColor;
        
        this.Text = data.Text;
        this.FontSize = data.FontSize;
        this.Spacing = data.Spacing;
    }

    protected internal override void Update() {
        float scaleFactor = Math.Min(this.WidthScale, this.HeightScale) * GuiManager.Scale;
        
        this.CalcFontSize = this.FontSize * scaleFactor;
        this.Size = FontHelper.MeasureText(this.Font, this.Text, this.CalcFontSize, this.Spacing);
        base.Update();
    }

    protected internal override void Draw() {
        if (this.Text != string.Empty) {
            Vector2 textPos = new Vector2(this.CalcPos.X + this.Size.X / 2, this.CalcPos.Y + this.Size.Y / 2);
            Vector2 textOrigin = new Vector2(this.Size.X / 2, this.Size.Y / 2);
            FontHelper.DrawText(this.Font, this.Text, textPos, textOrigin, this.Rotation, this.CalcFontSize, this.Spacing, this.IsHovered ? this.HoverColor : this.Color);
        }
    }
}