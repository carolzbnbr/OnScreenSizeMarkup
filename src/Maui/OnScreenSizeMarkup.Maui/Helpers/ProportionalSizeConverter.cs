namespace OnScreenSizeMarkup.Maui.Helpers;


static class ProportionalSizeConverter
{
	public static IConvertible Multiply(Type toType, object baseNumber, double factor) 
	{
		if (toType == typeof(int))
		{
			return ConvertTo((int)System.Convert.ChangeType(baseNumber, toType), factor);
		}
		else if (toType == typeof(double))
		{
			return ConvertTo((double)System.Convert.ChangeType(baseNumber, toType),factor);
		}
		else if (toType == typeof(float))
		{
			return ConvertTo((float)System.Convert.ChangeType(baseNumber, toType), factor);
		}
		else if (toType == typeof(long))
		{
			return ConvertTo((long)System.Convert.ChangeType(baseNumber, toType), factor);
		}
		else if (toType == typeof(short))
		{
			return ConvertTo((short)System.Convert.ChangeType(baseNumber, toType), factor);
		}
		else if (toType == typeof(decimal))
		{
			return ConvertTo((decimal)System.Convert.ChangeType(baseNumber, toType), factor);
		}

		throw new NotSupportedException($"Type \"{toType.Name}\" is not supported for proportional conversion");
	}
	
	static IConvertible ConvertTo(int numero, double fator)
	{
		var result = numero * fator;
		return (int)Math.Round(result);
	}

	static IConvertible ConvertTo(double numero, double fator)
	{
		var result = numero * fator;
		return Math.Round(result);
	}

	static IConvertible ConvertTo(float numero, double fator)
	{
		var result = numero * (float)fator;
		return (float)Math.Round(result, 1);
	}

	static IConvertible ConvertTo(long numero, double fator)
	{
		var result = numero * fator;
		return (long)Math.Round(result);
	}

	static IConvertible ConvertTo(short numero, double fator)
	{
		var result = numero * fator;
		return (short)Math.Round(result);
	}

	static IConvertible ConvertTo(decimal numero, double fator)
	{
		var result = (double)numero *  fator;
		return (decimal)Math.Round(result);
	}
}