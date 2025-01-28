using System.Collections.Generic;

public class KnotConnectionsData
{
    private List<List<int>> _data;
    private List<List<int>> _currentData;

    public KnotConnectionsData()
    {
        _data = new List<List<int>> { new() { 1, 2, 4, 10 }, new() { 0, 5, 11 }, new() { 0, 6 }, new() { 9, 11, 12 },
                              new() { 0, 7, 13 }, new() { 1, 12, 6 }, new() { 5, 2 }, new() { 4, 12, 8 },
                              new() { 7, 13, 9 }, new() { 8, 3, 10 }, new() { 9, 0, 11 },
                              new() { 10, 1, 3, 12 }, new() { 11, 7, 3, 5 }, new() { 8, 4 } };

        _currentData = new List<List<int>>(_data);
        DeleteDublicateValues();
    }

    public int GetConnectionCount(int cellIndex) => _currentData[cellIndex].Count;
    public int GetConnection(int cellIndex, int connectionIndex) => _currentData[cellIndex][connectionIndex];

    private void DeleteDublicateValues()
    {
        for (int i = 0; i < _currentData.Count; i++)
            for (int j = 0; j < _currentData[j].Count; j++)
                if (_currentData[j].Contains(i))
                    _currentData[j].Remove(i);
    }
}
