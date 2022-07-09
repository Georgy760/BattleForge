using UnityEngine;
using Sirenix.OdinInspector;
[CreateAssetMenu(fileName = "New spell", menuName = "Spell", order = 0)]
public class Spell : ScriptableObject
{
    [SerializeField] private DamageType damageType;
    [SerializeField] private static float castRange;
    [EnumToggleButtons]
    [Title("Cast Type")]
    [HideLabel]
    public CastType castType;
    public enum CastType
    {
        CastToPoint,
        LinerCast,
        AreaCast
    }
    
}
