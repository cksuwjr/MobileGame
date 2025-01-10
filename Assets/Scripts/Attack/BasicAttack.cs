using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    FSMEntity attacker;
    FSMEntity target;

    float speed;
    float maxSpeed;

    Rigidbody2D _rigidbody;

    public void Init(FSMEntity attacker, FSMEntity target, float speed = 10, float maxSpeed = 10 * 1.3f)
    {
        this.attacker = attacker;
        this.target = target;
        this.speed = speed;
        this.maxSpeed = maxSpeed;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var direction = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        _rigidbody.velocity = direction * speed;

        if (speed < maxSpeed)
            speed += 0.025f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<FSMEntity>();
        if (!enemy) return;

        if(enemy == target)
        {
            enemy.statData.CurrentHp.Value -= attacker.statData.attackPower.Value;
            Destroy(gameObject);
        }
    }
}
