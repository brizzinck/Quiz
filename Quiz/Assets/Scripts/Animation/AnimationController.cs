using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private GroupCells _panelCells;
    [SerializeField] private Text _findTxt;
    private Sequence _sequence;
    private Restart _restart;

    public void Bounce(GameObject obj, Sequence sequence)
    {
        sequence.Append(obj.transform.DOScale(1.2f, 0.2f));
        sequence.Append(obj.transform.DOScale(0.80f, 0.2f));
        sequence.Append(obj.transform.DOScale(1f, 0.2f));
    }
    public void  EaseInBounce(GameObject obj, Sequence sequence)
    {
        sequence.Append(obj.transform.DOScale(0.80f, 1f).SetEase(Ease.InBounce));
        sequence.Append(obj.transform.DOScale(1f, 0.2f));
    }
    public void FadeImgCpntroll(Image img, float value, float speed = 1f)
    {
        img.DOFade(value, speed);
    }

    private void Awake()
    {
        _restart = FindObjectOfType<Restart>();
        DOTween.Init();
        _sequence = DOTween.Sequence();
        LevelPreparation(); 
    }
    private void OnEnable()
    {
        _restart.Restarting += AnimationRestart;
    }
    private void Start()
    {
        AnimationStartingLevel();
    }
    private void AnimationRestart()
    {
        LevelPreparation();
        AnimationStartingLevel();
    }
    private void LevelPreparation()
    {
        ClearTween();
        _sequence.Append(_findTxt.DOFade(0f, 0f));
        _sequence.Append(_panelCells.transform.DOScale(0f, 0f));
    }
    private void AnimationStartingLevel()
    {
        ClearTween();
        _findTxt.DOFade(1f, 1f);
        _sequence.AppendInterval(0.4f);
        Bounce(_panelCells.gameObject, _sequence);
    }
    private void ClearTween()
    {
        _sequence.WaitForKill();
        _sequence = DOTween.Sequence();
    }
    private void OnDisable()
    {
        _restart.Restarting -= AnimationRestart;
    }
}
