namespace Z3950.Api.Constants
{
    /// <summary>
    /// https://nlv.gov.vn/images/documents/marc21/gioithieu.htm
    /// </summary>
    public static class CategoryType
    {
        /// <summary>
        /// Sách (BK) - sử dụng cho các tài liệu văn bản được in, bản thảo và các tài liệu vi hình có bản chất chuyên khảo.
        /// </summary>
        public const string Book = "BK";
        /// <summary>
        /// Xuất bản phẩm nhiều kỳ (SE) - sử dụng cho tài liệu văn bản được in, bản thảo và các tài liệu vi hình mà nó được sử dụng ở  dạng từng phần với phương thức xuất bản lặp lại (như ấn phẩm định kỳ, báo, niên giám,...).
        /// </summary>
        public const string SerialMultiPart = "SE";
        /// <summary>
        /// Tệp tin (CF) - sử dụng cho phần mềm máy tính, dữ liệu số, các tài liệu đa phương tiện định hướng sử dụng bằng máy tính, hệ thống hoặc dịch vụ trực tuyến. Các loại nguồn tin điện tử khác được mã hoá theo khía cạnh quan trọng nhất của chúng. Tài liệu có thể có bản chất chuyên khảo hoặc xuất bản nhiều kỳ.
        /// </summary>
        public const string File = "CF";
        /// <summary>
        /// Bản đồ (MP) - sử dụng cho tài liệu bản đồ được in, bản thảo và vi hình, bao gồm tập bản đồ, bản đồ riêng lẻ và bản đồ hình cầu. Tài liệu có thể có bản chất chuyên khảo hoặc xuất bản nhiều kỳ.
        /// </summary>
        public const string Map = "MP";
        /// <summary>
        /// Âm nhạc (MU) - sử dụng cho bản nhạc được in, bản thảo và vi hình cũng như nhạc ghi âm và những tài liệu ghi âm không phải nhạc khác. Tài liệu có thể có bản chất chuyên khảo hoặc xuất bản nhiều kỳ.
        /// </summary>
        public const string Music = "MU";
        /// <summary>
        /// Tài liệu nhìn (VM) -   sử dụng cho những loại tài liệu chiếu hình, không chiếu hình, đồ hoạ hai chiều, vật phẩm nhân tạo hoặc các đối tượng gặp trong tự nhiên ba chiều, các bộ tài liệu. Tài liệu có thể có bản chất chuyên khảo hoặc xuất bản nhiều kỳ.
        /// </summary>
        public const string ViewDoc = "VM";
        /// <summary>
        /// Tài liệu hỗn hợp (MX) - sử dụng chủ yếu cho những sưu tập lưu trữ và bản thảo của hỗn hợp các dạng tài liệu. Tài liệu có thể có bản chất chuyên khảo hoặc xuất bản nhiều kỳ. (Ghi chú: trước năm 1994, tài liệu hỗn hợp (MX) được tham chiếu như là tài liệu lưu trữ và bản thảo (AM)).
        /// </summary>
        public const string MixDoc = "MX";
    }
}
