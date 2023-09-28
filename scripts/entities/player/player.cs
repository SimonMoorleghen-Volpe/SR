using Godot;
using System;
using System.Collections;


public partial class Player : CharacterBody2D
{
	
	public override void _Ready()
	{
		Godot.Collections.Array<Node> childList = GetChildren();
		foreach(Node child in childList){
			Godot.Collections.Array<Godot.StringName> childMeta = child.GetMetaList();
			if(childMeta.Contains("brain")){
				Controller = (State_Machine)child;
			} else if (childMeta.Contains("groundCheck")){
				GroundCheck = (RayCast2D)child;
				GroundCheck.CollisionMask = 12;
			} else if (childMeta.Contains("inputBuffer")){
				InBuffer = (InputBuffer)child;
			}
		}
		if(Controller == null){
			QueueFree();
		}
	}

	public bool Check_Ground(){	if(GroundCheck.IsColliding()){return true;}	return false; }

	public override void _PhysicsProcess(double delta)
	{
		Controller.PlayerProcess(delta);
		MoveAndSlide();
	}

    public override void _Input(InputEvent @event)
    {
        Controller.PassInput(@event);
    }

    public float WalkSpeed {get; private set;} = 0f;
	public float RunSpeed {get; private set;} = 0f;
	public float JumpVelocity {get; private set;} = 0f;
	public float JumpGravity {get; private set;}  = 0f;
	public float FallGravity {get; private set;} = 0f;


	private State_Machine Controller;
	private InputBuffer InBuffer;
	private RayCast2D GroundCheck;
	

}
