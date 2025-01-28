using UnityEngine;

[CreateAssetMenu(fileName = "RopesConfig", menuName = "Configs/RopesConfig")]
public class RopesConfig : ScriptableObject
{
    [SerializeField] private Rope _prefab;
    [SerializeField] private LayerMask _layerMask;

    public Rope Prefab => _prefab;
    public LayerMask LayerMask => _layerMask;
}
