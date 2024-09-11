using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Status : MonoBehaviour
{
    public enum StatType
    {
        Level,
        Hp,
        AttackPower,
    }


    [field: Header("�⺻ ����")]
    [field: SerializeField] public int level { private set; get; } = 1;

    [field: Header("�⺻ �ִ�ü��")]
    [field: SerializeField] public float maxHp { private set; get; }
    private float currentHp;
    public float CurrentHp
    {
        get { return currentHp; }
    }

    [field: Header("�⺻ ���ݷ�")]
    [field: SerializeField] public int attackPower { private set; get; } = 50;

    private float currentAttackPower;
    public float CurrentAttackPower
    {
        get { return currentAttackPower; }
    }

    public bool ModifyCurrentStat(StatType type, float value)
    {
        bool result = false;
        switch (type)
        {
            //case StatType.Level:
            //    level += (int)value;
            //    break;
            case StatType.Hp:
                currentHp += value;
                result = currentHp > 0;
                break;
            //case StatType.AttackPower:
            //    attackPower += (int)value;
            //    break;
        }
        return result;
    }

    public void UpgradeBaseStat(StatType type, float value)
    {
        switch(type)
        {
            case StatType.Level:
                level += (int)value;
                break;
            case StatType.Hp:
                maxHp += value;
                break;
            case StatType.AttackPower:
                attackPower += (int)value;
                break;
            default:
                Debug.Log($"�ش� {type} Ÿ�Կ� ���� ��ġ�� �Ǿ� ���� �ʽ��ϴ�.");
                break;
        }
        ModifyCurrentStat(type, value);
    }
}
