using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartLevel : MonoBehaviour
{
    [SerializeField] private GroupCells _panelBlock;
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private MainDataCells[] _mainDataCells;
    [SerializeField] private Text _findTxt;

    private List<Cell> _cells = new List<Cell>();
    private List<string> _currentsCorrectIdentifier = new List<string>();
    private List<string> _currentsAllIdentifier = new List<string>();

    private Restart _restart;

    private string _trueVariate;
    private int _indexLevel = 0;
    private int _levelVariation;

    public List<Cell> Cells { get => _cells; set => _cells = value; }
    public string TrueNameCell { get => _trueVariate; }
    public int CountCells { get => _indexLevel; }
    public int IndexLevel { get => _indexLevel; set => _indexLevel = value; }
    public Text FindTxt { get => _findTxt; }

    public void CleansingData()
    {
        _currentsCorrectIdentifier = new List<string>();
        _currentsAllIdentifier = new List<string>();
    }
    public void StartingLevel()
    {
        _levelVariation = Random.Range(0, _mainDataCells.Length);
        SpawnCell();
        SetVariablesCells();
        SetTrueVariate();
        DataListControll();
        _indexLevel += 1;
    }

    private void OnEnable()
    {
        _restart = FindObjectOfType<Restart>();
        _restart.Restarting += CleansingData;
        _restart.Restarting += StartingLevel;
    }
    private void Start()
    {
        StartingLevel();
    }
    private void SpawnCell()
    {
        for (int i = 0; i < _mainDataCells[_levelVariation].CellBundleData[_indexLevel].SizeCells; i++)
        {
            Cell cel = Instantiate(_cellPrefab, _panelBlock.transform);
            _cells.Add(cel.GetComponentInChildren<Cell>());
        }
    }
    private void SetVariablesCells()
    {
        foreach (Cell cell in _cells)
        {
            int numberCell = Random.Range(0, _mainDataCells[_levelVariation].CellBundleData[_indexLevel].CellsData.Length);
            string temp = _mainDataCells[_levelVariation].CellBundleData[_indexLevel].CellsData[numberCell].Identifier;

            bool repetitions = true;
            while (repetitions == true)
            {
                if (_currentsAllIdentifier.Contains(temp))
                {
                    numberCell = Random.Range(0, _mainDataCells[_levelVariation].CellBundleData[_indexLevel].CellsData.Length);
                    temp = _mainDataCells[_levelVariation].CellBundleData[_indexLevel].CellsData[numberCell].Identifier;
                }
                else repetitions = false;
            }
            PictureSetting(cell.ImageCell, _mainDataCells[_levelVariation].CellBundleData[_indexLevel].CellsData[numberCell]);
            cell.IdentifierCell = _mainDataCells[_levelVariation].CellBundleData[_indexLevel].CellsData[numberCell].Identifier;
            _currentsAllIdentifier.Add(temp);
        }
    }
    private void PictureSetting(Image image, CellData cellData)
    {
        image.sprite = cellData.Sprite;
        image.SetNativeSize();
        image.rectTransform.sizeDelta = new Vector2(image.rectTransform.sizeDelta.x / cellData.SizeSprite, image.rectTransform.sizeDelta.y / cellData.SizeSprite);
        image.rectTransform.eulerAngles = new Vector3(image.transform.rotation.x, image.transform.rotation.y, cellData.RotationSprite);
    }
    private void SetTrueVariate()
    {
        int numberCell = Random.Range(0, _cells.Count);
        _trueVariate = _cells[Random.Range(0, numberCell)].IdentifierCell;

        bool repetitions = true;
        while (repetitions == true)
        {
            if (_currentsCorrectIdentifier.Contains(_trueVariate))
            {
                numberCell = Random.Range(0, _cells.Count);
                _trueVariate = _cells[numberCell].IdentifierCell;
            }
            else repetitions = false;
        }

        _findTxt.text = "Find " + _trueVariate;
    }
    private void DataListControll()
    {
        _currentsCorrectIdentifier.Add(_trueVariate);
        _currentsAllIdentifier = new List<string>();
    }
    private void OnDisable()
    {
        _restart.Restarting -= CleansingData;
        _restart.Restarting -= StartingLevel;
    }
}
