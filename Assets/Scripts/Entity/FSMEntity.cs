using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// FSM 패턴 적용
/// 게임 내의 기본 엔티티 모두 적용
/// </summary>


public class FSMEntity : MonoBehaviour
{
    [field: Header("스탯 정보")]
    [field: SerializeField] public Status statData;
}

public abstract class BaseState
{
    protected FSMEntity monster;

    protected BaseState(FSMEntity monster)
    {
        this.monster = monster;
    }

    public abstract void OnStateEnter();
    public abstract void OnStateExit();
    public abstract void OnStateUpdate();

}

// FSM
public class StateChanger
{
    private BaseState _currentState;
    public StateChanger(BaseState initState)
    {
        ChangeState(initState);
    }

    public void ChangeState(BaseState nextState)
    {
        if (nextState == _currentState) return;
        if (_currentState != null) _currentState.OnStateExit();

        _currentState = nextState;
        _currentState.OnStateEnter();
    }

    public void UpdateState()
    {
        if (_currentState != null) _currentState.OnStateUpdate();
    }
}