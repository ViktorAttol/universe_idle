using Godot;
using System;

public partial class StardustLabel : Label
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		UpdateLabelText();
		// Connect signals to handler.
		HandlerStardust.Instance.StardustCreated += UpdateLabelText;
		HandlerStardust.Instance.StardustConsumed += UpdateLabelText;
	}
	
	/// Updates the text with the current stardust amount
	private void UpdateLabelText(int amount = 0){
		Text = "Stardust : " + HandlerStardust.Instance.StardustAvailable();
	}
}
