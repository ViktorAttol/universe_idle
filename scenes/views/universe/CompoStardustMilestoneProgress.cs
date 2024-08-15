using Godot;
using System;

public partial class CompoStardustMilestoneProgress : ProgressBar
{
	/// Reference to the label displaying numbered progress.
	[Export]
	private Label label;
	
	private StardustMilestones milestone;
	
	public CompoStardustMilestoneProgress(){
		milestone = HandlerConsciousnessCore.Instance.StardustMilestone;
	}
	
	public override void _Ready()
	{
		//base._Ready();
		ConnectSignals();
	}
	private void ConnectSignals(){
		milestone.Progressed += OnMilestoneChanged;
		milestone.NewMilestoneCreated += OnMilestoneChanged;
	}
	
	private void UpdateProgress(){
		MaxValue = milestone.StardustGoal;
		Value = milestone.StardustProgress;
		label.Text = Value + " / " + MaxValue;
	}
	/// Triggered when a new milestone is created or wehen the current milestone progresses.
	private void OnMilestoneChanged(){
		UpdateProgress();
	}
	
}
