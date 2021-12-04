using System;
using UnityEngine;
using UnityEngine.Events;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private LevelCreator _levelCreator;

    //Difficult(rows, columns)
    [SerializeField] private Vector2Int _easy = new Vector2Int(1, 3);
    [SerializeField] private Vector2Int _middle = new Vector2Int(2, 3);
    [SerializeField] private Vector2Int _hard = new Vector2Int(3, 3);

    [SerializeField] private UnityEvent _win;
    public UnityEvent _startGame;

    private int level = 0;

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        level = 1;
        _levelCreator.CreateGameField(this, _easy, true);
        
    }

    public void NextLevel()
    {
        switch (level++)
        {
            case 0:
                _levelCreator.CreateGameField(this, _easy, false);
                break;
            case 1:
                _levelCreator.CreateGameField(this, _middle, false);
                break;
            case 2:
                _levelCreator.CreateGameField(this, _hard, false);
                break;
            default:
                _win?.Invoke();
                break;
        }
    }
}
