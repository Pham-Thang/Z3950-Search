using MARC;
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
    /// https://nlv.gov.vn/tai-lieu-nghiep-vu/ung-dung-marc21-tai-thu-vien-quoc-gia-viet-nam.html
    public class BookEntity
    {
        /// <summary>
        /// Đầu biểu, 24 ký tự, đóng vai trò như Id
        /// </summary>
        [MARCLeaderField]
        public string Leader { get; set; }

        #region "0XX - Thông tin kiểm soát, định danh, chỉ số phân loại, v.v."

        #region "001 - 006 CÁC TRƯỜNG KIỂM SOÁT"
        ///// <summary>
        ///// 001   SỐ KIỂM SOÁT (KL)
        ///// </summary>
        //public string ControlNumber { get; set; }
        ///// <summary>
        ///// 003   MÃ CƠ QUAN GÁN SỐ KIỂM SOÁT (KL)
        ///// </summary>
        //public string CodeOfControlNumberAssignmentAgency { get; set; }
        ///// <summary>
        ///// 005   NGÀY VÀ THỜI GIAN GIAO DỊCH LẦN CUỐI VỚI BIỂU GHI (KL)
        ///// 16 ký tự
        ///// Ex: 1994023151047.0 => ngày 31 tháng 2 năm 1994, 15giờ 10 phút 47 giây
        ///// </summary>
        //public string ModifiedDate { get; set; }
        ///// <summary>
        ///// 006   YẾU TỐ DỮ LIỆU CÓ ĐỘ DÀI CỐ ĐỊNH - ĐẶC TRƯNG TÀI LIỆU BỔ SUNG (L)
        ///// </summary>
        //public string FeatureAdditionalDocumentation { get; set; }
        #endregion

        ///// <summary>
        ///// 007   TRƯỜNG MÔ TẢ VẬT LÝ CÓ ĐỘ DÀI CỐ ĐỊNH - THÔNG TIN CHUNG (L)
        ///// https://nlv.gov.vn/images/documents/marc21/007.htm
        ///// </summary>
        //public string Field_007 { get; set; }
        ///// <summary>
        ///// 008   CÁC YẾU TỐ DỮ LIỆU CÓ ĐỘ DÀI CỐ ĐỊNH (KL)
        ///// https://nlv.gov.vn/images/documents/marc21/008.htm
        ///// </summary>
        //public string Field_008 { get; set; }

        [MARCDataField("020 ##$a")]
        [FieldName("ISBN")]
        public string ISBN { get; set; }

        [MARCDataField("020 ##$c")]
        [FieldName("Giá tiền")]
        public string Price { get; set; }

        [MARCDataField("020 ##$d")]
        [FieldName("Số lượng bản")]
        public string NumberOfBook { get; set; }


        [MARCDataField("041 0#$a")]
        [FieldName("Mã ngôn ngữ")]
        public string LanguageCode { get; set; }


        [MARCDataField("084 ##$a")]
        [FieldName("Ký hiệu phân loại")]
        public string ClassifyCode { get; set; }
        [MARCDataField("084 ##$b")]
        [FieldName("Chỉ số cutter (mã cutter theo tên sách)")]
        public string CutterCode { get; set; }
        [MARCDataField("084 ##$2")]
        [FieldName("Nguồn phân loại")]
        public string ClassifySource { get; set; }
        #endregion

        #region "1XX - Tiêu đề chính"
        [MARCDataField("110 ##$2")]
        [FieldName("Tác giả tập thể")]
        public string CollectiveAuthor { get; set; }
        #endregion

        #region "2XX - Nhan đề và thông tin liên quan đến nhan đề(nhan đề, lần xuất bản, thông tin về in ấn)"
        [MARCDataField("242 ##$a")]
        [FieldName("Dịch tên sách")]
        public string TitleTranslate { get; set; }

        [MARCDataField("245 00$a")]
        [FieldName("Tên sách")]
        public string Title { get; set; }
        [MARCDataField("245 00$b")]
        [FieldName("Phụ đề")]
        public string SubTitle { get; set; }
        [MARCDataField("245 00$c")]
        [FieldName("Thông tin về trách nhiệm")]
        public string ResponsibilityInformation { get; set; }
        [MARCDataField("245 00$n")]
        [FieldName("Phần")]
        public string Serial { get; set; }
        //[MARCField("245 00$p")]
        //public string Field_245p { get; set; }


        [MARCDataField("260 ##$a")]
        [FieldName("Nơi xuất bản")]
        public string Publisher_Place { get; set; }
        [MARCDataField("260 ##$b")]
        [FieldName("Nhà xuất bản")]
        public string Publisher_Name { get; set; }
        [MARCDataField("260 ##$c")]
        [FieldName("Năm xuất bản")]
        public string Publisher_Year { get; set; }
        #endregion

        #region "3XX - Mô tả vật lý, v.v."
        //[FieldName("Mô tả vật lý")]
        //public string Physical { get {
        //        return Physical_NumberPage + " - " + Physical_Des + " - " + Physical_Size;
        //    } }
        [MARCDataField("300 ##$a")]
        [FieldName("Số trang")]
        public string NumberPage { get; set; }
        [MARCDataField("300 ##$b")]
        [FieldName("Các chi tiết vật lí khác")]
        public string OtherPhysical { get; set; }
        [MARCDataField("300 ##$c")]
        [FieldName("Kích thước")]
        public string Size { get; set; }
        [MARCDataField("300 ##$e")]
        [FieldName("Tài liệu kèm theo")]
        public string AttachmentDocument { get; set; }
        #endregion

        #region "4XX - Thông báo về tùng thư"
        [MARCDataField("490 ##$a")]
        [FieldName("Thông tin về tùng thư")]
        public string Tungthu_Infomation { get; set; }
        [MARCDataField("490 ##$v")]
        [FieldName("Số thứ tự tập")]
        public string Tungthu_PartSerial { get; set; }
        #endregion

        #region "5XX - Chú giải"
        [MARCDataField("500 ##$c")]
        [FieldName("Phụ chú chung")]
        public string GeneralNote { get; set; }

        [MARCDataField("504 ##$c")]
        [FieldName("Phụ chú thư mục")]
        public string FolderNote { get; set; }


        [MARCDataField("520 ##$a")]
        [FieldName("Tóm tắt")]
        public string Description { get; set; }
        #endregion

        #region "6XX - Các trường về truy cập chủ đề"
        [MARCDataField("600 #7$a")]
        [FieldName("Nhân vật - Họ và tên")]
        public string Character_FullName { get; set; }
        [MARCDataField("600 #7$c")]
        [FieldName("Nhân vật - Chức danh")]
        public string Character_Position { get; set; }
        [MARCDataField("600 #7$a")]
        [FieldName("Nhân vật - Năm sinh năm mất")]
        public string Character_NSNM { get; set; }
        [MARCDataField("600 #7$a")]
        [FieldName("Nhân vật - Địa lý")]
        public string Character_Dialy { get; set; }
        [MARCDataField("600 #7$a")]
        [FieldName("Nhân vật - Nguồn")]
        public string Character_Source { get; set; }


        [MARCDataField("605 #7$2")]
        [FieldName("Nguồn gốc chủ đề")]
        public string Subject_Source { get; set; }
        [MARCDataField("605 #7$a")]
        [FieldName("Chủ đề")]
        public string Subject_Name { get; set; }


        [MARCDataField("653 ##$a")]
        [FieldName("Chủ đề không được kiểm soát")]
        public string Subject_Uncontrollable { get; set; }


        [MARCDataField("655 #7$a")]
        [FieldName("Phân loại")]
        public string Type { get; set; }
        [MARCDataField("655 #7$2")]
        [FieldName("Nguồn gốc phân loại")]
        public string Type_Source { get; set; }
        #endregion

        #region "7XX - Tiêu đề bổ sung, không phải chủ đề hoặc tùng thư; trường liên kết"
        [MARCDataField("700 1#$a")]
        [FieldName("Tác giả - cá nhân")]
        public string Creator_Personal { get; set; }
        [MARCDataField("700 1#$2")]
        [FieldName("Vai trò Tác giả - cá nhân")]
        public string Creator_Personal_Role { get; set; }
        [MARCDataField("710 1#$a")]
        [FieldName("Tác giả - tập thể")]
        public string Creator_Corporate { get; set; }
        [MARCDataField("710 1#$2")]
        [FieldName("Vai trò tác giả - tập thể")]
        public string Creator_Corporate_Role { get; set; }
        [MARCDataField("711 1#$a")]
        [FieldName("Tác giả - Hội thảo, hội nghị")]
        public string Creator_Conference { get; set; }
        [MARCDataField("711 1#$2")]
        [FieldName("Vai trò tác giả - Hội thảo, hội nghị")]
        public string Creator_Conference_Role { get; set; }


        //[MARCField("773 ##$d")]
        //public string Field_773d{ get; set; }
        //[MARCField("773 ##$t")]
        //[FieldName("<chưa xác định>")]
        //public string Field_773t { get; set; }
        //[MARCField("773 ##$w")]
        //public string Field_773w { get; set; }
        #endregion

        #region "8XX - Tiêu đề tùng thư bổ sung, sưu tập, v.v."

        #endregion

        #region "9XX - Dành cho ứng dụng cục bộ"
        [MARCDataField("930 ##$a")]
        [FieldName("Số thứ tự")]
        public string SortOrder { get; set; }
        //[MARCField("930 ##$b")]
        //public string Field_930b { get; set; }


        //[MARCField("941 ##$a")]
        //public string Field_941a { get; set; }
        //[MARCField("941 ##$b")]
        //public string Field_941b { get; set; }
        #endregion
    }
}
