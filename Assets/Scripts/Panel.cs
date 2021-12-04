using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;

public class Panel : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private UnityEvent Load, Game;


    public void ShowHalf()
    {
        _image.DOFade(0.5f, 1);
    }

    public void ShowAll()
    {
        _image.DOFade(1.0f, 1).OnComplete(() => Load?.Invoke());
    }

    public void CloseAll()
    {
        _image.DOFade(0.0f, 1).OnComplete(() => Game?.Invoke()); ;
    }
}
