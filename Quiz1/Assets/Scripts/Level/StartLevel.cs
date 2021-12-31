using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartLevel : MonoBehaviour
{
    [SerializeField] private GroupCells _panelBlock;
    [SerializeField] private Cell _cell;
    [SerializeField] private MainDataCells[] _mainDataCells;
    [SerializeField] private Text _findTxt;

    private List<DisplayInfoCell> _infoCells = new List<DisplayInfoCell>();
    private List<string> _currentsCorrectIdentifier = new List<string>();
    private List<string> _currentsAllIdentifier = new List<string>();

    private Restart _restart;

    private string _trueVariate;
    private int _currentLevel = 0;
    private int _levelVariationNumber;

    public List<DisplayInfoCell> Cells { get => _infoCells; set => _infoCells = value; }
    public string TrueNameCell { get => _trueVariate; }
    public int CountCells { get => _currentLevel; }
    public int CurrentLevel { get => _currentLevel; set => _currentLevel = value; }
    public void CleansingList()
    {
        _currentsCorrectIdentifier = new List<string>();
        _currentsAllIdentifier = new List<string>();
    }
    public void StartingLevel()
    {
        _levelVariationNumber = Random.Range(0, _mainDataCells.Length);
        SpawnCell();
        SetVariablesCells();
        SetTrueVariate();
        DataListControll();
        _currentLevel += 1;
    }

    private void OnEnable()
    {
        _restart = FindObjectOfType<Restart>();
        _restart.Restarting += CleansingList;
        _restart.Restarting += StartingLevel;
    }
    private void Start()
    {
        StartingLevel();
    }
    private void SpawnCell()
    {
        for (int i = 0; i < _mainDataCells[_levelVariationNumber].CellBundleData[_currentLevel].SizeCells; i++)
        {
            Cell cel = Instantiate(_cell, _panelBlock.transform);
            _infoCells.Add(cel.GetComponentInChildren<DisplayInfoCell>());
        }
    }
    private void SetVariablesCells()
    {
        foreach (Cell cell in _infoCells)
        {
            int numberCell = Random.Range(0, _mainDataCells[_levelVariationNumber].CellBundleData[_currentLevel].CellsData.Length);
            string temp = _mainDataCells[_levelVariationNumber].CellBundleData[_currentLevel].CellsData[numberCell].Identifier;

            bool repetitions = true;
            while (repetitions == true)
            {
                if (_currentsAllIdentifier.Contains(temp))
                {
                    numberCell = Random.Range(0, _mainDataCells[_levelVariationNumber].CellBundleData[_currentLevel].CellsData.Length);
                    temp = _mainDataCells[_levelVariationNumber].CellBundleData[_currentLevel].CellsData[numberCell].Identifier;
                }
                else repetitions = false;
            }
            PictureSetting(cell.GetComponent<Image>(), _mainDataCells[_levelVariationNumber].CellBundleData[_currentLevel].CellsData[numberCell]);
            cell.GetComponent<DisplayInfoCell>().IdentifierCell = _mainDataCells[_levelVariationNumber].CellBundleData[_currentLevel].CellsData[numberCell].Identifier;

            _currentsAllIdentifier.Add(temp);
        }
    }
    private void PictureSetting(Image image, CellData cellData)
    {
        image.sprite = cellData.Sprite;
        image.SetNativeSize();
        image.rectTransform.sizeDelta = new Vector2(image.rectTransform.sizeDelta.x / 2.5f, image.rectTransform.sizeDelta.y / 2.5f);
        image.rectTransform.eulerAngles = new Vector3(image.transform.rotation.x, image.transform.rotation.y, cellData.RotationSprite);
    }
    private void SetTrueVariate()
    {
        int numberCell = Random.Range(0, _infoCells.Count);
        _trueVariate = _infoCells[Random.Range(0, numberCell)].IdentifierCell;

        bool repetitions = true;
        while (repetitions == true)
        {
            if (_currentsCorrectIdentifier.Contains(_trueVariate))
            {
                numberCell = Random.Range(0, _infoCells.Count);
                _trueVariate = _infoCells[numberCell].IdentifierCell;
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
        _restart.Restarting -= CleansingList;
        _restart.Restarting -= StartingLevel;
    }
}
