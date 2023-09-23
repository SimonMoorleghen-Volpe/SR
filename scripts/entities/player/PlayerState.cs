using Godot;
using System;

public partial class PlayerState : Node
{
	[Export ]
	public String State_ID = "none";

	private Player Player;
	public override void _Ready()
	{
		SetMeta("PlayerState", true);
	}

	public void Set_Player(Player controller){Player = controller;}

	public void Enter(){}

	public void Exit(){}

	public virtual string Take_Input(InputEvent @event){
		return null;
	}

	public virtual string Operate(double delta){
		return null;
	}

	protected virtual void Apply_Gravity(double delta){
		
	}

}
