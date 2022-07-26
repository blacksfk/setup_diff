using System.Collections.ObjectModel;

namespace SetupDiff {
	// aliases
	using OCS = ObservableCollection<Setting>;

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

		// column header row
		public ObservableCollection<ColumnHeader> ColumnHeaders {get;} =
			new ObservableCollection<ColumnHeader>();

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

			this.ColumnHeaders.Add(new ColumnHeader(
				s.Path, car.Name, s.Name, s.LastWriteTime));

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
			this.RideHeightF.Add(car.RideHeight[F].Apply(s.RideHeightF));
			this.RideHeightR.Add(car.RideHeight[R].Apply(s.RideHeightR));
			this.Splitter.Add(car.Splitter.Apply(s.Aero.Splitter));
			this.DuctF.Add(car.Duct.Apply(s.Aero.BrakeDuct[F]));
			this.Wing.Add(car.Wing.Apply(s.Aero.RearWing));
			this.DuctR.Add(car.Duct.Apply(s.Aero.BrakeDuct[R]));
		}

		// Remove all of the settings at the same index as the matched ID.
		// Returns true if the ID was found (and all settings removed),
		// and false otherwise.
		public bool Remove(string id) {
			int i;
			var coll = this.ColumnHeaders;

			// search for the id
			for (i = 0; i < coll.Count; i++) {
				if (coll[i].Id == id) {
					break;
				}
			}

			if (i >= coll.Count) {
				// id not found
				return false;
			}

			this.ColumnHeaders.RemoveAt(i);
			this.PressureFL.RemoveAt(i);
			this.ToeFL.RemoveAt(i);
			this.CamberFL.RemoveAt(i);
			this.CasterFL.RemoveAt(i);
			this.PressureFR.RemoveAt(i);
			this.ToeFR.RemoveAt(i);
			this.CamberFR.RemoveAt(i);
			this.CasterFR.RemoveAt(i);
			this.PressureRL.RemoveAt(i);
			this.ToeRL.RemoveAt(i);
			this.CamberRL.RemoveAt(i);
			this.PressureRR.RemoveAt(i);
			this.ToeRR.RemoveAt(i);
			this.CamberRR.RemoveAt(i);
			this.TC1.RemoveAt(i);
			this.TC2.RemoveAt(i);
			this.ABS.RemoveAt(i);
			this.ECU.RemoveAt(i);
			this.Fuel.RemoveAt(i);
			this.Tyre.RemoveAt(i);
			this.PadF.RemoveAt(i);
			this.PadR.RemoveAt(i);
			this.SteeringRatio.RemoveAt(i);
			this.ARBF.RemoveAt(i);
			this.BrakePower.RemoveAt(i);
			this.BrakeBias.RemoveAt(i);
			this.ARBR.RemoveAt(i);
			this.Preload.RemoveAt(i);
			this.WheelRateFL.RemoveAt(i);
			this.BumpStopRateFL.RemoveAt(i);
			this.BumpStopRangeFL.RemoveAt(i);
			this.WheelRateFR.RemoveAt(i);
			this.BumpStopRateFR.RemoveAt(i);
			this.BumpStopRangeFR.RemoveAt(i);
			this.WheelRateRL.RemoveAt(i);
			this.BumpStopRateRL.RemoveAt(i);
			this.BumpStopRangeRL.RemoveAt(i);
			this.WheelRateRR.RemoveAt(i);
			this.BumpStopRateRR.RemoveAt(i);
			this.BumpStopRangeRR.RemoveAt(i);
			this.BumpSlowFL.RemoveAt(i);
			this.BumpFastFL.RemoveAt(i);
			this.ReboundSlowFL.RemoveAt(i);
			this.ReboundFastFL.RemoveAt(i);
			this.BumpSlowFR.RemoveAt(i);
			this.BumpFastFR.RemoveAt(i);
			this.ReboundSlowFR.RemoveAt(i);
			this.ReboundFastFR.RemoveAt(i);
			this.BumpSlowRL.RemoveAt(i);
			this.BumpFastRL.RemoveAt(i);
			this.ReboundSlowRL.RemoveAt(i);
			this.ReboundFastRL.RemoveAt(i);
			this.BumpSlowRR.RemoveAt(i);
			this.BumpFastRR.RemoveAt(i);
			this.ReboundSlowRR.RemoveAt(i);
			this.ReboundFastRR.RemoveAt(i);
			this.RideHeightF.RemoveAt(i);
			this.Splitter.RemoveAt(i);
			this.DuctF.RemoveAt(i);
			this.RideHeightR.RemoveAt(i);
			this.Wing.RemoveAt(i);
			this.DuctR.RemoveAt(i);

			return true;
		}
	}
}
