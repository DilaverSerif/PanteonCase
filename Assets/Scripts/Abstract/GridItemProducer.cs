public abstract class GridItemProducer: GridItem
{
    protected abstract bool CheckRequirements();
    public abstract void Produce();
}