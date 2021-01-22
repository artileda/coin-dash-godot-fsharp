using Godot;
using System;

public class Coin : AnimatedSprite
{
	public void pickup(){
		QueueFree();
	}
}
