using UnityEngine;

[CreateAssetMenu(fileName = "New spell", menuName = "Spell", order = 0)]
public class Spell : ScriptableObject
{
    [SerializeField] private DamageType damageType;
}