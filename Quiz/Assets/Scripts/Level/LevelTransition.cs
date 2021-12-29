using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelTransition : MonoBehaviour
{
    [SerializeField] private int _maxLevel = 2;
    private StartLevel _startScen;
    private Restart _restart;
    public void TransitionNextLevel()
    {
        for (int i = 0; i < _startScen.Cells.Count; i++)
        {
            Destroy(_startScen.Cells[i].ParentCell.gameObject);
        }
        _startScen.Cells = new List<DisplayInfoCell>();

        if (_startScen.CurrentLevel > _maxLevel)
        {
            _restart.PreviewRestartPanel();
            _startScen.CurrentLevel = 0;
            return;
        }
        _startScen.StartingLevel();
    }
    private void Start()
    {
        _startScen = FindObjectOfType<StartLevel>();
        _restart = FindObjectOfType<Restart>();
    }
}
