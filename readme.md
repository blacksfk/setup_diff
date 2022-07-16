# ACC Setup Diff
Compare setups locally!

## Compilation
### Debugging
`dotnet build` or `dotnet run`. Remember to pass the path to `cars.json` if it isn't in the current directory.

### Publishing
`dotnet publish --no-self-contained -c Release`. .NET runtime required. The single-file, self-contained executable is ridicuously large (>150MiB).

## Running
The program expects the working directory to contain `cars.json`. Either create your own in the format described below or use the one in this repo.

## Cars.json format
```javascript
[
	{
		// Car ID as described in the shared memory documentation.
		"id": "bmw_m4_gt3",

		// The car's name. assign it to anything you wish.
		"name": "BMW M4 GT3",

		// Example of a setting. rule of thumb: if the value
		// appears as a floating point in the game, then multiply it by
		// a factor until that value becomes an integer. Then note that
		// factor down as the "fac" key in the object. The "inc" key describes
		// by how much the value in-game increases with every click.
		//
		// If the setting starts at 0, increments by 1, and is an integer value
		// already (eg. tc1), then the object can be ommitted entirely as Setup.cs
		// will default to those values anyway.
		"caster": {
			"min": 61,
			"fac": 10,
			"inc": 2
		},

		// and so on...
		// see Car.cs and Ref.cs for an overview of which values are expected
		// to be arrays and how many values they require (if any at all).
	}
]
```

# Licence
BSD-3-Clause
