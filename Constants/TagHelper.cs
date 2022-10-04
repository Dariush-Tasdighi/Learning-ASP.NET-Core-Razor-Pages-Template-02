namespace Constants;

public static class TagHelper : object
{
	static TagHelper()
	{
	}

	public const string Prefix = "dtat-";

	public const string Label = Prefix + "simple-label";
	public const string Input = Prefix + "simple-input";
	public const string CheckBox = Prefix + "simple-checkbox";
	public const string TextArea = Prefix + "simple-textarea";

	public const string FullInput = Prefix + "full-input";
	public const string FullSelect = Prefix + "full-select";
	public const string FullCheckBox = Prefix + "full-checkbox";
	public const string FullTextArea = Prefix + "full-textarea";
	public const string FullPasswordInput = Prefix + "full-password-input";

	public const string ReadOnlyInput = Prefix + "readonly-input";
	public const string ReadOnlyCheckBox = Prefix + "readonly-checkbox";
	public const string ReadOnlyTextArea = Prefix + "readonly-textarea";
}
