using Godot;
using System;

/// <Summary>
/// A cklicker prototype creating stardust
/// </Summary>
public partial class PrototypeClicker : Control
{
	/// Label which displays current stardust amount
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
	
	/// Callback function for creating stardust
	private void _on_btn_pressed_create_stardust()
	{
		CreateStardust();
		UpdateLabelText();
	}
	
	/// Creates stardust
	private void CreateStardust(){
		_stardust += 1;
	}
	
	/// Updates stardust label with current stardust ammount
	private void UpdateLabelText(){
		_label.Text = "Stardust: " + _stardust;
	}
}





