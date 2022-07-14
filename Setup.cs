using System;
using System.IO;
using System.Text.Json;

namespace SetupDiff {
	// Mimics the ACC setup file JSON structure.
	public class Setup {
		public string CarName {get;set;} = string.Empty;
		public string SetupName {get;set;} = string.Empty;
		public BasicSetup BasicSetup {get;set;} = new BasicSetup();
		public AdvancedSetup AdvancedSetup {get;set;} = new AdvancedSetup();

		// Shortcut to tyre offsets.
		public Tyres Tyres {
			get {
				return this.BasicSetup.Tyres;
			}
		}

		// Shortcut to alignment offsets.
		public Alignment Align {
			get {
				return this.BasicSetup.Alignment;
			}
		}

		// Shortcut to electronic offsets.
		public Electronics Elec {
			get {
				return this.BasicSetup.Electronics;
			}
		}

		// Shortcut to strategy offsets.
		public Strategy Strat {
			get {
				return this.BasicSetup.Strategy;
			}
		}

		// Shortcut to mechanical offsets.
		public MechanicalBalance Mech {
			get {
				return this.AdvancedSetup.MechanicalBalance;
			}
		}

		// Shortcut to damper offsets.
		public Dampers Dampers {
			get {
				return this.AdvancedSetup.Dampers;
			}
		}

		// Shortcut to aero offsets.
		public AeroBalance Aero {
			get {
				return this.AdvancedSetup.AeroBalance;
			}
		}

		// Shortcut to the preload offset
		public int Preload {
			get {
				return this.AdvancedSetup.Drivetrain.Preload;
			}
		}

		private static JsonSerializerOptions opts = new JsonSerializerOptions() {
			PropertyNameCaseInsensitive = true
		};

		// Deserialise a setup file.
		public static Setup FromFile(string path) {
			// open the file
			var stream = File.Open(path, FileMode.Open);

			// deserialize into Setup
			var sj = JsonSerializer.Deserialize<Setup>(stream, opts);

			// close the file
			stream.Close();

			if (sj == null) {
				throw new Exception(string.Format("Could not load setup: {0}", path));
			}

			// set the setup name
			sj.SetupName = Path.GetFileName(path);

			return sj;
		}
	}

	public class BasicSetup {
		public Tyres Tyres {get;set;} = new Tyres();
		public Alignment Alignment {get;set;} = new Alignment();
		public Electronics Electronics {get;set;} = new Electronics();
		public Strategy Strategy {get;set;} = new Strategy();
	}

	public class Tyres {
		public int TyreCompound {get;set;} = 0;
		public int[] TyrePressure {get;set;} = new int[4];
	}

	public class Alignment {
		public int[] Camber {get;set;} = new int[4];
		public int[] Toe {get;set;} = new int[4];
		public int CasterLF {get;set;} = 0;
		public int CasterRF {get;set;} = 0;
		public int SteerRatio {get;set;} = 0;
	}

	public class Electronics {
		public int TC1 {get;set;} = 0;
		public int TC2 {get;set;} = 0;
		public int ABS {get;set;} = 0;
		public int ECUMap {get;set;} = 0;
	}

	public class Strategy {
		public int Fuel {get;set;} = 0;
		public int TyreSet {get;set;} = 0;
		public int FrontBrakePadCompound {get;set;} = 0;
		public int RearBrakePadCompound {get;set;} = 0;
	}

	public class AdvancedSetup {
		public MechanicalBalance MechanicalBalance {get;set;} = new MechanicalBalance();
		public Dampers Dampers {get;set;} = new Dampers();
		public AeroBalance AeroBalance {get;set;} = new AeroBalance();
		public Drivetrain Drivetrain {get;set;} = new Drivetrain();
	}

	public class MechanicalBalance {
		public int ARBFront {get;set;} = 0;
		public int ARBRear {get;set;} = 0;
		public int[] WheelRate {get;set;} = new int[4];
		public int[] BumpStopRateUp {get;set;} = new int[4];
		public int[] BumpStopWindow {get;set;} = new int[4];
		public int BrakeTorque {get;set;} = 0;
		public int BrakeBias {get;set;} = 0;
	}

	public class Dampers {
		public int[] BumpSlow {get;set;} = new int[4];
		public int[] BumpFast {get;set;} = new int[4];
		public int[] ReboundSlow {get;set;} = new int[4];
		public int[] ReboundFast {get;set;} = new int[4];
	}

	public class AeroBalance {
		public int[] RideHeight {get;set;} = new int[2];
		public int Splitter {get;set;} = 0;
		public int RearWing {get;set;} = 0;
		public int[] BrakeDuct {get;set;} = new int[2];
	}

	public class Drivetrain {
		public int Preload {get;set;} = 0;
	}
}
