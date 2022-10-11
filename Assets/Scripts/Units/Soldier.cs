using UnityEngine;

public class Soldier : GridItemMoveable
{
    private IMovedable _move;
    private Coroutine moveCoroutine;

    private void Awake()
    {
        _move = GetComponent<IMovedable>();
    }
    
    public override void Move(ref Cell cell)
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
            moveCoroutine = null;
        }
        
        moveCoroutine = StartCoroutine(_move.Move(cell));
    }
}
