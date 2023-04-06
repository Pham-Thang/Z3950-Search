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
	public class TestFactories
	{

            static void Main( )
            {
                TestFactories t = new TestFactories();
                Console.WriteLine("TestFactories::Main");
                t.TestIConnectionFactory(); 
                t.TestIConnectionExtendedFactory(); 
                t.TestIPrefixQueryFactory();
                t.TestICQLQueryFactory();
             }


            [Test] 
                public void TestIConnectionFactory() 
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("TestFactories::TestIConnectionFactory");
                
                IConnection conn_factory 
                    = IConnectionFactory.Create("no.host.exits", 1234);
                IConnection conn_static 
                    = new Connection("no.host.exits", 1234);

                Type conn_factory_type = conn_factory.GetType(); 
                Type conn_static_type = conn_static.GetType();
 
                Assert.AreEqual(conn_factory_type, conn_static_type, 
                                "IConnectionFactory.Create");
            }
            

            [Test] 
                public void TestIConnectionExtendedFactory() 
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("TestFactories::TestIConnectionExtendedFactory");
                
                IConnection conn_factory 
                    = IConnectionFactory.CreateExtended("no.host.exits", 1234);
                IConnection conn_static 
                    = new ConnectionExtended("no.host.exits", 1234);

                Type conn_factory_type = conn_factory.GetType(); 
                Type conn_static_type = conn_static.GetType();
 
                Assert.AreEqual(conn_factory_type, conn_static_type, 
                                "IConnectionExtendedFactory.Create");
            }
            
            [Test] 
                public void TestIPrefixQueryFactory() 
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("TestFactories::TestIPrefixQueryFactory");
                
                IPrefixQuery query_factory 
                    = IQueryFactory.CreatePrefix("@attr 1=4 @attr 2=102 term");
                IPrefixQuery query_static 
                    = new PrefixQuery("@attr 1=4 @attr 2=102 term");

                Type query_factory_type = query_factory.GetType(); 
                Type query_static_type = query_static.GetType();
 
                Assert.AreEqual(query_factory_type, query_static_type, 
                                "IPrefixQueryFactory.Create");
            }

            
            [Test] 
                public void TestICQLQueryFactory() 
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("TestFactories::TestICQLQueryFactory");
                
                ICQLQuery query_factory 
                    = IQueryFactory.CreateCQL("cql.all=house");
                ICQLQuery query_static 
                    = new CQLQuery("cql.all=house");

                Type query_factory_type = query_factory.GetType(); 
                Type query_static_type = query_static.GetType();
 
                Assert.AreEqual(query_factory_type, query_static_type, 
                                "ICQLQueryFactory.Create");
            }
        }
}
