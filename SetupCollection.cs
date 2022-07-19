using System.Collections.ObjectModel;

namespace SetupDiff {
	// aliases
	using OCS = ObservableCollection<Setting>;
	using OCStr = ObservableCollection<string>;

	// Wrapper where each member is an observable collection of setup
	// values.
	public class SetupCollection {
		// end
		private const int F = 0;
		private const int R = 1;

		// corner
		private const int FL = 0;
		private const int FR = 1;
		private const int RL = 2;
		private const int RR = 3;

		public OCStr CarName {get;set;} = new OCStr();
		public OCStr SetupName {get;set;} = new OCStr();
		public OCStr SetupPath {get;set;} = new OCStr();

		// tyres: front left
		public OCS PressureFL {get;} = new OCS();
		public OCS ToeFL {get;} = new OCS();
		public OCS CamberFL {get;} = new OCS();
		public OCS CasterFL {get;} = new OCS();

		// tyres: front right
		public OCS PressureFR {get;} = new OCS();
		public OCS ToeFR {get;} = new OCS();
		public OCS CamberFR {get;} = new OCS();
		public OCS CasterFR {get;} = new OCS();

		// tyres: rear left
		public OCS PressureRL {get;} = new OCS();
		public OCS ToeRL {get;} = new OCS();
		public OCS CamberRL {get;} = new OCS();

		// tyres: rear right
		public OCS PressureRR {get;} = new OCS();
		public OCS ToeRR {get;} = new OCS();
		public OCS CamberRR {get;} = new OCS();

		// electronics
		public OCS TC1 {get;} = new OCS();
		public OCS TC2 {get;} = new OCS();
		public OCS ABS {get;} = new OCS();
		public OCS ECU {get;} = new OCS();

		// strategy
		public OCS Fuel {get;} = new OCS();
		public OCS Tyre {get;} = new OCS();
		public OCS PadF {get;} = new OCS();
		public OCS PadR {get;} = new OCS();

		// mechanical
		public OCS SteeringRatio {get;} = new OCS();
		public OCS ARBF {get;} = new OCS();
		public OCS BrakePower {get;} = new OCS();
		public OCS BrakeBias {get;} = new OCS();
		public OCS ARBR {get;} = new OCS();
		public OCS Preload {get;} = new OCS();

		// mechanical: front left
		public OCS WheelRateFL {get;} = new OCS();
		public OCS BumpStopRateFL {get;} = new OCS();
		public OCS BumpStopRangeFL {get;} = new OCS();

		// mechanical: front right
		public OCS WheelRateFR {get;} = new OCS();
		public OCS BumpStopRateFR {get;} = new OCS();
		public OCS BumpStopRangeFR {get;} = new OCS();

		// mechanical: rear left
		public OCS WheelRateRL {get;} = new OCS();
		public OCS BumpStopRateRL {get;} = new OCS();
		public OCS BumpStopRangeRL {get;} = new OCS();

		// mechanical: rear right
		public OCS WheelRateRR {get;} = new OCS();
		public OCS BumpStopRateRR {get;} = new OCS();
		public OCS BumpStopRangeRR {get;} = new OCS();

		// dampers: front left
		public OCS BumpSlowFL {get;} = new OCS();
		public OCS BumpFastFL {get;} = new OCS();
		public OCS ReboundSlowFL {get;} = new OCS();
		public OCS ReboundFastFL {get;} = new OCS();

		// dampers: front right
		public OCS BumpSlowFR {get;} = new OCS();
		public OCS BumpFastFR {get;} = new OCS();
		public OCS ReboundSlowFR {get;} = new OCS();
		public OCS ReboundFastFR {get;} = new OCS();

		// dampers: rear left
		public OCS BumpSlowRL {get;} = new OCS();
		public OCS BumpFastRL {get;} = new OCS();
		public OCS ReboundSlowRL {get;} = new OCS();
		public OCS ReboundFastRL {get;} = new OCS();

		// dampers: rear right
		public OCS BumpSlowRR {get;} = new OCS();
		public OCS BumpFastRR {get;} = new OCS();
		public OCS ReboundSlowRR {get;} = new OCS();
		public OCS ReboundFastRR {get;} = new OCS();

		// aero
		public OCS RideHeightF {get;} = new OCS();
		public OCS Splitter {get;} = new OCS();
		public OCS DuctF {get;} = new OCS();
		public OCS RideHeightR {get;} = new OCS();
		public OCS Wing {get;} = new OCS();
		public OCS DuctR {get;} = new OCS();

		// Append a setup of the the given car. Values are calcuated
		// from the offsets given in the setup with the appropriate
		// increments and factors given in the car.
		public void Append(Setup s, Car car) {
			// shortcuts
			var tp = s.Tyres.TyrePressure;
			var toe = s.Align.Toe;
			var cbr = s.Align.Camber;
			var bsr = s.Mech.BumpStopRateUp;
			var bsw = s.Mech.BumpStopWindow;

			this.CarName.Add(car.Name);
			this.SetupName.Add(s.Name);
			this.SetupPath.Add(s.Path);

			this.PressureFL.Add(car.Pressure.Apply(tp[FL]));
			this.PressureFR.Add(car.Pressure.Apply(tp[FR]));
			this.PressureRL.Add(car.Pressure.Apply(tp[RL]));
			this.PressureRR.Add(car.Pressure.Apply(tp[RR]));

			this.ToeFL.Add(car.Toe[F].Apply(toe[FL]));
			this.ToeFR.Add(car.Toe[F].Apply(toe[FR]));
			this.ToeRL.Add(car.Toe[R].Apply(toe[RL]));
			this.ToeRR.Add(car.Toe[R].Apply(toe[RR]));

			this.CamberFL.Add(car.Camber[F].Apply(cbr[FL]));
			this.CamberFR.Add(car.Camber[F].Apply(cbr[FR]));
			this.CamberRL.Add(car.Camber[R].Apply(cbr[RL]));
			this.CamberRR.Add(car.Camber[R].Apply(cbr[RR]));

			this.CasterFL.Add(car.Caster.Apply(s.Align.CasterLF));
			this.CasterFR.Add(car.Caster.Apply(s.Align.CasterRF));

			this.TC1.Add(car.TC1.Apply(s.Elec.TC1));
			this.TC2.Add(car.TC2.Apply(s.Elec.TC2));
			this.ABS.Add(car.ABS.Apply(s.Elec.ABS));
			this.ECU.Add(car.ECU.Apply(s.Elec.ECUMap));

			this.Fuel.Add(car.Fuel.Apply(s.Strat.Fuel));
			this.Tyre.Add(car.TyreCompound(s.Tyres.TyreCompound, s.Strat.TyreSet));
			this.PadF.Add(car.Pads.Apply(s.Strat.FrontBrakePadCompound));
			this.PadR.Add(car.Pads.Apply(s.Strat.RearBrakePadCompound));

			// mechanical
			this.SteeringRatio.Add(car.SteeringRatio.Apply(s.Align.SteerRatio));
			this.ARBF.Add(car.ARB.Apply(s.Mech.ARBFront));
			this.BrakePower.Add(car.BrakePower.Apply(s.Mech.BrakeTorque));
			this.BrakeBias.Add(car.BrakeBias.Apply(s.Mech.BrakeBias));
			this.ARBR.Add(car.ARB.Apply(s.Mech.ARBRear));
			this.Preload.Add(car.Preload.Apply(s.Preload));

			this.WheelRateFL.Add(car.WheelRate[F].Apply(s.Mech.WheelRate[FL]));
			this.WheelRateFR.Add(car.WheelRate[F].Apply(s.Mech.WheelRate[FR]));
			this.WheelRateRL.Add(car.WheelRate[R].Apply(s.Mech.WheelRate[RL]));
			this.WheelRateRR.Add(car.WheelRate[R].Apply(s.Mech.WheelRate[RR]));

			this.BumpStopRateFL.Add(car.BumpStopRate[F].Apply(bsr[FL]));
			this.BumpStopRateFR.Add(car.BumpStopRate[F].Apply(bsr[FR]));
			this.BumpStopRateRL.Add(car.BumpStopRate[R].Apply(bsr[RL]));
			this.BumpStopRateRR.Add(car.BumpStopRate[R].Apply(bsr[RR]));

			this.BumpStopRangeFL.Add(car.BumpStopRange.Apply(bsw[FL]));
			this.BumpStopRangeFR.Add(car.BumpStopRange.Apply(bsw[FR]));
			this.BumpStopRangeRL.Add(car.BumpStopRange.Apply(bsw[RL]));
			this.BumpStopRangeRR.Add(car.BumpStopRange.Apply(bsw[RR]));

			this.BumpSlowFL.Add(car.BumpSlow.Apply(s.Dampers.BumpSlow[FL]));
			this.BumpSlowFR.Add(car.BumpSlow.Apply(s.Dampers.BumpSlow[FR]));
			this.BumpSlowRL.Add(car.BumpSlow.Apply(s.Dampers.BumpSlow[RL]));
			this.BumpSlowRR.Add(car.BumpSlow.Apply(s.Dampers.BumpSlow[RR]));

			this.BumpFastFL.Add(car.BumpFast.Apply(s.Dampers.BumpFast[FL]));
			this.BumpFastFR.Add(car.BumpFast.Apply(s.Dampers.BumpFast[FR]));
			this.BumpFastRL.Add(car.BumpFast.Apply(s.Dampers.BumpFast[RL]));
			this.BumpFastRR.Add(car.BumpFast.Apply(s.Dampers.BumpFast[RR]));

			this.ReboundSlowFL.Add(car.ReboundSlow.Apply(s.Dampers.ReboundSlow[FL]));
			this.ReboundSlowFR.Add(car.ReboundSlow.Apply(s.Dampers.ReboundSlow[FR]));
			this.ReboundSlowRL.Add(car.ReboundSlow.Apply(s.Dampers.ReboundSlow[RL]));
			this.ReboundSlowRR.Add(car.ReboundSlow.Apply(s.Dampers.ReboundSlow[RR]));

			this.ReboundFastFL.Add(car.ReboundFast.Apply(s.Dampers.ReboundFast[FL]));
			this.ReboundFastFR.Add(car.ReboundFast.Apply(s.Dampers.ReboundFast[FR]));
			this.ReboundFastRL.Add(car.ReboundFast.Apply(s.Dampers.ReboundFast[RL]));
			this.ReboundFastRR.Add(car.ReboundFast.Apply(s.Dampers.ReboundFast[RR]));

			// aero
			this.RideHeightF.Add(car.RideHeight[F].Apply(s.Aero.RideHeight[F]));
			this.Splitter.Add(car.Splitter.Apply(s.Aero.Splitter));
			this.DuctF.Add(car.Duct.Apply(s.Aero.BrakeDuct[F]));
			this.RideHeightR.Add(car.RideHeight[R].Apply(s.Aero.RideHeight[R]));
			this.Wing.Add(car.Wing.Apply(s.Aero.RearWing));
			this.DuctR.Add(car.Duct.Apply(s.Aero.BrakeDuct[R]));
		}

		// Remove the setup pointed to by path.
		// Returns true on success and false otherwise.
		public bool Remove(string path) {
			int idx = this.SetupPath.IndexOf(path);

			if (idx < 0) {
				return false;
			}

			this.CarName.RemoveAt(idx);
			this.SetupName.RemoveAt(idx);
			this.SetupPath.RemoveAt(idx);
			this.PressureFL.RemoveAt(idx);
			this.ToeFL.RemoveAt(idx);
			this.CamberFL.RemoveAt(idx);
			this.CasterFL.RemoveAt(idx);
			this.PressureFR.RemoveAt(idx);
			this.ToeFR.RemoveAt(idx);
			this.CamberFR.RemoveAt(idx);
			this.CasterFR.RemoveAt(idx);
			this.PressureRL.RemoveAt(idx);
			this.ToeRL.RemoveAt(idx);
			this.CamberRL.RemoveAt(idx);
			this.PressureRR.RemoveAt(idx);
			this.ToeRR.RemoveAt(idx);
			this.CamberRR.RemoveAt(idx);
			this.TC1.RemoveAt(idx);
			this.TC2.RemoveAt(idx);
			this.ABS.RemoveAt(idx);
			this.ECU.RemoveAt(idx);
			this.Fuel.RemoveAt(idx);
			this.Tyre.RemoveAt(idx);
			this.PadF.RemoveAt(idx);
			this.PadR.RemoveAt(idx);
			this.SteeringRatio.RemoveAt(idx);
			this.ARBF.RemoveAt(idx);
			this.BrakePower.RemoveAt(idx);
			this.BrakeBias.RemoveAt(idx);
			this.ARBR.RemoveAt(idx);
			this.Preload.RemoveAt(idx);
			this.WheelRateFL.RemoveAt(idx);
			this.BumpStopRateFL.RemoveAt(idx);
			this.BumpStopRangeFL.RemoveAt(idx);
			this.WheelRateFR.RemoveAt(idx);
			this.BumpStopRateFR.RemoveAt(idx);
			this.BumpStopRangeFR.RemoveAt(idx);
			this.WheelRateRL.RemoveAt(idx);
			this.BumpStopRateRL.RemoveAt(idx);
			this.BumpStopRangeRL.RemoveAt(idx);
			this.WheelRateRR.RemoveAt(idx);
			this.BumpStopRateRR.RemoveAt(idx);
			this.BumpStopRangeRR.RemoveAt(idx);
			this.BumpSlowFL.RemoveAt(idx);
			this.BumpFastFL.RemoveAt(idx);
			this.ReboundSlowFL.RemoveAt(idx);
			this.ReboundFastFL.RemoveAt(idx);
			this.BumpSlowFR.RemoveAt(idx);
			this.BumpFastFR.RemoveAt(idx);
			this.ReboundSlowFR.RemoveAt(idx);
			this.ReboundFastFR.RemoveAt(idx);
			this.BumpSlowRL.RemoveAt(idx);
			this.BumpFastRL.RemoveAt(idx);
			this.ReboundSlowRL.RemoveAt(idx);
			this.ReboundFastRL.RemoveAt(idx);
			this.BumpSlowRR.RemoveAt(idx);
			this.BumpFastRR.RemoveAt(idx);
			this.ReboundSlowRR.RemoveAt(idx);
			this.ReboundFastRR.RemoveAt(idx);
			this.RideHeightF.RemoveAt(idx);
			this.Splitter.RemoveAt(idx);
			this.DuctF.RemoveAt(idx);
			this.RideHeightR.RemoveAt(idx);
			this.Wing.RemoveAt(idx);
			this.DuctR.RemoveAt(idx);

			return true;
		}
	}
}
