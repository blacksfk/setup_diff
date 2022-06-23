namespace SetupDiff {
	// End of the car enumeration.
	public enum End {
		F,
		R
	}

	// Car corner enumeration.
	public enum Corner {
		FL,
		FR,
		RL,
		RR
	}

	// Represents a setup with the offsets applied
	// to the various settings.
	public class Setup {
		private string carName;
		private string setupName;

		private Setting<float>[] pressure;
		private Setting<float>[] toe;
		private Setting<float>[] camber;
		private Setting<float>[] caster;

		private Setting<int>[] tc;
		private Setting<int> abs;
		private Setting<int> ecu;

		private Setting<int> fuel;
		private Setting<int> tyreSet;
		private Setting<int>[] pads;

		private Setting<int>[] arb;
		private Setting<int> brakePower;
		private Setting<int> brakeBias;
		private Setting<int> steeringRatio;
		private Setting<int>[] wheelRate;
		private Setting<int>[] bumpstopRate;
		private Setting<int>[] bumpstopRange;
		private Setting<int> preload;

		private Setting<int>[] bumpSlow;
		private Setting<int>[] bumpFast;
		private Setting<int>[] reboundSlow;
		private Setting<int>[] reboundFast;

		private Setting<int>[] rideHeight;
		private Setting<int>[] ducts;
		private Setting<int> splitter;
		private Setting<int> wing;

		public Setup(
			string carName,
			string setupName,
			Setting<float>[] pressure,
			Setting<float>[] toe,
			Setting<float>[] camber,
			Setting<float>[] caster,
			Setting<int>[] tc,
			Setting<int> abs,
			Setting<int> ecu,
			Setting<int> fuel,
			Setting<int> tyreSet,
			Setting<int>[] pads,
			Setting<int>[] arb,
			Setting<int> brakePower,
			Setting<int> brakeBias,
			Setting<int> steeringRatio,
			Setting<int>[] wheelRate,
			Setting<int>[] bumpstopRate,
			Setting<int>[] bumpstopRange,
			Setting<int> preload,
			Setting<int>[] bumpSlow,
			Setting<int>[] bumpFast,
			Setting<int>[] reboundSlow,
			Setting<int>[] reboundFast,
			Setting<int>[] rideHeight,
			Setting<int>[] ducts,
			Setting<int> splitter,
			Setting<int> wing
		) {
			this.carName = carName;
			this.setupName = setupName;
			this.pressure = pressure;
			this.toe = toe;
			this.camber = camber;
			this.caster = caster;
			this.tc = tc;
			this.abs = abs;
			this.ecu = ecu;
			this.fuel = fuel;
			this.tyreSet = tyreSet;
			this.pads = pads;
			this.arb = arb;
			this.brakePower = brakePower;
			this.brakeBias = brakeBias;
			this.steeringRatio = steeringRatio;
			this.wheelRate = wheelRate;
			this.bumpstopRate = bumpstopRate;
			this.bumpstopRange = bumpstopRange;
			this.preload = preload;
			this.bumpSlow = bumpSlow;
			this.bumpFast = bumpFast;
			this.reboundSlow = reboundSlow;
			this.reboundFast = reboundFast;
			this.rideHeight = rideHeight;
			this.ducts = ducts;
			this.splitter = splitter;
			this.wing = wing;
		}

		public string CarName {
			get {
				return this.carName;
			}
		}

		public string SetupName {
			get {
				return this.setupName;
			}
		}

		public Setting<float>[] Pressure {
			get {
				return this.pressure;
			}
		}

		public Setting<float>[] Toe {
			get {
				return this.toe;
			}
		}

		public Setting<float>[] Camber {
			get {
				return this.camber;
			}
		}

		public Setting<float>[] Caster {
			get {
				return this.caster;
			}
		}

		public Setting<int> TC1 {
			get {
				return this.tc[0];
			}
		}

		public Setting<int> TC2 {
			get {
				return this.tc[1];
			}
		}

		public Setting<int> ABS {
			get {
				return this.abs;
			}
		}

		public Setting<int> ECU {
			get {
				return this.ecu;
			}
		}

		public Setting<int> Fuel {
			get {
				return this.fuel;
			}
		}

		public Setting<int> TyreSet {
			get {
				return this.tyreSet;
			}
		}

		public Setting<int>[] Pads {
			get {
				return this.pads;
			}
		}

		public Setting<int>[] ARB {
			get {
				return this.arb;
			}
		}

		public Setting<int> BrakePower {
			get {
				return this.brakePower;
			}
		}

		public Setting<int> BrakeBias {
			get {
				return this.brakeBias;
			}
		}

		public Setting<int> SteeringRatio {
			get {
				return this.steeringRatio;
			}
		}

		public Setting<int>[] WheelRate {
			get {
				return this.wheelRate;
			}
		}

		public Setting<int>[] BumpstopRate {
			get {
				return this.bumpstopRate;
			}
		}

		public Setting<int>[] BumpstopRange {
			get {
				return this.bumpstopRange;
			}
		}

		public Setting<int> Preload {
			get {
				return this.preload;
			}
		}

		public Setting<int>[] BumpSlow {
			get {
				return this.bumpSlow;
			}
		}

		public Setting<int>[] BumpFast {
			get {
				return this.bumpFast;
			}
		}

		public Setting<int>[] ReboundSlow {
			get {
				return this.reboundSlow;
			}
		}

		public Setting<int>[] ReboundFast {
			get {
				return this.reboundFast;
			}
		}

		public Setting<int>[] RideHeight {
			get {
				return this.rideHeight;
			}
		}

		public Setting<int>[] Ducts {
			get {
				return this.ducts;
			}
		}

		public Setting<int> Splitter {
			get {
				return this.splitter;
			}
		}

		public Setting<int> Wing {
			get {
				return this.wing;
			}
		}

	}
}
