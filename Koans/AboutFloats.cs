using System.Globalization;
using Xunit;
using DotNetKoans.Engine;
using System;

namespace DotNetKoans.Koans;

public class AboutFloats : Koan
{
	[Step(1)]
	public void UnquotedNumbersEndingInFAreFloats()
	{
		var f = 1f;

		Assert.Equal(typeof(float), f.GetType());
	}

	[Step(2)]
	public void FloatsPreserveDecimalPoints()
	{
		float f = 1.5f;

		Assert.Equal(f, 1.5);

		//Floating Point numbers are able to keep data beyond the decimal point
		//unlike Integers which are whole numbers.
		//Here f is set to 1.5, and retains the value of 1.5
		//without rounding or truncating the stored number.
	}

	[Step(3)]
	public void FloatsAreSingles()
	{
		Assert.Equal(typeof(float), typeof(Single));

		//.NET doesn't have a type called `float`
		//Instead, it has a "Single Precision Floating Point Number" type:
		//`System.Single`
		//CoreCLR Languages, like C#, sometimes define language aliases for types.
		//C# calls a `System.Single` a `float` for convenience.
	}

	[Step(4)]
	public void FloatingPointMathOutputsFloats()
	{
		var result = 1 * 2f; //One's an integer, one's a float (even though it's a whole number)!

		//what will the result type be?
		Assert.Equal(typeof(float), result.GetType());

		//.NET kindly stores the result of the math in a float
		//so you don't lose the extra information in your floating point value
	}

	[Step(5)]
	public void FloatsHaveLimitedMaximumAndMinimumValues()
	{
		Assert.Equal(float.MaxValue, 3.40282347E+38f);
		Assert.Equal(float.MinValue, -3.40282347E+38f);
	}

	[Step(6)]
	public void ValueLargerThanTheMaximumFloatBecomesInfinity()
	{
		// If you try to store a number larger than the maximum number a float can store, it will become Infinity or -Infinity
		var largerThanMaximumFloatValue = float.Parse("3.5E+38",CultureInfo.InvariantCulture);
		Assert.True(largerThanMaximumFloatValue == float.PositiveInfinity);
	}

	[Step(7)]
	public void FloatsHaveLimitedPrecision()
	{
		var sevenDigits = 0.9999999f;
		var eightDigits = 0.99999999f;

		Assert.Equal(sevenDigits, 0.999999881f);
		Assert.Equal(eightDigits, 1.0);

		//Remember how floats are "Single Precision"?
		//What does that actually mean?
		//It means that they are actually only precisely accurate up to 7 significant digits,
		//because they only use so much memory (32 bits) to store their value and decimal position.

		//.NET does have a more precise (64 bits) floating point type called `System.Double`
		//or `double` in C#.

		//Floating point numbers round values that are beyond their precision.

		//The required precision for a given application is a major factor in choosing an appropriate
		//number type.
		//If no decimal precision is required, use `int`
		//If up to 7 digits precision is acceptable, use `float`
		//If up to 15 digits precision is acceptable, use `double`
		//If greater precision is needed, consider `decimal`
	}

	[Step(8)]
	public void FloatingPointMathIsWeird()
	{
		var f = 0.3f + 0.6f;
		
		Assert.True(f == 0.900000036f);

		//Math with floating point numbers doesn't always behave how humans expect.
		//This is because floating point numbers are stored in binary,
		//and calculations on them are done in binary.
		//This makes them super efficient for computer processors to do math with,
		//but means those calculations don't behave the same way as decimal (base 10) math.

		//This behaviour is the most important consideration when deciding whether to use
		//Floating Point number types (`float` and `double`) or the `decimal` type.
		//If the math needs to make exact sense in base 10 (e.g. financial calculations),
		//don't use floats.
		//If there are going to be approximations anyway, and/or performance is important
		//(e.g. scientific calculations involving real world measurements) then use floats.
	}
}