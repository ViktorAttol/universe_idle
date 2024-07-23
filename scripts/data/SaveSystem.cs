using Godot;
using System;

/// <Summary>
/// Responsible for save and load of the game.
/// Currently with the common ResourceSaver/Loader which is not save.
/// </Summary>
public partial class SaveSystem
{
	/// Path for save and load
	private const String PATH = "user://save.tres";
	
	/// Value to turn the possibility to load the data on and off.
	private const bool SHOULDLOAD= false;
	
	/// Saves games Data object.
	public static void SaveData(){
		//GD.Print("save level: " + Game.Instance.Data.Up01Level);
		ResourceSaver.Save(Game.Instance.Data, PATH);
	}
	
	/// Loads the data and overrides the games Data object.
	public static void LoadData(){
		if(!SHOULDLOAD) return;
		if(ResourceLoader.Exists(PATH)) Game.Instance.Data = (Data)ResourceLoader.Load(PATH);
	}
}
