using Godot;
using System;

/// <Summary>
/// Displays the information of a nebula.
/// </Summary>
public partial class CompoNebula : VBoxContainer
{
	/// Reference to the label displaying the name.
	[Export]
	private Label labelName;
	
	/// Reference to the label displaying the composition. 
	[Export]
	private RichTextLabel labelComposition;
	
	/// References the slider managing the consumption.
	[Export]
	private HSlider consumptionSlider;
	
	/// Reference to the nebula which should be displayed;
	private Nebula nebula; 
	
	private int consumptionSliderMaxValue = 5;
	
	/// Updates all the nodes of the component.
	private void UpdateComponent(){
		UpdateLabelName();
		UpdateLabelComposition();
		UpdateSlider();
	}
	
	private void UpdateLabelName(){
		labelName.Text = nebula.GivenName;
	}
	
	private void UpdateLabelComposition(){
		String text = "[b]Stardust[/b] " + nebula.Stardust;
		labelComposition.Text = text;
	}
	
	private void UpdateSlider(){
		consumptionSlider.MaxValue = consumptionSliderMaxValue;
		consumptionSlider.Value = nebula.StardustConsumed;
	}
}
