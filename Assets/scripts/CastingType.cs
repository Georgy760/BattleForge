using System.Collections.Generic;
using UnityEngine;

public class CastingType
{
    private CastToPoint? castToPoint = null;
    private LinerCast? linerCast = null;
    private AreaCast? areaCast = null;
    public enum Types
    {
        CastToPoint,
        LinerCast,
        AreaCast
    }

    public CastingType SetCastingType(Types type, float range)
    {
        CastingType castingType;
        switch (type)
        {
            case Types.CastToPoint:
                castingType = new CastingType(new CastToPoint(range));
                return (castingType);
            case Types.LinerCast:
                castingType = new CastingType(new LinerCast(range));
                return (castingType);
            case Types.AreaCast:
                castingType = new CastingType(new AreaCast(range));
                return (castingType);
        }

        return null;
    }

    public CastingType(CastToPoint castToPoint)
    {
        this.castToPoint = castToPoint;
    }
    public CastingType(LinerCast linerCast)
    {
        this.linerCast = linerCast;
    }

    public CastingType(AreaCast areaCast)
    {
        this.areaCast = areaCast;
    }
    public struct CastToPoint
    {
        public float pointRadius;

        public CastToPoint(float pointRadius)
        {
            this.pointRadius = pointRadius;
        }
    }

    public struct LinerCast
    {
        public float lineThinckness;

        public LinerCast(float lineThinckness)
        {
            this.lineThinckness = lineThinckness;
        }
    }

    public struct AreaCast
    {
        public float range;

        public AreaCast(float range)
        {
            this.range = range;
        }
    }
}

