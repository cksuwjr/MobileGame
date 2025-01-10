using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Attack", menuName = "Attack/Data", order = 1)]
public class AttackData : ScriptableObject
{
    public GameObject prefab;

    public float basicDamage;
    public float damageRatio;

    public DamageType damageType;

    public enum DamageType
    {
        Physical,
        Magical,
        Fixed,
    }
}
