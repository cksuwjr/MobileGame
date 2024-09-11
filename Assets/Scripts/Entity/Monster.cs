using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : FSMEntity
{
    public enum State
    {
        Idle,
        Move,
        Attack,
    }

    State _state;

    protected StateChanger _changer;

    private void Awake()
    {
        statData = GetComponent<Status>();
    }

    private void Start()
    {
        _state = State.Idle;
        _changer = new StateChanger(new IdleState(this));
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
        public AttackState(FSMEntity monster) : base(monster) { }

        public override void OnStateEnter() { }
        public override void OnStateExit() { }
        public override void OnStateUpdate() { }

    }
}
