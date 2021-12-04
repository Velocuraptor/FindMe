using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Cell : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _cardSprite;
    [SerializeField] private BoxCollider2D _boxCollider2D;

    private Vector3 _startPosition;
    private bool _isTrueCard;

    public UnityEvent _trueAnswer;
    public UnityEvent _falseAnswer;


    private void Start()
    {
        _startPosition = _cardSprite.transform.position;
        _falseAnswer.AddListener(() => _cardSprite.transform.DOMoveX(_startPosition.x + 0.2f, 0.5f).SetEase(Ease.OutBounce).From());
    }

    public void Initialzie(LevelChanger levelGenerator ,CardData cardData, bool isTrueCard)
    {
        _cardSprite.sprite = cardData.Sprite;
        _isTrueCard = isTrueCard;
        _trueAnswer.AddListener(() => _cardSprite.transform.DOScale(1, 1).SetEase(Ease.OutBounce).From().OnComplete(() => levelGenerator.NextLevel()));
    }

    private void OnMouseDown()
    {
        if (_isTrueCard)
            _trueAnswer?.Invoke();
        else
            _falseAnswer?.Invoke();
    }

    public void NonAcitve() => _boxCollider2D.enabled = false;

}
