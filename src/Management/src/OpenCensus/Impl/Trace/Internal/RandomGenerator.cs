﻿// Copyright 2017 the original author or authors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;

namespace Steeltoe.Management.Census.Trace.Internal
{
    [Obsolete("Use OpenCensus project packages")]
    internal class RandomGenerator : IRandomGenerator
    {
        private Random _random;

        internal RandomGenerator()
        {
            _random = new Random();
        }

        internal RandomGenerator(int seed)
        {
            _random = new Random(seed);
        }

#pragma warning disable SCS0005 // Weak random generator
        public void NextBytes(byte[] bytes) => _random.NextBytes(bytes);
#pragma warning restore SCS0005 // Weak random generator
    }
}
