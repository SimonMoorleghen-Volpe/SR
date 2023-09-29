using System;
using System.Collections.Generic;
using Godot;


public partial class State_Machine : Node {
    public override void _Ready(){
        SetMeta("brain", true);
        
        Godot.Collections.Array<Node> childArray = GetChildren();
        PlayerStates = new PlayerState[childArray.Count];
        byte i = 0;
        foreach(Node child in childArray){
            if(child.HasMeta("PlayerState")){
                PlayerStates[i] = (PlayerState)child;
                StateDictionary.Add(PlayerStates[i].State_ID, i);
                PlayerStates[i].Set_Controller(GetOwner<Player>());
                i++;
                ((PlayerState)child).init();
            }
        }
        CurrentState = PlayerStates[StateDictionary["idle"]];
    }

    private void Change_State(string NewState){
        if(NewState == null){  return;  }
        if(!StateDictionary.ContainsKey(NewState)){
            return;
        }
        CurrentState.Exit();
        CurrentState = PlayerStates[StateDictionary[NewState]];
        CurrentState.Enter();

    }

    public bool PassInput(InputEvent input){
        string NewState = CurrentState.Take_Input(input);
        if(NewState == ""){
            return false;
        }
        Change_State(NewState);
        return true;
    }

    public void PlayerProcess(double delta){
        Change_State(CurrentState.Operate(delta));
    }

    private PlayerState[] PlayerStates;
    private readonly Dictionary<String, byte> StateDictionary = new();
    private PlayerState CurrentState;

}