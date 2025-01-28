using UnityEngine;

[CreateAssetMenu(fileName = "RopesConfig", menuName = "Configs/RopesConfig")]
public class RopesConfig : ScriptableObject
{
    [SerializeField] private Rope _prefab;
    [SerializeField] private KnotConfig[] _knotConfigs;

    public Rope Prefab => _prefab;
    public int GetCount(int index) => _knotConfigs[index].RopeCount;
}
