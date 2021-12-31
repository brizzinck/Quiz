using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cells/Cell Data", fileName = "New Cell Data")]
public class CellBundleData : ScriptableObject
{
    [SerializeField] private CellData[] _cells;
    [SerializeField] private int _sizeCells;
    public CellData[] CellsData { get => _cells; }
    public int SizeCells { get => _sizeCells; }
}
