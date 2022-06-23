using System.Collections.Generic;

namespace SetupDiff {
	// Base class with a generic type parameter for the list.
	public abstract class Node<T> {
		// Name of the node.
		protected string name;

		// Sub-directories or files of the node.
		protected List<T> children;

		protected Node(string name, List<T> children) {
			this.name = name;
			this.children = children;
		}

		public string Name {
			get {
				return this.name;
			}
		}

		public List<T> Children {
			get {
				return this.children;
			}
		}
	}

	// Represents a car directory with track sub-directories.
	public class CarNode : Node<TrackNode> {
		// Whether or not the actual directory name is
		// a known car ID.
		private bool supported;

		public CarNode(string name, bool supported = true) : base(name, new List<TrackNode>()) {
			this.supported = supported;
		}

		public bool Supported {
			get {
				return this.supported;
			}
		}
	}

	// Represents a track directory with setup files contained within.
	public class TrackNode : Node<SetupNode> {
		public TrackNode(string name) : base(name, new List<SetupNode>()) {}
	}

	// Represents a setup file. Has no children.
	public class SetupNode : Node<byte> {
		private string path;

		public SetupNode(string name, string path) : base(name, new List<byte>()) {
			this.path = path;
		}

		public string Path {
			get {
				return this.path;
			}
		}
	}
}
