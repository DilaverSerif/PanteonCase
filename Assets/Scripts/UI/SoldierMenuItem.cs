public class SoldierMenuItem: ClickableMenuItem
{
    public override void OnClick()
    {
        Factory.Instance.ProducSoldier();
    }
}