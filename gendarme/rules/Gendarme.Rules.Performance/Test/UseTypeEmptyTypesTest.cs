//
// Unit tests for UseTypeEmptyTypesRule
//
// Authors:
//	Jb Evain <jbevain@novell.com>
//
// Copyright (C) 2008 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Reflection;

using Gendarme.Framework;
using Gendarme.Rules.Performance;
using Mono.Cecil;

using NUnit.Framework;
using Test.Rules.Fixtures;

namespace Test.Rules.Performance {

	[TestFixture]
	public class UseTypeEmptyTypesTest : MethodRuleTestFixture<UseTypeEmptyTypesRule> {
	
		public class TestCase {

			Type [] empty = new Type [0];
			
			public void CreateEmptyTypeArray ()
			{
				Type [] array = new Type [0];
			}

			public void CreateNotEmptyTypeArray ()
			{
				Type [] array = new Type [42];
			}
		}

		[Test]
		public void CreateEmptyTypeArray ()
		{
			AssertRuleFailure<TestCase> ("CreateEmptyTypeArray");
		}

		[Test]
		public void CreateEmptyTypeArrayInCtor ()
		{
			AssertRuleFailure<TestCase> (".ctor");
		}

		[Test]
		public void CreateNotEmptyTypeArray ()
		{
			AssertRuleSuccess<TestCase> ("CreateNotEmptyTypeArray");
		}
	}
}
