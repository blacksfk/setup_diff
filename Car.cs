namespace SetupDiff {
	// Represents a car model with its minimum reference values for
	// each setting in its setup.
	public class Car {
		public string ID {get;set;} = string.Empty;
		public string Name {get;set;} = string.Empty;

		public Ref Pressure {get;set;} = new Ref();

		// only two reference points; front and rear
		public Ref[] Toe {get;set;} = new Ref[2];
		public Ref[] Camber {get;set;} = new Ref[2];

		// should be the same for both front wheels
		public Ref Caster {get;set;} = new Ref();

		public Ref TC1 {get;set;} = new Ref();
		public Ref TC2 {get;set;} = new Ref();
		public Ref ABS {get;set;} = new Ref();
		public Ref ECU {get;set;} = new Ref();

		public Ref Fuel {get;set;} = new Ref();
		public Ref Tyre {get;set;} = new Ref();
		public Ref Pads {get;set;} = new Ref();

		public Ref ARB {get;set;} = new Ref();
		public Ref BrakePower {get;set;} = new Ref();
		public Ref BrakeBias {get;set;} = new Ref();
		public Ref SteeringRatio {get;set;} = new Ref();

		// two reference points for both the front and rear suspension
		public Ref[] WheelRate {get;set;} = new Ref[2];
		public Ref[] BumpStopRate {get;set;} = new Ref[2];

		public Ref BumpStopRange {get;set;} = new Ref();
		public Ref Preload {get;set;} = new Ref();

		// all damper settings start at the same value for each corner
		public Ref BumpSlow {get;set;} = new Ref();
		public Ref BumpFast {get;set;} = new Ref();
		public Ref ReboundSlow {get;set;} = new Ref();
		public Ref ReboundFast {get;set;} = new Ref();

		// front and rear ride heights
		public Ref[] RideHeight {get;set;} = new Ref[2];

		// both ducts range from 1 through 6
		public Ref Duct {get;set;} = new Ref();

		public Ref Splitter {get;set;} = new Ref();
		public Ref Wing {get;set;} = new Ref();
	}
}
