using System.Collections.ObjectModel;

namespace SetupDiff {
	// aliases
	using OCS = ObservableCollection<Setting>;
	using OCStr = ObservableCollection<string>;

	// Wrapper where each member is an observable collection of setup
	// values.
	public class SetupCollection {
		public OCStr CarName {get;set;} = new OCStr();
		public OCStr SetupName {get;set;} = new OCStr();

		// tyres: front left
		public OCS PressureFL {get;set;} = new OCS();
		public OCS ToeFL {get;set;} = new OCS();
		public OCS CamberFL {get;set;} = new OCS();
		public OCS CasterFL {get;set;} = new OCS();

		// tyres: front right
		public OCS PressureFR {get;set;} = new OCS();
		public OCS ToeFR {get;set;} = new OCS();
		public OCS CamberFR {get;set;} = new OCS();
		public OCS CasterFR {get;set;} = new OCS();

		// tyres: rear left
		public OCS PressureRL {get;set;} = new OCS();
		public OCS ToeRL {get;set;} = new OCS();
		public OCS CamberRL {get;set;} = new OCS();

		// tyres: rear right
		public OCS PressureRR {get;set;} = new OCS();
		public OCS ToeRR {get;set;} = new OCS();
		public OCS CamberRR {get;set;} = new OCS();

		// electronics
		public OCS TC1 {get;set;} = new OCS();
		public OCS TC2 {get;set;} = new OCS();
		public OCS ABS {get;set;} = new OCS();
		public OCS ECU {get;set;} = new OCS();

		// strategy
		public OCS Fuel {get;set;} = new OCS();
		public OCS Tyre {get;set;} = new OCS();
		public OCS PadF {get;set;} = new OCS();
		public OCS PadR {get;set;} = new OCS();

		// mechanical
		public OCS SteeringRatio {get;set;} = new OCS();
		public OCS ARBF {get;set;} = new OCS();
		public OCS BrakePower {get;set;} = new OCS();
		public OCS BrakeBias {get;set;} = new OCS();
		public OCS ARBR {get;set;} = new OCS();
		public OCS Preload {get;set;} = new OCS();

		// mechanical: front left
		public OCS WheelRateFL {get;set;} = new OCS();
		public OCS BumpStopRateFL {get;set;} = new OCS();
		public OCS BumpStopRangeFL {get;set;} = new OCS();

		// mechanical: front right
		public OCS WheelRateFR {get;set;} = new OCS();
		public OCS BumpStopRateFR {get;set;} = new OCS();
		public OCS BumpStopRangeFR {get;set;} = new OCS();

		// mechanical: rear left
		public OCS WheelRateRL {get;set;} = new OCS();
		public OCS BumpStopRateRL {get;set;} = new OCS();
		public OCS BumpStopRangeRL {get;set;} = new OCS();

		// mechanical: rear right
		public OCS WheelRateRR {get;set;} = new OCS();
		public OCS BumpStopRateRR {get;set;} = new OCS();
		public OCS BumpStopRangeRR {get;set;} = new OCS();

		// dampers: front left
		public OCS BumpSlowFL {get;set;} = new OCS();
		public OCS BumpFastFL {get;set;} = new OCS();
		public OCS ReboundSlowFL {get;set;} = new OCS();
		public OCS ReboundFastFL {get;set;} = new OCS();

		// dampers: front right
		public OCS BumpSlowFR {get;set;} = new OCS();
		public OCS BumpFastFR {get;set;} = new OCS();
		public OCS ReboundSlowFR {get;set;} = new OCS();
		public OCS ReboundFastFR {get;set;} = new OCS();

		// dampers: rear left
		public OCS BumpSlowRL {get;set;} = new OCS();
		public OCS BumpFastRL {get;set;} = new OCS();
		public OCS ReboundSlowRL {get;set;} = new OCS();
		public OCS ReboundFastRL {get;set;} = new OCS();

		// dampers: rear right
		public OCS BumpSlowRR {get;set;} = new OCS();
		public OCS BumpFastRR {get;set;} = new OCS();
		public OCS ReboundSlowRR {get;set;} = new OCS();
		public OCS ReboundFastRR {get;set;} = new OCS();

		// aero
		public OCS RideHeightF {get;set;} = new OCS();
		public OCS Splitter {get;set;} = new OCS();
		public OCS DuctF {get;set;} = new OCS();
		public OCS RideHeightR {get;set;} = new OCS();
		public OCS Wing {get;set;} = new OCS();
		public OCS DuctR {get;set;} = new OCS();

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
			this.SetupName.Add(s.SetupName);

			this.PressureFL.Add(car.Pressure.Apply(tp[Corner.FL]));
			this.PressureFR.Add(car.Pressure.Apply(tp[Corner.FR]));
			this.PressureRL.Add(car.Pressure.Apply(tp[Corner.RL]));
			this.PressureRR.Add(car.Pressure.Apply(tp[Corner.RR]));

			this.ToeFL.Add(car.Toe[End.F].Apply(toe[Corner.FL]));
			this.ToeFR.Add(car.Toe[End.F].Apply(toe[Corner.FR]));
			this.ToeRL.Add(car.Toe[End.R].Apply(toe[Corner.RL]));
			this.ToeRR.Add(car.Toe[End.R].Apply(toe[Corner.RR]));

			this.CamberFL.Add(car.Camber[End.F].Apply(cbr[Corner.FL]));
			this.CamberFR.Add(car.Camber[End.F].Apply(cbr[Corner.FR]));
			this.CamberRL.Add(car.Camber[End.R].Apply(cbr[Corner.RL]));
			this.CamberRR.Add(car.Camber[End.R].Apply(cbr[Corner.RR]));

			this.CasterFL.Add(car.Caster.Apply(s.Align.CasterLF[Corner.FL]));
			this.CasterFR.Add(car.Caster.Apply(s.Align.CasterLF[Corner.FR]));

			this.TC1.Add(car.TC1.Apply(s.Elec.TC1));
			this.TC2.Add(car.TC2.Apply(s.Elec.TC2));
			this.ABS.Add(car.ABS.Apply(s.Elec.ABS));
			this.ECU.Add(car.ECU.Apply(s.Elec.ECU));

			// strategy TODO: apply the correct compound
			this.Fuel.Add(car.Fuel.Apply(s.Strat.Fuel));
			this.Tyre.Add(car.Tyre.Apply(s.Strat.TyreSet));
			this.PadF.Add(car.PadF.Apply(s.Strat.FrontBrakePadCompound));
			this.PadR.Add(car.PadR.Apply(s.Strat.RearBrakePadCompound));

			// mechanical
			this.SteeringRatio.Add(car.SteeringRatio.Apply(s.Align.SteerRatio));
			this.ARBF.Add(car.ARBF.Apply(s.Mech.ARBFront));
			this.BrakePower.Add(car.BrakePower.Apply(s.Mech.BrakeTorque));
			this.BrakeBias.Add(car.BrakeBias.Apply(s.Mech.BrakeBias));
			this.ARBR.Add(car.ARBR.Apply(s.Mech.ARBRear));
			this.Preload.Add(car.Preload.Apply(s.Preload));

			this.WheelRateFL.Add(car.WheelRate[End.F].Apply(s.Mech.WheelRate[Corner.FL]));
			this.WheelRateFR.Add(car.WheelRate[End.F].Apply(s.Mech.WheelRate[Corner.FR]));
			this.WheelRateRL.Add(car.WheelRate[End.R].Apply(s.Mech.WheelRate[Corner.RL]));
			this.WheelRateRR.Add(car.WheelRate[End.R].Apply(s.Mech.WheelRate[Corner.RR]));

			this.BumpStopRateFL.Add(car.BumpStopRate[End.F].Apply(bsr[Corner.FL]));
			this.BumpStopRateFR.Add(car.BumpStopRate[End.F].Apply(bsr[Corner.FR]));
			this.BumpStopRateRL.Add(car.BumpStopRate[End.R].Apply(bsr[Corner.RL]));
			this.BumpStopRateRR.Add(car.BumpStopRate[End.R].Apply(bsr[Corner.RR]));

			this.BumpStopRangeFL.Add(car.BumpStopRange.Apply(bsw[Corner.FL]));
			this.BumpStopRangeFR.Add(car.BumpStopRange.Apply(bsw[Corner.FR]));
			this.BumpStopRangeRL.Add(car.BumpStopRange.Apply(bsw[Corner.RL]));
			this.BumpStopRangeRR.Add(car.BumpStopRange.Apply(bsw[Corner.RR]));

			this.BumpSlowFL.Add(car.BumpSlow.Apply(s.Dampers.BumpSlow[Corner.FL]));
			this.BumpSlowFR.Add(car.BumpSlow.Apply(s.Dampers.BumpSlow[Corner.FR]));
			this.BumpSlowRL.Add(car.BumpSlow.Apply(s.Dampers.BumpSlow[Corner.RL]));
			this.BumpSlowRR.Add(car.BumpSlow.Apply(s.Dampers.BumpSlow[Corner.RR]));

			this.BumpFastFL.Add(car.BumpFast.Apply(s.Dampers.BumpFast[Corner.FL]));
			this.BumpFastFR.Add(car.BumpFast.Apply(s.Dampers.BumpFast[Corner.FR]));
			this.BumpFastRL.Add(car.BumpFast.Apply(s.Dampers.BumpFast[Corner.RL]));
			this.BumpFastRR.Add(car.BumpFast.Apply(s.Dampers.BumpFast[Corner.RR]));

			this.ReboundSlowFL.Add(car.ReboundSlow.Apply(s.Dampers.ReboundSlow[Corner.FL]));
			this.ReboundSlowFR.Add(car.ReboundSlow.Apply(s.Dampers.ReboundSlow[Corner.FR]));
			this.ReboundSlowRL.Add(car.ReboundSlow.Apply(s.Dampers.ReboundSlow[Corner.RL]));
			this.ReboundSlowRR.Add(car.ReboundSlow.Apply(s.Dampers.ReboundSlow[Corner.RR]));

			this.ReboundFastFL.Add(car.ReboundFast.Apply(s.Dampers.ReboundFast[Corner.FL]));
			this.ReboundFastFR.Add(car.ReboundFast.Apply(s.Dampers.ReboundFast[Corner.FR]));
			this.ReboundFastRL.Add(car.ReboundFast.Apply(s.Dampers.ReboundFast[Corner.RL]));
			this.ReboundFastRR.Add(car.ReboundFast.Apply(s.Dampers.ReboundFast[Corner.RR]));

			// aero
			this.RideHeightF.Add(car.RideHeight[End.F].Apply(s.Aero.RideHeight[End.F]));
			this.Splitter.Add(car.Splitter.Apply(s.Aero.Splitter));
			this.DuctF.Add(car.Duct.Apply(s.Aero.BrakeDuct[End.F]));
			this.RideHeightR.Add(car.RideHeight[End.R].Apply(s.Aero.RideHeight[End.R]));
			this.Wing.Add(car.Wing.Apply(s.Aero.RearWing));
			this.DuctR.Add(car.Duct.Apply(s.Aero.BrakeDuct[End.R]));
		}
	}
}
