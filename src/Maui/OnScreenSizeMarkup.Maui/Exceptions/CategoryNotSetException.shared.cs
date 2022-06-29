using System;
using System.Runtime.Serialization;

namespace OnScreenSizeMarkup.Maui.Exceptions;


/// <summary>
/// Exception raised when the categorizer can't determine a category for the screen diagonal size.
/// </summary>
public class CategoryNotSetException: Exception
{
	public CategoryNotSetException()
	{
	}

	public CategoryNotSetException(string message) : base(message)
	{
	}

	public CategoryNotSetException(string message, Exception innerException) : base(message, innerException)
	{
	}

	protected CategoryNotSetException(SerializationInfo info, StreamingContext context) : base(info, context)
	{
	}
}