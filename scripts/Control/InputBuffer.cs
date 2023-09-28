using Godot;
using System;

public partial class InputBuffer : Node
{
	[Export]
	private readonly float ClearTime = 0.2f;
	private Timer ClearTimer;
	private InputEvent BufferedEvent = null;
	public override void _Ready()
	{
		SetMeta("inputBuffer", true);
        ClearTimer = new()
        {
            WaitTime = ClearTime,
            OneShot = true,
        };
		ClearTimer.Timeout += ClearBuffer;
    }

	public void Buffer(InputEvent input){
		BufferedEvent = input;
		ClearTimer.Start();
	}

	private void ClearBuffer(){
		BufferedEvent = null;
	}


}
