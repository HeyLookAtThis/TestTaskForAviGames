using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField, Range(300, 350)] private int _winScoreCount;

    private int _totalCount;

    public void AddWinCount() => _totalCount += _winScoreCount;
}
