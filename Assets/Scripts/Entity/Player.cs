using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : FSMEntity
{
    public enum State
    {
        Idle,
        Move,
        Attack,
    }

    State _state;

    protected StateChanger _changer;

    public FSMEntity ____Target;

    private void Start()
    {
        _state = State.Idle;

        var state = new AttackState(this);
        state.SetTarget(____Target);

        _changer = new StateChanger(state);


    }

    public class IdleState : BaseState
    {
        public IdleState(FSMEntity monster) : base(monster) { }

        public override void OnStateEnter() { }
        public override void OnStateExit() { }
        public override void OnStateUpdate() { }

    }

    public class MoveState : BaseState
    {
        public MoveState(FSMEntity monster) : base(monster) { }

        public override void OnStateEnter() { }
        public override void OnStateExit() { }
        public override void OnStateUpdate() { }

    }

    public class AttackState : BaseState
    {
        float timer = 0f;
        FSMEntity enemy;

        public AttackState(FSMEntity monster) : base(monster) { }

        public override void OnStateEnter() { }
        public override void OnStateExit() { }
        public override void OnStateUpdate() 
        {
            //if (!enemy) return;

            // Skill Attack
            if (_entity.statData.CurrentMp.Value >= _entity.statData.maxMp.Value)
            {
                _entity.statData.CurrentMp.Value = 0;
                Skill();
                return;
            }


            // Basic Attack
            if (timer < _entity.statData.attackSpeed.Value)
                timer += Time.fixedDeltaTime;
            else
            {
                timer = 0;
                Attack();
            }

        }

        public void SetTarget(FSMEntity enemy)
        {
            this.enemy = enemy;
        }

        private void Attack()
        {
            _entity.statData.CurrentMp.Value += 10;

            var attack = Instantiate(_entity.basicAttack.prefab, _entity.transform.position, Quaternion.identity);
            attack.GetComponent<BasicAttack>().Init(_entity, enemy);
            Debug.Log("공격");
        }

        private void Skill()
        {
            Debug.Log("스킬공격");
        }
    }

    private void FixedUpdate()
    {
        _changer.UpdateState();
    }

}
