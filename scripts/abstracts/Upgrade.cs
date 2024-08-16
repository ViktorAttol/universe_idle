using Godot;
using System;

/// <Summary>
/// Abstract class as base for every upgrade.
/// </Summary>
public partial class Upgrade : Node
{
	/// Signal should be mostly used to upgrade ui elements.
	[Signal]
	public delegate void UpgradeLevelUpEventHandler();
	
	protected int level = -1;
	protected int baseCost = -1;
	protected int cost = -1;
	
	public Upgrade(int level,int baseCost){
		this.level = level;
		this.baseCost = baseCost;
	}
	
	public int GetLevel(){
		return level;
	}
	
	public virtual String GetTitle(){
		return "Not Defined";
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
	
	/// Returns weather or not the upgrade has been unlocked..
	public virtual bool IsUnlocked(){
		return false;
	}
}
