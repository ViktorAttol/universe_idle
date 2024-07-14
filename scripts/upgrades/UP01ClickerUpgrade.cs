using Godot;
using System;

/// <Summary>
/// Upgrade 01 - Increases stardust created by the clicker
/// </Summary>
public partial class Up01ClickerUpgrade: Node
{
	[Signal]
	public delegate void Upgrade01LevelUpEventHandler();
	
	private int level = 0;
	private String title = "Clicker Upgrade";
	private int baseCost = 5;
	private int cost;
	
	public Up01ClickerUpgrade(){
		level = Game.Instance.Data.Up01Level;
		CalculateCost();
	}
	
	public override void _Ready(){
		//level = Game.Instance.Data.Up01Level;
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
	
	/// Returns an String with the description of the upgrade.
	public String GetDescription(){
		return "Increses the amount of stardust created by the clicker. \n" + 
		"Effects: +1 Stardust / Level \n" +
		"Cost: " + cost;
	}
	
	/// Calculates the cost for the current upgrade.
	private void CalculateCost(){
		cost = (int)(baseCost * Math.Pow(1.5f, level));
	}
	
	/// Returns bool if upgrade can be bought.
	public bool CanAfford(){
		if(Game.Instance.Data.Stardust >= cost) return true;
		return false;
	}
	
	/// Consumes stardust to level up.
	public void LevelUp(){
		bool success = HandlerStardust.Instance.ConsumeStardust(cost);
		if(!success) return;
		level ++;
		Game.Instance.Data.Up01Level = level;
		
		CalculateCost();
		EmitSignal(SignalName.Upgrade01LevelUp);
	}
}
