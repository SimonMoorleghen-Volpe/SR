using System;
using Godot;


public partial class State_Machine : Node {
    public override void _Ready(){
        SetMeta("brain", true);
        PlayerStates = new PlayerState[Enum.GetNames(typeof(Player_States)).Length];
        Godot.Collections.Array<Node> childArray = GetChildren();
        foreach(Node child in childArray){
            if(child.HasMeta("PlayerState")){
                PlayerStates[(int)((PlayerState)child).State_ID] = (PlayerState)child;
            }
        }
    }

    private PlayerState[] PlayerStates;

}