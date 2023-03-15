using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3950.Api.Attrs;

namespace Z3950.Api.Models
{
    /// <summary>
    /// Demo document
    /// </summary>
    /// https://nlv.gov.vn/tai-lieu-nghiep-vu/xml-metadata-va-dublin-core-metadata.html?fbclid=IwAR3Ue8AGaMoxxQ5AywaT7wNGA6IkZCTHw-SVChRP1Ks6JMiy5aBK261VEKs
    /// https://www.loc.gov/marc/dccross_199911.html
    public class DocumentEntity
    {
        [MARCField("245", 'a')]
        public string Title { get; set; }


        public string Creator { get; set; }

        [MARCField("700", 'a')]
        public string PersonalCreator { get; set; }

        [MARCField("700", 'a')]
        public string CollectiveCreator { get; set; }

        [MARCField("711", 'a')]
        public string Conferences { get; set; }


        public string Subject { get; set; }

        [MARCField("653", 'a')]
        public string ControllableSubject { get; set; }

        [MARCField("650", 'a')]
        public string UncontrollableSubject { get; set; }


        public string Description { get; set; }
        [MARCField("520", 'a')]
        public string SummaryDescription { get; set; }
        [MARCField("505", 'a')]
        public string NoteDescription { get; set; }


        [MARCField("260", 'b')]
        public string Publisher { get; set; }

        /// <summary>
        /// Added Entry--Uncontrolled Name/Name
        /// </summary>
        [MARCField("720 ##$a")]
        public string ContributorName { get; set; }
        /// <summary>
        /// Added Entry--Personal Name
        /// </summary>
        [MARCField("700 1#$a")]
        public string Contributor_Personal { get; set; }
        /// <summary>
        /// Added Entry--Corporate Name
        /// </summary>
        [MARCField("720 ##$e")]
        public string Contributor_Corporate { get; set; }
        /// <summary>
        /// Added Entry--Conference Name
        /// </summary>
        [MARCField("720 ##$e")]
        public string ContributorConference { get; set; }
        [MARCField("720 ##$e")]
        public string Contributor_Role { get; set; }


        [MARCField("260", 'g')]
        public string Date { get; set; }


        //[MARCField("655", '')]
        public string Type { get; set; }


        public string Format { get; set; }
        [MARCField("856", 'q')]
        public string Location { get; set; }
        [MARCField("300", 'a')]
        public string PhysicalDescription { get; set; }


        public string Identifier { get; set; }
        [MARCField("024", 'a')]
        public string Identifier_Other { get; set; }
        [MARCField("856", 'u')]
        public string Identifier_URI { get; set; }
        [MARCField("020", 'a')]
        public string Identifier_ISBN { get; set; }
        [MARCField("022", 'a')]
        public string Identifier_ISSN { get; set; }



        [MARCField("786", 'o')]
        public string Source { get; set; }


        public string Language { get; set; }
        [MARCField("546", 'a')]
        public string Language_Sub { get; set; }
        [MARCField("041", 'a')]
        public string Language_ISO { get; set; }


        public string Relation { get; set; }
        [MARCField("787", 'u')]
        public string Relation_Sub { get; set; }
        [MARCField("787", 'o')]
        public string Relation_Other { get; set; }
        [MARCField("776", 'u')]
        public string Relation_PhySub { get; set; }
        [MARCField("776", 'o')]
        public string Relation_PhyOther { get; set; }


        public string Coverage { get; set; }
        [MARCField("500", 'a')]
        public string Coverage_Common { get; set; }
        [MARCField("522", 'a')]
        public string Coverage_Space { get; set; }
        [MARCField("513", 'a')]
        public string Coverage_Time { get; set; }


        public string Rights { get; set; }
        [MARCField("540", 'a')]
        public string Rights_Condition { get; set; }
        [MARCField("865", 'a')]
        public string Rights_Online { get; set; }

    }
}
