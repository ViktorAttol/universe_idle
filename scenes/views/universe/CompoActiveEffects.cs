using Godot;
using System;

/// <Summary>
/// Displays the active effects of the universe.
/// </Summary>
public partial class CompoActiveEffects : VBoxContainer
{
	/// Reference to the label displaying the current stardust per seconds.
	[Export]
	private RichTextLabel stardustPerSecond; 
	
	public override void _Ready()
	{
		ConnectSignals();
		UpdateStardustPerSecond();
	}

	private void ConnectSignals(){
		HandlerStardustGenerator.Instance.GeneratorPowerCalculated += OnStardustGeneratorPowerCalculated;
	}
	
	/// CB triggered when stardust generator power was calculated
	private void OnStardustGeneratorPowerCalculated(){
		UpdateStardustPerSecond();
	}
	
	/// Updates the stardust per second display.
	private void UpdateStardustPerSecond(){
		String text = "[b]Stardust/s:[/b] " + HandlerStardustGenerator.Instance.GeneratorPower;
		stardustPerSecond.Text = text;
	}
	

}
