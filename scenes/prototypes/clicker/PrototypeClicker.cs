using Godot;
using System;
/// <Summary>
/// A cklicker prototype creating stardust
/// </Summary>

public partial class PrototypeClicker : Control
{
	[Export]
	private Label _label;
	
	[Export]
	private int _stardust = 0;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		UpdateLabelText();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void _on_button_pressed()
	{
		CreateStardust();
		UpdateLabelText();
	}
	
	private void CreateStardust(){
		_stardust += 1;
	}
	
	private void UpdateLabelText(){
		_label.Text = "Stardust: " + _stardust;
	}
}




