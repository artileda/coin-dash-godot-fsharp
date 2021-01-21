using GameFs;
using Godot;

public class Player : PlayerFs.Class
{
	[Signal]
	public delegate void Pickup();
	
	[Signal]
	public delegate void Hurt();
	
	private void OnPlayerAreaEntered(Node area)
	{
		if(area.IsInGroup("coins")){
			EmitSignal("pickup");
		}else{
			EmitSignal("hurt");
		}
	}
}
