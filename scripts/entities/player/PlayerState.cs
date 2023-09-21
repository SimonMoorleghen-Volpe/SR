using Godot;
using System;

public partial class PlayerState : Node
{
	[Export ]
	public String State_ID = "none";
	public override void _Ready()
	{
		SetMeta("PlayerState", true);
	}

	public void Enter(){}

	public void Exit(){}
	public Player_States Take_Input(InputEvent @event){
		return Player_States.none;
	}

	public Player_States Operate(double delta){
		return Player_States.none;
	}

}
