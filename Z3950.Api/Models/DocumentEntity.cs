using Microsoft.AspNetCore.Identity;
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
    /// Cần sửa lại theo tài liệu https://www.loc.gov/marc/dccross_199911.html
    public class DocumentEntity
    {

        [MARCField("020 ##$a")]
        [FieldName("ISBN")]
        public string ISBN { get; set; }

        [MARCField("020 ##$c")]
        [FieldName("Giá bìa")]
        public string Price { get; set; }

        [MARCField("020 ##$d")]
        public string Field_020d { get; set; }


        [MARCField("041 0#$a")]
        [FieldName("Ngôn ngữ")]
        public string Language { get; set; }


        [MARCField("082 04$2")]
        public string Field_0822 { get; set; }
        [MARCField("082 04$a")]
        public string Field_082a { get; set; }
        [MARCField("082 04$b")]
        public string Field_082b { get; set; }


        [MARCField("245 00$a")]
        [FieldName("Tiêu đề")]
        public string Title { get; set; }
        [MARCField("245 00$b")]
        [FieldName("Tiêu đề phụ")]
        public string SubTitle { get; set; }
        [MARCField("245 00$c")]
        [FieldName("Author")]
        public string Author { get; set; }
        [MARCField("245 00$n")]
        [FieldName("Phần")]
        public string Volume { get; set; }
        [MARCField("245 00$p")]
        public string Field_245p { get; set; }


        [MARCField("260 ##$a")]
        [FieldName("Nơi XB")]
        public string Publisher_Place { get; set; }
        [MARCField("260 ##$b")]
        [FieldName("Nhà XB")]
        public string Publisher_Name { get; set; }
        [MARCField("260 ##$c")]
        [FieldName("Năm XB")]
        public string Publisher_Time { get; set; }


        [FieldName("Mô tả vật lý")]
        public string Physical { get {
                return Physical_NumberPage + " - " + Physical_Des + " - " + Physical_Size;
            } }
        [MARCField("300 ##$a")]
        public string Physical_NumberPage { get; set; }
        [MARCField("300 ##$b")]
        public string Physical_Des { get; set; }
        [MARCField("300 ##$c")]
        public string Physical_Size { get; set; }


        [MARCField("504 ##$c")]
        public string Field_504c { get; set; }


        [MARCField("520 ##$a")]
        [FieldName("Mô tả")]
        public string Description { get; set; }


        [MARCField("605 #7$2")]
        [FieldName("Nguồn gốc chủ đề")]
        public string Subject_Source { get; set; }
        [MARCField("605 #7$a")]
        [FieldName("Chủ đề")]
        public string Subject { get; set; }


        [MARCField("653 ##$a")]
        [FieldName("Chủ đề không được kiểm soát")]
        public string Subject_Uncontrollable { get; set; }


        [MARCField("655 #7$a")]
        [FieldName("Phân loại")]
        public string Type { get; set; }
        [MARCField("655 #7$2")]
        [FieldName("Nguồn gốc phân loại")]
        public string Type_Source { get; set; }


        [MARCField("700 1#$a")]
        [FieldName("Tác giả - cá nhân")]
        public string Creator_Personal { get; set; }
        [MARCField("700 1#$2")]
        [FieldName("Vai trò Tác giả - cá nhân")]
        public string Creator_Personal_Role { get; set; }
        [MARCField("710 1#$a")]
        [FieldName("Tác giả - tập thể")]
        public string Creator_Corporate { get; set; }
        [MARCField("710 1#$2")]
        [FieldName("Vai trò tác giả - tập thể")]
        public string Creator_Corporate_Role { get; set; }
        [MARCField("711 1#$a")]
        [FieldName("Tác giả - Hội thảo, hội nghị")]
        public string Creator_Conference { get; set; }
        [MARCField("711 1#$2")]
        [FieldName("Vai trò tác giả - Hội thảo, hội nghị")]
        public string Creator_Conference_Role { get; set; }


        [MARCField("773 ##$d")]
        public string Field_773d{ get; set; }
        [MARCField("773 ##$t")]
        [FieldName("<chưa xác định>")]
        public string Field_773t { get; set; }
        [MARCField("773 ##$w")]
        public string Field_773w { get; set; }


        [MARCField("930 ##$a")]
        [FieldName("Số thứ tự")]
        public string SortOrder { get; set; }
        [MARCField("930 ##$b")]
        public string Field_930b { get; set; }


        [MARCField("941 ##$a")]
        public string Field_941a { get; set; }
        [MARCField("941 ##$b")]
        public string Field_941b { get; set; }
    }
}
