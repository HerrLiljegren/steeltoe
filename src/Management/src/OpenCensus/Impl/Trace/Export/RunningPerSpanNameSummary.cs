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

namespace Steeltoe.Management.Census.Trace.Export
{
    [Obsolete("Use OpenCensus project packages")]
    public sealed class RunningPerSpanNameSummary : IRunningPerSpanNameSummary
    {
        internal RunningPerSpanNameSummary(int numRunningSpans)
        {
            NumRunningSpans = numRunningSpans;
        }

        public int NumRunningSpans { get; }

        public static IRunningPerSpanNameSummary Create(int numRunningSpans)
        {
            if (numRunningSpans < 0)
            {
                throw new ArgumentOutOfRangeException("Negative numRunningSpans.");
            }

            return new RunningPerSpanNameSummary(numRunningSpans);
        }

        public override string ToString()
        {
            return "RunningPerSpanNameSummary{"
                + "numRunningSpans=" + NumRunningSpans
                + "}";
        }

        public override bool Equals(object o)
        {
            if (o == this)
            {
                return true;
            }

            if (o is RunningPerSpanNameSummary)
            {
                RunningPerSpanNameSummary that = (RunningPerSpanNameSummary)o;
                return this.NumRunningSpans == that.NumRunningSpans;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int h = 1;
            h *= 1000003;
            h ^= this.NumRunningSpans;
            return h;
        }
    }
}
