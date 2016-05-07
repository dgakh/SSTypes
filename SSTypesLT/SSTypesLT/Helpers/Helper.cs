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
    /// for general purposes.
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Combines two int hash values into one.
        /// </summary>
        /// <param name="code_1">First code to combine.</param>
        /// <param name="code_2">Second code to combine.</param>
        /// <returns>Combined hash code.</returns>
        public static int CombineHashCodes(int code_1, int code_2)
        {
            int result;

            unchecked
            {
                result = (code_1 << 5) + 3 + code_1 ^ code_2;
            }

            return result;
        }
    }
}
