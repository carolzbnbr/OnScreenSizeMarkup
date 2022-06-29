using System;
using System.Runtime.Serialization;

namespace OnScreenSizeMarkup.Maui.Exceptions;

/// <summary>
/// Raised when a xaml markup has some invalid args/values.
/// </summary>
public class XamlMarkupException : Exception
{
	/// <summary>
	/// 
	/// </summary>
	public XamlMarkupException()
	{
	}
	/// <summary>
	/// 
	/// </summary>
	public XamlMarkupException(string message) : base(message)
	{
	}
	/// <summary>
	/// 
	/// </summary>
	public XamlMarkupException(string message, Exception innerException) : base(message, innerException)
	{
	}
	/// <summary>
	/// 
	/// </summary>
	protected XamlMarkupException(SerializationInfo info, StreamingContext context) : base(info, context)
	{
	}
}