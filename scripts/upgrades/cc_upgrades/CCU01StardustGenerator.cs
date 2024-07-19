using Godot;
using System;

/// <Summary>
/// Unlocks the passive stardust generation.
/// </Summary>
public partial class CCU01StardustGenerator : Upgrade
{
	private int maxLevel = 1;
	
	public CCU01StardustGenerator() : base(Game.Instance.Data.CCUpgrades.U01StardustGeneration ? 1 : 0, "Awakening Universe", 1){
		CalculateCost();
		
	}
	
	/// Returns an String with the description of the upgrade.
	public override String GetDescription(){
		return "Awaken the universe to start generating Stardust. \n" +
		"Effect: passive Stardust generation \n" +
		"Cost: " + cost + " Consciousness Core";
	}
	
	/// Calculates the cost for the current upgrade.
	public override void CalculateCost(){
		cost = baseCost;
	}
	
	/// Returns bool if upgrade can be bought.
	public override bool CanAfford(){
		if(Game.Instance.Data.Stardust >= cost && level < maxLevel) return true;
		return false;
	}
	
	/// Consumes stardust to level up.
	public override void LevelUp(){
		if(level >= maxLevel) return;
		bool success = HandlerConsciousnessCore.Instance.ConsumeConsciousneddCores(cost);
		if(!success) return;
		level ++;
		Game.Instance.Data.CCUpgrades.U01StardustGeneration = true;
		
		HandlerCCUpgrades.Instance.OnCCUpgradeLevelUp(this);
	}
}
