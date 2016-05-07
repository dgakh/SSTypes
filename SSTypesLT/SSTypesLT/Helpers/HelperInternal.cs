/**********************************************************************************

Simple Smart Types Lite
https://github.com/dgakh/SSTypes
-----------------------

The MIT License (MIT)

Copyright (c) 2016 Dmitriy Gakh ( dmgakh@gmail.com ).

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

**********************************************************************************/

namespace SSTypes
{
    /// <summary>
    /// Class containing useful fields, methods, and properties need for other classes or
    /// for general internal purposes.
    /// </summary>
    internal static class HelperInternal
    {
        // https://msdn.microsoft.com/en-us/library/system.random%28v=vs.110%29.aspx

        private static System.Random random_generator = new System.Random();

        /// <summary>
        /// Returns common System.Random object that can be used for general purposes.
        /// The method is not thread safe.
        /// </summary>
        internal static System.Random GetRandomGenerator()
        {
            return random_generator;
        }

        /// <summary>
        /// Creates new common instance of System.Random object.
        /// The method is not thread safe.
        /// </summary>
        internal static void ResetRandomGenerator()
        {
            random_generator = new System.Random();
        }

        /// <summary>
        /// Creates new instance of System.Random object with specific seed.
        /// The method is not thread safe.
        /// </summary>
        /// <param name="seed">Seed for the new common System.Random object.</param>
        internal static void ResetRandomGenerator(int seed)
        {
            random_generator = new System.Random(seed);
        }
    }

}
