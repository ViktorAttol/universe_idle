using Godot;
using System;

/// <Summary>
/// CCUpgrade 03 - Unlocks Nebulas
/// </Summary>
public partial class CCU03UnlockNebulas : Upgrade
{
	private int maxLevel = 1;
	
	public CCU03UnlockNebulas() : base(Game.Instance.Data.CCUpgrades.U03UnlockNebulas ? 1 : 0, 2){
		CalculateCost();
		if(!IsUnlocked()) HandlerCCUpgrades.Instance.U01StardustGeneration.UpgradeLevelUp += OnCCU01LevelUp;
	}

	public override String GetTitle(){
		String text = "Unlock Nebulas ";
		return text;
	}
	
	/// Returns an String with the description of the upgrade.
	public override String GetDescription(){
		String text = "[b]Effect: [/b]Unlock the ability to create Nebulas. \n";
		if(level < maxLevel) {
			text += "\n[b]Cost: [/b]" + cost + " Consciousness Cores";
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
	
	/// Consumes consciousness cores to level up.
	public override void LevelUp(){
		if(level >= maxLevel) return;
		bool success = HandlerConsciousnessCore.Instance.ConsumeConsciousnessCores(cost);
		if(!success) return;
		level ++;
		Game.Instance.Data.CCUpgrades.U03UnlockNebulas = true;
		//GD.Print("levelup");
		HandlerCCUpgrades.Instance.OnCCUpgradeLevelUp(this);
		//EmitSignal(nameof(UpgradeLevelUp));
		EmitSignal(SignalName.UpgradeLevelUp);
	}
	
	/// Returns weather or not the upgrade has been unlocked..
	public override bool IsUnlocked(){
		if(Game.Instance.Data.CCUpgrades.U01StardustGeneration) return true;
		return false;
	}
	
	/// Triggered wehen CCU01 leveled up.
	private void OnCCU01LevelUp(){
		HandlerCCUpgrades.Instance.U01StardustGeneration.UpgradeLevelUp -= OnCCU01LevelUp; 
		HandlerCCUpgrades.Instance.OnUpgradeUnlocked(this);
	}
}
