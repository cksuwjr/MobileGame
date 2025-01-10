using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class Status
{
    public enum StatType
    {
        Level,
        Hp,
        AttackPower,
    }

    [System.Serializable]
    public class Data<T>
    {
        [SerializeField]
        private T v;
        public T Value
        {
            get => this.v;
            set
            {
                this.v = value;
                this.onChange?.Invoke(value);
            }
        }
        public Action<T> onChange;
    }

    [field: Header("기본 레벨")]

    [field: SerializeField] public Data<int> level { private set; get; }



    [field: Header("기본 최대체력")]

    [field: SerializeField] public Data<float> maxHp { private set; get; }

    private Data<float> currentHp { set; get; }

    public Data<float> CurrentHp { get => currentHp; }


    [field: Header("기본 최대마나")]

    [field: SerializeField] public Data<float> maxMp { private set; get; }

    private Data<float> currentMp { set; get; }

    public Data<float> CurrentMp { get => currentMp; }


    [field: Header("기본 공격력")]

    [field: SerializeField] public Data<int> attackPower { private set; get; }



    [field: Header("기본 공격속도")]

    [field: SerializeField] public Data<float> attackSpeed { private set; get; }

    public Status(int level = 1, float maxHp = 100, float currentHp = 100, float maxMp = 100, float currentMp = 100, int attackPower = 50, float attackSpeed = 1)
    {
        this.level = new Data<int>();
        this.maxHp = new Data<float>();
        this.maxMp = new Data<float>();
        this.currentHp = new Data<float>();
        this.currentMp = new Data<float>();
        this.attackPower = new Data<int>();
        this.attackSpeed = new Data<float>();

        this.level.Value = level;
        this.maxHp.Value = maxHp;
        this.maxMp.Value = maxMp;
        this.currentHp.Value = currentHp;
        this.currentMp.Value = currentMp;
        this.attackPower.Value = attackPower;
        this.attackSpeed.Value = attackSpeed;
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
                currentHp.Value += value;
                result = currentHp.Value > 0;
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
                level.Value += (int)value;
                break;
            case StatType.Hp:
                maxHp.Value += value;
                break;
            case StatType.AttackPower:
                attackPower.Value += (int)value;
                break;
            default:
                Debug.Log($"해당 {type} 타입에 대한 조치가 되어 있지 않습니다.");
                break;
        }
        ModifyCurrentStat(type, value);
    }
}




//[field: Header("기본 레벨")]
//[field: SerializeField] public int level { private set; get; } = 1;

//[field: Header("기본 최대체력")]
//[field: SerializeField] public float maxHp { private set; get; }
//private float currentHp
//{
//    set { 
//        currentHp = value;
//        OnHpChanged?.Invoke(value);
//    }
//    get { return currentHp; }
//}
//public float CurrentHp
//{
//    get { return currentHp; }
//}

//[field: Header("기본 공격력")]
//[field: SerializeField] public int attackPower { private set; get; } = 50;

//private int currentAttackPower;
//public int CurrentAttackPower => currentAttackPower;

//public event Action<float> OnHpChanged;