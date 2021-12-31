using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Restart : MonoBehaviour
{
    public UnityAction Restarting;

    [SerializeField] private Image _panelRestart;
    [SerializeField] private Image _panelLoading;
    [SerializeField] private Text _findTxt;
    private AnimationController _animationController;
    public void PreviewRestartPanel()
    {
        _findTxt.text = "";
        _panelRestart.gameObject.SetActive(true);
        _animationController.FadeImgCpntroll(_panelRestart, 1);
    }    
    public void RestartGame()
    {
        StartCoroutine(RestartingGame());
    }
    private void Start()
    {
        _animationController = FindObjectOfType<AnimationController>();
    }
    private IEnumerator RestartingGame()
    {
        _panelLoading.gameObject.SetActive(true);
        _animationController.FadeImgCpntroll(_panelLoading, 1);
        yield return new WaitForSeconds(1);
        _animationController.FadeImgCpntroll(_panelRestart, 0, 0);
        _animationController.FadeImgCpntroll(_panelLoading, 0, 0);
        _panelRestart.gameObject.SetActive(false);
        _panelLoading.gameObject.SetActive(false);
        Restarting?.Invoke();
    }
}
