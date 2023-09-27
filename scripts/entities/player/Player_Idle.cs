using Godot;
using System;

public partial class Player_Idle : PlayerState
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
	}

	public override void Enter(){
		GD.Print("Idle");
		GD.Print(Body.Check_Ground());
	}

    public override string Operate(double delta)
    {
		if(!Body.Check_Ground()){ return "fall";}
        return null;
    }

}
