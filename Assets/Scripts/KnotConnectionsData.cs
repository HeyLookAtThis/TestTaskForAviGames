public class KnotConnectionsData
{
    private int[][] _data;

    public KnotConnectionsData()
    {
        _data = new int[][] { new int[] { 1, 2, 4, 10 }, new int[] { 0, 5, 11 }, new int[] { 0, 6 }, new int[] { 9, 11, 12 },
                              new int[] { 0, 7, 13 }, new int[] { 1, 12, 6 }, new int[] { 5, 2 }, new int[] { 4, 12, 8 },
                              new int[] { 7, 13, 9 }, new int[] { 8, 3, 10 }, new int[] { 9, 0, 11 },
                              new int[] { 10, 1, 3, 12 }, new int[] { 11, 7, 3, 5 }, new int[] { 8, 4 } };
    }

    public int GetConnectionCount(int cellIndex) => _data[cellIndex].Length;
    public int GetConnection(int cellIndex, int connectionIndex) => _data[cellIndex][connectionIndex];
}
