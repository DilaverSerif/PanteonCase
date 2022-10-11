using System.Collections;
using UnityEngine;

interface IMovedable
{
    IEnumerator Move(Cell TargetCell);
}