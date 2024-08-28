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
	private Nebula _nebula; 
	
	/// Max value of the consumption slider.
	private int consumptionSliderMaxValue = 5;
	
	public Nebula Nebula{
		get{ return _nebula; }
		set{ _nebula = value; }
	}
	
	public override void _Ready(){
		UpdateComponent();
		_nebula.CompositionUpdated += UpdateLabelComposition;
	}
	
	/// Updates all the nodes of the component.
	private void UpdateComponent(){
		UpdateLabelName();
		UpdateLabelComposition();
		UpdateSlider();
	}
	
	private void UpdateLabelName(){
		labelName.Text = _nebula.GivenName;
	}
	
	private void UpdateLabelComposition(){
		String text = "[b]Stardust[/b] " + _nebula.Stardust;
		labelComposition.Text = text;
	}
	
	private void UpdateSlider(){
		consumptionSlider.MaxValue = consumptionSliderMaxValue;
		consumptionSlider.Value = _nebula.StardustConsumed;
	}
	private void OnHSliderValueChanged(double value)
	{
		HandlerNebulas.Instance.UpdateNebulaStardustConsumptionValue(_nebula.DataIndex, (int)value);
	}
}




