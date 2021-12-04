
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    private List<Cell> _createdCells = new List<Cell>();

    public void AddCell(Cell cell) => _createdCells.Add(cell);

    public void ShowCells()
    {
        foreach (var cell in _createdCells)
            cell.gameObject.SetActive(true);
    }

    public void BounceCells()
    {
        ShowCells();
        foreach (var cell in _createdCells)
            cell.transform.DOScale(0.3f, 1).SetEase(Ease.OutBounce).From();
    }

    public void ClearGameField()
    {
        foreach (var cell in _createdCells)
            Destroy(cell.gameObject);
        _createdCells.Clear();
    }

    public void NonActiveGameField()
    {
        foreach (var cell in _createdCells)
            cell.NonAcitve();
    }
}
