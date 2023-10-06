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
			} else if (childMeta.Contains("buffer")){
				InBuffer = (InputBuffer)child;
			} else if (childMeta.Contains("crush")){
				CrushRaycasts[(int)child.GetMeta("crush")] = (RayCast2D)child;
			} else if (childMeta.Contains("wall")){
				WallJumpRaycasts[(int)child.GetMeta("wall")] = (RayCast2D)child;
			}
		}
		if(Controller == null){
			QueueFree();
		}
		if(InBuffer == null){
			QueueFree();
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		CheckBuffer();
		Controller.PlayerProcess(delta);
		MoveAndSlide();
		CrushCheck();
	}

    public override void _Input(InputEvent @event)
    {
        if(!Controller.PassInput(@event)){
			InBuffer.Push(@event);
		}
    }

	private void CheckBuffer(){
		InputEvent BufferedAction = InBuffer.Read();
		if(BufferedAction == null){
			return;
		}
		if(Controller.PassInput(BufferedAction)){
			InBuffer.Pop();
		}
	}
	public bool Check_Ground(){	if(GroundCheck.IsColliding()){return true;}	return false; }
	private void CrushCheck(){
		if(CrushRaycasts[0].IsColliding() & CrushRaycasts[1].IsColliding()){
			Die();
		}
	}
	public void Die(){
		QueueFree();
	}

    public float WalkSpeed {get; private set;} = 0f;
	public float RunSpeed {get; private set;} = 0f;
	public float JumpVelocity {get; private set;} = 0f;
	public float JumpGravity {get; private set;}  = 0f;
	public float FallGravity {get; private set;} = 0f;


	private State_Machine Controller;
	private InputBuffer InBuffer;
	private RayCast2D GroundCheck;
	private RayCast2D[] CrushRaycasts = new RayCast2D[4];
	private RayCast2D[] WallJumpRaycasts = new RayCast2D[2];
	

}
