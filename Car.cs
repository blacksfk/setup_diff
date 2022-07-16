namespace SetupDiff {
	// Represents a car model with its minimum reference values for
	// each setting in its setup.
	public class Car {
		public string ID {get;set;} = string.Empty;
		public string Name {get;set;} = string.Empty;

		public ReferencePoint Pressure {get;set;} = new ReferencePoint();

		// only two reference points; front and rear
		public ReferencePoint[] Toe {get;set;} = new ReferencePoint[2];
		public ReferencePoint[] Camber {get;set;} = new ReferencePoint[2];

		// should be the same for both front wheels
		public ReferencePoint Caster {get;set;} = new ReferencePoint();

		public ReferencePoint TC1 {get;set;} = new ReferencePoint();
		public ReferencePoint TC2 {get;set;} = new ReferencePoint();
		public ReferencePoint ABS {get;set;} = new ReferencePoint();
		public ReferencePoint ECU {get;set;} = new ReferencePoint();

		public ReferencePoint Fuel {get;set;} = new ReferencePoint();
		public ReferencePoint Tyre {get;set;} = new ReferencePoint();
		public ReferencePoint Pads {get;set;} = new ReferencePoint();

		public ReferencePoint ARB {get;set;} = new ReferencePoint();
		public ReferencePoint BrakePower {get;set;} = new ReferencePoint();
		public ReferencePoint BrakeBias {get;set;} = new ReferencePoint();
		public ReferencePoint SteeringRatio {get;set;} = new ReferencePoint();

		// two reference points for both the front and rear suspension
		// wheel rate is expected to be an array of values
		public ReferenceList[] WheelRate {get;set;} = new ReferenceList[2];
		public ReferencePoint[] BumpStopRate {get;set;} = new ReferencePoint[2];

		public ReferencePoint BumpStopRange {get;set;} = new ReferencePoint();
		public ReferencePoint Preload {get;set;} = new ReferencePoint();

		// all damper settings start at the same value for each corner
		public ReferencePoint BumpSlow {get;set;} = new ReferencePoint();
		public ReferencePoint BumpFast {get;set;} = new ReferencePoint();
		public ReferencePoint ReboundSlow {get;set;} = new ReferencePoint();
		public ReferencePoint ReboundFast {get;set;} = new ReferencePoint();

		// front and rear ride heights
		public ReferencePoint[] RideHeight {get;set;} = new ReferencePoint[2];

		// both ducts range from 1 through 6
		public ReferencePoint Duct {get;set;} = new ReferencePoint();

		public ReferencePoint Splitter {get;set;} = new ReferencePoint();
		public ReferencePoint Wing {get;set;} = new ReferencePoint();
	}
}
