using System.Collections.Generic;
using System.Linq;

public class KnotPointerPressChecker
{
    private readonly IReadOnlyList<Knot> _knots;

    public KnotPointerPressChecker(IReadOnlyList<Knot> knots)
    {
        _knots = knots;
    }

    public bool IsKnotsFree { get; private set; }

    public void Update()
    {
        var knot = _knots.FirstOrDefault(knot => knot.CanMove == true);

        if (knot == null)
            IsKnotsFree = true;
    }
}
