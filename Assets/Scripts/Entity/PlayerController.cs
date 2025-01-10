using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Player player;
    Vector3 moveVector;

    Rigidbody2D _rigidbody;

    private void Awake()
    {
        player = GetComponent<Player>();
        player.statData = new Status();

        //Debug.Log($"레벨:  {player.statData.level}, 현재체력: {player.statData.CurrentHp}, 공격력: {player.statData.attackPower}");
        
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        moveVector = new Vector3(moveH, moveV).normalized;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = moveVector;
    }
}
