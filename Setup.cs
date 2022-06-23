namespace SetupDiff {
	// Represents a setup with the offsets applied
	// to the various settings.
	public class Setup {
		public string CarName {get;set;} = string.Empty;
		public string SetupName {get;set;} = string.Empty;
		public Setting<float> PressureFL {get;set;} = new Setting<float>(0, 0);
		public Setting<float> ToeFL {get;set;} = new Setting<float>(0, 0);
		public Setting<float> CamberFL {get;set;} = new Setting<float>(0, 0);
		public Setting<float> CasterFL {get;set;} = new Setting<float>(0, 0);
		public Setting<float> PressureFR {get;set;} = new Setting<float>(0, 0);
		public Setting<float> ToeFR {get;set;} = new Setting<float>(0, 0);
		public Setting<float> CamberFR {get;set;} = new Setting<float>(0, 0);
		public Setting<float> CasterFR {get;set;} = new Setting<float>(0, 0);
		public Setting<float> PressureRL {get;set;} = new Setting<float>(0, 0);
		public Setting<float> ToeRL {get;set;} = new Setting<float>(0, 0);
		public Setting<float> CamberRL {get;set;} = new Setting<float>(0, 0);
		public Setting<float> PressureRR {get;set;} = new Setting<float>(0, 0);
		public Setting<float> ToeRR {get;set;} = new Setting<float>(0, 0);
		public Setting<float> CamberRR {get;set;} = new Setting<float>(0, 0);
		public Setting<int> TC1 {get;set;} = new Setting<int>(0, 0);
		public Setting<int> TC2 {get;set;} = new Setting<int>(0, 0);
		public Setting<int> ABS {get;set;} = new Setting<int>(0, 0);
		public Setting<int> ECU {get;set;} = new Setting<int>(0, 0);
		public Setting<int> Fuel {get;set;} = new Setting<int>(0, 0);
		public Setting<int> Tyre {get;set;} = new Setting<int>(0, 0);
		public Setting<int> PadF {get;set;} = new Setting<int>(0, 0);
		public Setting<int> PadR {get;set;} = new Setting<int>(0, 0);
		public Setting<int> SteeringRatio {get;set;} = new Setting<int>(0, 0);
		public Setting<int> ARBF {get;set;} = new Setting<int>(0, 0);
		public Setting<int> BrakePower {get;set;} = new Setting<int>(0, 0);
		public Setting<float> BrakeBias {get;set;} = new Setting<float>(0, 0);
		public Setting<int> WheelRateFL {get;set;} = new Setting<int>(0, 0);
		public Setting<int> BumpstopRateFL {get;set;} = new Setting<int>(0, 0);
		public Setting<int> BumpstopRangeFL {get;set;} = new Setting<int>(0, 0);
		public Setting<int> WheelRateFR {get;set;} = new Setting<int>(0, 0);
		public Setting<int> BumpstopRateFR {get;set;} = new Setting<int>(0, 0);
		public Setting<int> BumpstopRangeFR {get;set;} = new Setting<int>(0, 0);
		public Setting<int> WheelRateRL {get;set;} = new Setting<int>(0, 0);
		public Setting<int> BumpstopRateRL {get;set;} = new Setting<int>(0, 0);
		public Setting<int> BumpstopRangeRL {get;set;} = new Setting<int>(0, 0);
		public Setting<int> WheelRateRR {get;set;} = new Setting<int>(0, 0);
		public Setting<int> BumpstopRateRR {get;set;} = new Setting<int>(0, 0);
		public Setting<int> BumpstopRangeRR {get;set;} = new Setting<int>(0, 0);
		public Setting<int> ARBR {get;set;} = new Setting<int>(0, 0);
		public Setting<int> Preload {get;set;} = new Setting<int>(0, 0);
		public Setting<int> BumpSlowFL {get;set;} = new Setting<int>(0, 0);
		public Setting<int> BumpFastFL {get;set;} = new Setting<int>(0, 0);
		public Setting<int> ReboundSlowFL {get;set;} = new Setting<int>(0, 0);
		public Setting<int> ReboundFastFL {get;set;} = new Setting<int>(0, 0);
		public Setting<int> BumpSlowFR {get;set;} = new Setting<int>(0, 0);
		public Setting<int> BumpFastFR {get;set;} = new Setting<int>(0, 0);
		public Setting<int> ReboundSlowFR {get;set;} = new Setting<int>(0, 0);
		public Setting<int> ReboundFastFR {get;set;} = new Setting<int>(0, 0);
		public Setting<int> BumpSlowRL {get;set;} = new Setting<int>(0, 0);
		public Setting<int> BumpFastRL {get;set;} = new Setting<int>(0, 0);
		public Setting<int> ReboundSlowRL {get;set;} = new Setting<int>(0, 0);
		public Setting<int> ReboundFastRL {get;set;} = new Setting<int>(0, 0);
		public Setting<int> BumpSlowRR {get;set;} = new Setting<int>(0, 0);
		public Setting<int> BumpFastRR {get;set;} = new Setting<int>(0, 0);
		public Setting<int> ReboundSlowRR {get;set;} = new Setting<int>(0, 0);
		public Setting<int> ReboundFastRR {get;set;} = new Setting<int>(0, 0);
		public Setting<int> RideHeightF {get;set;} = new Setting<int>(0, 0);
		public Setting<int> Splitter {get;set;} = new Setting<int>(0, 0);
		public Setting<int> DuctF {get;set;} = new Setting<int>(0, 0);
		public Setting<int> RideHeightR {get;set;} = new Setting<int>(0, 0);
		public Setting<int> Wing {get;set;} = new Setting<int>(0, 0);
		public Setting<int> DuctR {get;set;} = new Setting<int>(0, 0);
	}
}
