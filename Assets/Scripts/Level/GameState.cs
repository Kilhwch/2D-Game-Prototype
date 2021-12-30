using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { ALIVE, DEAD }

public class StateManager : MonoBehaviour
{

    public GameState state;

    private void Start()
    {
        state = GameState.ALIVE;    
    }

    void updateState(GameState _state)
    {
        state = _state;
    }
}
