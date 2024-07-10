using Godot;
using System;

public partial class StardustLabel : Label
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		UpdateLabelText();
	}
	
	/// Updates the text with the current stardust amount
	private void UpdateLabelText(){
		Text = "Stardust : " + Game.Instance.Data.Stardust;
	}
}
