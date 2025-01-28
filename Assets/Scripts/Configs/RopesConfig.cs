using UnityEngine;

[CreateAssetMenu(fileName = "RopesConfig", menuName = "Configs/RopesConfig")]
public class RopesConfig : ScriptableObject
{
    [SerializeField] private Rope _prefab;
    [SerializeField] private KnotConfig[] _knotConfigs;

    public Rope Prefab => _prefab;
    public KnotConfig GetKnotConfig(int index) => _knotConfigs[index];
}
