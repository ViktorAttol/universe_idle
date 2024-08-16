using Godot;
using System;

/// <Summary>
/// Unlocks the passive stardust generation.
/// </Summary>
public partial class CCU01StardustGenerator : Upgrade
{
	private int maxLevel = 1;
	
	public CCU01StardustGenerator() : base(Game.Instance.Data.CCUpgrades.U01StardustGeneration ? 1 : 0, 1){
		CalculateCost();
		
	}
	
	public override String GetTitle(){
		return  "Awakening Universe";
	}
	
	/// Returns an String with the description of the upgrade.
	public override String GetDescription(){
		String text = "Awaken the universe to start generating Stardust. \n" +
		"Effect: passive Stardust generation";
		if(level < maxLevel) {
			text += "\nCost: " + cost + " Consciousness Core";
			//text+= "/// level: " + level + ", maxLevel " + maxLevel;
		}
		return  text;
		
	}
	
	/// Calculates the cost for the current upgrade.
	public override void CalculateCost(){
		cost = baseCost;
	}
	
	/// Returns bool if upgrade can be bought.
	public override bool CanAfford(){
		if(Game.Instance.Data.ConsciousnessCore >= cost && level < maxLevel) return true;
		return false;
	}
	
	/// Consumes stardust to level up.
	public override void LevelUp(){
		if(level >= maxLevel) return;
		bool success = HandlerConsciousnessCore.Instance.ConsumeConsciousnessCores(cost);
		if(!success) return;
		level ++;
		Game.Instance.Data.CCUpgrades.U01StardustGeneration = true;
		//GD.Print("levelup");
		HandlerCCUpgrades.Instance.OnCCUpgradeLevelUp(this);
		//EmitSignal(nameof(UpgradeLevelUp));
		EmitSignal(SignalName.UpgradeLevelUp);
	}
	
	/// Returns weather or not the upgrade has been unlocked..
	public override bool IsUnlocked(){
		return true;
	}
	
	/// Returns weather or not the upgrade has been disabled.
	public override bool IsDisabled(){
		return Game.Instance.Data.CCUpgrades.U01StardustGeneration;
	}
}
