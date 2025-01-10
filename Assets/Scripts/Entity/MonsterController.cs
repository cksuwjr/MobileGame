using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    Monster monster;
    Vector3 moveVector;

    Rigidbody2D _rigidbody;

    private void Awake()
    {
        monster = GetComponent<Monster>();
        monster.statData = new Status();

        //Debug.Log($"레벨:  {player.statData.level}, 현재체력: {player.statData.CurrentHp}, 공격력: {player.statData.attackPower}");

        _rigidbody = GetComponent<Rigidbody2D>();
    }
}
