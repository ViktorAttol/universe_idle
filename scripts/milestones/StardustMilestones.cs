using Godot;
using System;

/// <Summary>
/// Passively generates stardust.
/// </Summary>
public partial class StardustMilestones : Node
{
	/// Amount of sardust required to create the next consciousness core.
	private int _stardustGoal = -1;
	/// Amount of stardust generated in the last milestone.
	private int _stardustProgress = -1;

	
	/// Reference to the universe data.
	private DataUniverse universe;
	
	public StardustMilestones(){
		//GD.Print("Milestones initialized");
		universe = Game.Instance.Data.Universe;	
		HandlerStardust.Instance.StardustCreated += OnStardustCreated; // Put into _Ready() because of initialization problems
		InitializeNewMilestone(universe.StardustMilestoneProgress);
	}
	
	public override void _Ready()
	{
	}
	
	/// Initialize a new milestone after the previous one is completed.
	public void InitializeNewMilestone(int transferedProgress = 0){
		if(universe.ConsciousnessCore == 0){
			_stardustGoal = 4;
		}
		else {
			_stardustGoal = universe.ConsciousnessCore * 8;
		}
		_stardustProgress = transferedProgress;
		universe.StardustMilestoneProgress = _stardustProgress;
	}
	
	/// Checks for milestone completion.
	private void CheckForCompletion(){
		if(_stardustProgress < _stardustGoal) return;
		int stardustExcess = _stardustProgress - _stardustGoal;
		HandlerConsciousnessCore.Instance.CreateConsciousnessCores(1);	
		InitializeNewMilestone(stardustExcess);	
		CheckForCompletion();
	}
	
	/// Triggered when stardust is created. Progress the milestone.
	private void OnStardustCreated(int amount){
		_stardustProgress += amount;
		universe.StardustMilestoneProgress = _stardustProgress;
		CheckForCompletion();
		
	}
}
