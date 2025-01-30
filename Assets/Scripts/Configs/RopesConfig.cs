using UnityEngine;

[CreateAssetMenu(fileName = "RopesConfig", menuName = "Configs/RopesConfig")]
public class RopesConfig : ScriptableObject
{
    [SerializeField] private Rope _prefab;

    public Rope Prefab => _prefab;
}
