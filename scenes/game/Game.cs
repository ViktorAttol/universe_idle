using Godot;
using System;

/// <Summary>
/// Main node of the game.
/// </Summary>
public partial class Game : Node
{
	/// singletion reference
	private static Game _instance;
	
	/// Contains data to save and load
	private Data _data;
	
	/// Reference to the user interface packed scene
	[Export]
	private PackedScene sceneUserInterface;
	
	private Game(){
		//GD.Print("Game created");
		_instance = this;
		_data = new Data();
	}
	
	public static Game Instance {
		get { 
			return _instance;
		}
	}
	
	public Data Data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
	
	public override void _EnterTree(){
		//if(_instance == null) _instance = new Game();
		SaveSystem.LoadData();
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(_instance == null) _instance = new Game();
		UserInterface nodeUserInterface = sceneUserInterface.Instantiate() as UserInterface;
		this.AddChild(nodeUserInterface);
	}
	
	/// Triggered when the save timer completes a loop. Sage Game
	private void OnSaveTimerTimeout()
	{
		SaveSystem.SaveData();
	}
}



