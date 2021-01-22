
using Godot;
using GameFs;

public class Main : GameFs.Main
{
	Node CoinContainer;
	
	public  void _Ready()
	{
		CoinContainer = GetNode(new NodePath("CCon"));
		this.INIT.screensize = this.getScreensize;
	}
	
	public override void _Process(float delta){
		
	}	
}
