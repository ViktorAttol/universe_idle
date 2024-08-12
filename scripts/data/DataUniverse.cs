using Godot;
using System;

/// <Summary>
/// Contains universe realated data to save and load.
/// </Summary>
public partial class DataUniverse : Resource
{
	/// Total amount of stardust created in this universe.
	[Export]
	private int _stardust = 0;
	/// Total amount of consciousness cores created in this universe.
	[Export]
	private int _consciousnessCore = 0;
	
	[Export]
	private int _stardustMilestoneProgress = 0;
	
	public int ConsciousnessCore {
		get {	return _consciousnessCore;	}
	}
	
	public int Stardust {
		get {	return _stardust;	}
	}
	
	public int StardustMilestoneProgress {
		get {	return _stardustMilestoneProgress;	}
		set{	_stardustMilestoneProgress = value;	}
	}
	
	public void AddStardust(int amount){
		_stardust += amount;
	}
	
	public void AddConsciousnessCores(int amount){
		_consciousnessCore += amount;
	}
}
