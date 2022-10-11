using System;
using System.Threading.Tasks;

public class GridManager : Singlenton<GridManager>
{
    public static Action OnChanged;
    private IGridCreater GridCreater { get; set; }
    public IRaySelector RaySelector { get; private set; }
    public IGridChecker GridChecker { get; private set; }
    public Task Initialize()
    {
        GridCreater = GetComponent<IGridCreater>();
        RaySelector = GetComponent<IRaySelector>();
        GridChecker = GetComponent<IGridChecker>();
        
        GridCreater.CreateGrid();
        
        return Task.CompletedTask;
    }

    private void OnEnable()
    {
        OnChanged += GridCreater.AllCellCheck;
    }
    
    private void OnDisable()
    {
        OnChanged -= GridCreater.AllCellCheck;
    }
    
}