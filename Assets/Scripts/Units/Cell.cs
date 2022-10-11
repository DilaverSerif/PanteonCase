using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Cell: GridItem
{
    private SpriteRenderer rend;
    private TextMeshPro cellText;
    public bool IsBusy=> _BuildingType != BuildingType.None;
    public BuildingType _BuildingType = BuildingType.None;
    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        cellText = GetComponentInChildren<TextMeshPro>();
    }

    public void Setup(Vector2 pos,BuildingType type)
    {
        Position = pos;
        _BuildingType = type;

        if (IsBusy) 
            rend.color = Color.red;

        transform.position = pos;
        cellText.text = pos.x + "/" + pos.y;
    }
    
    
    public void SetColor(Color color)
    {
        rend.color = color;
    }
    
    public Vector2 Position;
    public Cell NextCell { get; private set; }
    public List<Cell> Neighbours
    {
        get
        {
            return Physics2D.BoxCastAll(transform.position,Vector2.one,0,Vector2.zero,0.1f,LayerMask.GetMask("Cell"))
                .Select(x=> x.collider.GetComponent<Cell>()).ToList();
        }
    }
    
    public float g { get; private set; }
    public float h { get; private set; }
    public float F => g + h;
    public float GetDistance(Cell other) => CellGetDistance.GetDistance(this,other);
    public void SetG(float G) => g = G;
    public void SetH(float H) => h = H;
    public void SetNextCell(ref Cell nextCell) => NextCell = nextCell;
    
    public Cell(Vector2 position)
    {
        Position = position;
    }
}