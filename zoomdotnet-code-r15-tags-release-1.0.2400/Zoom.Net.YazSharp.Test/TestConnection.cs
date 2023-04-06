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
    using NUnit.Framework;
    using Zoom.Net;
    using Zoom.Net.YazSharp;
    
    /// <summary>YAZ lib load tests</summary>
    [TestFixture] 
	public class TestConnection
	{
            [Test] 
                public void TestConnectionNew() 
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("TestConnection::TestConnectionNew");

                IConnection conn = new Connection("no.host.exits", -1234);
                Assert.AreEqual(conn, conn, "new Connection('no.host.exits', -1234)");
                
                //Assert.IsTrue(conn);
                //Assert.IsFalse(conn);
                //Assertion.Assert(conn);
                //Assertion.Assert(typeof(conn) == typeof(IConn));
            }
            
            [Test] [ExpectedException(typeof(Zoom.Net.ConnectionUnavailableException))]
                public void TestConnectionUnavailableException() 
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("TestConnection::TestConnectionUnavailableException");
                IPrefixQuery query = new PrefixQuery("@attr 1=4 the");
                IConnection conn = new Connection("no.host.exits", -1234); 
                conn.DatabaseName = "nonsense"; 
                conn.Username = "fred";
                conn.Password = "apple";
                IResultSet resset = conn.Search(query);
                Assert.AreEqual(resset, resset, "IResultSet");
            }
            
            
            [Test] [ExpectedException(typeof(Zoom.Net.ConnectionUnavailableException))]
                public void TestConnectionUnavailableException2() 
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("TestConnection::TestConnectionUnavailableException2");

                IPrefixQuery query = new PrefixQuery("@attr 1=4 the");
                IConnection conn = new Connection("no.host.exits", -1234); 
                conn.DatabaseName = "nonsense"; 
                IScanSet scanset = conn.Scan(query);
                Assert.AreEqual(scanset, scanset, "IScanSet");
            }
	}
}
