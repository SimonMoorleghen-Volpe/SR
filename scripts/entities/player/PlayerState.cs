using Godot;
using System;

public partial class PlayerState : Node
{
	[Export]
	public Player_States State_ID = Player_States.none;
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
