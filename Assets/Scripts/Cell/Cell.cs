using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public sealed class Cell : MonoBehaviour
{
    [SerializeField] private Image _imageCell;
    private string _identifierCell;
    private StartLevel _startScen;
    private AnimationController _animationController;
    private LevelTransition _levelTransition;

    public string IdentifierCell { get => _identifierCell; set => _identifierCell = value; }
    public Image ImageCell { get => _imageCell; }

    public void Choose()
    {
        Sequence sequence = DOTween.Sequence();
        if (_startScen.TrueNameCell == _identifierCell)
        {
            _animationController.Bounce(_imageCell.gameObject, sequence);
            sequence.OnComplete(_levelTransition.TransitionNextLevel);
        }
        else
        {
            _animationController.EaseInBounce(_imageCell.gameObject, sequence);
        }
    }

    private void Awake()
    {
        _startScen = FindObjectOfType<StartLevel>();
        _animationController = FindObjectOfType<AnimationController>();
        _levelTransition = FindObjectOfType<LevelTransition>();
    }
}

