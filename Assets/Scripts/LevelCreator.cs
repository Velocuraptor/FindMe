using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    private const int step = 1;

    [SerializeField] private CellManager _cellManager;
    [SerializeField] private Quest _quest;
    [SerializeField] private Cell _cell;

    [SerializeField] CardBundleData[] _cardBundleDatas;

    private List<CardData>[] _cardForUse;
    private CardData _trueCard;

    private void Start()
    {
        _cardForUse = new List<CardData>[_cardBundleDatas.Length];
        for (int i = 0; i < _cardBundleDatas.Length; i++)
            _cardForUse[i] = _cardBundleDatas[i].CardData.ToList();
    }

    public void CreateGameField(LevelChanger levelChanger, Vector2Int difficult, bool isStart)
    {
        _cellManager.ClearGameField();
        CreateGameField(levelChanger, difficult);
        if (!isStart)
        {
            _cellManager.ShowCells();           
            return;
        }
            
        levelChanger._startGame?.Invoke();
    }

    private void CreateGameField(LevelChanger levelChanger, Vector2Int difficult)
    {
        var cards = GetCards(difficult.x * difficult.y);
        var startPosition = new Vector3(-difficult.y / 2, difficult.x / 2, 0.0f);
        var spawnPosition = startPosition;
        for (int i = 0; i < difficult.x; i++)
        {
            spawnPosition.x = startPosition.x;
            for (int j = 0; j < difficult.y; j++)
            {
                var card = cards[Random.Range(0, cards.Count)];
                cards.Remove(card);
                var newCell = Instantiate(_cell, spawnPosition, Quaternion.identity, transform);
                newCell.Initialzie(levelChanger, card, card == _trueCard);
                _cellManager.AddCell(newCell);
                spawnPosition.x += step;
            }
            spawnPosition.y -= step;
        }
        _quest.ShowQuest(_trueCard.Identifier);
    }

    private List<CardData> GetCards(int count)
    {
        var cards = new List<CardData>();

        var type = Random.Range(0, _cardForUse.Length);
        var cardDatas = _cardForUse[type];

        var idTrueCard = Random.Range(0, cardDatas.Count);
        _trueCard = cardDatas[idTrueCard];
        cards.Add(_trueCard);
        cardDatas.RemoveAt(idTrueCard);

        for (int i = 1; i < count; i++)
            cards.Add(cardDatas[Random.Range(0, cardDatas.Count)]);

        return cards;
    }
}
