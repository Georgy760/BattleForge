using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New spell data", menuName = "Spell data", order = 0)]
public class SpellData : ScriptableObject
{
    [SerializeField] private string Name;
    [SerializeField] private float castRange;
    [SerializeField] private float baseDamage;
    [SerializeField] private CastingType castingType;
    [SerializeField] private Spell spell;


}
