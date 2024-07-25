using Godot;
using System;

/// <Summary>
/// Passively generates stardust.
/// </Summary>
public partial class HandlerStardustGenerator : Node
{
	private static HandlerStardustGenerator _instance;

	/// 
	private int generatorPower = 1;

	/// Reference to the generator timer
	[Export]
	private Timer timer;
	
	private HandlerStardustGenerator(){
		
	}
	
	public static HandlerStardustGenerator Instance{
		get{
			return _instance;
		}
	}
	
	public override void _EnterTree(){
		if(_instance == null) _instance = new HandlerStardustGenerator();
	}	
	public override void _Ready(){
		CalculateGeneratorPower();
		
		HandlerCCUpgrades.Instance.CCUpgradeLeveledUp += WatchForUpgradesLevelUp;
		
		if(Game.Instance.Data.CCUpgrades.U01StardustGeneration){
			timer.Start();
			return;
		}

		HandlerCCUpgrades.Instance.U01StardustGeneration.UpgradeLevelUp += WatchForCCU01LevelUp;		
	}
	
	private void _OnTimerTimeout()
	{
		HandlerStardust.Instance.CreateStardust(generatorPower);
	}
	
	/// Callback function to recalculate generatorPower when there is an ccupgrade.
	private void WatchForUpgradesLevelUp(Upgrade upgrade){
		CalculateGeneratorPower();
	}
	
	/// Callback function for consciousness core upgrades.
	private void WatchForCCU01LevelUp(){
		timer.Start();
		HandlerCCUpgrades.Instance.U01StardustGeneration.UpgradeLevelUp -= WatchForCCU01LevelUp;
	}
	/// Calculate the amount of stardust which should be created every seconds.
	private void CalculateGeneratorPower(){
		int newPower = 1;
		newPower += Game.Instance.Data.CCUpgrades.U02StardustBoostLevel;
		generatorPower = newPower;
	}
}



