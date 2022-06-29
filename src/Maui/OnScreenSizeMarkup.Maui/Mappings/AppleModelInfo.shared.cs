namespace OnScreenSizeMarkup.Maui.Mappings;

public struct AppleModelInfo : IEquatable<AppleModelInfo>
{
	readonly string[] models;
	readonly int ppi;

	public AppleModelInfo(string[] models, int ppi)
	{
		this.models = models;
		this.ppi = ppi;


	}

	public string[] Models { get { return models; } }
	public int PixelPerInches { get { return ppi; } }

	public override int GetHashCode()
	{
		return models.GetHashCode() ^ ppi.GetHashCode();
	}

	public override bool Equals(object? targetObj)
	{
		if (targetObj == null || GetType() != targetObj.GetType())
		{
			return false;
		}

		var target = (AppleModelInfo)targetObj;
		
		return Equals(target);
	}

	public bool Equals(AppleModelInfo other)
	{
		return other.models.Equals(models) && other.ppi.Equals(ppi);
	}
}