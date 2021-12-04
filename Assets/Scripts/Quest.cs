using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Quest : MonoBehaviour
{
    [SerializeField] private Text _quest;

    public void ShowQuest(string identifier)
    {
        _quest.text = $"Find {identifier}";
    }

    public void FadeQuest() => _quest.DOFade(1, 1.0f);

    public void ResetColor()
    {
        var newColor = _quest.color;
        newColor.a = 0;
        _quest.color = newColor;
    }
}
