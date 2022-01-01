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
            Destroy(_startScen.Cells[i].gameObject);
        }
        _startScen.Cells = new List<Cell>();

        if (_startScen.IndexLevel > _maxLevel)
        {
            _restart.PreviewRestartPanel();
            _startScen.IndexLevel = 0;
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
