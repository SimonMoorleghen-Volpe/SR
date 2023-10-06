using Godot;
using System;

public partial class InputBuffer : Node
{
	[Export]
	private float ClearTime = 0.2f;
	private Timer ClearTimer;
	private InputEvent BufferedEvent = null;
	public override void _Ready()
	{
		SetMeta("buffer", true);
        ClearTimer = new()
        {
            WaitTime = ClearTime,
            OneShot = true,
        };
		ClearTimer.Timeout += ClearBuffer;
		AddChild(ClearTimer);
    }

	public InputEvent Read(){	return BufferedEvent;	}

	public void Push(InputEvent input){
		BufferedEvent = input;
		ClearTimer.Start();
	}

	public void Pop(){
		BufferedEvent = null;
		ClearTimer.Stop();
	}

	private void ClearBuffer(){
		BufferedEvent = null;
	}


}
