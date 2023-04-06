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
    using System.Reflection;
    using System.Text;
    using NUnit.Framework;
    using Zoom.Net;
    using Zoom.Net.YazSharp;
    
    /// <summary>YAZ lib load tests</summary>
    [TestFixture] 
	public class TestConnectionExtended
	{
            /*
            static void Main( )
            {
                TestConnectionExtended t = new TestConnectionExtended();
                Console.WriteLine("TestConnectionExtended::Main");
                t.TestRecordFetchPQF(); 
                t.TestConnectionExtendedItemOrder();
                t.TestConnectionExtendedUpdate();
                t.TestConnectionExtendedCreate();
                t.TestConnectionExtendedDrop();
                t.TestConnectionExtendedCommit();
            }
            */

            [Test] 
                public void TestConnectionExtendedNew() 
            {
                System.Console.WriteLine("");
                System.Console.WriteLine(
                       "TestConnectionExtended::TestConnectionExtendedNew");

                IConnectionExtended conn 
                    = new ConnectionExtended("no.host.exits", -1234);
                Assert.AreEqual(conn, conn, 
                       "new ConnectionExtended('no.host.exits', -1234)");
            }


            [Test] 
                public void TestRecordFetchPQF() 
            {
                System.Console.WriteLine("");
                System.Console.WriteLine(
                              "TestConnectionExtended::TestRecordFetchPQF");

                IPrefixQuery query = new PrefixQuery("@attr 1=4 the");
                IConnectionExtended conn 
                    = new ConnectionExtended("localhost", 9999); 
                conn.DatabaseName = "Default"; 
                
                IResultSet resset = conn.Search(query);
                Assert.AreEqual(resset, resset, "IResultSet");
                
                Console.Out.WriteLine("IResultSet.Size: '{0}'", resset.Size);
                Assert.IsTrue(resset.Size > 0);
                
                for (uint i = 0; i < resset.Size && i < 3; i++){
                    IRecord record = resset[i];
                    RecordSyntax syntax = record.Syntax;
                    //byte[] content = record.Content;
                    string content = Encoding.ASCII.GetString(record.Content);
                    int size = content.Length;
                    Assert.IsTrue(size > 0);

                    System.Console.WriteLine("record {0} syntax {1} size {2}", 
                                             i, syntax, size);
                    //System.Console.WriteLine(content);
                }
                
            }


            [Test] 
                public void TestConnectionExtendedItemOrder() 
            {
                System.Console.WriteLine("");
                System.Console.WriteLine(
                    "TestConnectionExtended::TestConnectionExtendedItemOrder");

                IConnectionExtended conn 
                    = new ConnectionExtended("localhost", 9999);
                conn.DatabaseName = "Default"; 

                Assert.AreEqual(conn, conn, 
                                "new ConnectionExtended('localhost', 9999)");

                IPackage pack = conn.Package("itemorder");
                pack.Options["contact-name"] = "ILL contact name";
                pack.Options["contact-phone"] = "ILL contact phone";
                pack.Options["contact-email"] = "ILL contact email";
                pack.Options["itemorder-item"] = "1";
                pack.Send();
            }



            [Test] 
                public void TestConnectionExtendedUpdate() 
            {
                System.Console.WriteLine("");
                System.Console.WriteLine(
                      "TestConnectionExtended::TestConnectionExtendedUpdate");

                IConnectionExtended conn 
                    = new ConnectionExtended("localhost", 9999);
                conn.DatabaseName = "Default"; 

                Assert.AreEqual(conn, conn, 
                                "new ConnectionExtended('localhost', 9999)");

                IPackage pack = conn.Package("update");
                //pack.Options["recordIdOpaque"] = "1";
                //pack.Options["recordIdNumber"] = "2";
                pack.Options["record"] = "<test><a>abc</a><b>bde</b></test>";
                pack.Options["syntax"] = "xml";
                //pack.Options["databaseName"] = "Default";
                pack.Send();

            }



            [Test] 
                public void TestConnectionExtendedCreate() 
            {
                System.Console.WriteLine("");
                System.Console.WriteLine(
                      "TestConnectionExtended::TestConnectionExtendedCreate");

                IConnectionExtended conn 
                    = new ConnectionExtended("localhost", 9999);
                conn.DatabaseName = "Default"; 

                Assert.AreEqual(conn, conn, 
                                "new ConnectionExtended('localhost', 9999)");

                IPackage pack = conn.Package("create");
                pack.Options["databaseName"] = "NewDB";
                pack.Send();

            }



            [Test] 
                public void TestConnectionExtendedDrop() 
            {
                System.Console.WriteLine("");
                System.Console.WriteLine(
                      "TestConnectionExtended::TestConnectionExtendedDrop");

                IConnectionExtended conn 
                    = new ConnectionExtended("localhost", 9999);
                conn.DatabaseName = "Default"; 

                Assert.AreEqual(conn, conn, 
                                "new ConnectionExtended('localhost', 9999)");

                IPackage pack = conn.Package("drop");
                pack.Options["databaseName"] = "NewDB";
                pack.Send();

            }



            [Test] 
                public void TestConnectionExtendedCommit() 
            {
                System.Console.WriteLine("");
                System.Console.WriteLine(
                      "TestConnectionExtended::TestConnectionExtendedCommit");

                IConnectionExtended conn 
                    = new ConnectionExtended("localhost", 9999);
                conn.DatabaseName = "Default"; 

                Assert.AreEqual(conn, conn, 
                                "new ConnectionExtended('localhost', 9999)");

                IPackage pack = conn.Package("commit");
                pack.Send();

            }


        }
}
