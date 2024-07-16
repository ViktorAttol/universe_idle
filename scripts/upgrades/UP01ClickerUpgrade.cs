using Godot;
using System;

/// <Summary>
/// Upgrade 01 - Increases stardust created by the clicker
/// </Summary>
public partial class Up01ClickerUpgrade: Upgrade
{
	public Up01ClickerUpgrade() : base(Game.Instance.Data.Up01Level, "Clicker Upgrade", 5){
		CalculateCost();
	}
		
	/// Returns an String with the description of the upgrade.
	public override String GetDescription(){
		return "Increses the amount of stardust created by the clicker. \n" + 
		"Effects: +1 Stardust / Level \n" +
		"Cost: " + cost;
	}
	
	/// Calculates the cost for the current upgrade.
	public override void CalculateCost(){
		cost = (int)(baseCost * Math.Pow(1.5f, level));
	}
	
	/// Returns bool if upgrade can be bought.
	public override bool CanAfford(){
		if(Game.Instance.Data.Stardust >= cost) return true;
		return false;
	}
	
	/// Consumes stardust to level up.
	public override void LevelUp(){
		bool success = HandlerStardust.Instance.ConsumeStardust(cost);
		if(!success) return;
		level ++;
		Game.Instance.Data.Up01Level = level;
		
		CalculateCost();
		EmitSignal(SignalName.Upgrade01LevelUp);
	}
}
