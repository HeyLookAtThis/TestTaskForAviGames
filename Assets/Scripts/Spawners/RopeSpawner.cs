using UnityEngine;

public class RopeSpawner : MonoBehaviour
{
    [SerializeField] private RopesConfig _config;
    [SerializeField] private KnotStorage _knotStorage;

    private RopeFactory _factory;

    public void InitializeFactory() => _factory = new RopeFactory(_config);

    public void Run()
    {
        GameObject storage = new("Rope");

        for(int i =0; i < _knotStorage.Count; i++)
        {
            KnotConfig knotConfig = _config.GetKnotConfig(i);

            for (int j = 0; j < knotConfig.IndexesOfKnotToConnectTo.Length; j++)
            {
                int knotIndex = knotConfig.IndexesOfKnotToConnectTo[j];

                Knot begginer = _knotStorage.Get(i);
                Knot ender = _knotStorage.Get(knotIndex);

                if (begginer.HaveConnect(ender) == false)
                {
                    _factory.Create(begginer.Position, ender.Position);
                    begginer.AddConnect(ender);
                    ender.AddConnect(begginer);
                }
            }
        }
    }
}
