using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public sealed class DisplayInfoCell : Cell
{
    private string _identifierCell;
    private Cell _parentCell;
    private StartLevel _startScen;
    private AnimationController _animationController;
    private LevelTransition _levelTransition;

    public Cell ParentCell { get => _parentCell; }
    public string IdentifierCell { get => _identifierCell; set => _identifierCell = value; }

    public void Choose()
    {
        Sequence sequence = DOTween.Sequence();
        if (_startScen.TrueNameCell == _identifierCell)
        {
            _animationController.Bounce(gameObject, sequence);
            _levelTransition.TransitionNextLevel();
        }
        else
        {
            _animationController.EaseInBounce(gameObject, sequence);
        }
    }

    private void Awake()
    {
        _parentCell = transform.parent.GetComponentInParent<Cell>();
        _startScen = FindObjectOfType<StartLevel>();
        _animationController = FindObjectOfType<AnimationController>();
        _levelTransition = FindObjectOfType<LevelTransition>();
    }
}
