using Godot;
using System;

public partial class Upgrade : Node
{
	[Signal]
	public delegate void Upgrade01LevelUpEventHandler();
	
	protected int level = -1;
	protected String title = "Not Defined";
	protected int baseCost = -1;
	protected int cost = -1;
	
	public Upgrade(int level, String title, int baseCost){
		this.level = level;
		this.title = title;
		this.baseCost = baseCost;
		
	}
	
	public int GetLevel(){
		return level;
	}
	
	public String GetTitle(){
		return title;
	}
	
	public int GetBaseCost(){
		return baseCost;
	}
	
	/// Virtuals class, must be overwritten.
	/// Returns an String with the description of the upgrade.
	public virtual String GetDescription(){
		return "Description not defined.";
	}
	
	/// Calculates the cost for the current upgrade.
	public virtual void CalculateCost(){
		GD.PrintErr("CalculateCost() method not defined!");
	}
	
	/// Returns bool if upgrade can be bought.
	public virtual bool CanAfford(){
		return false;
	}
	
	/// Consumes stardust to level up.
	public virtual void LevelUp(){
		GD.PrintErr("LevelUp() method not defined!");
	}
}
