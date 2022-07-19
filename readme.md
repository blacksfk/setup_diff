# ACC Setup Diff
Compare setups locally!

## How to use
1. Ensure `cars.json` is in your working directory.
2. All of your setups contained within `...\My Documents\Assetto Corsa Competizione\Setups` will be loaded into the tree view on the left sorted by car and circuit.
3. Double click on setup files in the tree to add as many as you like to the comparison table.
4. Setups are compared against the setup in the first column and are highlighted for your convienience (green = above, red = below).
5. Remove setups from the comparison by clicking on the corresponding header.

## Caveats/Known bugs
* The minimums provided for GT3s in `cars.json` only encompass the DHE tyre and their associated camber limits. If you need to compare setups that use different camber limits, adjust the associated values in `cars.json` manually.

## Compilation
### Debugging
`dotnet build` or `dotnet run`. Remember to pass the path to `cars.json` if it isn't in the current directory.

### Publishing
`dotnet publish --no-self-contained -c Release`. .NET runtime required. The single-file, self-contained executable is ridicuously large (>150MiB).

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
		// see Car.cs for an overview of which values are expected
		// to be arrays and how many values they require (if any at all).
	}
]
```

## Licence
BSD-3-Clause
