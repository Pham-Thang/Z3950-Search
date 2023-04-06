/*
 * Copyright (c) 2005, Talis Information Limited.
 *
 * Permission to use, copy, modify, distribute, and sell this software and
 * its documentation, in whole or in part, for any purpose, is hereby granted,
 * provided that:
 *
 * 1. This copyright and permission notice appear in all copies of the
 * software and its documentation. Notices of copyright or attribution
 * which appear at the beginning of any file must remain unchanged.
 *
 * 2. The names of BLCMP, Talis Information Limited or the individual authors
 * may not be used to endorse or promote products derived from this software
 * without specific prior written permission.
 *
 * 3. Users of this software agree to make their best efforts, when
 * documenting their use of the software, to acknowledge Zoom.Net
 * and the role played by the software in their work.
 *
 * THIS SOFTWARE IS PROVIDED "AS IS" AND WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS, IMPLIED, OR OTHERWISE, INCLUDING WITHOUT LIMITATION, ANY
 * WARRANTY OF MERCHANTABILITY OR FITNESS FOR A PARTICULAR PURPOSE.
 * IN NO EVENT SHALL INDEX DATA BE LIABLE FOR ANY SPECIAL, INCIDENTAL,
 * INDIRECT OR CONSEQUENTIAL DAMAGES OF ANY KIND, OR ANY DAMAGES
 * WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER OR
 * NOT ADVISED OF THE POSSIBILITY OF DAMAGE, AND ON ANY THEORY OF
 * LIABILITY, ARISING OUT OF OR IN CONNECTION WITH THE USE OR PERFORMANCE
 * OF THIS SOFTWARE.
 *
 */


namespace Zoom.Net.YazSharp.Test
{
    using System;
    using System.Text;
    using NUnit.Framework;
    using Zoom.Net;
    using Zoom.Net.YazSharp;
    
    /// <summary>YAZ lib load tests</summary>
    [TestFixture] 
	public class TestScan
	{
            [Test] 
                public void TestScanFetch() 
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("TestScan::TestScanFetch");

                IPrefixQuery query = new PrefixQuery("@attr 1=4 the");
                IConnection conn = new Connection("localhost", 9999); 
                conn.DatabaseName = "Default"; 
                
                IScanSet scanset = conn.Scan(query);
                Assert.AreEqual(scanset, scanset, "IScanSet");
                
                Console.Out.WriteLine("IScanSet.Size: '{0}'", scanset.Size);
                //Assert.IsTrue(scanset.Size > 0);
                
                for (uint i = 0; i < scanset.Size && i < 3; i++){
                    IScanTerm term = scanset[i];
                    System.Console.WriteLine("term {0} {1} ({2})",
                                             i, term.Term, term.Occurences); 

                }
                
            }
            
            
        }
}
