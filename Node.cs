using System.Collections.Generic;

namespace SetupDiff {
	// Represents a directory or file.
	public class Node {
		// Name of the directory or file.
		private string name;

		// Absolute path to the directory or file.
		private string path;

		// Sub-directories of the directory.
		private List<Node> children;

		public Node(string name, string path) {
			this.name = name;
			this.path = path;
			this.children = new List<Node>();
		}

		public string Name {
			get {
				return this.name;
			}
		}

		public string Path {
			get {
				return this.path;
			}
		}

		public List<Node> Children {
			get {
				return this.children;
			}
		}
	}
}
