// 
// Gendarme.Framework.Rule base class
//
// Authors:
//	Sebastien Pouliot <sebastien@ximian.com>
//
// Copyright (C) 2008 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;

namespace Gendarme.Framework {

	/// <summary>
	/// Most rules should be able to inherit from Rule and implement one of the
	/// <c>IAssemblyRule</c>, <c>ITypeRule</c> or <c>IMethodRule</c> and override 
	/// the Check[Assembly|Type|Method] method.
	/// </summary>
	abstract public class Rule : IRule {

		private IRunner runner;
		private string rule_name;
		private string rule_url;

		/// <summary>
		/// Return true if the rule is currently active, false otherwise.
		/// </summary>
		public virtual bool Active {
			get { return true; }
			set { ; }
		}

		/// <summary>
		/// Return the runner executing the rule. This is helpful to get information
		/// outside the rule, like the list of assemblies being analyzed.
		/// </summary>
		public IRunner Runner {
			get { return runner; }
		}

		/// <summary>
		/// Return the name of the rule.
		/// By default this returns the name of the current class.
		/// </summary>
		public virtual string Name {
			get {
				if (rule_name == null)
					rule_name = GetType ().Name;
				return rule_name;
			}
		}

		public abstract string Problem { get; }

		public abstract string Solution { get; }

		/// <summary>
		/// Return an Uri instance to the rule documentation.
		/// By default this returns:
		/// http://www.mono-project.com/{rule name space}#{rule name}
		/// </summary>
		public virtual Uri Uri {
			get {
				if (rule_url == null) {
					Type t = GetType ();
					rule_name = t.Name;
					rule_url = String.Format ("http://www.mono-project.com/{0}#{1}", t.Namespace, rule_name);
				}
				// note: we return a new copy since Uri is not immutable
				return new Uri (rule_url);
			}
		}

		/// <summary>
		/// Initialize the rule. This is where rule can do it's heavy initialization
		/// since the assemblies to be analyzed are already known (and accessible thru
		/// the runner parameter).
		/// </summary>
		/// <param name="runner">The runner that will execute this rule.</param>
		public virtual void Initialize (IRunner runner)
		{
			this.runner = runner;
		}
	}
}
