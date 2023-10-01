using Godot;
using System;

public partial class Player_Jump : PlayerState
{

    public override void _Ready()
    {
        base._Ready();
        JumpVector = new(){X=0, Y=JumpHeight/JumpTime};
        JumpTimer = new(){
            OneShot=true,
            WaitTime=JumpTime
        };
    }

    [Export]
    private float JumpTime = 0.5f;
    [Export]
    private float JumpHeight = 500;
    private Vector2 JumpVector;
    private Timer JumpTimer;
}
