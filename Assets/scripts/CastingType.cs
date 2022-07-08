using System.Collections.Generic;
using UnityEngine;

public class CastingType
{
    
}

public class CastToPoint : CastingType
{
    public float PointRadius { get; set; }
}

public class LinerCast : CastingType
{
    public float LineThinckness { get; set; }
}

public class AreaCast : CastingType
{
        
}