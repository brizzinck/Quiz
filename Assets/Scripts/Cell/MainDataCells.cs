using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cells/Cell Main Data", fileName = "New Cell Main Data")]
public class MainDataCells : ScriptableObject
{
    [SerializeField] private CellBundleData[] _cellBundleData;
    public CellBundleData[] CellBundleData { get => _cellBundleData; }
}
