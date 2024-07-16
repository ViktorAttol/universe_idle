using Godot;
using System;

/// <Summary>
/// Displays the current number of consciousness cores.
/// </Summary>
public partial class LabelConsciousnessCore : Label
{
	public override void _Ready()
	{
		UpdateLabelText();
		// Connect signals to handler.
		HandlerConsciousnessCore.Instance.ConsciousnessCoreCreated += UpdateLabelText;
		HandlerConsciousnessCore.Instance.ConsciousnessCoreConsumed += UpdateLabelText;
	}
	
	/// Updates the text with the current stardust amount
	private void UpdateLabelText(int amount = 0){
		Text = "ConsciousnessCore : " + HandlerConsciousnessCore.Instance.ConsciousneddCoresAvailable();
	}
}
