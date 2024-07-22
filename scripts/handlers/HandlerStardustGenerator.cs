using Godot;
using System;

/// <Summary>
/// Passively generates stardust.
/// </Summary>
public partial class HandlerStardustGenerator : Node
{
	private static HandlerStardustGenerator _instance;

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
		if(Game.Instance.Data.CCUpgrades.U01StardustGeneration){
			timer.Start();
			return;
		}
		HandlerCCUpgrades.Instance.CCUpgradeLeveledUp += WatchForCCU01LevelUp;
	}
	
	private void _OnTimerTimeout()
	{
		HandlerStardust.Instance.CreateStardust(1);
	}
	
	/// Callback function for consciousness core upgrades.
	private void WatchForCCU01LevelUp(Upgrade upgrade){
		if(upgrade == HandlerCCUpgrades.Instance.U01StardustGeneration){
			timer.Start();
			HandlerCCUpgrades.Instance.CCUpgradeLeveledUp -= WatchForCCU01LevelUp;
		}
	}
}



