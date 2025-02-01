using System.Collections.Generic;
using System.Linq;

public class RopeCrossingChecker
{
    private readonly IReadOnlyList<Rope> _ropes;

    public RopeCrossingChecker(IReadOnlyList<Rope> ropes)
    {
        _ropes = ropes;
    }

    public bool IsRopesFree { get; private set; }

    public void Update()
    {
        var rope = _ropes.FirstOrDefault(rope => rope.IsCrossing == true);

        if (rope == null)
            IsRopesFree = true;
    }
}
