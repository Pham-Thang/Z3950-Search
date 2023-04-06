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
	public class TestConnectionOptions
	{

            [Test] 
                public void TestRecordFetchConnnectionOptions() 
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("TestConnectionOptions::TestRecordFetchConnnectionOptions");
                IPrefixQuery query = new PrefixQuery("@attr 1=4 the");


                //IConnection conn = opts.CreateConnection();
                IConnection conn = new Connection("localhost", 9999); 
                //conn.DatabaseName = "Default"; 
      
                // Standard Connection Options          
                conn.Options["implementationId"] = "81";
                conn.Options["implementationName"]  = "Zoom.Net.YazSharp";
                conn.Options["implementationVersion"] = "0.9";

                conn.Options["user"] = "auser";
                conn.Options["group"] = "agroup";
                conn.Options["password"] = "apassword";
                conn.Options["databaseName"] = "Default";

                // Interesting Connections options
                conn.Options["piggyback"] = "1";
                conn.Options["lang"] = "en";
                conn.Options["charset"] = "UTF-8";
                conn.Options["elementSetName"] = "F";
                conn.Options["preferredRecordSyntax"] = "XML";
                // allowed are: USMARC, SUTRS, XML, SGML, GRS-1, OPAC, EXPLAIN 

                // Exotic Connections options - not tested yet
                //conn.Options["proxy"] = "bagel.indexdata.dk:9000";
                //conn.Options["async"] = "1";
                //conn.Options["maximumRecordSize"] = "1024";
                //conn.Options["preferredMessageSize"] = "1MB";
                //conn.Options["serverImplementationId"] = "anserverid";
                //conn.Options["targetImplementationName"] = "obsolete";
                //conn.Options["serverImplementationVersion"] = "aversion";
                //conn.Options["smallSetUpperBound"] = "10";
                //conn.Options["largeSetLowerBound"] = "1000";
                //conn.Options["mediumSetPresentNumber"] = "100";
                //conn.Options["smallSetElementSetName"] = "F";
                //conn.Options["mediumSetElementSetName"] = "B";



                IResultSet resset = conn.Search(query);
                Assert.AreEqual(resset, resset, "IResultSet");

                // Result set Options
                //resset.Options["start"] = "1";
                //resset.Options["count"] = "2";
                //resset.Options["presentChunk"] = "3";
                //resset.Options["elementSetName"] = "F";
                //resset.Options["preferredRecordSyntax"] = "SUTRS";
                //resset.Options["schema"] = "Gils-schema"; // Geo-schema 
                //resset.Options["setname"] = "asetname";

                Console.Out.WriteLine("IResultSet.Size: '{0}'", resset.Size);
                Assert.IsTrue(resset.Size > 0);

                for (uint i = 0; i < resset.Size && i < 3; i++){
                    IRecord record = resset[i];
                    RecordSyntax syntax = record.Syntax;
                    //byte[] content = record.Content;
                    string content = Encoding.ASCII.GetString(record.Content);
                    int size = content.Length;
                    Assert.IsTrue(size > 0);

                    System.Console.WriteLine("record {0} syntax {1} size {2}", i, syntax, size);
                    //System.Console.WriteLine(content);
                }
          
            }

            [Test] 
                public void TestScanFetchConnnectionOptions() 
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("TestConnectionOptions::TestScanFetchConnnectionOptions");
                IPrefixQuery query = new PrefixQuery("@attr 1=4 the");


                //IConnection conn = opts.CreateConnection();
                IConnection conn = new Connection("localhost", 9999); 
                //conn.DatabaseName = "Default"; 
      
                // Standard Connection Options          
                conn.Options["implementationId"] = "81";
                conn.Options["implementationName"]  = "Zoom.Net.YazSharp";
                conn.Options["implementationVersion"] = "0.9";

                conn.Options["user"] = "auser";
                conn.Options["group"] = "agroup";
                conn.Options["password"] = "apassword";
                conn.Options["databaseName"] = "Default";

                // Interesting Connections options
                conn.Options["piggyback"] = "1";
                conn.Options["lang"] = "en";
                conn.Options["charset"] = "UTF-8";
                conn.Options["elementSetName"] = "F";
                conn.Options["preferredRecordSyntax"] = "XML";
                // allowed are: USMARC, SUTRS, XML, SGML, GRS-1, OPAC, EXPLAIN 

                // Exotic Connections options - not tested yet
                //conn.Options["proxy"] = "bagel.indexdata.dk:9000";
                //conn.Options["async"] = "1";
                //conn.Options["maximumRecordSize"] = "1024";
                //conn.Options["preferredMessageSize"] = "1MB";
                //conn.Options["serverImplementationId"] = "anserverid";
                //conn.Options["targetImplementationName"] = "obsolete";
                //conn.Options["serverImplementationVersion"] = "aversion";
                //conn.Options["smallSetUpperBound"] = "10";
                //conn.Options["largeSetLowerBound"] = "1000";
                //conn.Options["mediumSetPresentNumber"] = "100";
                //conn.Options["smallSetElementSetName"] = "F";
                //conn.Options["mediumSetElementSetName"] = "B";



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
