
public interface IFigure
{
    bool CanPress { get; set; }
    void UpdateFigure(bool activeEffect);
    void Destroy();
}
