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
                i++;
            }
        }
        CurrentState = PlayerStates[StateDictionary["idle"]];
    }

    public void PlayerProcess(double delta){
        CurrentState.Operate(delta);
    }

    private PlayerState[] PlayerStates;
    private Dictionary<String, byte> StateDictionary = new();
    private PlayerState CurrentState;

}