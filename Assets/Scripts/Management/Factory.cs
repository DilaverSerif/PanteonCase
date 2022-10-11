using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Singlenton<Factory>
{
    private GridItemProducer selectedGridItemProducer;
    
    public void SetSelectedGridItemProducer(GridItemProducer gridItemProducer)
    {
        selectedGridItemProducer = gridItemProducer;
        ScrollManager.ChangerMenu.Invoke(1);
    }
    
    public void ProducSoldier()
    {
        if (selectedGridItemProducer == null) 
            return;
        selectedGridItemProducer.Produce();
    }
}
